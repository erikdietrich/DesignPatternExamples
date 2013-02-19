using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <remarks>
/// This implementation started out simply with classes Worker, Manager, and Executive having different pay rates and bios.
/// From there, we added the high performer designation which muddied theings a little by cobbling onto the xtors.
/// Next came the SafetyTeam inheritors which made things start looking really ugly.
/// Finally, came the SoftballPlayer inheritors, which illustrate the combinatorial explosion of classes that this (anti) 'pattern' of development requires
/// </remarks>
namespace DecoratorBefore
{
    public abstract class Employee
    {
        public string Name { get; protected set; }

        public double HourlyWage { get; protected set; }

        public string EmployeeBio { get; protected set; }

        protected Employee(string name, double hourlyWage, string bio, bool isHighPerformer = false)
        {
            HourlyWage = hourlyWage;
            Name = name;
            EmployeeBio = bio;
            if (isHighPerformer)
            {
                HourlyWage *= 1.10;
                EmployeeBio = EmployeeBio + ", High Performer";
            }
        }
    }

    public class Worker : Employee
    {
        public Worker(string name, bool isHighPerformer = false) : base(name, 12.5, "Rank and File", isHighPerformer) { }
    }

    public class SoftballPlayingWorker : Worker
    {
        public string Position { get; set; }

        public SoftballPlayingWorker(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    public class SafetyTeamWorker : Worker
    {
        public string SafetyDescription { get; set; }

        public SafetyTeamWorker(string name, bool isHighPerformer = false) : base(name, isHighPerformer) 
        {
            EmployeeBio += ", Safety Team Member";
        }
    }

    public class SoftballPlayingSafetyTeamWorker : SafetyTeamWorker
    {
        public string Position { get; set; }

        public SoftballPlayingSafetyTeamWorker(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    public class Manager : Employee
    {
        public Manager(string name, bool isHighPerformer = false) : base(name, 25.0, "Line Manager", isHighPerformer) { }
    }

    public class SoftballPlayingManager : Manager
    {
        public string Position { get; set; }

        public SoftballPlayingManager(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    public class SafetyTeamManager : Manager
    {
        public string SafetyDescription { get; set; }

        public SafetyTeamManager(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Safety Team Member";
        }
    }

    public class SoftballPlayingSafetyTeamManager : SafetyTeamManager
    {
        public string Position { get; set; }

        public SoftballPlayingSafetyTeamManager(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    public class Executive : Employee
    {
        public Executive(string name, bool isHighPerformer = false) : base(name, 50.0, "Bigwig", isHighPerformer) { }
    }

    public class SoftballPlayingExecutive : Executive
    {
        public string Position { get; set; }

        public SoftballPlayingExecutive(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    public class SafetyTeamExecutive : Executive
    {
        public string SafetyDescription { get; set; }

        public SafetyTeamExecutive(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Safety Team Member";
        }
    }

    public class SoftballPlayingSafetyTeamExecutive : SafetyTeamExecutive
    {
        public string Position { get; set; }

        public SoftballPlayingSafetyTeamExecutive(string name, bool isHighPerformer = false) : base(name, isHighPerformer)
        {
            EmployeeBio += ", Softball Player";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var myEmployees = new List<Employee>();
            myEmployees.Add(new Worker("Jim Halpert", true));
            myEmployees.Add(new SafetyTeamManager("Michael Scott"));
            myEmployees.Add(new SoftballPlayingSafetyTeamExecutive("Jan Levenson"));

            PrintAllEmployees(myEmployees);
        }

        private static void PrintAllEmployees(List<Employee> myEmployees)
        {
            foreach (var myEmployee in myEmployees)
            {
                Console.WriteLine(String.Format("{0}, {1}, makes {2} per hour.", myEmployee.Name, myEmployee.EmployeeBio, myEmployee.HourlyWage));
            }
            Console.ReadLine();
        }
    }
}
