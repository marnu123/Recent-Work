using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Attributes;
using DataLayer;
using System.Data;

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
        private bool isOutgoing;

        public Call(int id, DateTime timeStart, DateTime timeEnd, string fK_EmployeeId, string cellNumber, string capturedInformation, bool isOutgoing)
        {
            this.Id = id;
            this.TimeStart = timeStart;
            this.TimeEnd = timeEnd;
            this.FK_EmployeeId = fK_EmployeeId;
            this.CellNumber = cellNumber;
            this.CapturedInformation = capturedInformation;
            this.isOutgoing = isOutgoing;
        }

        public Call(DataRow dataRow)
        {
            this.Id = Convert.ToInt32(dataRow["PK_CallID"]);
            this.TimeStart = (DateTime)dataRow["TimeStart"];
            this.TimeEnd = (DateTime)dataRow["TimeEnd"];
            this.FK_EmployeeId = dataRow["FK_EmployeeID"].ToString();
            this.CellNumber = dataRow["CellNumber"].ToString();
            this.CapturedInformation = dataRow["CapturedInformation"].ToString();
            this.isOutgoing = Convert.ToBoolean(dataRow["IsOutgoing"]);
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
        [Column("IsOutgoing")]
        public bool IsOutgoing { get => isOutgoing; set => isOutgoing = value; }

        public static List<Call> Select(params Expression<Func<Call, object>>[] expression)
        {
            return DataObjectFactory.Select<Call>(expression);
        }

        public override bool Equals(object obj)
        {
            Call temp = obj as Call;
            if (temp == null) return false;
            return temp.Id == Id && temp.IsOutgoing == IsOutgoing && temp.TimeEnd == TimeEnd && temp.TimeStart == TimeStart && temp.FK_EmployeeId == FK_EmployeeId;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", Id, isOutgoing, TimeStart, TimeEnd, FK_EmployeeId);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ IsOutgoing.GetHashCode() ^ TimeStart.GetHashCode() ^ TimeEnd.GetHashCode() ^ FK_EmployeeId.GetHashCode();
        }
    }
}
