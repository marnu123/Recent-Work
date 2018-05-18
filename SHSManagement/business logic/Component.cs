using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Component
    {
        private int id;
        private string description;
        private float price;

        public int ID { get; }
        public string Description
        {
            get
            {
                return description ?? "no description";
            }
            set { }
        }
        public float Price { get; set; }

        public Component(int id, string description, float price) { }
    }
}
