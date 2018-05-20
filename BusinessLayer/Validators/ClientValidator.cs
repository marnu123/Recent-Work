using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ClientValidator : IValidator<Client>
    {
        char[] validFirstLetters = { 'A', 'B', 'C', 'D', 'E' };

        public IEnumerable<string> BrokenRules(Client entity)
        {
            IEnumerable<string> personRules;
            (entity as Person).Validate(out personRules);
            foreach (string item in personRules) yield return item;
            foreach (string item in validateId(entity.ClientId)) yield return item;
            if (Utils.IsZeroOrEmpty(entity.FK_NotificationTypeId)) yield return "A notification setting has to be provided";
        }

        public bool IsValid(Client entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }

        private IEnumerable<string> validateId(string id)
        {
            if (Utils.IsEmpty(id)) yield return "ID may not be empty";
            else
            {
                if (id.Length != 9) yield return "ID must be 9 characters in length";

                if (!validFirstLetters.Contains(id[0]))
                {
                    yield return "ID's first letter must be a letter between 'A' and 'E'";
                }

                string numbers = id.Substring(1);

                if (!int.TryParse(numbers, out int i))
                {
                    yield return "ID's last 8 characters must be digits";
                }
            }
        }
    }
}
