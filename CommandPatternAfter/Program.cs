using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPatternAfter
{
    /// <summary>This is the main entry point, see remarks for explanation</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/25/2012</written>
    /// <remarks>This is about as simple an implementation of the command pattern as you can get. Here are the
    /// "participants" of the classes in fulfilling the pattern:
    /// 
    /// Command:           DocumentCommand
    /// ConcreteCommand:   PrintCommand, AddNodeCommand
    /// Client:            Program (right here)
    /// Invoker:           DocumentBuilder
    /// Receiver:          XDocument
    /// 
    /// Here is the gist of this.  We're encapsulating an action as an object in the form of IDocumentCommand and its implementers.
    /// What this allows us to do is decouple the request of a command from the mechanics of fulfilling that request.  Specifically,
    /// the builder knows how to parameterize and manage commands, while the commands themselves know how to do things to an XDocument.
    /// The value here is that we can change the scheme for managing undo/redo (or whatever other command management concerns
    /// may arise) without changing the mechanics of command execution.  Likewise, we can change how commands get executed
    /// without worrying that we may bork the undo/redo scheme.
    /// 
    /// Another valid concern is adherence to open closed principle.  Consider in the "before" scheme what we would have to do
    /// if we wanted to add Udpate functionality to the document builder.  We would have needed to open the Builder class
    /// and add another method to it.  We would also have needed to modify the undo and redo methods.  By contrast, here
    /// we can add update simply by defining a new class UpdateNodeCommand : IDocumentCommand.  Life is a lot better
    /// when new functionality requires new code.  In the old scheme, DocumentBuilder would rot as new functionality was added.
    /// In the new scheme, not at all.
    /// 
    /// At the risk of editorializing, if the Fuse UndoRedoStack class implemented this paradigm, we'd probably have had a lot fewer
    /// defects over the course of time.  And, if it weren't static... well, that might be asking too much ;)
    /// </remarks>
    public static class Program
    {
        public static int Main(string[] args)
        {
            var myInvoker = new DocumentBuilder();
            myInvoker.Execute(new AddNodeCommand("Hoowa"));
            myInvoker.Execute(new PrintCommand());
            myInvoker.Undo(2);
            myInvoker.Execute(new PrintCommand());

            Console.ReadLine();
            return 0;
        }
    }
}
