using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightBefore
{
    public class Letter : MailPiece 
    {
        public override decimal Postage { get; set; }
        public override decimal Width { get; set; }
        public override decimal Height { get; set; }
        public override decimal Thickness { get; set; }

        public Letter()
        {
            Postage = 0.46M;
            Width = 11.5M;
            Height = 6.125M;
            Thickness = 0.25M;
        }
    }
}
