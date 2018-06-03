using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tbloption")]
    public class Option : DataObject
    {
        private string fK_ProductID;
        private string fK_ComponentID;
        //private int quantity;

        public Option(string fK_ProductID, string fK_ComponentID/*, int quantity*/)
        {
            FK_ProductID = fK_ProductID;
            FK_ComponentID = fK_ComponentID;
            //Quantity = quantity;
        }

        public Option(DataRow dataRow)
        {
            FK_ProductID = dataRow["FK_ProductID"].ToString();
            FK_ComponentID = dataRow["FK_ComponentID"].ToString();
            //Quantity = Convert.ToInt32(dataRow["Quantity"]);
        }

        [Key]
        [ForeignKey(typeof(Product))]
        [Column("FK_ProductID")]
        public string FK_ProductID { get => fK_ProductID; set => fK_ProductID = value; }
        [Key]
        [ForeignKey(typeof(Component))]
        [Column("FK_ComponentID")]
        public string FK_ComponentID { get => fK_ComponentID; set => fK_ComponentID = value; }
        //[Column("Quantity")]
        //public int Quantity { get => quantity; set => quantity = value; }

        public override string ToString()
        {
            return "FK_ProductID: " + FK_ProductID + " FK_ComponentID: " + FK_ComponentID;// + " Quantity: " + Quantity;
        }
    }
}
