using AutoFixture;
using AutoFixture.Kernel;
using ValueObjectDemo.Types;

namespace ValueObjectDemo.Utilities.AutoFixture.SpecimenBuilders
{
    public class AddressBuilder : BaseSpecimenBuilder<Address>
    {
        public override Address CreateItem(ISpecimenContext context)
        {
            return new Address(Faker.Address.StreetAddress(),
                               Faker.Address.City(),
                               Faker.Address.State(),
                               context.Create<ZipCode>());
        }
    }
}