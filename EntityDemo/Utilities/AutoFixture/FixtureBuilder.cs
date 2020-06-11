using AutoFixture;
using EntityDemo.Utilities.AutoFixture.SpecimenBuilders;

namespace EntityDemo.Utilities.AutoFixture
{
    class FixtureBuilder
    {
        public static Fixture Fixture
        {
            get
            {
                var fixture = new Fixture();

                fixture.Customizations.Add(new AddressBuilder());

                return fixture;
            }
        }
    }
}
