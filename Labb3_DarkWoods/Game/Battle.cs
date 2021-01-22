using System;
using System.Collections.Generic;
using System.Text;
using Labb3_DarkWoods.Monster;
using Labb3_DarkWoods.Utility;
using static Labb3_DarkWoods.Monster.Monster;
using static Labb3_DarkWoods.Player.Player;

namespace Labb3_DarkWoods.Game
{
    class Battle
    {
        public static void NewBattle(Monster.Monster monster)
        {
            PlayerBattleDmg(monster);
            MonsterBattleHp(monster);
            MonsterBattleDmg(monster);
            PlayerBattleHp();
            BattleHitWonLose(monster);
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

       

        

        
       

       
    }
}
