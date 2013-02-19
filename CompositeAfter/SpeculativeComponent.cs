using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompositeAfter
{
    /// <summary>We have to define the component - this could theoretically be an interface</summary>
    /// <remarks>Common functionality and default behaviors should go in here.  Even though some inheritors
    /// may not use all methods, this class is important to provide the uniformity advertised by the pattern</remarks>
    public abstract class SpeculativeComponent
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        private readonly HashSet<SpeculativeComponent> _children = new HashSet<SpeculativeComponent>();
        protected HashSet<SpeculativeComponent> Children { get { return _children; } }

        public SpeculativeComponent(string name)
        {
            _name = name ?? string.Empty;
        }

        public virtual SpeculativeComponent GetChild(string name) { return null; }

        public virtual void Add(SpeculativeComponent component) { }

        public virtual void DeleteByName(string name) { }

        public void Print()
        {
            Print(0);
        }

        public void CreateOnDisk()
        {
            CreateOnDisk(Name);
        }

        protected virtual void Print(int depth)
        {
            string myTabs = new string(Enumerable.Repeat<char>('\t', depth).ToArray());
            Console.WriteLine(myTabs + Name);

            foreach (SpeculativeComponent myChild in _children)
            {
                myChild.Print(depth + 1);
            }
        }

        protected virtual void CreateOnDisk(string path)
        {
            foreach (var myChild in _children)
            {
                myChild.CreateOnDisk(Path.Combine(path, Name));
            }
        }
        
    }
}
