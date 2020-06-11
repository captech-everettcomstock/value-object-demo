using System;
using ValueObjectDemo.Data;
using ValueObjectDemo.Utilities.AutoFixture;
using AutoFixture;
using ValueObjectDemo.Types;
using Newtonsoft.Json;

namespace ValueObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var person = FixtureBuilder.Fixture.Create<Person>();

            DatabaseContext context = new DatabaseContext();

            context.People.Add(person);

            context.SaveChanges();

            var response = JsonConvert.SerializeObject(person);
        }
    }
}
