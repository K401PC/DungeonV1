using DungonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibrary
{
    public class Dragon : Monster
    {
        public bool IsAncient { get; set; }

        public Dragon(string name, int life, int maxLife,int hitChance, int block, int minDamage, int maxDamage,
            string description, bool isAncient)
            :base (name,maxLife,life,hitChance,block,minDamage,maxDamage,description)
        {
            IsAncient = isAncient;
        }
        public override string ToString()
        {
            return base.ToString() + (IsAncient ? "It is Ancient and horrifying" : "It's not yet full grown");
        }
        public override int CalcBlock()
        {
            return IsAncient ? Block * 2: Block;
        }
    }
}
