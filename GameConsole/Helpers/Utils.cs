using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsole.Helpers
{
    static class Utils
    {
        public static int ReadInt(string msg, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(
                    (min == int.MinValue && max == int.MaxValue)
                    ? $"{msg}: "
                    : $"{msg} ({min} - {max}): "
                );

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if(input >= min && input <= max)
                    {
                        Console.Clear();
                        return input;
                    }
                }
            }
        }

        public static int ChooseOption<T>(IEnumerable<T> options, bool index)
        {
            for (int i = 0; i < options.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {options.ElementAt(i)}");
            }

            int choice = ReadInt("Choose option", 1, options.Count());

            return index ? choice - 1 : choice;
        }
    }
}
