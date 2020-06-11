using AutoFixture;
using ValueObjectDemo.Utilities.AutoFixture.SpecimenBuilders;

namespace ValueObjectDemo.Utilities.AutoFixture
{
    class FixtureBuilder
    {
        public static Fixture Fixture
        {
            get
            {
                var fixture = new Fixture();

                fixture.Customizations.Add(new StatusBuilder());
                fixture.Customizations.Add(new ZipCodeBuilder());
                fixture.Customizations.Add(new AddressBuilder());

                return fixture;
            }
        }
    }
}
