using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;


namespace BusinessLayer.Classes
{
    [Serializable]
    [Table("tblservicelevel")]
    public class ServiceLevel : DataObject
    {
        private char id;

        public ServiceLevel(char id)
        {
            Id = id;
        }

        public ServiceLevel(DataRow dataRow)
        {
            Id = Convert.ToChar(dataRow["PK_ServiceLevelID"].ToString().Substring(0,1));
        }

        [Key]
        [Column("PK_ServiceLevelID")]
        public char Id { get => id; set => id = value; }

        public static List<ServiceLevel> Select(params Expression<Func<ServiceLevel, object>>[] expression)
        {
            return DataObjectFactory.Select<ServiceLevel>(expression);
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
