using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;


namespace BusinessLayer.Classes
{
    [Table("tblservicelevel")]
    public class ServiceLevel : DataObject
    {
        private char id;
        private string serviceLevelTitle;

        public ServiceLevel(char id, string serviceLevelTitle)
        {
            Id = id;
            ServiceLevelTitle = serviceLevelTitle;
        }

        public ServiceLevel(DataRow dataRow)
        {
            Id = (char) dataRow["PK_ServiceLevelID"];
            ServiceLevelTitle = dataRow["ServiceLevelTitle"].ToString();
        }

        [Key]
        [Column("PK_ServiceLevelID")]
        public char Id { get => id; set => id = value; }
        [Column("ServiceLevelTitle")]
        public string ServiceLevelTitle { get => serviceLevelTitle; set => serviceLevelTitle = value; }

        public static List<ServiceLevel> Select(params Expression<Func<ServiceLevel, object>>[] expression)
        {
            return DataObjectFactory.Select<ServiceLevel>(expression);
        }

        public override string ToString()
        {
            return Id + " " + ServiceLevelTitle;
        }
    }
}
