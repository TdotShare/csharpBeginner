using csharpBeginner.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpBeginner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generateRandomPassword = new GenerateRandomPassword();

            generateRandomPassword.StartProgram();


            Console.ReadLine();

        }
    }
}
