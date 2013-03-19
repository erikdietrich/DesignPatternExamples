using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightBefore
{
    public abstract class MailPiece
    {
        public abstract decimal Postage { get; set; }
        public abstract decimal Width { get; set; }
        public abstract decimal Height { get; set; }
        public abstract decimal Thickness { get; set; }

        public int DestinationZip { get; set; }
    }
}
