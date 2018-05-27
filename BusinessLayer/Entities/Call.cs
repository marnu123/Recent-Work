using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Attributes;
using DataLayer;

namespace BusinessLayer.Classes
{
    [Serializable]
    [Table("tblcall")]
    public class Call : DataObject
    {
        private int id;
        private DateTime timeStart;
        private DateTime timeEnd;
        private string fK_EmployeeId;
        private string cellNumber;
        private string capturedInformation;

        public Call(int id, DateTime timeStart, DateTime timeEnd, string fK_EmployeeId, string cellNumber, string capturedInformation)
        {
            this.Id = id;
            this.TimeStart = timeStart;
            this.TimeEnd = timeEnd;
            this.FK_EmployeeId = fK_EmployeeId;
            this.CellNumber = cellNumber;
            this.CapturedInformation = capturedInformation;
        }

        public Call() { }

        [Key(true)]
        [Column("PK_CallID")]
        public int Id { get => id; set => id = value; }
        [Column("TimeStart")]
        public DateTime TimeStart { get => timeStart; set => timeStart = value; }
        [Column("TimeEnd")]
        public DateTime TimeEnd { get => timeEnd; set => timeEnd = value; }
        [ForeignKey(typeof(Employee))]
        [Column("FK_EmployeeID")]
        public string FK_EmployeeId { get => fK_EmployeeId; set => fK_EmployeeId = value; }
        [Column("CellNumber")]
        public string CellNumber { get => cellNumber; set => cellNumber = value; }
        [Column("CapturedInformation")]
        public string CapturedInformation { get => capturedInformation; set => capturedInformation = value; }

        public static List<Call> Select(params Expression<Func<Call, object>>[] expression)
        {
            return DataObjectFactory.Select<Call>(expression);
        }
    }
}
