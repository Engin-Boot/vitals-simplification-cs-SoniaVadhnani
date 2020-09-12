using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsCSharp
{
     class VitalChecker
    {
        public static  void ExpectTrue(bool expression)
        {
            if (!expression)
             {
                 Console.WriteLine("Expected true, but got false");
                 Environment.Exit(1);
             }
        }
        public static void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }
    }
}
