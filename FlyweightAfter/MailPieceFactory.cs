using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightAfter
{
    public class MailPieceFactory
    {
        private readonly Dictionary<char, MailPiece> _mailPieces = new Dictionary<char,MailPiece>();

        public MailPiece GetPiece(char key)
        {
            if (!_mailPieces.ContainsKey(key))
                _mailPieces[key] = BuildPiece(key);

            return _mailPieces[key];            
        }

        private static MailPiece BuildPiece(char key)
        {
            switch (key)
            {
                case 'P': return new Postcard();
                default: return new Letter();
            }
        }
    }
}
