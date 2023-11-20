using System;
using System.ComponentModel.Design;

namespace z.Projektem;

class Program
{
    static void Main()
    {
        //Definicja listy projektów w konstruktorze klasy ListOfProjects
        ListOfProjects projects = new ListOfProjects();

        //Tworzenie listy zadań - domyślnych
        Task designSite = new Task("Stwórz projekt strony", "Zaprojektuj stronę internetową dotyczącą sprzedaży online w programie graficznym", 1);
        Task designBackend = new Task("Zaprojektuj backend", "Przemyśl system biznesowy, zastanów się nad modelem MVVM", 2);
        Task newProgrammer = new Task("Zatrudnij programistę", "Zatrudnij programistę z doświadczeniem Mida, od frontendu", 1);

        //Przydzielanie zadań do projektów
        projects.AssignTaskToProject(0, designSite);
        projects.AssignTaskToProject(0, designBackend);
        projects.AssignTaskToProject(2, newProgrammer);

        //Tworzenie listy osób - domyslnych
        Person Programmer_1 = new Person("Jan Kowalski", "Programista", 1);
        Person Designer_1 = new Person("Adam Nowak", "Projektant", 205);
        Person Programmer_2 = new Person("Janusz Piwniczak", "Starszy Programista", 0);
        Person Boss = new Person("Marcin Wojtek", "Szef", 115);

        //Przydzielanie osób do projektów
        projects.AssignPeopleToProject(0, Programmer_1);
        projects.AssignPeopleToProject(0, Designer_1);
        projects.AssignPeopleToProject(1, Programmer_2);
        projects.AssignPeopleToProject(1, Boss);


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Witaj w programie do zarządzania projektami!");
        Console.WriteLine();
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("1.Wyświetl projekty");
        Console.WriteLine("2.Dodaj projekt");
        Console.WriteLine("3.Usuń projekt");
        Console.WriteLine("4.Wyświetl skończone projekty");
        Console.WriteLine("5.Edytuj nazwę projektów");
        Console.WriteLine("6.Wyjdz z programu");
        Console.ResetColor();

        byte choice = 6;
        bool shows = false;
        do
        {
            if(shows == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Co chcesz zrobić?");
                Console.ResetColor();
                shows = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.Wyświetl projekty");
                Console.WriteLine("2.Dodaj projekt");
                Console.WriteLine("3.Usuń projekt");
                Console.WriteLine("4.Wyświetl skończone projekty");
                Console.WriteLine("5.Edytuj nazwę projektów");
                Console.WriteLine("6.Wyjdz z programu");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Co chcesz zrobić?");
                Console.ResetColor();
            }

            try
            {
                choice = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Błąd: " + ex.Message);
                Console.ResetColor();
            }
            finally
            {
                switch (choice)
                {
                    case 1:
                        {
                            showProject(projects);
                            break;
                        }
                    case 2: 
                        {
                            AddProject(projects);
                            break;
                        }
                    case 3:
                        {
                            //w budowie
                            break;
                        }
                    case 4:
                        {
                            //w budowie
                            break;
                        }
                    case 5:
                        {
                            //w budowie
                            break;
                        }
                    case 6:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Zapraszamy ponownie!");
                            Console.ResetColor();
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wybrałeś zły numer!");
                            Console.ResetColor();
                            break;
                        }
                }
            }
        } while (choice != 6);
    }

    static void showProject(ListOfProjects proj)
    {
        proj.Show(); //showDetail
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine();
        Console.WriteLine("Wybierz 0 - by wyjść z listy projektów!");
        Console.ResetColor();

        byte choice2 = 0;

        bool shows2 = false;

        do
        {
            if (shows2 == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Podaj numer projektu, dla którego chcesz wyświetlić szczegóły:");
                shows2 = true;
                Console.ResetColor();
            }
            else
            {
                proj.Show();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Podaj numer projektu, dla którego chcesz wyświetlić szczegóły:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Kliknij 0 by wyjść z podmenu projektów");
                Console.WriteLine();
                Console.ResetColor();
            }

            try
            {
                choice2 = byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Błąd: " + ex.Message);
                Console.ResetColor();
            }
            finally
            {
                if (choice2 != 0)
                {
                    proj[choice2 - 1].showDetail();
                }
            }

        } while (choice2 != 0);
    }

    static void AddProject(ListOfProjects proj)
    {
        string name = null;
        string description = null;
        int numberP = 0;
        int toDoQ = 0;
        int finishQ = 0;

        Console.WriteLine();
        Console.WriteLine("Wpisz nazwę nowego projektu:");
        name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Stwórz opis projektu: {name}");
        description = Console.ReadLine();

        try
        {
            Project newest = new Project(name, description, numberP, toDoQ, finishQ);
            proj.Add(newest);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex);
        }
    }
}