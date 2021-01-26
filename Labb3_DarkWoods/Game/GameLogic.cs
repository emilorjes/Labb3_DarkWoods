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
        // Public lista med player och monster. Random som andvänds för alla random i denna klass, public bool för menyerna, public string för felhantering
        //===================================================================================================================================================================================
        public static List<Monster.Monster> listOfMOnsters = new List<Monster.Monster>()
        {CreekJumper.creekJumper, DeathRunner.deathRunner, EarthCrawler.earthCrawler, SwampDemon.swampDemon, TreeDropper.treeDropper};
        public static List<Player.Player> playerList = new List<Player.Player> { playerOne };
        public static Random random = new Random();
        public static string menuChoice;




        //===================================================================================================================================================================================
        // Startar upp ett nytt game
        //===================================================================================================================================================================================
        public static void NewGame()
        {
            GameLogic.GameIntro(); // Spelets namn och en historia visas upp och använderen får välja namn på player och wepon
            GameLogic.MainMenu(); // Huvudmeny med olika alternativ
        }





        //===================================================================================================================================================================================
        // Spelets namn och en historia visas upp och använderen får välja namn på player och wepon
        //===================================================================================================================================================================================
        private static void GameIntro()
        {
            MenuVisualText.GameLogo(); // En "logo" till spelet
            //StoryVisualText.IntroText(); // Skriver ut en introtext med hjälp av metoden PrintSlow
            ChoosePlayerAndWeponNames(); // Spelaren får välja namn på player och wepon
            Tools.GodMode(); // Om Robin/robin Skrivs in ändras playerstatsen till användarens fördel.
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
            playerOne.Name = Console.ReadLine();
            Console.Write("Wepon: ");
            playerOne.WeponName = Console.ReadLine();
        }





        //===================================================================================================================================================================================
        // Huvudmeny med olika alternativ
        //===================================================================================================================================================================================
        private static void MainMenu()
        {
            bool keepMenuGo = true;
            do
            {
                MenuVisualText.MainMenuText(); // Skriver ut text till MainMenu meny
                menuChoice = Console.ReadLine();
                ErrorHandling.FourChoiceMenuHandling(menuChoice); // Felhanterar en meny som har fyra stycken menyval

                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        EnterDarkwoods(); //  Gå in i Darkwoods
                        break;
                    case "2":
                        PrintPlayerInfo(playerList[0]); // Skriver ut alla stats på player
                        break;
                    case "3":
                        Shop.Shop.ShopCabin(); // En shop där man kan köpa Strenght och Toughness till sin player
                        break;
                    case "4":
                        Tools.Exit(); // Stänger ner spelet
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
            do
            {
                MenuVisualText.EnterDarkwoodsMenuText(); // Skriver ut text till EnterDarkwoods meny
                menuChoice = Console.ReadLine();

                ErrorHandling.TwoChoiceMenuHandling(menuChoice); // Felhanterar en meny som har två stycken menyval

                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        ExploreDarkwoods(); // Utforska Darkwoods, välj om du vill attackera eller fly, om inget monster dyker upp skrivs ett meddalande ut
                        break;
                    case "2":
                        keepMenuGo = false;
                        break;
                }

                Console.Clear();

            } while (keepMenuGo);
        }





        //===================================================================================================================================================================================
        // Utforska Darkwoods, välj om du vill attackera eller fly, om inget monster dyker upp skrivs ett meddalande ut
        //===================================================================================================================================================================================
        private static void ExploreDarkwoods()
        {
            bool keepMenuGo = true;
            int randomFightNoFight = random.Next(1, 12);
            int randomMonster = random.Next(listOfMOnsters.Count);

            if (randomFightNoFight <= 8)
            {
                do
                {
                    MonsterAppear(listOfMOnsters[randomMonster]); //  Skriver ut ett random monster
                    MenuVisualText.ExploreDarkwoodsMenuText(); // Skriver ut text till ExploreDarkwoods meny
                    menuChoice = Console.ReadLine();

                    ErrorHandling.TwoChoiceMenuHandling(menuChoice);  // Felhanterar en meny som har två stycken menyval

                    Console.Clear();

                    switch (menuChoice)
                    {
                        case "1":
                            PlayerVsMonster(listOfMOnsters[randomMonster]); // Styr hela flödet av battlesystemet
                            break;
                        case "2":
                            keepMenuGo = false;
                            break;
                    }

                    Tools.PlayerMOnsterFullHp(listOfMOnsters[randomMonster]); // Återställer full Hp för player och monster
                    break;

                } while (keepMenuGo);
            }
            else
            {
                StoryVisualText.ExploreDarkWoodText(); // En array med meddelande som skrivs ut random när man inte möter ett monster
                Console.ReadLine();
            }
        }





        //===================================================================================================================================================================================
        // Styr hela flödet av battlesystemet
        //===================================================================================================================================================================================
        private static void PlayerVsMonster(Monster.Monster monster)
        {
            do
            {
                int randomPlayerDmg = random.Next(1, 60); // Sätter playerDmg till random
                playerOne.Dmg = randomPlayerDmg;
                Battle.MonsterRandomDmgAndGoldDrop(monster); // Beroende på vilken level monster är på ändras monstrets randomDmg  max skada, random guld droppas av monstret

                if (monster.Hp == 0)
                {
                    break;
                }

                Battle.NewBattle(monster); // En metod som tar in metoder som styr battle systemet

                Console.ReadLine();

                Console.Clear();
            } while (monster.Hp > 0);

            Battle.DefetedMonsterGains(monster); //  Skriver ut information och Stats efter att ett monster blivit besegrat.
            
        }
    }
}
