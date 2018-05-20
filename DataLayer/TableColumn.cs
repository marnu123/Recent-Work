using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TableColumn
    {
        private string columnName;
        private Type columnType;
        private string propertyName;
        private bool isKey;
        private bool isAutoNumber;

        public TableColumn(string propertyName, string columnName, Type columnType, bool isKey = false, bool isAutoNumber = false)
        {
            ColumnName = columnName;
            ColumnType = columnType;
            PropertyName = propertyName;
            IsKey = isKey;
            IsAutoNumber = isAutoNumber;
        }

        public string ColumnName { get => columnName; set => columnName = value; }
        public Type ColumnType { get => columnType; set => columnType = value; }
        public string PropertyName { get => propertyName; set => propertyName = value; }
        public bool IsKey { get => isKey; set => isKey = value; }
        public bool IsAutoNumber { get => isAutoNumber; set => isAutoNumber = value; }
    }
}
