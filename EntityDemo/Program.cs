﻿using EntityDemo.Data;
using EntityDemo.Types;
using EntityDemo.Utilities.AutoFixture;
using System;
using AutoFixture;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EntityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a new Person entity and saving it to the database.");

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
