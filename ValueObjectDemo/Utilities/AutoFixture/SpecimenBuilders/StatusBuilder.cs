using AutoFixture.Kernel;
using ValueObjectDemo.Types;

namespace ValueObjectDemo.Utilities.AutoFixture.SpecimenBuilders
{
    public class StatusBuilder : BaseSpecimenBuilder<Status>
    {
        public override Status CreateItem(ISpecimenContext context)
        {
            return Faker.Random.ArrayElement<Status>(new Status[] 
            { 
                Status.Available,
                Status.Unavailable,
                Status.Unknown
            });
        }
    }
}