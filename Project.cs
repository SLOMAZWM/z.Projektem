using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z.Projektem
{
    public class Project
    {
        public string name { get; set; }
        public string description { get; set; }
        public int numberPersons { get; set; }
        public int toDoQuest { get; set; }
        public int finishQuest { get; set; }

        public List<Person> AssignedPeople { get; set; }
        public List<Task> AssignedTask { get; set; } 

        public Project(string n, string d, int np, int tdq, int fq)
        {
            name = n;
            description = d;
            numberPersons = np;
            toDoQuest = tdq;
            finishQuest = fq;
            AssignedPeople = new List<Person>();
            AssignedTask = new List<Task>();
        }

        public void showDetail()
        {
            byte choice = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Nazwa projektu: {name}");
                Console.WriteLine();
                Console.WriteLine($"Opis projektu: {description}");
                Console.WriteLine();
                Console.WriteLine($"Liczba pracowników: {numberPersons} - wybierz 3 by wyświetlić szczegóły");
                Console.WriteLine();
                Console.WriteLine($"Liczba zadań do zrobienia: {toDoQuest} - wybierz 4 by wyświetlić szczegóły");
                Console.WriteLine();
                Console.WriteLine($"Liczba zrobionych zadań: {finishQuest} - wybierz 5 by wyświetlić szczegóły");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kliknij 0 - by cofnąć wybór projektu");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Co chcesz zrobić?");
                Console.ResetColor();
                try
                {
                    choice = byte.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Błąd: " + ex.Message);
                    Console.ResetColor();
                }
                finally
                {
                        switch (choice)
                    {
                        case 3:
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Lista osób w projekcie: {name}");
                                Console.WriteLine();
                                foreach(Person p in AssignedPeople)
                                {
                                    Console.WriteLine($"Imie i Nazwisko: {p.Name}");
                                    Console.WriteLine($"Stanowisko: {p.Position}");
                                    Console.WriteLine($"ID: {p.ID}");
                                    Console.WriteLine();
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"Lista zadań do zrobienia w projekcie: {name}");
                                Console.WriteLine();
                                foreach(Task t in AssignedTask)
                                {
                                    Console.WriteLine($"Tytuł zadania: {t.Title}");
                                    Console.WriteLine($"Opis zadania: {t.Description}");
                                    Console.WriteLine($"Priorytet zadania: {t.Priority}");
                                    Console.WriteLine();
                                }

                                byte choice2 = 4;

                                do // dodaj przeniesienie zadania do wykonanych zadan
                                {
                                    Console.WriteLine("1. Dodaj zadanie");
                                    Console.WriteLine("2. Edytuj zadanie");
                                    Console.WriteLine("3. Usuń zadanie");
                                    Console.WriteLine("4. Wyjdź z menu zadań");
                                    Console.WriteLine();
                                    Console.WriteLine("Co chcesz zrobić?");

                                    choice2 = byte.Parse(Console.ReadLine());
                                    switch (choice2)
                                    {
                                        case 1:
                                            {
                                                AddTaskToProject();
                                                break;
                                            }
                                        case 4:
                                            {
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Niepoprawna wartość!");
                                                    break;
                                            }
                                    }

                                } while (choice2 != 4);

                                break;
                            }
                        case 5:
                            {
                                //w budowie - klasa Task - metoda FinishTask?
                                break;
                            }
                        case 0:
                            {
                                Console.WriteLine();
                                choice = 0;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Błędny numer!");
                                break;
                            }
                    }
                }
            } while (choice != 0);
        }
        private void AddTaskToProject()
        {
            Console.WriteLine();
            Console.WriteLine($"Wpisz tytuł zadania, które chcesz dodać do projektu: {name}");
            string Title = Console.ReadLine();
            Console.WriteLine($"Wpisz opis zadania: {Title}");
            string Description = Console.ReadLine();
            Console.WriteLine("Nadaj priorytet zadaniu - od 1 do 3:");
            int Priority = int.Parse(Console.ReadLine());

            Task newest = new Task(Title, Description, Priority);
            AssignedTask.Add(newest);
            Console.WriteLine($"Poprawnie dodano zadanie: {Title} do projektu: {name}!");
        }
    }
}
