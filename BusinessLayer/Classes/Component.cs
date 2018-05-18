using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblcomponent")]
    public class Component : DataObject
    {
        private string id;
        private string title;
        private string description;
        private float price;

        public Component(string id, string title, string description, float price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Component(DataRow dataRow)
        {
            Id = dataRow["PK_ComponentTitle"].ToString();
            Title = dataRow["ComponentTitle"].ToString();
            Description = dataRow["ComponentDescription"].ToString();
            Price = (float)dataRow["ComponentPrice"];
        }

        [Key]
        [Column("PK_ComponentID")]
        public string Id { get => id; set => id = value; }
        [Column("ComponentTitle")]
        public string Title { get => title; set => title = value; }
        [Column("ComponentDescription")]
        public string Description { get => description; set => description = value; }
        [Column("ComponentPrice")]
        public float Price { get => price; set => price = value; }
    }
}
