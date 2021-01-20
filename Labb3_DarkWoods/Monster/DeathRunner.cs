using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Monster
{
    class DeathRunner: Monster
    {
        private string name;
        private string atkName;
        private int hp;
        private int maxHp;
        private int level;
        private int exp;
        private int atkDmg;
        private int goldDrop;

        public DeathRunner(string name, string atkName, int hp, int maxHp, int level, int exp, int atkDmg, int goldDrop)
        {
            this.Name = name;
            this.atkName = atkName;
            this.Hp = hp;
            this.MaxHp = maxHp;
            this.Level = level;
            this.Exp = exp;
            this.AtkDmg = atkDmg;
            this.GoldDrop = goldDrop;
        }

        public static DeathRunner deathRunner = new DeathRunner("Deathrunner", "Souldestroyer", 100, 100, 1, 100, default, default);
    }
}
