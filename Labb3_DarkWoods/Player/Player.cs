using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Player
{
    class Player
    {
        private string name;
        private string weponName;
        private int level;
        private int exp;
        private int expLevelUp;
        private int hp;
        private int gold;
        private int strenght;
        private int toughness;
        private int dmg;

        public string Name { get => name; set => name = value; }
        public string WeponName { get => weponName; set => weponName = value; }
        public int Level { get => level; set => level = value; }
        public int Exp { get => exp; set => exp = value; }
        public int ExpLevelUp { get => expLevelUp; set => expLevelUp = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Strenght { get => strenght; set => strenght = value; }
        public int Toughness { get => toughness; set => toughness = value; }
        public int Dmg { get => dmg; set => dmg = value; }

        public Player(string name, string weponName, int level, int exp, int expLevelUp, int hp, int gold, int strenght, int toughness, int dmg)
        {
            this.Name = name;
            this.WeponName = weponName;
            this.Level = level;
            this.Exp = exp;
            this.ExpLevelUp = expLevelUp;
            this.Hp = hp;
            this.Gold = gold;
            this.Strenght = strenght;
            this.Toughness = toughness;
            this.Dmg = dmg;
        }

        public static Player playerOne = new Player(" ", " ", 1,default,100,default,default,default,default,default);

        public static void PrintPlayerInfo(Player playerOne)
        {
            
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(playerOne.Name);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nLevel: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(playerOne.Level);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nHP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" / ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nEXP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{playerOne.Exp} / {playerOne.expLevelUp}");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nGold: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(playerOne.Gold);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nStrength: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(playerOne.Strenght);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nToughness: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(playerOne.Toughness);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\nWepon name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(playerOne.WeponName);
            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadLine();
        }
    }
}
