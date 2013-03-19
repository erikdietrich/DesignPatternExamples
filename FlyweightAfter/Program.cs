using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightAfter
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new MailPieceFactory();
            var zipCodes = new List<int>();

            for (int index = 0; index < 23458333; index++)
            {
                zipCodes.Add(index % 100000);
                var randomPiece = factory.GetPiece(GetRandomKey());
                string pieceStatistics = randomPiece.GetStatistics(zipCodes[index]);
                Console.Write(pieceStatistics);
            }

            Console.ReadLine();
        }

        private static char GetRandomKey()
        {
            return new Random().Next() % 2 == 0 ? 'P' : 'L';
        }
    }
}
