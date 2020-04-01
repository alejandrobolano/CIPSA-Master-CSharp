using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.Building.Models;
using CIPSA_CSharp_Module11.Building.Services;

namespace CIPSA_CSharp_Module11Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
        }

        private static void Exercise1()
        {
            var office = new Office(3, 4, 200, 4, 6);
            var house = new House(2, 4, 150, 4, 3);
            
            ConsoleWriteLine("Los objetos han sido creados" +
                             "\n Objeto Oficina:" +
                             $"\n {office}" +
                             "\n Objeto Casa:" +
                             $"\n {house}");

        }

        private static void ConsoleWriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
