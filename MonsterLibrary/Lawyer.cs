using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungonLibrary;

namespace MonsterLibrary
{
    public class Lawyer : Monster
    {
        public bool HasRestrainingOrder { get; set; }

        public Lawyer(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage,
            string description, bool hasRestrainingOrder)
            :base (name,maxLife,life,hitChance,block,minDamage,maxDamage,description)
        {
            HasRestrainingOrder = hasRestrainingOrder;
            MaxDamage = (HasRestrainingOrder ? MaxDamage * 9000 : MaxDamage * 2);
            Block = (HasRestrainingOrder ? block * 3 : Block);
        }
        public override string ToString()
        {
            return base.ToString() + (HasRestrainingOrder ? "A Sharply dressed man in a suit approaches with  PAPERs" : 
                "A drunken slob appears to have his tie over his eyes.");
        }
        public override int CalcBlock()
        {
            return HasRestrainingOrder ? Block * 3 : Block;
        }
    }//end class
}//end namespace
