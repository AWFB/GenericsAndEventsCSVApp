using System;
using System.Collections.Generic;

namespace GenericsAndEventsCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Antony", LastName = "BeardHorn", Email = "Antony@me.com"},
                new PersonModel{ FirstName = "Steve", LastName = "Lemons", Email = "Steve@dogs.net"},
                new PersonModel{ FirstName = "William", LastName = "bloodyhell", Email = "William@enterprise.com"}, // bad data row
                new PersonModel{ FirstName = "Brian", LastName = "May", Email = "Brian@queen.co.uk"}
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{Manufacturer = "VW", Model = "Golfblimey"}, // bad data row
                new CarModel{Manufacturer = "Audi", Model = "A4"},
                new CarModel{Manufacturer = "Toyota", Model = "Auris"},
            };

            DataAccess<PersonModel> peopleData = new DataAccess<PersonModel>();
            peopleData.BadEntryFound += PeopleData_BadEntryFound;
            peopleData.SaveToCSV(people, @"D:\temp\CSV_files\people.csv");

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadEntryFound += CarData_BadEntryFound;
            carData.SaveToCSV(cars, @"D:\temp\CSV_files\cars.csv");

            Console.ReadLine();
        }

        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry found for {e.Manufacturer} {e.Model}");
        }

        private static void PeopleData_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found for {e.FirstName} {e.LastName}");
        }
    }
}
