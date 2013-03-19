using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightBefore
{
    public class Postcard : MailPiece
    {
        public override decimal Postage { get; set; }
        public override decimal Width { get; set; }
        public override decimal Height { get; set; }
        public override decimal Thickness { get; set; }

        public Postcard()
        {
            Postage = 0.33M;
            Width = 6.0M;
            Height = 4.25M;
            Thickness = 0.016M;
        }
    }
}