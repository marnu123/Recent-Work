using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    public struct ContractID : IValidatable<ContractID>
    {
        public int Year { get; set; }
        public char ContractType { get; set; }
        public char ClientImportance { get; set; }
        public int Last6Digits { get; set; }

        public ContractID(int year, char contractType, char clientImportance, int last6Digits)
        {
            Year = year;
            ContractType = contractType;
            ClientImportance = clientImportance;
            Last6Digits = last6Digits;
        }

        public ContractID(string contractIDString)
        {
            Year = Convert.ToInt32(contractIDString.Substring(0, 4));
            ContractType = contractIDString[4];
            ClientImportance = contractIDString[5];
            Last6Digits = Convert.ToInt32(contractIDString.Substring(6));
        }

        public override string ToString()
        {
            return (Year.ToString() + ContractType.ToString().ToUpper() + ClientImportance.ToString().ToUpper() + Last6Digits.ToString().PadLeft(6, '0')).Trim();
        }

        public bool Validate(IValidator<ContractID> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}
