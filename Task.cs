using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z.Projektem
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

        public Task(string T, string D, int P) 
        {
            Title = T;
            Description = D;
            Priority = P;
        }

        public void ShowTask()
        {
            Console.WriteLine($"Tytuł zadania: {Title}");
            Console.WriteLine($"Opis zadania: {Description}");
            Console.WriteLine($"Priorytet zadania: {Priority}");
            Console.WriteLine();
        }

    }
}
