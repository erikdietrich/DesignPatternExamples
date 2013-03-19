using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightAfter
{
    public abstract class MailPiece
    {
        public abstract decimal Postage { get; set; }
        public abstract decimal Width { get; set; }
        public abstract decimal Height { get; set; }
        public abstract decimal Thickness { get; set; }

        public string GetStatistics(int zipCode)
        {
            return string.Format("Zip code is {0}, postage is {1} and height is {2}",
                zipCode, Postage, Height);
        }
    }
}
