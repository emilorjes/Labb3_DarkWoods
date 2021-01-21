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
        // GameLogic
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
            GameLogo();
            StoryVisualText.IntroText();
            ChoosePlayerAndWeponNames();
        }



        //===================================================================================================================================================================================
        // Huvudmeny
        //===================================================================================================================================================================================
        private static void MainMenu()
        {
            bool keepMenuGo = true;
            do
            {
                Console.WriteLine("1.  Enter the Darkwoods.....");
                Console.WriteLine("2.  Show details about your character");
                Console.WriteLine("3.  Go to shop.");
                Console.WriteLine("4.  Exit\n");
                Console.Write("Your coice: ");
                string menuChoiceString = Console.ReadLine();
                ErrorHandling.FourChoiceMenuHandling(menuChoiceString);

                Console.Clear();

                switch (menuChoiceString)
                {
                    case "1":
                        EnterDarkwoods();
                        break;
                    case "2":
                        Player.Player.PrintPlayerInfo(playerList[0]);
                        break;
                    case "3":
                        Shop.Shop.ShopCabin();
                        break;
                    case "4":
                        Exit();
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
            Console.WriteLine($"You have entered the Darkwoods {playerOne.Name}............... Stay safe my friend..... \n");



            do
            {
                Console.WriteLine($"1.  Explore the Darkwoods");
                Console.WriteLine($"2.  Leave the Darkwoods \n");
                Console.Write("Your choice: ");
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
            int randomMonster = rand.Next(listOfMOnsters.Count);
            MonsterAppear(listOfMOnsters[randomMonster]);
            bool keepMenuGo = true;
            string menuChoiceString;

            do
            {

                Console.WriteLine($"1.  Attack!");
                Console.WriteLine($"2.  Flee...... \n");
                Console.Write("Your choice: ");
                menuChoiceString = Console.ReadLine();

                ErrorHandling.TwoChoiceMenuHandling(menuChoiceString);

                Console.Clear();

                switch (menuChoiceString)
                {
                    case "1":
                        AttackMonster(listOfMOnsters[randomMonster]);
                        break;
                    case "2":
                        keepMenuGo = false;
                        PlayerMOnsterFUllHp(listOfMOnsters[randomMonster]);
                        break;

                }
                PlayerMOnsterFUllHp(listOfMOnsters[randomMonster]);
                break;



            } while (keepMenuGo);
        }




        //===================================================================================================================================================================================
        // Skriver ut ett random monster
        //===================================================================================================================================================================================
        private static void MonsterAppear(Monster.Monster monster)
        {
            Console.WriteLine($"Watch out! An ancient {monster.Name} level {monster.Level} is blocking your way\n");
        }



        //===================================================================================================================================================================================
        // Battlesystem
        //===================================================================================================================================================================================
        private static void AttackMonster(Monster.Monster monster)
        {
            do
            {
                int randomPlayerDmg = rand.Next(1, 50);
                playerOne.Dmg = randomPlayerDmg;
                int randomMonsterDmg = rand.Next(1, 25);
                monster.AtkDmg = randomMonsterDmg;
                int randomMonsterGoldDrop = rand.Next(0, 100);
                monster.GoldDrop = randomMonsterGoldDrop;



                Console.WriteLine($"You attack the {monster.Name} with your {playerOne.WeponName} and deal {playerOne.Dmg}(+{playerOne.Strenght}) damage.");
                monster.Hp = monster.Hp - playerOne.Dmg - playerOne.Strenght;
                if (monster.Hp <= 0)
                {
                    break;
                }

                Console.WriteLine($"The {monster.Name} life is {monster.Hp} / {monster.MaxHp}.\n");
                Console.WriteLine($"The {monster.Name} attack you with {monster.AtkName} and deal {monster.AtkDmg}.");
                playerOne.Hp = playerOne.Hp - monster.AtkDmg;
                Console.WriteLine($"Your life is {playerOne.Hp} / {playerOne.Toughness + 100} \n");
                Console.WriteLine("Press ENTER to hit again!");
                Console.ReadLine();


                Console.Clear();
            } while (monster.Hp > 0);

            if (playerOne.Hp <= 0)
            {
                Console.WriteLine("YOU DIED");
                Exit();
            }
            else if (monster.Hp <= 0)
            {
                Console.WriteLine($"\nYou defeted the {monster.Name}\n");

                playerOne.Exp = playerOne.Exp + monster.Exp;
                Console.WriteLine($"You gained {monster.Exp} exp.");
                Console.WriteLine($"Exp: {playerOne.Exp} / {playerOne.ExpLevelUp}");
                if (playerOne.Exp == playerOne.ExpLevelUp)
                {
                    playerOne.Exp = default;
                    playerOne.Level += 1;
                    playerOne.ExpLevelUp += 100;
                    Console.WriteLine($"\nNice! You are level {playerOne.Level} now.");
                }

                Console.WriteLine($"\n{monster.Name} dropped {monster.GoldDrop} gold");
                playerOne.Gold = playerOne.Gold + monster.GoldDrop;
                Console.WriteLine($"Your gold ammount is: {playerOne.Gold}");
                Console.ReadLine();

            }


        }



        //===================================================================================================================================================================================
        // Återställer full Hp
        //===================================================================================================================================================================================
        private static void PlayerMOnsterFUllHp(Monster.Monster monster)
        {
            playerOne.Hp = 100 + playerOne.Toughness;
            monster.Hp = monster.MaxHp;
        }



        //===================================================================================================================================================================================
        // En "logo" till spelet
        //===================================================================================================================================================================================
        private static void GameLogo()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("     WELCOME TO THE DARKWOODS     ");
            Console.WriteLine("==================================");
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
            Console.Clear();

            Console.WriteLine($"Hello {playerOne.Name}!");
        }



        //===================================================================================================================================================================================
        // Stänger ner spelet
        //===================================================================================================================================================================================
        private static void Exit()
        {
            Console.Write("The Darkwoods awiats you......\n\n\n");
            Environment.Exit(0);
        }
    }
  
}
