﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Monster
{
    class EarthCrawler: Monster
    {
        private string name;
        private string atkName;
        private int hp;
        private int maxHp;
        private int level;
        private int exp;
        private int atkDmg;
        private int goldDrop;

        public EarthCrawler(string name, string atkName, int hp, int maxHp, int level, int exp, int atkDmg, int goldDrop)
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

        public static EarthCrawler earthCrawler = new EarthCrawler("Earthcrawler", "Mudblast", 100, 100, 1, 100, default, default);
    }
}
