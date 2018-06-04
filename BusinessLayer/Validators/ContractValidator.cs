using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ContractValidator : IValidator<Contract>
    {
        public IEnumerable<string> BrokenRules(Contract entity)
        {
            ContractID contractID = new ContractID(entity.Id);
            IEnumerable<string> contractIdBrokenRules;

            contractID.Validate(out contractIdBrokenRules);
            foreach (string item in contractIdBrokenRules) yield return item;

            if (IsZeroOrEmpty(entity.FK_ContractTypeId)) yield return "A contract type has to be selected";
            if (IsDateTimeEmpty(entity.StartDate)) yield return "A start date must be defined";
            if (IsDateTimeEmpty(entity.EndDate)) yield return "An end date must be defined";
            if (entity.EndDate < entity.StartDate) yield return "A contract's end date must be later than its start date";
        }

        public bool IsValid(Contract entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
