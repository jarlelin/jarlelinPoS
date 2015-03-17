using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaspConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("Console started on " + Environment.OSVersion.Platform.ToString()));

            Console.ReadLine();

            Console.WriteLine("Exiting...");
        }
    }
}
