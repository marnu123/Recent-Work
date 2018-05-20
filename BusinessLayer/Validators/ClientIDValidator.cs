using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ClientIDValidator : IValidator<ClientID>
    {
        char[] validFirstLetters = { 'A', 'B', 'C', 'D', 'E', 'a', 'b', 'c', 'd', 'e' };
        public IEnumerable<string> BrokenRules(ClientID entity)
        {
            if (entity.ToString().Trim().Length != 9)
            {
                yield return "ID must be 9 characters in length";
            }

            if (!validFirstLetters.Contains(entity.FirstLetter))
            {
                yield return "ID's first letter must be a letter between 'A' and 'E'";
            }

            if (entity.Last8Digits > 99999999)
            {
                yield return "ID's last 8 characters must be digits";
            }
        }

        public bool IsValid(ClientID entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
