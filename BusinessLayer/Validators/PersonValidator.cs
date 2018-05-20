using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using BusinessLayer.StoredProcedures;

namespace BusinessLayer.Validators
{
    public class PersonValidator : IValidator<Person>
    {
        public IEnumerable<string> BrokenRules(Person entity)
        {
            if (Utils.IsEmpty(entity.Name))
            {
                yield return "Name may not be empty";
            }

            if (Utils.IsEmpty(entity.Surname))
            {
                yield return "Surname may not be empty";
            }

            if (Utils.IsEmpty(entity.Email))
            {
                yield return "Email may not be empty";
            }
            else
            {
                //Only run this test if the email has changed
                if (entity.Email != entity.OldEmail)
                    foreach (string str in validEmail(entity.Email))
                    {
                        yield return str;
                    }
            }

            foreach (string str in isValidCellNumber(entity.CellNumber)) yield return str;
        }

        private IEnumerable<string> validEmail(string email)
        {
            //Test for uniqueness of the email using a stored procedure
            if (!email.Contains("@")) yield return "Email must contain an '@' symbol";
            else
                if (!StoredProcedureHelper.IsUniqueEmail(email)) yield return "Email already exists";
        }

        private IEnumerable<string> isValidCellNumber(string cellNumber)
        {
            if (Utils.IsEmpty(cellNumber)) yield return "Cell number may not be empty";
            else
            {
                int temp;
                if (!int.TryParse(cellNumber, out temp)) yield return "Cell number may only contain digits";
            }
        }

        public bool IsValid(Person entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}
