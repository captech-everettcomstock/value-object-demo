using System.Collections.Generic;

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
