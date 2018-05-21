using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using DataLayer.Attributes;
using System.Runtime.CompilerServices;

namespace DataLayer
{ 
    public partial class DataHandler
    {
        private Dictionary<Type, TableSchema> cache = new Dictionary<Type, TableSchema>();

        public Dictionary<Type, TableSchema> Cache { get => cache; }

        private static DataHandler dh = new DataHandler();
        private SqlConnection conn;

        private DataHandler()
        {
            conn = new SqlConnection("Data Source=DESKTOP-43FGIVP\\SQLEXPRESS;Initial Catalog=shs_management;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DataTable SelectAll(Type objType)
        {
            updateCache(objType);
            TableSchema table = cache[objType];
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + table.TableName, conn);
            DataTable result = new DataTable();
            da.Fill(result);
            return result;
        }

        private string getWhereString(Type obj, List<UnaryExpression> whereCols, out List<SqlParameter> parms, out List<Type>tables)
        {
            StringBuilder result = new StringBuilder();
            parms = new List<SqlParameter>();
            tables = new List<Type>();

            foreach (Expression ex in whereCols)
            {
                result.Append(getWherePart(ex, ref parms, ref tables));
                result.Append(" AND ");
            }

            //Ensure that the last AND also has a boolean right side
            if (whereCols.Count > 0)
            {
                result.Append(" 1 = 1 ");
            }

            return result.ToString();
        }

        private string resolveExpressionTypeSymbol(ExpressionType typeToResolve)
        {
            switch(typeToResolve)
            {
                case ExpressionType.Equal:
                    return " = ";
                case ExpressionType.Not:
                    return " NOT ";
                case ExpressionType.AndAlso:
                    return " AND ";
                case ExpressionType.OrElse:
                    return " OR ";
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                default:
                    throw new ArgumentException("Type not supported by DataHandler");
            }
        }

        private object getPropertyValueFromClosure(object obj, string prop)
        {
            object result = new object();
            PropertyInfo[] props = obj.GetType().GetProperties();

            if (props.Count() == 0)
            {
                foreach (FieldInfo fi in obj.GetType().GetFields())
                {
                    result = getPropertyValueFromClosure(fi.GetValue(obj), prop);
                    if (result != null) break;
                }
            }
            else
            {
                result = obj.GetType().GetProperty(prop).GetValue(obj);
            }

            return result;
        }

        private object getValueFromExpression(Expression ex, string prop)
        {
            if (ex.NodeType == ExpressionType.Constant)
            {
                ConstantExpression ce = (ex as ConstantExpression);
                return getPropertyValueFromClosure(ce.Value, prop);
            }
            else return getValueFromExpression((ex as MemberExpression).Expression, prop);
        }

        private string getWherePart(Expression ex, ref List<SqlParameter> parms, ref List<Type>tables)
        {
            string result = "";

            switch (ex.NodeType)
            {
                case ExpressionType.Convert:
                    result = (getWherePart(((UnaryExpression)ex).Operand, ref parms, ref tables));
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)ex;
                    //Add tables to the cache that have not yet been saved
                    if (me.Expression.NodeType == ExpressionType.Constant)
                    {
                        return getWherePart(me.Expression, ref parms, ref tables);
                    }

                    object memberVal;
                    if (me.Expression.NodeType == ExpressionType.MemberAccess)
                    {
                        memberVal = getValueFromExpression(me.Expression, me.Member.Name);
                        if (memberVal != null)
                        {
                            string parmNameToAdd = "@" + parms.Count;
                            parms.Add(new SqlParameter(parmNameToAdd, memberVal));
                            return parmNameToAdd;
                        }
                    }

                    if (!cache.ContainsKey(me.Expression.Type))
                    {
                        updateCache(me.Expression.Type);
                    }
                    TableSchema schema = cache[me.Expression.Type];
                    if (tables.IndexOf(me.Expression.Type) == -1)
                    {
                        tables.Add(me.Expression.Type);
                    }
                    return schema.TableName + "." + schema.FindColumnByPropertyName(me.Member.Name).ColumnName;

                case ExpressionType.Constant:
                    string parmName = "@" + parms.Count;
                    object val = ((ConstantExpression)ex).Value;
                    bool isClosure = Attribute.IsDefined(val.GetType(), typeof(CompilerGeneratedAttribute));
                    object objectValue;

                    //Determine whether the expression is a closure type.  If yes, retrieve the value
                    if (isClosure)
                    {
                        objectValue = val.GetType().GetFields()[0].GetValue(val);
                    }
                    else
                    {
                        objectValue = val;
                    }
                    parms.Add(new SqlParameter(parmName, objectValue));
                    return parmName;
                default:
                    result = (" (" + getWherePart(((BinaryExpression)ex).Left, ref parms, ref tables) + resolveExpressionTypeSymbol(ex.NodeType) + getWherePart(((BinaryExpression)ex).Right, ref parms, ref tables) + ") ");
                    break;

            }
            return result;
        }

