using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ContractIDValidator : IValidator<ContractID>
    {
        char[] clientImportance = { 'A', 'B', 'C', 'D', 'a', 'b', 'c', 'd' };

        public IEnumerable<string> BrokenRules(ContractID entity)
        {
            if (entity.Year > DateTime.Today.Year || entity.Year < 1000)
            {
                yield return "The first 4 characters must be digits and smaller than today's year";
            }

            if (!isLetter(entity.ContractType))
            {
                yield return "The contract type must be a valid letter";
            }

            if (! clientImportance.Contains(entity.ClientImportance))
            {
                yield return "The client's importance level must be a valid letter between A and D";
            }

            if (entity.Last6Digits > 999999)
            {
                yield return "The last 6 characters must be digits";
            }
        }

        private bool isLetter(char let)
        {
            return ((let > 64 && let < 91 || let > 96 && let < 123));
        }

        public bool IsValid(ContractID entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
