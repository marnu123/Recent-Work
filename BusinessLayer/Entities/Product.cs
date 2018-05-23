using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblproduct")]
    public class Product : DataObject
    {
        private string id;
        private string name;
        private string description;
        private double price;
        private DateTime dateAdded;
        private string fK_ProductCategoryTitle;
        private int fK_ManufacturerId;
        private string model;
        private ProductCategory productCategory;
        private List<Component> components;
        private Manufacturer manufacturer;

        public Product(string id, string name, string description, float price, DateTime dateAdded, 
            string fK_ProductCategoryTitle)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            DateAdded = dateAdded;
            FK_ProductCategoryTitle = fK_ProductCategoryTitle;
        }

        public Product(DataRow dataRow)
        {
            Id = dataRow["PK_ProductID"].ToString();
            Name = dataRow["ProductName"].ToString();
            Description = dataRow["ProductDescription"].ToString();
            Price = Convert.ToDouble(dataRow["ProductPrice"]);
            DateAdded = (DateTime) dataRow["DateAdded"];
            FK_ProductCategoryTitle = dataRow["FK_ProductCategoryTitle"].ToString();
            FK_ManufacturerId = Convert.ToInt32(dataRow["FK_ManufacturerID"]);
            Model = dataRow["ProductModel"].ToString();

            try
            {
                Manufacturer = new Manufacturer(dataRow);
                ProductCategory = new ProductCategory(dataRow);
            }
            catch (Exception e) { }
        }

        [Key]
        [Column("PK_ProductID")]
        public string Id { get => id; set => id = value; }
        [Column("ProductName")]
        public string Name { get => name; set => name = value; }
        [Column("ProductDescription")]
        public string Description { get => description; set => description = value; }
        [Column("ProductPrice")]
        public double Price { get => price; set => price = value; }
        [Column("DateAdded")]
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public List<Component> Components { get => components; set => components = value; }
        public ProductCategory ProductCategory
        {
            get
            {
                if (productCategory == null)
                {
                    string id = fK_ProductCategoryTitle;
                    List<ProductCategory> list = ProductCategory.Select(p => p.Title == id);
                    productCategory = list.Count > 0 ? list[0] : new ProductCategory();
                }

                return productCategory;
            }
            set => productCategory = value;
        }
        [ForeignKey(typeof(ProductCategory))]
        [Column("FK_ProductCategoryTitle")]
        public string FK_ProductCategoryTitle { get => fK_ProductCategoryTitle; set => fK_ProductCategoryTitle = value; }
        [ForeignKey(typeof(Manufacturer))]
        [Column("FK_ManufacturerID")]
        public int FK_ManufacturerId { get => fK_ManufacturerId; set => fK_ManufacturerId = value; }
        [Column("Model")]
        public string Model { get => model; set => model = value; }
        public Manufacturer Manufacturer
        {
            get
            {
                if (manufacturer == null)
                {
                    int matchId = fK_ManufacturerId;
                    List<Manufacturer> temp = Manufacturer.Select(p => p.Id == matchId);
                    manufacturer = temp.Count > 0 ? temp[0] : null;
                }

                return manufacturer;

            }
            set => manufacturer = value;
        }

        public static List<Product> Select(params Expression<Func<Product, object>>[] expression)
        {
            Expression<Func<Product, ProductCategory, Manufacturer, object>> ex =
                (p, pc, m) => p.FK_ManufacturerId == m.Id && pc.Title == p.FK_ProductCategoryTitle;
            Expression[] list = { ex };

            return DataObjectFactory.Select<Product>(Utils.JoinArrays(list, expression));
        }

        public override string ToString()
        {
            return "ID: " + Id + " Name: " + Name + " Description: " + Description + " Price: " + Price.ToString() +
                " DateAdded: " + DateAdded.ToString();
        }
    }
}
