using AutoFixture.Kernel;
using Bogus;
using System;

namespace ValueObjectDemo.Utilities.AutoFixture.SpecimenBuilders
{
    public abstract class BaseSpecimenBuilder<TItem> : ISpecimenBuilder where TItem : class
    {
        protected static Faker Faker { get; } = new Faker();

        protected static string GenericTypeName
        {
            get
            {
                return typeof(TItem).Name;
            }
        }

        public abstract TItem CreateItem(ISpecimenContext context);

        public object Create(object request, ISpecimenContext context)
        {
            var modelType = request as Type;

            if (typeof(TItem).Equals(modelType))
            {
                return CreateItem(context);
            }

            return new NoSpecimen();
        }
    }
}
