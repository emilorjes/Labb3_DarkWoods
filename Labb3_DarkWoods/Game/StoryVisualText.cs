using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static Labb3_DarkWoods.Player.Player;

namespace Labb3_DarkWoods.Game
{
    class StoryVisualText
    {
        public static Random rand = new Random();

       
        public static void IntroText()
        {
          Tools.PrintSlow("A long long time ago in a dark and forgotten magical world the Darkwoods plauge had spread for many many years across the world. " +
                "Everything had been coverd by a dark rotten forest and no sunlight could get through the dense branches. " +
                "To stop and destory the Darkwoods the Origin tree of the pleauge must bee found and destroyed with a legendary wepon called The Ark. " +
                "You need to find the The Ark and destory the Origin tree! \nBut be careful it's something else lurking in the Darkwoods.............\n");
        }





        public static void EndingText()
        {
            Tools.PrintSlow($"The ground begins to shake and the doors, which have not been" +
                                $" opened for hundreds of years, open up a path into the forgotten mine......... And ther it is" +
                                $"....... The Ark");
            Console.WriteLine("\nPress [ENTER] to use The Ark on the Origin tree and save the world....");
            Console.ReadLine();
            Tools.GreenTextWr("\nYOU WON THE GAME!\n");
        }




        public static void ExploreDarkWoodText()
        {
            string[] noBattleText = new string[6];
            noBattleText[0] = ("It is something that is terrible wrong with this forest......");
            noBattleText[1] = ("Maybe it's best if you just sit down and give up.........");
            noBattleText[2]= ("This is a dead end...");
            noBattleText[3] = ($" Are you lost? Dont be afraid {playerOne.Name} the monsters aren't real... I think......... ");
            noBattleText[4] = ("Afterall it could have been worse...");
            noBattleText[5] = ("Rumor says that The Ark is hidden in an ancient mine.");

            int randomStoryText = rand.Next(noBattleText.Length);

            Console.WriteLine(noBattleText[randomStoryText]);
           
        }



        public static void EnterCabinShopText()
        {
            string[] enterShopText = new string[5];
            enterShopText[0] = ("Greetings my friend, how can i help you?");
            enterShopText[1] = ($"Nice to have you back {playerOne.Name}");
            enterShopText[2] = ("The Darkwwods is a dangerous place, spend som money in my shop to make it less dangerous");
            enterShopText[3] = ($" Hi {playerOne.Name} you are alredy back!? ");
            enterShopText[4] = ($"When i was at your age {playerOne.Name} i hade a teacher named Kakashi who taught" +
                $" me everything i needed to know to create this store");

            int randomStoryText = rand.Next(enterShopText.Length);
            
            Console.WriteLine(enterShopText[randomStoryText]);

        }

    }
}