        public string getFromString(List<Type> tables)
        {
            string result = "";

            foreach (Type table in tables)
            {
                updateCache(table);
            }

            foreach (Type table in tables)
            {
                var foreignKeyProps = table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(ForeignKeyAttribute)));
                if (foreignKeyProps.Count() > 0)
                {
                    var keys = from prop in foreignKeyProps where tables.IndexOf(prop.GetCustomAttribute<ForeignKeyAttribute>().ParentTable) != -1 select prop;
                    List<PropertyInfo> keyList = keys.ToList();

                    foreach (PropertyInfo child in keyList)
                    {
                        TableSchema parent = cache[child.GetCustomAttribute<ForeignKeyAttribute>().ParentTable];
                        string childTableName = table.GetCustomAttribute<TableAttribute>().Name;
                        string childKeyCol = child.GetCustomAttribute<ColumnAttribute>().Name;

                        if (result == "")
                        {
                            result = parent.TableName + " INNER JOIN " + childTableName + " ON " +
                                parent.TableName + "." + parent.FindPrimaryKey().ColumnName + " = " + childTableName + "." + childKeyCol;
                        }
                        else
                        {
                            result += " INNER JOIN " + parent.TableName + " ON " +
                                parent.TableName + "." + parent.FindPrimaryKey().ColumnName + " = " + childTableName + "." + childKeyCol;
                        }
                    }
                }
            }

