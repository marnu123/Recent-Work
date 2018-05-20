using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Attributes;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DataLayer
{
    public partial class DataHandler
    {
        public DataTable ExecuteProcedure(IReturnStoredProcedure sproc)
        {
            SqlCommand sc = getSprocCommand(sproc);
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void ExecuteProcedure(IVoidStoredProcedure sproc)
        {
            SqlCommand sc = getSprocCommand(sproc);
            sc.ExecuteNonQuery();
        }

        private string getSprocName(IStoredProcedure sproc)
        {
            object[] procedure = sproc.GetType().GetCustomAttributes(typeof(StoredProcedureAttribute), false);
            if (procedure == null)
                throw new ArgumentException("sproc does not have a StoredProcedure attribute");
            else
            {
                return (procedure[0] as StoredProcedureAttribute).Name;
            }
        }

        private SqlCommand getSprocCommand(IStoredProcedure sproc)
        {
            List<SqlParameter> parms = getSprocParameters(sproc);
            string name = getSprocName(sproc);
            //string query = getSprocString(name, parms);
            SqlCommand sc = new SqlCommand(name, conn);
            sc.CommandType = CommandType.StoredProcedure;
            parms.ForEach((parm) => sc.Parameters.Add(parm));
            return sc;
        }

        private List<SqlParameter> getSprocParameters(IStoredProcedure sproc)
        {
            var props = from prop
                        in sproc.GetType().GetProperties()
                        where prop.GetCustomAttributes(typeof(StoredProcedureParameterAttribute), false) != null
                        select prop;

            List<SqlParameter> result = new List<SqlParameter>();

            foreach (PropertyInfo propInfo in props)
            {
                result.Add(new SqlParameter("@" + propInfo.GetCustomAttribute<StoredProcedureParameterAttribute>().Name,
                    propInfo.GetValue(sproc)));
            }

            return result;
        }
    }
}
