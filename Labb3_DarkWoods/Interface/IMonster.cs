using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3_DarkWoods.Interface
{
    public interface IMonster
    {
        string Name { get; set; }
        string AtkName { get; set; }
        int Hp { get; set; }
        int MaxHp { get; set; }
        int Level { get; set; }
        int Exp { get; set; }
        int AtkDmg { get; set; }
        int GoldDrop { get; set; }
    }
}
