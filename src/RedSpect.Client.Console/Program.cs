using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("RedSpect 1.0 - .NET Application Inspector");
            System.Console.WriteLine("Alpha version. Not ready for production yet.");
            System.Console.WriteLine();

            Host.Run();
        }
    }
}
