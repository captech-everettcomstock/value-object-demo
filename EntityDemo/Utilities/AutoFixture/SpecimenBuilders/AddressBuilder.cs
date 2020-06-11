using AutoFixture.Kernel;
using EntityDemo.Types;
using System;

namespace EntityDemo.Utilities.AutoFixture.SpecimenBuilders
{
    public class AddressBuilder : BaseSpecimenBuilder<Address>
    {
        public override Address CreateItem(ISpecimenContext context)
        {
            return new Address()
            {
                Id = Guid.NewGuid(),
                StreetAddress = Faker.Address.StreetAddress(),
                City = Faker.Address.City(),
                State = Faker.Address.State(),
                ZipCode = Faker.Address.ZipCode()
            };
        }
    }
}