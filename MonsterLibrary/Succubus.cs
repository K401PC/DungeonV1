using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungonLibrary;

namespace MonsterLibrary
{
    public class Succubus : Monster
    {
        public Circle OfHell { get; set; }

        public Succubus(string name, int life, int maxLife, int minDamage, int maxDamage, int block,
            int hitChance,  Circle ofHell, string description)
            :base (name, maxLife, life, hitChance, block, minDamage, maxDamage, description)
        {
            OfHell = ofHell;
            switch (OfHell)
            {
                case Circle.Wrath:
                    MinDamage += 5;
                    MaxDamage += 15;
                    break;
                case Circle.Lust:
                    MaxLife += 15;
                    MaxLife += 10;
                    break;
                case Circle.Pride:
                    MaxLife += 20;
                    Life += 20;
                    MinDamage += 5;
                    MaxDamage += 20;
                    Block += 10;
                    HitChance += 20;
                    break;
                case Circle.Greed:
                    HitChance += 15;
                    MaxDamage += 10;
                    break;
                case Circle.Gluttnoy:
                    MaxLife += 10;
                    Life += 10;
                    HitChance += 10;
                    break;
                case Circle.Sloth:
                    HitChance -= 5;
                    Block += 10;
                    break;
                case Circle.Envy:
                    MaxLife += 10;
                    Life += 10;
                    MinDamage += 5;
                    MaxDamage += 10;
                    Block += 5;
                    HitChance += 10;
                    break;
                default:

                    break;
            }                              
        }
        public override string ToString()
        {
            return base.ToString() + ($"From the circle of {OfHell}");
        }
    }//end clas
}//end namespace    
