using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Monster
{
    class Monster
    {
        private string name;
        private string atkName;
        private int hp;
        private int maxHp;
        private int level;
        private int exp;
        private int atkDmg;
        private int goldDrop;

        public string Name { get => name; set => name = value; }
        public string AtkName { get => atkName; set => atkName = value; }
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Level { get => level; set => level = value; }
        public int Exp { get => exp; set => exp = value; }
        public int AtkDmg { get => atkDmg; set => atkDmg = value; }
        public int GoldDrop { get => goldDrop; set => goldDrop = value; }

    }
}
