using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblcomponent_configuration")]
    public class Component_Configuration : DataObject
    {
        private string fK_ComponentID;
        private string fK_ConfigurationID;

        public Component_Configuration(string fK_ComponentID, string fK_ConfigurationID)
        {
            FK_ComponentID = fK_ComponentID;
            FK_ConfigurationID = fK_ConfigurationID;
        }

        public Component_Configuration(DataRow dataRow)
        {
            FK_ComponentID = dataRow["FK_ComponentID"].ToString();
            FK_ConfigurationID = dataRow["FK_ConfigurationID"].ToString();
        }

        [ForeignKey(typeof(Component))]
        [Column("FK_ComponentID")]
        public string FK_ComponentID { get => fK_ComponentID; set => fK_ComponentID = value; }
        [ForeignKey(typeof(Configuration))]
        [Column("FK_ConfigurationID")]
        public string FK_ConfigurationID { get => fK_ConfigurationID; set => fK_ConfigurationID = value; }

        public override string ToString()
        {
            return "FK_ComponentID: " + FK_ComponentID + " FK_ConfigurationID: " + FK_ConfigurationID;
        }
    }
}
