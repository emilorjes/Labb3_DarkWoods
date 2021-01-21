using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Monster
{
    class TreeDropper: Monster
    {
        public TreeDropper(string name, string atkName, int hp, int maxHp, int level, int exp, int atkDmg, int goldDrop)
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

        public static TreeDropper treeDropper = new TreeDropper("Treedropper", "Webspinn", 100, 100, 1, 100, default, default);
    }
}
