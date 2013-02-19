using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorAfter
{
    /// <summary>This is our base class that already has a natural inheritance hierarchy (worker, manager, exec).  In the context
    /// of the design pattern, it is called the "Component"</summary>
    public abstract class Employee
    {
        public string Name { get; protected set; }

        public double HourlyWage { get; protected set; }

        public string EmployeeBio { get; protected set; }

        protected Employee() { }

        protected Employee(string name, double hourlyWage, string bio)
        {
            HourlyWage = hourlyWage;
            Name = name;
            EmployeeBio = bio;
        }
    }

    /// <summary>One of the basic inheritors</summary>
    public class Worker : Employee
    {
        public Worker(string name) : base(name, 12.5, "Rank and File, ") { }
    }

    /// <summary>One of the basic inheritors</summary>
    public class Manager : Employee
    {
        public Manager(string name) : base(name, 25.0, "Line Manager, ") { }
    }

    /// <summary>One of the basic inheritors</summary>
    public class Executive : Employee
    {
        public Executive(string name) : base(name, 50.0, "Bigwig, ") { }
    }


    /// <summary>The base decorator defines the basic scheme for wrapping and representing the component to clients</summary>
    public abstract class EmployeeDecorator : Employee
    {
        private readonly Employee _target;
        protected Employee Target { get { return _target; } }

        public EmployeeDecorator(Employee target)
        {
            _target = target;
            Name = target.Name;
            HourlyWage = target.HourlyWage;
            EmployeeBio = target.EmployeeBio;
        }
    }

    /// <summary>A specific decorator that supplies a behavior modification (decoration) to the component
    ///  as well as offering additional state</summary>
    public class SafetyTeamMember : EmployeeDecorator
    {
        public string SafetyDescription { get; set; }

        public SafetyTeamMember(Employee target) : base(target)
        {
            EmployeeBio += "Safety Team Member, ";
        }
    }

    /// <summary>A specific decorator that supplies a behavior modification (decoration) to the component
    ///  as well as offering additional state</summary>
    public class SoftballPlayer : EmployeeDecorator
    {
        public string Position { get; set; }

        public SoftballPlayer(Employee target) : base(target)
        {
            EmployeeBio += "Softball Player, ";
        }
    }

    /// <summary>A specific decorator that supplies a behavior modification (decoration) to the component
    ///  without offering additional state</summary>
    public class HighPerformer : EmployeeDecorator
    {
        public HighPerformer(Employee target) : base(target)
        {
            EmployeeBio += " High Performer,";
            HourlyWage *= 1.10;
        }
    }

    /// <summary>Basic scheme for creating objects and their decorators</summary>
    class Program
    {
        static void Main(string[] args)
        {
            var myEmployees = new List<Employee>(); //Create a list of the base class that we want to perform aggregate operations on

            Employee myWorker = new Worker("Jim Halpert"); //Create Jim 
            myEmployees.Add(new HighPerformer(myWorker)); //Add Jim to the list, but as a high performer
            Employee myManager = new Manager("Michael Scott"); //Create Michael Scott
            myManager = new SoftballPlayer(myManager); //Michae plays softball....
            myEmployees.Add(new SafetyTeamMember(myManager)); //... and he's on the safety team, so add him with both of these decorators
            myEmployees.Add(new Executive("Jan Levenson")); //Jan doesn't do anything until we add a decorator for inappropriate subordinate relationships, so add her as-is

            PrintAllEmployees(myEmployees); //And, print all of them, observing that the decorators do their work without clients needing to have conditional logic or other awkwardness
        }

        private static void PrintAllEmployees(List<Employee> myEmployees)
        {
            foreach (var myEmployee in myEmployees)
            {
                Console.WriteLine(String.Format("{0}, {1} makes {2} per hour.", myEmployee.Name, myEmployee.EmployeeBio, myEmployee.HourlyWage));
            }
            Console.ReadLine();
        }
    }
}
