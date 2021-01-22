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
        

        


        //===================================================================================================================================================================================
        // Startar upp ett nytt game
        //===================================================================================================================================================================================
        public static void NewGame()
        {
            GameLogic.GameIntro();
            GameLogic.MainMenu();
        }
        //===================================================================================================================================================================================





        //===================================================================================================================================================================================
        // Spelets namn och en historia visas upp och använderen får välja namn på player och wepon.
        //===================================================================================================================================================================================
        private static void GameIntro()
        {
            MenuVisualText.GameLogo();
            StoryVisualText.IntroText();
            ChoosePlayerAndWeponNames();
        }
        //===================================================================================================================================================================================





        //===================================================================================================================================================================================
        // Skriver ut ett random monster
        //===================================================================================================================================================================================
        private static void MonsterAppear(Monster.Monster monster)
        {
            Console.WriteLine($"Watch out! An ancient {monster.Name} level {monster.Level} is blocking your way\n");
        }
        //===================================================================================================================================================================================





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

            

            if (playerOne.Name == "Robin")
            {
                playerOne.Level = 9;
                playerOne.Toughness = 100;
                playerOne.Strenght = 100;
                playerOne.Gold = 1000000;
            }
        }
        //===================================================================================================================================================================================





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
                        Player.Player.PrintPlayerInfo(playerList[0]);
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
                            Battle(listOfMOnsters[randomMonster]);
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
                Console.WriteLine("Nothing happens.");
                Console.ReadLine();
            }
            
        }
        //===================================================================================================================================================================================





        //===================================================================================================================================================================================
        // Battlesystem
        //===================================================================================================================================================================================
        private static void Battle(Monster.Monster monster)
        {
            do
            {
                int randomPlayerDmg = rand.Next(1, 50);
                playerOne.Dmg = randomPlayerDmg;
                int randomMonsterDmg = rand.Next(1, 40);
                monster.AtkDmg = randomMonsterDmg;
                int randomMonsterGoldDrop = rand.Next(0, 100);
                monster.GoldDrop = randomMonsterGoldDrop;

                if (monster.Hp == 0)
                {
                    break;
                }

                PlayerBattleDmg(monster);

                MonsterBattleHp(monster);

                MonsterBattleDmg(monster);

                PlayerBattleHp();

                BattleHitWonLose(monster);

                Console.ReadLine();

                Console.Clear();
            } while (monster.Hp > 0);

            DefetedMonsterGains(monster);
        }

        private static void DefetedMonsterGains(Monster.Monster monster)
        {
            if (monster.Hp <= 0)
            {
                Console.Write($"You defeted the ");
                Tools.MagnetaTextWr($"{monster.Name}\n");

                Tools.MagnetaTextW($"\n{monster.Name} ");
                Console.Write("dropped ");
                Tools.YellowTextWr($"{monster.GoldDrop} Gold");
                playerOne.Gold += monster.GoldDrop;
                Console.Write($"Your gold ammount is: ");
                Tools.YellowTextWr($"{playerOne.Gold}\n");

                playerOne.Exp += monster.Exp;
                Console.WriteLine($"You gained {monster.Exp} exp.");
                Console.WriteLine($"Exp: {playerOne.Exp} / {playerOne.ExpLevelUp} to next level.");

                if (playerOne.Exp == playerOne.ExpLevelUp)
                {
                    playerOne.Exp = default;
                    playerOne.Level += 1;
                    playerOne.ExpLevelUp += 100;
                    Console.WriteLine($"\nNice! You are level {playerOne.Level} now.");
                    if (playerOne.Level == 10)
                    {
                        Console.WriteLine("\nYOU WON THE GAME!\n");
                        Tools.Exit();
                    }
                }

                Console.ReadLine();
            }
        }

        private static void BattleHitWonLose(Monster.Monster monster)
        {
            if (monster.Hp > 0 && playerOne.Hp > 0)
            {
                Console.WriteLine("Press ENTER to hit again!");
            }
            else if (monster.Hp <= 0 && playerOne.Hp > 0)
            {
                Tools.GreenTextWr("You Won The Battle!");
            }
            else if (playerOne.Hp <= 0)
            {
                Tools.RedTextWr("YOU DIED");
                Console.ReadLine();
                Console.Clear();
                Tools.Exit();
            }
        }

        private static void PlayerBattleHp()
        {
            if (playerOne.Hp > 0)
            {
                Console.Write($"Your life is ");
                Tools.RedTextW($"{playerOne.Hp + playerOne.Toughness} ");
                Console.Write("/");
                Tools.GreenTextWr($" {playerOne.FixedHp + playerOne.Toughness} \n");
            }
            else if (playerOne.Hp <= 0)
            {
                Console.Write($"Your life is ");
                Tools.RedTextW($"0 ");
                Console.Write("/");
                Tools.GreenTextWr($" {playerOne.FixedHp + playerOne.Toughness} \n");
            }
        }

        private static void MonsterBattleDmg(Monster.Monster monster)
        {
            Console.Write($"The ");
            Tools.MagnetaTextW($"{monster.Name} ");
            Console.Write("attack you with ");
            Tools.MagnetaTextW($"{monster.AtkName} ");
            Console.Write("and deal ");
            Tools.BlueTextW($"{monster.AtkDmg} ");
            Console.WriteLine("damage.");
            playerOne.Hp -= monster.AtkDmg;
        }

        private static void PlayerBattleDmg(Monster.Monster monster)
        {
            Console.Write($"You attack the ");
            Tools.MagnetaTextW($"{monster.Name} ");
            Console.Write("with your ");
            Tools.MagnetaTextW($"{playerOne.WeponName} ");
            Console.Write("and deal ");
            Tools.BlueTextW($"{playerOne.Dmg} ");
            Console.Write("(");
            Tools.BlueTextW($"+{playerOne.Strenght}");
            Console.WriteLine(") damage.");
            monster.Hp = monster.Hp - playerOne.Dmg - playerOne.Strenght;
        }

        private static void MonsterBattleHp(Monster.Monster monster)
        {
            if (monster.Hp > 0)
            {
                Console.Write($"The {monster.Name} life is ");
                Tools.RedTextW($"{monster.Hp} ");
                Console.Write("/");
                Tools.GreenTextWr($" {monster.MaxHp}.\n\n");
            }
            else if (monster.Hp <= 0)
            {
                Console.Write($"The {monster.Name} life is ");
                Tools.RedTextW($"0 ");
                Console.Write("/");
                Tools.GreenTextWr($" {monster.MaxHp}.\n\n");
            }
        }
        //===================================================================================================================================================================================

















    }

}
