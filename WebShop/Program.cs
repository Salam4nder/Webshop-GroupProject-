using System;
using System.Collections.Generic;

namespace WebShopMKJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.MenuModel.MenuHandler();
        }

        /// <summary>
        /// Reads the input and gets the Correct number for the menu.
        /// </summary>
        /// <param name="maxNum">The maximum number.</param>
        /// <returns>an int</returns>
        public static int MenuReader(int minNum,int maxNum)
        {
            int num = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    if (num <= maxNum && num >= minNum)
                    {
                        correctInput = true;
                    }
                    else
                        Console.Write("\n\tInput was not a valid menu choice");
                }
                else
                    Console.Write("\n\tInput was not a valid number");
            }
            return num;
        }

        /// <summary>
        /// Reads price
        /// </summary>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static float PriceReader(float minNum, float maxNum)
        {
            float num = 0;
            bool correctInput = false;
            while (!correctInput)
            {
                if (float.TryParse(Console.ReadLine(), out num))
                {
                    if (num <= maxNum && num >= minNum)
                    {
                        correctInput = true;
                    }
                    else
                        Console.Write("\n\tInput was not a valid menu choice");
                }
                else
                    Console.Write("\n\tInput was not a valid number");
            }
            return num;
        }
    }
}

