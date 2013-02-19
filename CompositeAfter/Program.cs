using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeAfter
{
    class Program
    {
        /// <remarks>Notice that the API here is cleaner and more intuitive</remarks>
        static void Main(string[] args)
        {
            //We just create the directory and then add different composite inheritors to it interachangably
            var myDirectory = new SpeculativeDirectory(".");

            myDirectory.Add(new SpeculativeFile("file1.txt"));
            myDirectory.Add(new SpeculativeDirectory("firstdir"));
            myDirectory.GetChild("firstdir").Add(new SpeculativeFile("hoowa"));
            myDirectory.Add(new SpeculativeDirectory("seconddir"));
            myDirectory.GetChild("seconddir").Add(new SpeculativeFile("hoowa"));
            myDirectory.DeleteByName("seconddir");
            myDirectory.Add(new SpeculativeFile("file2.txt"));
            myDirectory.Add(new SpeculativeFile("file3.txt"));
            myDirectory.DeleteByName("file2.txt");

            myDirectory.Print();

            Console.Read();

            myDirectory.CreateOnDisk();

        }
    }
}
