using System.Collections.Generic;
using ValueObjectDemo.Utilities;

namespace ValueObjectDemo.Types
{
    public class Address : ValueObject
    {
        public string StreetAddress { get; }

        public string City { get; }

        public string State { get; }

        public ZipCode ZipCode { get; }

        private Address() { } // Needed by Entity Framework Migrations

        public Address(string streetAddress, string city, string state, ZipCode zipCode)
        {
            #region Validation

            Guard.AgainstEmpty(streetAddress);
            Guard.LessThan(601, streetAddress.Length);
            Guard.AgainstEmpty(city);
            Guard.LessThan(151, city.Length);
            Guard.AgainstEmpty(state);
            Guard.LessThan(61, state.Length);
            Guard.AgainstNull(zipCode);

            #endregion

            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetAddress;
            yield return City;
            yield return State;
            yield return ZipCode;
        }
    }
}
