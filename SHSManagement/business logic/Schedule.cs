using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Schedule
    {
        private int id;
        private DateTime timeStart;
        private float price;
        private string description;
        private string operationType;

        public Schedule(int id, DateTime timeStart, float price, string description, string operationType)
        {
            this.id = id;
            this.timeStart = timeStart;
            this.price = price;
            this.description = description;
            this.operationType = operationType;
        }

        public int ID { get; set; }
        public DateTime TimeStart { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string OperationType { get; set; }
    }
}
