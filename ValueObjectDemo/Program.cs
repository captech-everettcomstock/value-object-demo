using System;
using ValueObjectDemo.Data;
using ValueObjectDemo.Utilities.AutoFixture;
using AutoFixture;
using ValueObjectDemo.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ValueObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a new Person entity with Address Value Object and saving to the database.");

            var person = FixtureBuilder.Fixture.Create<Person>();

            DatabaseContext context = new DatabaseContext();

            context.People.Add(person);

            context.SaveChanges();

            var response = JsonConvert.SerializeObject(person);
            string formattedResponse = JValue.Parse(response).ToString(Formatting.Indented);

            Console.WriteLine("The following person was just written to the database:");
            Console.WriteLine(formattedResponse);

            Console.ReadLine();
        }
    }
}
