using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Serializable]
    [Table("tblcomponent")]
    public class Component : DataObject, IValidatable<Component>
    {
        private string id;
        private string oldKey;
        private string title;
        private string description;
        private double price;
        private List<Configuration> configurations;

        public Component(string id, string title, string description, double price)
        {
            Id = id;
            OldKey = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public Component(DataRow dataRow)
        {
            Id = dataRow["PK_ComponentID"].ToString();
            Title = dataRow["ComponentTitle"].ToString();
            Description = dataRow["ComponentDescription"].ToString();
            Price = (double)dataRow["ComponentPrice"];
            OldKey = id;
        }

        [Key]
        [Column("PK_ComponentID")]
        public string Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public string OldKey { get => oldKey; set => oldKey = value; }
        [Column("ComponentTitle")]
        public string Title { get => title; set => title = value; }
        [Column("ComponentDescription")]
        public string Description { get => description; set => description = value; }
        [Column("ComponentPrice")]
        public double Price { get => price; set => price = value; }
        public List<Configuration> Configurations
        {
            get
            {
                if (configurations == null)
                {
                    string id = Id;
                    Expression<Func<Component_Configuration, Configuration, object>> ex =
                        (cc, c) => cc.FK_ComponentID == id && cc.FK_ConfigurationID == c.PK_ConfigurationID;
                    Expression[] list = { ex };
                    configurations = DatabaseHelper.Select<Configuration>(list);
                }

                return configurations;
            }
            set => configurations = value;
        }

        public static List<Component> Select(params Expression<Func<Component, object>>[] expression)
        {
            return DatabaseHelper.Select<Component>(expression);
        }

        public override bool Equals(object obj)
        {
            Component temp = obj as Component;
            if (temp == null) return false;

            return Id == temp.Id && temp.Price == Price && temp.Title == Title;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Id, Price, Title);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Title.GetHashCode() ^ Price.GetHashCode();
        }

        public bool Validate(IValidator<Component> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}
