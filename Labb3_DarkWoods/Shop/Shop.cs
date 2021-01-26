using static Labb3_DarkWoods.Player.Player;
using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3_DarkWoods.Game;

namespace Labb3_DarkWoods.Shop
{
    class Shop
    {
        //===================================================================================================================================================================================
        // Fields
        //===================================================================================================================================================================================
        private int addStrenght;
        private int addToughness;
        private int strenghtPrice;
        private int toughnessPrice;
        private int zeroGold;





        //===================================================================================================================================================================================
        // Property
        //===================================================================================================================================================================================
        public int AddStrenght { get => addStrenght; set => addStrenght = value; }
        public int AddToughness { get => addToughness; set => addToughness = value; }
        public int StrenghtPrice { get => strenghtPrice; set => strenghtPrice = value; }
        public int ToughnessPrice { get => toughnessPrice; set => toughnessPrice = value; }
        public int ZeroGold { get => zeroGold; set => zeroGold = value; }





        //===================================================================================================================================================================================
        // Constructor
        //===================================================================================================================================================================================
        public Shop(int addStrenght, int addToughness, int strenghtPrice, int toughnessPrice, int zeroGold)
        {
            this.AddStrenght = addStrenght;
            this.AddToughness = addToughness;
            this.StrenghtPrice = strenghtPrice;
            this.ToughnessPrice = toughnessPrice;
            this.ZeroGold = zeroGold;
        }





        //===================================================================================================================================================================================
        // Nytt objekt skapas
        //===================================================================================================================================================================================
        public static Shop cabinShop = new Shop(5, 5, 50, 50, default);





        //===================================================================================================================================================================================
        // En shop där man kan köpa Strenght och Toughness till sin player
        //===================================================================================================================================================================================
        public static void ShopCabin()
        {
            bool keepMenuGo = true;
            StoryVisualText.EnterCabinShopText(); // En array med meddelande som skrivs ut random när man besöker butiken (CabinShop)
            do
            {
                MenuVisualText.CabinShopMenuText(); // Skriver ut text till CabinShop meny

                string menuChoiceString = Console.ReadLine();
                ErrorHandling.ThreeChoiceMenuHandling(menuChoiceString); // Felhanterar en meny som har tre stycken menyval

                switch (menuChoiceString)
                {
                    case "1":
                        BuyStrenght(); // Köper Strenght och lägger till den till player
                        break;
                    case "2":
                        BuyToughness(); //  Köper Toughness och lägger till den till player
                        break;
                    case "3":
                        keepMenuGo = false;
                        break;
                }
                Console.Clear();

            } while (keepMenuGo);
        }





        //===================================================================================================================================================================================
        // Köper Strenght och lägger till den till player
        //===================================================================================================================================================================================
        private static void BuyStrenght()
        {
            if (playerOne.Gold < cabinShop.StrenghtPrice || playerOne.Gold <= cabinShop.ZeroGold)
            {
                NotEnoughMoney(); // Skriver ut ett meddelande om player har för lite pengar
            }
            else
            {
                playerOne.Strenght += cabinShop.AddStrenght;
                playerOne.Gold -= cabinShop.StrenghtPrice;

                Tools.GreenTextWr($"\nYou added {cabinShop.AddStrenght} points to your Toughness! Your toughness is now {playerOne.Strenght}. ");
            }
            Console.ReadLine();
        }





        //===================================================================================================================================================================================
        // Köper Toughness och lägger till den till player
        //===================================================================================================================================================================================
        private static void BuyToughness()
        {
            if (playerOne.Gold < cabinShop.ToughnessPrice || playerOne.Gold <= cabinShop.ZeroGold)
            {
                NotEnoughMoney(); // Skriver ut ett meddelande om player har för lite pengar
            }
            else
            {
                playerOne.Toughness += cabinShop.AddToughness;
                playerOne.Gold -= cabinShop.ToughnessPrice;

                Tools.GreenTextWr($"\nYou added {cabinShop.AddToughness} points to your Toughness! Your toughness is now {playerOne.Toughness}. ");
            }
            Console.ReadLine();
        }





        //===================================================================================================================================================================================
        // Skriver ut ett meddelande om player har för lite pengar
        //===================================================================================================================================================================================
        private static void NotEnoughMoney()
        {
            Tools.RedTextWr("\nYou don't have enough gold to buy this item. Kill more monsters to earn more gold.");
            Console.Write($"Current Gold: ");
            Tools.YellowTextWr($"{playerOne.Gold}");
        }
    }
}
