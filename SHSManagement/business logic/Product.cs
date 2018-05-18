using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Product
    {
        private int id;
        private string name;
        private string description;
        private float price;
        private DateTime dateAdded;
        private List<Component> components;

        public int ID { get {return id;} }
        public string Name
        {
            get { return name; }
            set { name = value ?? "no name"; }
        }
        public string Description
        {
            get
            {
                return description ?? "no description";
            }
            set { }
        }
        public float Price { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Component> Components { get; set; }

        public Product(int id, string name, string description, float price, DateTime dateAdded) { }
    }
}
