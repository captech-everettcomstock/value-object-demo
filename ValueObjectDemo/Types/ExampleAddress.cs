using System;

namespace ValueObjectDemo.Types
{
    public class ExampleAddress
    {
        public string StreetAddress { get; } // no property setters are exposed

        public string City { get; }

        public string State { get; }

        public string ZipCode { get; }

        public ExampleAddress(string streetAddress, string city, string state, string zipCode)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        #region Value Object Overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var address = (ExampleAddress)obj;

            return this.StreetAddress.Equals(address.StreetAddress) &&
                   this.City.Equals(address.City) &&
                   this.State.Equals(address.State) &&
                   this.ZipCode.Equals(address.ZipCode);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StreetAddress, City, State, ZipCode);
        }

        public static bool operator ==(ExampleAddress a, ExampleAddress b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ExampleAddress a, ExampleAddress b)
        {
            return !(a == b);
        }

        #endregion
    }
}