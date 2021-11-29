using System;
using System.Collections.Generic;
using System.Text;

namespace PileEtFile_LibrairieClasses
{
    public class PileVideException : InvalidOperationException
    {
        public PileVideException() : base() { }
        public PileVideException(string p_message) : base(p_message) { }
        public PileVideException(string p_message, Exception p_innerException) : base(p_message, p_innerException) { }

    }
}
