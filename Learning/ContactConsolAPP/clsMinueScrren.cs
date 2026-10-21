using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConsolAPP
{
    internal class clsMinueScrren
    {
        static public void ShowMainMinueScreen(string Message)
        {
            Console.WriteLine("{0,90}", "====================================================");

            Console.WriteLine("{0,72}", Message);


            Console.WriteLine("{0,90}", "====================================================");

        }

    }
}
