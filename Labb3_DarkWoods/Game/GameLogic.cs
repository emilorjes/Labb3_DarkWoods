using static Labb3_DarkWoods.Monster.Monster;
using static Labb3_DarkWoods.Player.Player;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3_DarkWoods.Utility;
using Labb3_DarkWoods.Player;
using Labb3_DarkWoods.Monster;

namespace Labb3_DarkWoods.Game
{
    class GameLogic
    {
        
        //===================================================================================================================================================================================
        // Public lista med player och monster. Public random som andvänds för alla random
        //===================================================================================================================================================================================
        public static List<Monster.Monster> listOfMOnsters = new List<Monster.Monster>()
        {CreekJumper.creekJumper, DeathRunner.deathRunner, EarthCrawler.earthCrawler, SwampDemon.swampDemon, TreeDropper.treeDropper};
        public static List<Player.Player> playerList = new List<Player.Player> {playerOne};
        public static Random rand = new Random();
        

        


        //===================================================================================================================================================================================
        // Startar upp ett nytt game
        //===================================================================================================================================================================================
        public static void NewGame()
        {
            GameLogic.GameIntro();
            GameLogic.MainMenu();
        }





        //===================================================================================================================================================================================
        // Spelets namn och en historia visas upp och använderen får välja namn på player och wepon.
        //===================================================================================================================================================================================
        private static void GameIntro()
        {
            MenuVisualText.GameLogo();
           // StoryVisualText.IntroText();
            ChoosePlayerAndWeponNames();
            Tools.GodMode();
  
        }
      




        //===================================================================================================================================================================================
        // Skriver ut ett random monster
        //===================================================================================================================================================================================
        private static void MonsterAppear(Monster.Monster monster)
        {
            Console.WriteLine($"Watch out! An ancient {monster.Name} level {monster.Level} is blocking your way\n");
        }





        //===================================================================================================================================================================================
        // Spelaren får välja namn på player och wepon
        //===================================================================================================================================================================================
        private static void ChoosePlayerAndWeponNames()
        {
            Console.WriteLine("Choose a name for your.... ");
            Console.Write("Hero:");
            playerOne.Name = Console.ReadLine().ToLower();
            Console.Write("Wepon: ");
            playerOne.WeponName = Console.ReadLine();
        

        }





        //===================================================================================================================================================================================
        // Huvudmeny
        //===================================================================================================================================================================================
        private static void MainMenu()
        {
            bool keepMenuGo = true;
            do
            {
                MenuVisualText.MainMenuText();
                string menuChoiceString = Console.ReadLine();
                ErrorHandling.FourChoiceMenuHandling(menuChoiceString);

                Console.Clear();

                switch (menuChoiceString)
                {
                    case "1":
                        EnterDarkwoods();
                        break;
                    case "2":
                        PrintPlayerInfo(playerList[0]);
                        break;
                    case "3":
                        Shop.Shop.ShopCabin();
                        break;
                    case "4":
                        Tools.Exit();
                        break;
                }

                Console.Clear();

            } while (keepMenuGo);
        }





        //===================================================================================================================================================================================
        // Gå in i Darkwoods
        //===================================================================================================================================================================================
        private static void EnterDarkwoods()
        {
            bool keepMenuGo = true;
            string menuChoiceString;
           
            do
            {
                MenuVisualText.EnterDarkwoodsMenuText();
                menuChoiceString = Console.ReadLine();

                ErrorHandling.TwoChoiceMenuHandling(menuChoiceString);

                Console.Clear();

                switch (menuChoiceString)
                {
                    case "1":
                        ExploreDarkwoods();
                        break;
                    case "2":
                        keepMenuGo = false;
                        break;
                }

                Console.Clear();

            } while (keepMenuGo);
        }





        //===================================================================================================================================================================================
        // Utforska Darkwoods, välj om du vill attackera eller fly
        //===================================================================================================================================================================================
        private static void ExploreDarkwoods()
        {
            int randomFightNoFight = rand.Next(1,12);
            int randomMonster = rand.Next(listOfMOnsters.Count);
            bool keepMenuGo;
            string menuChoiceString;
            
            if(randomFightNoFight <= 8)
            {
                do
                {
                    MonsterAppear(listOfMOnsters[randomMonster]);
                    MenuVisualText.ExploreDarkwoodsMenuText();
                    menuChoiceString = Console.ReadLine();

                    ErrorHandling.TwoChoiceMenuHandling(menuChoiceString);

                    Console.Clear();

                    switch (menuChoiceString)
                    {
                        case "1":
                            PlayerVsMonster(listOfMOnsters[randomMonster]);
                            break;
                        case "2":
                            keepMenuGo = false;
                            break;
                    }
                    
                    Tools.PlayerMOnsterFUllHp(listOfMOnsters[randomMonster]);
                    break;



                } while (keepMenuGo);
            }
            else
            {
                Console.WriteLine($" Are you lost? Dont be afraid {playerOne.Name} the monsters aren't real... I think......... ");
                //StoryVisualText.ExploreDarkWoodText();
                Console.ReadLine();
            }  
        }





        //===================================================================================================================================================================================
        // Battlesystem
        //===================================================================================================================================================================================
        private static void PlayerVsMonster(Monster.Monster monster)
        {
            do
            {
                int randomPlayerDmg = rand.Next(1, 60);
                playerOne.Dmg = randomPlayerDmg;
                int randomMonsterDmg = rand.Next(1, 35);
                monster.AtkDmg = randomMonsterDmg;
                int randomMonsterGoldDrop = rand.Next(0, 100);
                monster.GoldDrop = randomMonsterGoldDrop;

                if (monster.Hp == 0)
                {
                    break;
                }

                Battle.NewBattle(monster);
                
                Console.ReadLine();

                Console.Clear();
            } while (monster.Hp > 0);

            Battle.DefetedMonsterGains(monster);
        }
    }
}
