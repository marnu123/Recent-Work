using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblconfiguration")]
    public class Configuration : DataObject
    {
        private string pK_ConfigurationID;
        private string title;
        private string value;

        public Configuration(string pK_ConfigurationID, string title, string value)
        {
            PK_ConfigurationID = pK_ConfigurationID;
            Title = title;
            Value = value;
        }

        public Configuration(DataRow dataRow)
        {
            PK_ConfigurationID = dataRow["PK_ConfigurationID"].ToString();
            Title = dataRow["ConfigurationTitle"].ToString();
            Value = dataRow["Value"].ToString();
        }

        [Key]
        [Column("PK_ConfigurationID")]
        public string PK_ConfigurationID { get => pK_ConfigurationID; set => pK_ConfigurationID = value; }
        [Column("ConfigurationTitle")]
        public string Title { get => title; set => title = value; }
        [Column("Value")]
        public string Value { get => value; set => this.value = value; }

        public override string ToString()
        {
            return "PK_ConfigurationID: " + PK_ConfigurationID + " Title: " + Title + " Value: " + Value;
        }
    }
}
