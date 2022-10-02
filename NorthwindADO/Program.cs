using NorthwindClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindADO
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====NorthWind Database=====\n");
            Authentication.Execute();
        }
    }
}
