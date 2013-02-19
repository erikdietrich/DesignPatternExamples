using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompositeAfter
{

    public class SpeculativeDirectory : SpeculativeComponent
    {
        public SpeculativeDirectory(string name) : base(name) { }

        public override SpeculativeComponent GetChild(string name)
        {
            return Children.FirstOrDefault(child => child.Name == name);
        }

        public override void Add(SpeculativeComponent child)
        {
            if(child != null)
                Children.Add(child);
        }

        public override void DeleteByName(string name)
        {
            var myMatchingChild = Children.FirstOrDefault(child => child.Name == name);
            if (myMatchingChild != null)
            {
                Children.Remove(myMatchingChild);
            }
        }

        protected override void CreateOnDisk(string path)
        {
            string myPath = Path.Combine(path, Name);
            if (!Directory.Exists(myPath))
            {
                Directory.CreateDirectory(myPath);
            }

            base.CreateOnDisk(path);
        }
    }
}
