using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_LINQ
{
    class FileReadCompletedEventArgs : EventArgs
    {
        public int Lines { get; set; }
        public FileReadCompletedEventArgs(int lines)
        {
            this.Lines = lines;
        }
    }
}
