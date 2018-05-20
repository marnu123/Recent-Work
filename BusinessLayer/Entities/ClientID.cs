using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    /// <summary>
    /// Generate a client ID according to specification
    /// </summary>
    public struct ClientID : IValidatable<ClientID>
    {
        public char FirstLetter { get; set; }
        public int Last8Digits { get; set; }
        public ClientID(char firstLetter, int last8Digits)
        {
            FirstLetter = firstLetter;
            Last8Digits = last8Digits;
        }

        public ClientID(string clientIDString)
        {
            FirstLetter = clientIDString[0];
            Last8Digits = Convert.ToInt32(clientIDString.Substring(1));
        }

        public override string ToString()
        {
            return (FirstLetter + Last8Digits.ToString().PadLeft(8, '0')).Trim();
        }

        public bool Validate(IValidator<ClientID> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}
