using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzGame;

namespace FizzBuzzGameApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            FizzBuzzGameBase fizzBuzzGameBase = new FizzBuzzGameBase();
            fizzBuzzGameBase.FizBuzzOutputEvent += FizzBuzzGameBase_FizBuzzOutputEvent;
            fizzBuzzGameBase.Play(1, 5000);
            Console.ReadKey();
        }

        private static void FizzBuzzGameBase_FizBuzzOutputEvent(object sender, FizBuzzOutputEventArgs e)
        {
            Console.WriteLine(e.FizzBuzzOutput);
        }
    }
}
