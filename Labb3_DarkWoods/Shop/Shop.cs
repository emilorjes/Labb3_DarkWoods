using static Labb3_DarkWoods.Player.Player;
using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Text;


namespace Labb3_DarkWoods.Shop
{
    class Shop
    {
        private int addStrenght;
        private int addToughness;
        private int strenghtPrice;
        private int toughnessPrice;
        private int zeroGold;

        public int AddStrenght { get => addStrenght; set => addStrenght = value; }
        public int AddToughness { get => addToughness; set => addToughness = value; }
        public int StrenghtPrice { get => strenghtPrice; set => strenghtPrice = value; }
        public int ToughnessPrice { get => toughnessPrice; set => toughnessPrice = value; }
        public int ZeroGold { get => zeroGold; set => zeroGold = value; }

        public Shop(int addStrenght, int addToughness, int strenghtPrice, int toughnessPrice, int zeroGold)
        {
            this.AddStrenght = addStrenght;
            this.AddToughness = addToughness;
            this.StrenghtPrice = strenghtPrice;
            this.ToughnessPrice = toughnessPrice;
            this.ZeroGold = zeroGold;
        }

        public static Shop cabinShop = new Shop(5, 5, 50, 50, default);

        public static void ShopCabin()
        {
            
            bool keepMenuGo = true;

          
            do
            {
                Console.WriteLine("Welcom to The Cabin Store, what can i help you with traveller?\n");
                Console.WriteLine($"Current Gold ammount: {playerOne.Gold} \n");
                Console.WriteLine($"1.  Buy Strenght Amulette: {cabinShop.StrenghtPrice} Gold.");
                Console.WriteLine($"2.  Buy Toughness Amulette: {cabinShop.ToughnessPrice} Gold.");
                Console.WriteLine($"3.  Leave the shop \n");
                Console.Write("Your choice: ");

                string menuChoiceString = Console.ReadLine();
                ErrorHandling.ThreeChoiceMenuHandling(menuChoiceString);



                switch (menuChoiceString)
                {
                    case "1":
                        BuyStrenght();
                        break;
                    case "2":
                        BuyToughness();
                        break;
                    case "3":
                        keepMenuGo = false;
                        break;
                }
                Console.Clear();

            } while (keepMenuGo);
        }


        private static void BuyStrenght()
        {
            if (playerOne.Gold < cabinShop.StrenghtPrice || playerOne.Gold <= cabinShop.ZeroGold)
            {
                NotEnoughMoney();
            }
            else
            {
                playerOne.Strenght += cabinShop.AddStrenght;
                playerOne.Gold -= cabinShop.StrenghtPrice;
                
                Console.WriteLine($"\nYou added {cabinShop.AddStrenght} points to your Toughness! Your toughness is now {playerOne.Strenght}. ");
            }
            Console.ReadLine();
        }


        private static void BuyToughness()
        {
            if (playerOne.Gold < cabinShop.ToughnessPrice || playerOne.Gold <= cabinShop.ZeroGold)
            {
                NotEnoughMoney();
            }
            else
            {
                playerOne.Toughness += cabinShop.AddToughness;
                playerOne.Gold -= cabinShop.ToughnessPrice;

                Console.WriteLine($"\nYou added {cabinShop.AddToughness} points to your Toughness! Your toughness is now {playerOne.Toughness}. ");
            }
            Console.ReadLine();
        }


        private static void NotEnoughMoney()
        {
            Tools.RedTextWr("\nYou don't have enough gold to buy this item. Kill more monsters to earn more gold.");
            Console.WriteLine($"Current Gold: {playerOne.Gold}");
        }
    }
}
