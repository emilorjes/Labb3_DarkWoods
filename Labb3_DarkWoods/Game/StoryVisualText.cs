using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using static Labb3_DarkWoods.Player.Player;

namespace Labb3_DarkWoods.Game
{
    class StoryVisualText
    {
        public static Random randText = new Random();

       
        public static void IntroText()
        {
          Tools.PrintSlow("A long long time ago in a dark and forgotten magical world the Darkwoods plauge had spread for many many years across the world. " +
                "Everything had been coverd by a dark rotten forest and no sunlight could get through the dense branches. " +
                "To stop and destory the Darkwoods the Origin tree of the pleauge must bee found and destroyed with a legendary wepon called The Ark. " +
                "You need to find the The Ark and destory the Origin tree! \nBut be careful it's something else lurking in the Darkwoods.............\n");
        }




        public static void ExploreDarkWoodText()
        {
            
            List<string> randomStoryText = new List<string>();
            randomStoryText.Add("It is something that is terrible wrong with this forest......");
            randomStoryText.Add("Maybe it's best if you just sit down and die.......");
            randomStoryText.Add("This is a dead end...");
            randomStoryText.Add($" Are you lost? Dont be afraid {playerOne.Name} the monsters aren't real... I think......... ");
            randomStoryText.Add("Afterall it could have been worse...");

            int index = randText.Next(randomStoryText.Count);
            string randomStory = randomStoryText[index];
            foreach (var item in randomStory)
            {
                Console.WriteLine(item);
            }
            
           
            

        }
    }
}
