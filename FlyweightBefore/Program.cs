using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightBefore
{
    class Program
    {
        static void Main(string[] args)
        {
            var pieces = new List<MailPiece>();
            for (long index = 0; index < 23458333; index++)
            {
                pieces.Add(new Letter() { DestinationZip = (int)(index % 100000) });
            }

            Console.ReadLine();
        }
    }
}
