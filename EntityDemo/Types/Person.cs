using System;

namespace EntityDemo.Types
{
    public class Person
    {
        public Guid Id { get; set; }

        public Address Address { get; set; }

        public Status Status { get; set; }
    }
}
