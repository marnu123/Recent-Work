using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class EmployeeTypeValidator : IValidator<EmployeeType>
    {
        public IEnumerable<string> BrokenRules(EmployeeType entity)
        {
            if (!Utils.IsEmpty(entity.Title) && !isUniqueTitle(entity.Title)) yield return "Employee Type already exists";
        }

        private bool isUniqueTitle(string title)
        {
            return EmployeeType.Select(e => e.Title == title).Count == 0;
        }

        public bool IsValid(EmployeeType entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
