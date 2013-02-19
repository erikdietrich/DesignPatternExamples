using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace CompositeBefore
{

    public class DirectoryStructure
    {
        private const string DefaultDirectory = ".";

        //This is nasty and getting nastier every time you add another layer of nesting
        private readonly List<string> _filenames = new List<string>();
        private readonly List<string> _directories = new List<string>();
        private readonly Dictionary<string, List<string>> _subDirectoryFilenames = new Dictionary<string, List<string>>();
        private readonly Dictionary<string, List<string>> _subDirectoryNames;
        private readonly Dictionary<string, Dictionary<string, List<string>>> _subSubDirectoryFilenames = new Dictionary<string, Dictionary<string, List<string>>>();

        private readonly string _root;

        public DirectoryStructure(string root = null)
        {
            _root = string.IsNullOrEmpty(root) ? DefaultDirectory : root;
        }


        public void AddFile(string filename)
        {
            _filenames.Add(filename);
            _filenames.Sort();
        }

        public void AddFile(string subDirectory, string filename)
        {
            if (!_directories.Contains(subDirectory))
            {
                AddDirectory(subDirectory);
            }
            _subDirectoryFilenames[subDirectory].Add(filename);
        }

        public void AddDirectory(string directoryName)
        {
            _directories.Add(directoryName);
            _subDirectoryFilenames[directoryName] = new List<string>();
        }

        public void DeleteDirectory(string directoryName)
        {
            if (_directories.Contains(directoryName))
            {
                _directories.Remove(directoryName);
                _subDirectoryFilenames[directoryName] = null;
            }
        }

        public void DeleteFile(string filename)
        {
            if (_filenames.Contains(filename))
            {
                _filenames.Remove(filename);
            }
        }

        public void DeleteFile(string directoryName, string filename)
        {
            if (_directories.Contains(directoryName) && _subDirectoryFilenames[directoryName].Contains(filename))
            {
                _subDirectoryFilenames[directoryName].Remove(filename);
            }
        }

        public void PrintStructure()
        {
            Console.WriteLine("Starting in " + _root);
            foreach (var myDir in _directories)
            {
                Console.WriteLine(myDir);
                _subDirectoryFilenames[myDir].ForEach(filename => Console.WriteLine("\t" + filename));
            }
            _filenames.ForEach(filename => Console.WriteLine(filename));
        }

        public void CreateOnDisk()
        {
            if (!Directory.Exists(_root))
            {
                Directory.CreateDirectory(_root);
            }

            foreach (var myDir in _directories)
            {
                Directory.CreateDirectory(Path.Combine(_root, myDir));
                _subDirectoryFilenames[myDir].ForEach(filename => File.Create(Path.Combine(myDir, filename)));
            }
            _filenames.ForEach(filename => File.Create(filename));
        }
    }
}
