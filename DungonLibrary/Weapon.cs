using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    public class Weapon
    {
        //fields
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private int _bonusHitChance;
        private bool _isTwoHanded;

        //properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded
        public int MinDamge
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }//end minDamage
        //ctor//constructor
        //Only use FQCTOR
        public Weapon(string name,int maxDamage,int minDamage,int bonusHitChance,bool isTwoHanded)//can be in any order
        {
            //The order that the parameters are placed doesn't matter at all. The order
            //they are assigned in is critical if we have properties whose business rules
            //rely on the value of other properties. In that case it's best to set the
            //dependent values first:
            MaxDamage = maxDamage;
            Name = name;
            MinDamge = minDamage;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }
        //methods
        public override string ToString()
        {
            //return base.ToString();
            //The default base.ToString() for complex objects is namespace.ClassName
            //which we don't want
            return string.Format("{0}\t{1} to {2} damage\nBonus Hit Chance: {3}%\t{4}",
                Name,
                MinDamge,
                MaxDamage,
                BonusHitChance,
                //MINI LAB
                //Build a ternary operator to ut put whether or not the weapon is two handed
                //IsTwoHanded == false ? "One-Handed" : "Two-Handed" ); my trenary
                IsTwoHanded ? "Two-Handed" : "One-Handed");//instructor
        }
    }//end class
}
