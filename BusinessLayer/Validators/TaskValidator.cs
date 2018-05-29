using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using BusinessLayer.Classes;
using BusinessLayer.Validators;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class TaskValidator : IValidator<Task>
    {
        public IEnumerable<string> BrokenRules(Task entity)
        {
            if (IsEmpty(entity.Id)) yield return "Task ID may not be empty";
            if (IsZeroOrEmpty(entity.FK_TaskTypeId)) yield return "A Task Status has to be selected";
            if (IsZeroOrEmpty(entity.FK_TaskTypeId)) yield return "A Task Type has to be selected";
            if (IsEmpty(entity.FK_ClientId)) yield return "A Client has to be selected";
            if (IsZeroOrEmpty(entity.FK_LocationId)) yield return "A Location of the Client has to be selected";
        }

        public bool IsValid(Task entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
