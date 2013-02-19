using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CommandPatternAfter
{
    /// <summary>This class is the base class for commands, and it must be a polymorph for the pattern to work
    /// I chose a base class instead of an interface because I think it's easier to explain and for people to visualize,
    /// and I can port some common functionality here.  Interface (or both) is fine too.</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/25/2012</written>
    public interface IDocumentCommand
    {
        /// <summary>Document (receiver) upon which to operate</summary>
        XDocument Document { get; set; }

        /// <summary>Execute the command</summary>
        void Execute();
        
        /// <summary>Revert the execution of the command</summary>
        void UndoExecute();

    }
}
