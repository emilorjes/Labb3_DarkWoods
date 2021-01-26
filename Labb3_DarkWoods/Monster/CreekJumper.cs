using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Monster
{
    class CreekJumper: Monster
    {
        //===================================================================================================================================================================================
        // Constructor
        //===================================================================================================================================================================================
        public CreekJumper(string name, string atkName, int hp, int maxHp, int level, int exp, int atkDmg, int goldDrop)
        {
            this.Name = name;
            this.AtkName = atkName;
            this.Hp = hp;
            this.MaxHp = maxHp;
            this.Level = level;
            this.Exp = exp;
            this.AtkDmg = atkDmg;
            this.GoldDrop = goldDrop;
        }





        //===================================================================================================================================================================================
        // Nytt objekt skapas
        //===================================================================================================================================================================================
        public static CreekJumper creekJumper = new CreekJumper("Creekjumper", "Creekstone", 100, 100, 1, 100, default, default);
    }
}
