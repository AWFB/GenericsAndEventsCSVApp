using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndEventsCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Antony", LastName = "Beardsmore", Email = "Antony@me.com"},
                new PersonModel{ FirstName = "Steve", LastName = "Lemons", Email = "Steve@dogs.net"},
                new PersonModel{ FirstName = "William", LastName = "Riker", Email = "William@enterprise.com"},
                new PersonModel{ FirstName = "Brian", LastName = "May", Email = "Brian@queen.co.uk"}
            };

            List<CarModel> cars = new List<CarModel>
            {
                new CarModel{Manufacturer = "VW", Model = "Golf"},
                new CarModel{Manufacturer = "Audi", Model = "A4"},
                new CarModel{Manufacturer = "Toyota", Model = "Auris"},
            };


            Console.ReadLine();
        }
    }


}
