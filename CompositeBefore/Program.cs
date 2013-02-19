using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeBefore
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStructure = new DirectoryStructure();

            myStructure.AddFile("file1.txt");
            myStructure.AddDirectory("firstdir");
            myStructure.AddFile("firstdir", "hoowa");
            myStructure.AddDirectory("seconddir");
            myStructure.AddFile("seconddir", "hoowa");
            myStructure.DeleteDirectory("seconddir");
            myStructure.AddFile("file2.txt");
            myStructure.AddFile("file3.txt");
            myStructure.DeleteFile("file2.txt");

            myStructure.PrintStructure();

            Console.Read();

            myStructure.CreateOnDisk();
        }
    }
}
