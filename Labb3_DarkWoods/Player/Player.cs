using Labb3_DarkWoods.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Labb3_DarkWoods.Player
{
    class Player
    {
        //===================================================================================================================================================================================
        // Fields
        //===================================================================================================================================================================================
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
        private int fixedHp;





        //===================================================================================================================================================================================
        // Property
        //===================================================================================================================================================================================
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
        public int FixedHp { get => fixedHp; set => fixedHp = value; }





        //===================================================================================================================================================================================
        // Constructor
        //===================================================================================================================================================================================
        public Player(string name, string weponName, int level, int exp, int expLevelUp, int hp, int gold, int strenght, int toughness, int dmg, int fixedHp)
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
            this.fixedHp = fixedHp;
        }





        //===================================================================================================================================================================================
        // Nytt objekt skapas
        //===================================================================================================================================================================================
        public static Player playerOne = new Player(" ", " ", 1, default, 100, 100, default, default, default, default, 100);





        //===================================================================================================================================================================================
        // Skriver ut alla stats på player
        //===================================================================================================================================================================================
        public static void PrintPlayerInfo(Player playerOne)
        {
            
            Console.Write("Name: ");
            Tools.GreenTextWr($"{playerOne.Name}");
         
            Console.Write("\nLevel: ");
            Tools.GreenTextWr($"{playerOne.Level}");
           
            Console.Write("\nHP: ");
            Tools.GreenTextWr($" {playerOne.Hp + playerOne.Toughness} / {playerOne.FixedHp + playerOne.Toughness} ");

            Console.Write("\nEXP: ");
            Tools.GreenTextWr($"{playerOne.Exp} / {playerOne.ExpLevelUp} ( {playerOne.ExpLevelUp - playerOne.Exp} exp left to level {playerOne.Level + 1})");
         
            Console.Write("\nGold: ");
            Tools.GreenTextWr($"{playerOne.Gold}");
       
            Console.Write("\nStrength: ");
            Tools.GreenTextWr($"+ {playerOne.Strenght}");

            Console.Write("\nToughness: ");
            Tools.GreenTextWr($"+ {playerOne.Toughness}");
       
            Console.Write("\nWepon name: ");
            Tools.GreenTextWr($"{playerOne.WeponName}");
           
            Console.ReadLine();
        }
    }
}
