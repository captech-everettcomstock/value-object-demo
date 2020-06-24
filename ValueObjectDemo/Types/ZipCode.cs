using System.Collections.Generic;
using ValueObjectDemo.Utilities;

namespace ValueObjectDemo.Types
{
    public class ZipCode : ValueObject
    {
        public string Code { get; }

        public string PlusFour { get; }
                
        private ZipCode() { } // Needed by Entity Framework Migrations

        public ZipCode(string code, string plusFour)
        {
            #region Validation

            Guard.AgainstEmpty(code);
            Guard.AgainstEmpty(plusFour);

            #endregion

            Code = code;
            PlusFour = plusFour;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return PlusFour;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(PlusFour))
            {
                return Code;
            }

            return $"{Code}-{PlusFour}";
        }
    }
}
