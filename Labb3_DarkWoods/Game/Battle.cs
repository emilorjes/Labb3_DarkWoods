using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Labb3_DarkWoods.Monster;
using Labb3_DarkWoods.Utility;
using static Labb3_DarkWoods.Monster.Monster;
using static Labb3_DarkWoods.Player.Player;

namespace Labb3_DarkWoods.Game
{
    class Battle
    {
        //===================================================================================================================================================================================
        // En random som används i denna klass
        //===================================================================================================================================================================================
        public static Random rand = new Random();





        //===================================================================================================================================================================================
        // En metod som tar in metoder som styr battle systemet
        //===================================================================================================================================================================================
        public static void NewBattle(Monster.Monster monster)
        {
            PlayerBattleDmg(monster); // Skriver ut vilket monster som attackeras och hur mycket Dmg player slår
            MonsterBattleHp(monster); // Skriver ut hur mycket Hp monstret har efter den blivit skadad
            MonsterBattleDmg(monster); // Skriver ut vilket monster som attackerar och hur mycket Dmg monstret slår
            PlayerBattleHp(); // Skriver ut hur mycket Hp player har efter den blivit skadad
            BattleHitWonLose(monster); // Beroende på player och monsters Hp skrivs något av dessa if statments ut
        }





        //===================================================================================================================================================================================
        // Skriver ut vilket monster som attackeras och hur mycket Dmg player slår
        //===================================================================================================================================================================================
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





        //===================================================================================================================================================================================
        // Skriver ut hur mycket Hp monstret har efter den blivit skadad
        //===================================================================================================================================================================================
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
        // Skriver ut vilket monster som attackerar och hur mycket Dmg monstret slår
        //===================================================================================================================================================================================
        private static void MonsterBattleDmg(Monster.Monster monster)
        {
            if (monster.Hp > 0)
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
            else if (monster.Hp <= 0)
            {
                Console.Write($"The ");
                Tools.MagnetaTextW($"{monster.Name} ");
                Console.Write("died before it could hit you. ");

            }
        }





        //===================================================================================================================================================================================
        // Skriver ut hur mycket Hp player har efter den blivit skadad
        //===================================================================================================================================================================================
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





        //===================================================================================================================================================================================
        // Beroende på player och monsters Hp skrivs något av dessa if statments ut
        //===================================================================================================================================================================================
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





        //===================================================================================================================================================================================
        // Skriver ut information och Stats efter att ett monster blivit besegrat.
        //===================================================================================================================================================================================
        public static void DefetedMonsterGains(Monster.Monster monster)
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
                    monster.Level = playerOne.Level;
                    playerOne.ExpLevelUp += 100;
                    Console.WriteLine($"\nNice! You are level {playerOne.Level} now.");
                    LevelTen(); // När level 10 är uppnåt måste användaren skriva in ett lösenord för att kunna fortsätta
                }

                Console.ReadLine();
            }
        }





        //===================================================================================================================================================================================
        // När level 10 är uppnåt måste användaren skriva in ett lösenord för att kunna fortsätta
        //===================================================================================================================================================================================
        private static void LevelTen()
        {
            if (playerOne.Level == 10)
            {
                Console.Clear();
                Console.WriteLine("You killed all the monsters that guarded the ancient Mine that contains The Ark");
                Console.Write("Enter the password my to open the Doors of Durin: ");

                string minePassword = "Mellon";
                string durinPassword = Console.ReadLine().ToLower();

                if (durinPassword == minePassword.ToLower())
                {

                    StoryVisualText.EndingText();

                }
                else
                {
                    while (durinPassword != minePassword.ToLower())
                    {
                        Console.Clear();
                        Tools.RedTextWr("Wrong Password....\n");
                        StoryVisualText.SecretPasswordHints(); // En array med ledtrådar till secretPassword som skrivs ut random
                        Console.Write("Password: ");
                        durinPassword = Console.ReadLine().ToLower();
                    }
                    StoryVisualText.EndingText(); // Skriver ut endingtext med hjälp av metoden PrintSlow

                }

                Console.ReadLine();
                Console.Clear();
                Tools.Exit(); // Stänger ner spelet
            }
        }





        //===================================================================================================================================================================================
        // Beroende på vilken level monster är på ändras monstrets randomDmg  max skada, random guld droppas av monstret
        //===================================================================================================================================================================================
        public static void MonsterRandomDmgAndGoldDrop(Monster.Monster monster)
        {
          
            int randomMonsterDmg;
            if (monster.Level == 1)
            {
                randomMonsterDmg = rand.Next(1, 10);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 2)
            {
                randomMonsterDmg = rand.Next(1, 20);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 3)
            {
                randomMonsterDmg = rand.Next(1, 30);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 4)
            {
                randomMonsterDmg = rand.Next(1, 40);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 5)
            {
                randomMonsterDmg = rand.Next(1, 50);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 6)
            {
                randomMonsterDmg = rand.Next(1, 60);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 7)
            {
                randomMonsterDmg = rand.Next(1, 70);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 8)
            {
                randomMonsterDmg = rand.Next(1, 80);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 9)
            {
                randomMonsterDmg = rand.Next(1, 90);
                monster.AtkDmg = randomMonsterDmg;
            }
            else if (monster.Level == 10)
            {
                randomMonsterDmg = rand.Next(1, 100);
                monster.AtkDmg = randomMonsterDmg;
            }

            int randomMonsterGoldDrop = rand.Next(0, 100);
            monster.GoldDrop = randomMonsterGoldDrop;
        }
    }
}
