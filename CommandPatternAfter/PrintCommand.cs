using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace CommandPatternAfter
{
    /// <summary>This is a concrete implementation of the command - this is a print command</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/25/2012</written>
    public class PrintCommand : IDocumentCommand
    {

        #region Fields/Properties

        private XDocument _document = new XDocument();
        public XDocument Document { get { return _document; } set { _document = value ?? _document; } }

        #endregion

        #region Public API

        /// <summary>Execute the print command</summary>
        public void Execute()
        {
            var myBuilder = new StringBuilder();
            Console.Out.WriteLine("\nDocument contents:\n");
            using (var myWriter = XmlWriter.Create(myBuilder, new XmlWriterSettings() { Indent = true, IndentChars = "\t" }))
            {
                Document.WriteTo(myWriter);
            }
            Console.WriteLine(myBuilder.ToString());
        }

        /// <summary>Undo the print command (which, you can't)</summary>
        public void UndoExecute()
        {
            Console.WriteLine("\nDude, you can't un-ring that bell.\n");
        }

        #endregion

    }
}
