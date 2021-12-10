using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionnaire_LibrairieClasses
{
    public class ClefDejaPresenteException : ArgumentOutOfRangeException
    {
        public ClefDejaPresenteException(): base() { }
        public ClefDejaPresenteException(string p_message): base(p_message) { }
        public ClefDejaPresenteException(string p_message, Exception p_innerException): base(p_message, p_innerException) { }
    }
}
