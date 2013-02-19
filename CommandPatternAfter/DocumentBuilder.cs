using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CommandPatternAfter
{
    /// <summary>This class is the "invoker" in the pattern.  This guy serves as the API to the client, who
    /// passes in commands</summary>
    /// <author>Erik Dietrich</author>
    /// <written>1/25/2012</written>
public class DocumentBuilder
{
    #region Fields

    /// <summary>This is the document that the user will be dealing with</summary>
    private readonly XDocument _document;

    /// <summary>This houses commands for undo</summary>
    private readonly Stack<IDocumentCommand> _undoCommands = new Stack<IDocumentCommand>();

    /// <summary>This houses commands for redo</summary>
    private readonly Stack<IDocumentCommand> _redoCommands = new Stack<IDocumentCommand>();

    #endregion

    #region Constructor

    /// <summary>User can give us an xdocument or we can create our own</summary>
    public DocumentBuilder(XDocument document = null)
    {
        _document = document ?? new XDocument(new XElement("Root"));
    }

    #endregion

    #region Public API

    /// <summary>Executes the given command</summary>
    /// <param name="command"></param>
    public void Execute(IDocumentCommand command)
    {
        if (command == null) throw new ArgumentNullException("command", "nope");
        command.Document = _document;
        command.Execute();
        _redoCommands.Clear();
        _undoCommands.Push(command);
    }

    /// <summary>Perform the number of undos given by iterations</summary>
    public void Undo(int iterations)
    {
        for (int index = 0; index < iterations; index++)
        {
            if (_undoCommands.Count > 0)
            {
                var myCommand = _undoCommands.Pop();
                myCommand.UndoExecute();
                _redoCommands.Push(myCommand);
            }
        }
    }

    /// <summary>Perform the number of redos given by iterations</summary>
    public void Redo(int iterations)
    {
        for (int index = 0; index < iterations; index++)
        {
            if (_redoCommands.Count > 0)
            {
                var myCommand = _redoCommands.Pop();
                myCommand.UndoExecute();
                _undoCommands.Push(myCommand);
            }
        }
    }

    #endregion
}
}
