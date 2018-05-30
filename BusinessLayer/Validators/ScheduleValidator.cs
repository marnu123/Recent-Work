using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using BusinessLayer.Validators;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ScheduleValidator : IValidator<Schedule>
    {
        public IEnumerable<string> BrokenRules(Schedule entity)
        {
            if (IsEmpty(entity.Id) && entity.Id.Length > 10) yield return "Schedule ID may only be 10 characters long and may not be empty";
            if (entity.Duration == null) yield return "A Schedule duration must be supplied";
            if (entity.TimeStart == null) yield return "A Schedule Start Time has to be supplied";
            if (IsEmpty(entity.FK_EmployeeId)) yield return "A technician has to be assigned to the schedule";
            if (IsEmpty(entity.FK_TaskId)) yield return "A task has to be assigned to the schedule";
        }

        public bool IsValid(Schedule entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
