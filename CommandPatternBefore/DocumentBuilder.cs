using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace CommandPatternBefore
{
    /// <summary>This class is responsible for doing document build operations</summary>
    public class DocumentBuilder
    {
        /// <summary>This is the document that we're doing to be modifying</summary>
        private readonly XDocument _document;

        /// <summary>This defines what type of operation that we're doing</summary>
        private enum OperationType
        {
            Add,
            Print
        }

        /// <summary>Store things here for undo</summary>
        private readonly Stack<Tuple<OperationType, string>> _undoItems;

        /// <summary>Store things here for redo</summary>
        private readonly Stack<Tuple<OperationType, string>> _redoItems;

        #region Constructor

        /// <summary>Initializes a new instance of the DocumentBuilder class.</summary>
        /// <param name="document"></param>
        public DocumentBuilder(XDocument document = null)
        {
            _document = document ?? new XDocument(new XElement("Root"));
        }

        #endregion

        #region Public Api

        /// <summary>Add a node to the document</summary>
        /// <param name="elementName"></param>
        public void AddNode(string elementName)
        {
            _document.Root.Add(new XElement(elementName));
            _undoItems.Push(new Tuple<OperationType, string>(OperationType.Add, elementName));
            _redoItems.Clear();
        }

        /// <summary>Print out the document</summary>
        public void PrintDocument()
        {
            Print();

            _redoItems.Clear();
            _undoItems.Push(new Tuple<OperationType, string>(OperationType.Print, string.Empty));
        }

        /// <summary>Undo the previous steps operations</summary>
        public void Undo(int steps)
        {
            for (int index = 0; index < steps; index++)
            {
                var myOperation = _undoItems.Pop();
                switch (myOperation.Item1)
                {
                    case OperationType.Add:
                        _document.Root.Elements(myOperation.Item2).Remove();
                        _redoItems.Push(myOperation);
                        break;
                    case OperationType.Print:
                        Console.Out.WriteLine("Sorry, but I really can't undo a print to screen.");
                        _redoItems.Push(myOperation);
                        break;
                }
            }
        }

        /// <summary>Redo the number of operations given by steps</summary>
        public void Redo(int steps)
        {
            for (int index = 0; index < steps; index++)
            {
                var myOperation = _redoItems.Pop();
                switch (myOperation.Item1)
                {
                    case OperationType.Add:
                        _document.Root.Elements(myOperation.Item2).Remove();
                        _undoItems.Push(myOperation);
                        break;
                    case OperationType.Print:
                        Print();
                        _undoItems.Push(myOperation);
                        break;
                }
            }
        }
        #endregion


        #region Helpers

        private void Print()
        {
            var myBuilder = new StringBuilder();
            Console.Out.WriteLine("\nDocument contents:\n");
            using (var myWriter = XmlWriter.Create(myBuilder, new XmlWriterSettings() { Indent = true, IndentChars = "\t" }))
            {
                _document.WriteTo(myWriter);
            }
            Console.WriteLine(myBuilder.ToString());
        }

        #endregion
    }
}
