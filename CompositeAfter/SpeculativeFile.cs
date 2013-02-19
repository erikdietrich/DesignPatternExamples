using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CompositeAfter
{
    public class SpeculativeFile : SpeculativeComponent
    {
        public SpeculativeFile(string name) : base(name) {}

        protected override void CreateOnDisk(string path)
        {
            File.Create(Path.Combine(path, Name));
            base.CreateOnDisk(path);
        }

    }
}
