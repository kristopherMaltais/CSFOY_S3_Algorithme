using System;
using AA_Module04_ListesChainees;
using System.Collections.Generic;

namespace AA_Module04_ListesChainees_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>() { 1, 2, 3 };

            ListeChainee<int> test2 = new ListeChainee<int>(test);

            test2.Remove(3);

            for (int i = 0; i < test2.Count; i++)
            {
                Console.WriteLine(test2[i]);
            }
        }
    }
}
