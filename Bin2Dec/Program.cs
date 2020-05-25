using System;
using System.Linq;

namespace Bin2Dec
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();
            Console.ReadKey();
        }

        static void Bin2Dec(string bin)
        {

            if (_valid(bin))
            {
                Console.WriteLine(bin);
                calculate(bin);
            } else
            {
                Bin2Dec(_getInput());
            }
        }

        static void menu()
        {

            ConsoleKey input;

            Console.WriteLine("Press 1 for Binary to Decimal.");
            Console.WriteLine("Press q to quit");
            input = Console.ReadKey().Key;

            switch (input)
            {
                case (ConsoleKey.D1):
                    Bin2Dec(_getInput());
                    break;
                case (ConsoleKey.Q):
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input.. Try Again");
                    break;
            }

        }

        private static void calculate(string binString)
        {
            int dec = 0;
            int tmp;
            int factor = _findFactor(binString.Length);

            foreach(char c in binString)
            {

                tmp = int.Parse(c.ToString());

                if (tmp == 1)
                {
                    dec = dec + (tmp * factor);
                }

                factor /= 2;
            }

            Console.WriteLine(dec.ToString());
            menu();
        }

        private static int _findFactor(int stringLength)
        {
            int factor = 1;
            if (stringLength == 1)
            {
                return 1;
            } else
            {
                for (int i = 1; i < stringLength; i++)
                {
                    factor *= 2;                    
                }
                return factor;
            }
        }

        private static string _getInput()
        {
            Console.Write("\nBinary: ");
            return Console.ReadLine();
        }

        private static bool _valid(string input)
        {

            foreach (char c in input)
            {
                int tmp = int.Parse(c.ToString());
                if (tmp != 0 && tmp != 1)
                {
                    Console.WriteLine("Invalid input.");
                    return false;
                }
            }
            return true;
        }
    }
}
