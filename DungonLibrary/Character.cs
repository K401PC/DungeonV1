using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    //The abstract keyword indicates that the thing being modified is an incomplete
    //implementation, meaning that it is never intended to be initialized on its own.
    //When applied to a class it indicates that the calss is only intedned to be a
    //parent class for child classes. Abstract gives us a compiler-enforced rule
    //that prevent instantiation of the class
    public abstract class Character
    {
        private int _life;
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }//BlockChance
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end HP
        public virtual int CalcBlock()
        {
            //made this virtual so we can override it in child classes
            return Block;
        }//end CalcBlock
        //MINI LAB build the CalcHitChance() and make it return the HitChance
        //Make it overridable:
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end ClacHitChance
        //public virtual int CalacDamage()
        //{
        //    return 0;
            //PLayer and Monster calculate damage diferently, so we can;t have default
            //functionality like we do for HitChance and Block. Instead, we're just returning
            //0 and we will override the functionality in the derived classes
        //}
        public abstract int CalcDamage();//we would have to use this method as part of Calculations
        //prevents some problems
        //The abstract keyword forces child classes to override this functionality by providing a
        //method body. This prevents the possible mistake of returning zero which could happen
        //with the above version
    }//end class
}
