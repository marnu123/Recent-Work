using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblproduct_location")]
    public class Product_Location : DataObject
    {
        private int id;
        private string fK_ProductId;
        private int fK_LocationId;
        //private int quantity;

        public Product_Location(int id, string fK_ProductId, int fK_LocationId/*, int quantity*/)
        {
            Id = id;
            FK_ProductId = fK_ProductId;
            FK_LocationId = fK_LocationId;
            //Quantity = quantity;
        }

        public Product_Location(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_Product_LocationID"]);
            FK_ProductId = dataRow["FK_ProductID"].ToString();
            FK_LocationId = Convert.ToInt32(dataRow["FK_LocationID"]);
            //Quantity = Convert.ToInt32(dataRow["Quantity"]);
        }

        //[Key]
        //[Column("PK_Product_LocationID")]
        public int Id { get => id; set => id = value; }
        [Key]
        [ForeignKey(typeof(Product))]
        [Column("FK_ProductID")]
        public string FK_ProductId { get => fK_ProductId; set => fK_ProductId = value; }
        [Key]
        [ForeignKey(typeof(Location))]
        [Column("FK_LocationID")]
        public int FK_LocationId { get => fK_LocationId; set => fK_LocationId = value; }
       // [Column("Quantity")]
       // public int Quantity { get => quantity; set => quantity = value; }
    }
}
