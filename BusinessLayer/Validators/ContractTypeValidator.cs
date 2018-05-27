using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Validators;
using BusinessLayer.Classes;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ContractTypeValidator : IValidator<ContractType>
    {
        public IEnumerable<string> BrokenRules(ContractType entity)
        {
            if (!IsUpAlphabeticChar(entity.Id)) yield return "ID must be a single upper case alpahbetic character";
            if (IsEmpty(entity.Title)) yield return "Contract Type Title may not be empty";
            if (IsZeroOrEmpty(entity.FK_ServiceLevelId)) yield return "A Service Level must be specified";
        }

        public bool IsValid(ContractType entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
