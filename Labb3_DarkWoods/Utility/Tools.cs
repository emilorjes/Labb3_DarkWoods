﻿using System;
using System.Collections.Generic;
using System.Text;
using static Labb3_DarkWoods.Player.Player;

namespace Labb3_DarkWoods.Utility
{
    class Tools
    {
        //===================================================================================================================================================================================
        // Stänger ner spelet
        //===================================================================================================================================================================================
        public static void Exit()
        {
            Console.Write("The Darkwoods awiats you......\n\n\n");
            Environment.Exit(0);
        }





        //===================================================================================================================================================================================
        // Återställer full Hp för player och monster
        //===================================================================================================================================================================================
        public static void PlayerMOnsterFullHp(Monster.Monster monster)
        {
            playerOne.Hp = 100;
            monster.Hp = monster.MaxHp;
        }




        //===================================================================================================================================================================================
        // Skriver ut texten "sakta" som matas in i metoden
        //===================================================================================================================================================================================
        public static void PrintSlow(string text, int textSpeed = 20)
        {
            foreach (char item in text)
            {
                Console.Write(item);
                System.Threading.Thread.Sleep(textSpeed);

            }

            Console.WriteLine();
        }





        //===================================================================================================================================================================================
        // Om Robin/robin Skrivs in ändras playerstatsen till användarens fördel.
        //===================================================================================================================================================================================
        public static void GodMode()
        {
            if (playerOne.Name == "Robin" || playerOne.Name == "robin")
            {
                playerOne.Level = 9;
                playerOne.Toughness = 100;
                playerOne.Strenght = 100;
                playerOne.Gold = 1000000;
                playerOne.ExpLevelUp = 300;

                Console.WriteLine($"\nI've beeen expecting you master {playerOne.Name}\n");
                Console.WriteLine($"Your player level has been uppgraded to level {playerOne.Level}");
                Console.WriteLine($"Toughness is at {playerOne.Toughness} and Strenght is also at {playerOne.Strenght}");
                Console.WriteLine($"Your pocket is hevy with {playerOne.Gold} in it\n");
                Console.WriteLine($"You are very ready to explore the Darkwoods!");
                Console.ReadLine();
            }
        }





        //===================================================================================================================================================================================
        // Ändrar färg på texten som används som inparameter
        //===================================================================================================================================================================================
        public static void RedTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void RedTextW(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void GreenTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void YellowTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void DarkYellowTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void DarkYellowTextW(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void BlueTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void BlueTextW(string input)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void MagnetaTextWr(string input)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //===================================================================================================================================================================================
        public static void MagnetaTextW(string input)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(input);
            Console.ResetColor();
        }
    }
}
