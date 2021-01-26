using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using static Labb3_DarkWoods.Player.Player;
using static Labb3_DarkWoods.Shop.Shop;
namespace Labb3_DarkWoods.Game
{
    class MenuVisualText
    {
        //===================================================================================================================================================================================
        // En "logo" till spelet
        //===================================================================================================================================================================================
        public static void GameLogo()
        {
            Tools.DarkYellowTextWr("==================================");
            Console.WriteLine("     WELCOME TO THE DARKWOODS     ");
            Tools.DarkYellowTextWr("==================================");
        }





        //===================================================================================================================================================================================
        // Skriver ut text till CabinShop meny
        //===================================================================================================================================================================================
        public static void CabinShopMenuText()
        {

            Console.Write($"\nCurrent Gold ammount: ");
            Tools.YellowTextWr($"{playerOne.Gold} \n");

            Tools.DarkYellowTextWr("=====================================");
            Console.Write($"1.  Buy Strenght Amulette: ");
            Tools.YellowTextWr($"{cabinShop.StrenghtPrice} Gold.");

            Console.Write($"2.  Buy Toughness Amulette: ");
            Tools.YellowTextWr($"{cabinShop.ToughnessPrice} Gold.");

            Console.WriteLine($"3.  Leave the shop");
            Tools.DarkYellowTextWr("=====================================\n");
            Console.Write("Your choice: ");
        }
        




        //===================================================================================================================================================================================
        // Skriver ut text till MainMenu meny
        //===================================================================================================================================================================================
        public static void MainMenuText()
        {
            Console.WriteLine($"Welcome {playerOne.Name}!\n");
            Tools.DarkYellowTextWr("=====================================");
            Console.WriteLine("1.  Enter the Darkwoods.....");
            Console.WriteLine("2.  Show details about your character");
            Console.WriteLine("3.  Go to shop.");
            Console.WriteLine("4.  Exit");
            Tools.DarkYellowTextWr("=====================================\n");
            Console.Write("Your coice: ");
        }





        //===================================================================================================================================================================================
        // Skriver ut text till EnterDarkwoods meny
        //===================================================================================================================================================================================
        public static void EnterDarkwoodsMenuText()
        {
            Tools.DarkYellowTextWr("=====================================");
            Console.WriteLine($"1.  Explore the Darkwoods");
            Console.WriteLine($"2.  Leave the Darkwoods ");
            Tools.DarkYellowTextWr("=====================================\n");
            Console.Write("Your choice: ");
        }





        //===================================================================================================================================================================================
        // Skriver ut text till ExploreDarkwoods meny
        //===================================================================================================================================================================================
        public static void ExploreDarkwoodsMenuText()
        {
            Tools.DarkYellowTextWr("=====================================");
            Console.WriteLine($"1.  Attack!");
            Console.WriteLine($"2.  Flee......");
            Tools.DarkYellowTextWr("=====================================\n");
            Console.Write("Your choice: ");
        }
    }
}
