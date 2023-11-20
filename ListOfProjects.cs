using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z.Projektem
{
    public class ListOfProjects : List<Project>
    {

        public ListOfProjects()
        {
            Add(new Project("Testowy Projekt", "Projekt ten jest tylko testowy", 0, 0, 0)); // 0, 0, 0 - by sprawdzić czy Count działa dla właściwości z Project.cs
            Add(new Project("Drugi Projekt", "Drugi projekt w kolejce", 2, 3, 1));
            Add(new Project("Trzeci Projekt", "Trzeci projekt w kolejce", 1, 0, 0));

        }

        public void Show()
        {
            int numberP = 1;
            Console.WriteLine();
            foreach (Project p in this) 
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{numberP}.{p.name}");
                numberP++;
            }
            Console.ResetColor();
        }

        public void AssignPeopleToProject(int projectIndex, Person person)
        {
            if (projectIndex >= 0 && projectIndex < this.Count)
            {
                this[projectIndex].AssignedPeople.Add(person);
                this[projectIndex].numberPersons = this[projectIndex].AssignedPeople.Count;
            }
        }

        public void AssignTaskToProject(int projectIndex, Task task)
        {
            if (projectIndex >= 0 && projectIndex < this.Count)
            {
                this[projectIndex].AssignedTask.Add(task);
                this[projectIndex].toDoQuest = this[projectIndex].AssignedTask.Count;
            }
        }
    }
}
