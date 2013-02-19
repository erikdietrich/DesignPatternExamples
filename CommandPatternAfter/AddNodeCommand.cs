using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CommandPatternAfter
{
    /// <summary>This is a concrete implementation of the command - a command that adds nodes to the document</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/25/2012</written>
    public class AddNodeCommand : IDocumentCommand
    {
        #region Fields/Properties

        private readonly string _nodeName;

        private XDocument _document = new XDocument();
        public XDocument Document { get { return _document; } set { _document = value ?? _document; } }

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the AddNodeCommand class.</summary>
        /// <remarks>Note the extra parameter here -- this is important.  This class essentially conceptually
        /// an action, so you're more used to seeing things in method form like this.  We pass in the "method" parameters
        /// to the constructor because we're encapsulating an action as an object with state</remarks>
        public AddNodeCommand(string nodeName)
        {
            _nodeName = nodeName ?? string.Empty;
        }

        #endregion

        #region Public API

        public void Execute()
        {
            Document.Root.Add(new XElement(_nodeName));
        }

        public void UndoExecute()
        {
            Document.Root.Elements(_nodeName).Remove();
        }

        #endregion
    }
}
