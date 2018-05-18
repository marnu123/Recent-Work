using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class TableSchema
    {
        private string tableName;
        private List<TableColumn> tableColumns;

        public TableSchema(string tableName, List<TableColumn> tableColumns)
        {
            TableName = tableName;
            TableColumns = tableColumns;
        }

        public string TableName { get => tableName; set => tableName = value; }
        public List<TableColumn> TableColumns { get => tableColumns; set => tableColumns = value; }
        public TableColumn this[string columnName]
        {
            get
            {
                return findTableColumn(columnName);
            }

            set
            {
                TableColumn result = findTableColumn(columnName);
                result = value;
            }
        }

        public TableColumn findPrimaryKey()
        {
            for (int i = 0; i < tableColumns.Count; i++)
            {
                if (tableColumns[i].IsKey)
                {
                    return tableColumns[i];
                }
            }

            return null;
        }

        private TableColumn findTableColumn(string columnName)
        {
            for (int i = 0; i < tableColumns.Count; i++)
            {
                if (tableColumns[i].ColumnName == columnName)
                {
                    return tableColumns[i];
                }
            }

            throw new ArgumentOutOfRangeException("The column name does not exist");
        }

        public TableColumn FindColumnByPropertyName(string propertyName)
        {
            for (int i = 0; i < tableColumns.Count; i++)
            {
                if (tableColumns[i].PropertyName == propertyName)
                {
                    return tableColumns[i];
                }
            }

            throw new ArgumentOutOfRangeException("The property name does not exist");
        }
    }
}
