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
            
            string commandLine = null;

            do
            {
                System.Console.Write(CommandManager.Prompt);
                commandLine = System.Console.ReadLine();

                CommandManager.Execute(commandLine, "Hello World");

            } while (commandLine.ToLower() != "exit");
            

        }
    }
}
