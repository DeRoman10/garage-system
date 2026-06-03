using System;
using System.Collections.Generic;
namespace Ex03.ConsoleUI
{
    internal static class ConsoleUtils
    {
        internal static int chooseOption<T>(List<T> i_Options)
        {
            for (int i = 0; i < i_Options.Count; i++)
            {
                Console.WriteLine("{0}) {1}", i + 1, i_Options[i]);
            }

            int userChoice = int.Parse(Console.ReadLine());

            if (userChoice < 1 || userChoice > i_Options.Count)
            {
                throw new ArgumentException("Invalid choice.");
            }

            return userChoice - 1;
        }
    }
}
