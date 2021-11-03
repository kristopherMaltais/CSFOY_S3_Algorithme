using System;
using System.Collections.Generic;
using System.Collections;
using AA_Module03_TableauACapaciteVariable;

namespace AA_Module03_TableauACapaciteVariable_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liste = new List<int>() { };
            TableauCapaciteVariable<int> test = new TableauCapaciteVariable<int>(liste);
        }
    }
}