            return result;
        }

        public DataTable Select<T>(params Expression[] expression)
        {
            Type objType = typeof(T);
            updateCache(objType);
            string whereStr = "";
            string fromStr = "";
            List<SqlParameter> parms = new List<SqlParameter>();
            List<Type> tables = new List<Type>();

            if (expression.Length > 0)
            {
                List<MemberExpression> selectCols;
                var colsQuery = from ex in expression where ex.NodeType == ExpressionType.Lambda && (ex as LambdaExpression).Body.NodeType == ExpressionType.MemberAccess select (ex as LambdaExpression).Body as MemberExpression;
                selectCols = colsQuery.ToList();
                List<UnaryExpression> whereCols;
                var whereQuery = from ex in expression where ex.NodeType == ExpressionType.Lambda && (ex as LambdaExpression).Body.NodeType == ExpressionType.Convert select (ex as LambdaExpression).Body as UnaryExpression;
                whereCols = whereQuery.ToList();

                if (whereCols.Count > 0)
                {
                    whereStr = " WHERE " + getWhereString(typeof(T), whereCols, out parms, out tables);
                }
            }

            if (tables.Count > 1)
            {
                fromStr = " FROM " + getFromString(tables);
            }
            else
            {
                TableSchema table = cache[objType];
                fromStr = " FROM " + table.TableName;
            }

            SqlCommand cmd = new SqlCommand("SELECT * " + fromStr + " " + whereStr, conn);

            foreach (SqlParameter parm in parms)
            {
                cmd.Parameters.Add(parm);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable result = new DataTable();
            da.Fill(result);
            return result;
        }


        public void Update<T>(T entity)
        {
            updateCache(typeof(T));
            List<SqlParameter> parms = getUpdateParameterList<T>(entity);
            SqlCommand sc = new SqlCommand(getUpdateString(typeof(T)), conn);
            
            foreach (SqlParameter sp in parms)
            {
                sc.Parameters.Add(sp);
            }

            conn.Open();
            sc.ExecuteNonQuery();
            conn.Close();
        }

        private string getUpdateString(Type entity)
        { 
            TableSchema schema = cache[entity];
            string resultStr = "UPDATE " + schema.TableName + " SET ";
            List<string> columns = new List<string>();
            List<string> keyCols = new List<string>();


            foreach (TableColumn col in schema.TableColumns)
            {
                if (col.IsKey)
                {
                    string name = getOldKeyPropertyName(entity, col.PropertyName);
                    keyCols.Add(col.ColumnName + " = @" + name);
                }

                if (!col.IsAutoNumber)
                {
                    columns.Add(" " + col.ColumnName + " = @" + col.ColumnName);
                }
            }

            resultStr += String.Join(",", columns.ToArray());
            resultStr += " WHERE " + String.Join(" AND ", keyCols);

            return resultStr;
        }

        private List<SqlParameter> getUpdateParameterList<T>(T entity)
        {
            Type type = typeof(T);
            TableSchema schema = cache[type];
            List<SqlParameter> result = new List<SqlParameter>();

            foreach (TableColumn col in schema.TableColumns)
            {
                if (!col.IsAutoNumber)
                    result.Add(new SqlParameter("@" + col.ColumnName, type.GetProperty(col.PropertyName).GetValue(entity)));

                if (col.IsKey && !col.IsAutoNumber)
                {
                    string name = getOldKeyPropertyName(type, col.PropertyName);
                    result.Add(new SqlParameter("@" + name, type.GetProperty(name).GetValue(entity)));
                }
            }

            return result;
        }

        //Retrieve the old key for a property
        //This enables the updating of primary keys
        private string getOldKeyPropertyName(Type entity, string propertyName)
        {
            //PropertyInfo[] props1 = entity.GetProperties();

            var props = from prop in entity.GetProperties()
                        let attrs = prop.GetCustomAttribute<KeyStorage>()
                        where attrs != null && attrs.StoredFieldName == propertyName
                        select prop;
            return props.First().Name ?? throw new ArgumentException("Class does not contain an KeyStorage field for the " + 
                "requested property");
        }

        public void Delete<T>(T entity)
        {
            updateCache(typeof(T));
            List<SqlParameter> parms = getParameterList<T>(entity);
            SqlCommand sc = new SqlCommand(getDeleteString(entity.GetType()), conn);

            foreach (SqlParameter sp in parms)
            {
                sc.Parameters.Add(sp);
            }

            conn.Open();
            sc.ExecuteNonQuery();
            conn.Close();
        }

        private string getDeleteString(Type entity)
        {
            TableSchema schema = cache[entity];
            string resultStr = "DELETE FROM " + schema.TableName;
            List<string> keyCols = new List<string>();

            foreach (TableColumn col in schema.TableColumns)
            {
                if (col.IsKey)
                {
                    keyCols.Add(col.ColumnName + " = @" + col.ColumnName);
                }
            }
            resultStr += " WHERE " + String.Join(" AND ", keyCols);
            return resultStr;
        }

        public object Insert<T>(T entity)
        {
            updateCache(typeof(T));
            List<SqlParameter> parms = getParameterList<T>(entity);
            SqlCommand sc = new SqlCommand(getInsertString(typeof(T)), conn);

            foreach (SqlParameter sp in parms)
            {
                sc.Parameters.Add(sp);
            }

            conn.Open();
            object val = sc.ExecuteScalar();
            conn.Close();
            return val;
        }

        private string getInsertString(Type entity)
        {
            TableSchema schema = cache[entity];
            string resultStr = "INSERT INTO " + schema.TableName;
            List<string> columns = new List<string>();


            foreach (TableColumn col in schema.TableColumns)
            {
                if (!col.IsAutoNumber)
                {
                    columns.Add(col.ColumnName);
                }
            }

            resultStr += " (" + String.Join(",", columns.ToArray()) + ")";

            TableColumn primKey = cache[entity].FindPrimaryKey();
            if (primKey.IsAutoNumber)
            {
                resultStr += " OUTPUT INSERTED." + primKey.ColumnName;
            }
            resultStr += " VALUES(@" + String.Join(",@", columns.ToArray()) + ")";

            return resultStr;
        }

        private List<SqlParameter> getParameterList<T>(T entity)
        {
            //Type type = entity.GetType();
            Type type = typeof(T);
            TableSchema schema = cache[type];
            List<SqlParameter> result = new List<SqlParameter>();

            foreach(TableColumn col in schema.TableColumns)
            {
                result.Add(new SqlParameter("@" + col.ColumnName, type.GetProperty(col.PropertyName).GetValue(entity)));
            }

            return result;
        }

        public void UpdateDB(DataTable dt)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblperson", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
            da.InsertCommand = cb.GetInsertCommand();
            da.Update(dt);
        }

        public static DataHandler GetInstance()
        {
            return dh;
        }

        /// <summary>
        /// Update the cache of table name to column mappings for individual classes
        /// </summary>
        /// <param name="objType">The object type to insert into the cache</param>
        /// <returns></returns>
        public void updateCache(Type objType)
        {
            TableSchema tableCols;
            cache.TryGetValue(objType, out tableCols);

            if (tableCols == null)
            {
                var table = objType.GetCustomAttributes(typeof(TableAttribute), false);

                if (table.Length > 0)
                {
                    PropertyInfo[] props = objType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
                    tableCols = new TableSchema(((TableAttribute)table[0]).Name, new List<TableColumn>());

                    foreach (PropertyInfo prop in props)
                    {
                        object[] attributes = prop.GetCustomAttributes(true);
                        bool isKey = false;
                        bool isAutoNumber = false;
                        //Temporarily store the column name if a key has been found
                        string tempName = "";

                        foreach (object attr in attributes)
                        {
                            ColumnAttribute col = attr as ColumnAttribute;
                            if (col != null)
                            {
                                tempName = col.Name;
                                tableCols.TableColumns.Add(new TableColumn(prop.Name, col.Name, prop.GetType(), false, col.IsAutoNumber));
                            }
                            else
                            {
                                //Test if a column is a key
                                KeyAttribute key = attr as KeyAttribute;
                                if (key != null)
                                {
                                    isKey = true;
                                    isAutoNumber = key.IsAutoNumber;
                                }
                            }
                        }

                        if (isKey)
                        {
                            tableCols[tempName].IsKey = isKey;
                            tableCols[tempName].IsAutoNumber = isAutoNumber;
                        }
                    }
                    cache.Add(objType, tableCols);
                }
                else
                {
                    throw new ArgumentException("The parameter objType does not contain a class with a 'Table' attribute");
                }
            }
            
        }
    }
}
