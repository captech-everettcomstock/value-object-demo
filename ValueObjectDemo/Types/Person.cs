using System;

namespace ValueObjectDemo.Types
{
    public class Person
    {
        public Guid Id { get; set; }

        public Address Address { get; set; }

        public Status Status { get; set; }
    }
}
