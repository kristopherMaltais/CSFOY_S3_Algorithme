using System;

namespace Dictionnaire_LibrairieClasses
{
    public class ClefNonTrouveeException: ArgumentException
    {
        public ClefNonTrouveeException() : base() { }
        public ClefNonTrouveeException(string p_message) : base(p_message) { }
        public ClefNonTrouveeException(string p_message, Exception p_innerException) : base(p_message, p_innerException) { }
    }
}
