using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using System.Reflection;
using BusinessLayer;
using DataLayer;
using DataLayer.Attributes;
using System.Data;
using BusinessLayer;
using BusinessLayer.Validators;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Component cs = new Component("CER123", "Geyser Solenoid", "Solenoid valve for geyser", 123.45f);
            cs.Insert();
            Product p = new Product("GEY213", "Geyser Controller", "Controls geyser on/off times", 321.45f,
                DateTime.Now, "Home Energy Management");
            p.Insert();*/
            /*Client c = new Client(1, "", "", "", "", "A12345678", 1);
            IEnumerable<string> brokenRules = new List<string>();
            bool result = c.Validate(out brokenRules);
            if (result)
            {
                Console.WriteLine("Valid id");
            }

            foreach (string item in brokenRules)
            {
                Console.WriteLine(item);
            }*/


            List<Client> people = Client.Select();
            Person last = people[0];
            Location l = last.Locations[0];
            if (l.Street.IsUnique()) Console.WriteLine("Unique Address");
            if ((new Street(1, "Sarel", "0123", l.Street.City)).IsUnique()) Console.WriteLine("Unique Address 2");
            /*List<Location> loc = last.Locations;
            Console.WriteLine("Locations for " + last);

            foreach (Location l in loc)
            {
                Console.WriteLine(l);
            }*/

            Console.WriteLine("People");
            foreach (Person pe in people)
            {
                Console.WriteLine(pe);
            }
            
            Console.ReadLine();
        }
    }
}
