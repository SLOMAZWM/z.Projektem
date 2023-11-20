using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z.Projektem
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int ID { get; set; }

        public Person(string n, string p, int i)
        {
            Name = n;
            Position = p;
            ID = i;
        }

        public void showPerson()
        {
            Console.WriteLine($"Imię i nazwisko: {Name}");
            Console.WriteLine();
            Console.WriteLine($"Stanowisko: {Position}");
            Console.WriteLine();
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine();
        }


    }
}
