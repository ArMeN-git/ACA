using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_LINQ
{
    class FileFormatExcpetion : Exception
    {
        private static readonly string DefaultMessage = "File content is wrong.";
        public int LineNumber { get; }
        public FileFormatExcpetion() : base(DefaultMessage)
        {
        }

        public FileFormatExcpetion(string message) : base(message)
        {                
        }

        public FileFormatExcpetion(int lineNumber, string message) : this(message)
        {
            this.LineNumber = lineNumber;
        }
        public FileFormatExcpetion(int lineNumber, string message, Exception innerException) : base(message, innerException)
        {
            this.LineNumber = lineNumber;
        }

        public override string Message
        {
            get
            {
                return $"{base.Message}\n Line number: {LineNumber}";
            }
        }
    }
}
