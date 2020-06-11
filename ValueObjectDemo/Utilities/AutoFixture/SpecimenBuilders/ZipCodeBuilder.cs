using AutoFixture.Kernel;
using ValueObjectDemo.Types;

namespace ValueObjectDemo.Utilities.AutoFixture.SpecimenBuilders
{
    public class ZipCodeBuilder : BaseSpecimenBuilder<ZipCode>
    {
        public override ZipCode CreateItem(ISpecimenContext context)
        {
            return new ZipCode(Faker.Address.ZipCode("#####"),
                               Faker.Address.ZipCode("####"));
        }
    }
}