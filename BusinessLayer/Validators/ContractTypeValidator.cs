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
            char contractTypeID = entity.Id;
            if (!IsUpAlphabeticChar(entity.Id)) yield return "ID must be a single upper case alpahbetic character";
            else if (ContractType.Select(c => c.Id == contractTypeID).Count != 0) yield return "The ID must be unique";
            if (IsEmpty(entity.Title)) yield return "Contract Type Title may not be empty";
        }

        public bool IsValid(ContractType entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
