using System;
using System.Collections.Generic;
using System.Text;

namespace PileEtFile_LibrairieClasses
{
    public class FileVideException : InvalidOperationException
    {
        public FileVideException() : base() { }
        public FileVideException(string p_message) : base(p_message) { }
        public FileVideException(string p_message, Exception p_innerException) : base(p_message, p_innerException) { }

    }
}
