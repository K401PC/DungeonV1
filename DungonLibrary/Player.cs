using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    public class Player : Character
    {
        //fields
        //private int _life;//life/HP
        /*
         * Automatic properties were introduced with .Net 3.5. They are a shortcut syntax
         * that allows you to quickly build a proprty without a filed. Instead, the field 
         * gets built by the compiler at runtime and automatically tied to the property.
         * You can't use automatic properties for any property with a business rule, so
         * we have a fied for life/hP, as it is going to have a rule that it can't be 
         * more than MaxLfe/maxHp
         */
        //properties //prop\t\t
        //public string Name { get; set; }
        //public int HitChance { get; set; }
        //public int BlockChance { get; set; }
        //public int MaxLife { get; set; }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //public int Life
        //{
        //    get { return _life; }
        //    set
        //    {
        //        _life = value <= MaxLife ? value : MaxLife;
        //    }//end set
        //}//end HP
        //ctors//ctor\t\t
        //MINI LAB BUILD FQCTOR
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        { 
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            switch (CharacterRace)
            {
                case Race.Elf:
                    HitChance += 10;
                    break;
                case Race.Dwarf:
                    Life += 10;
                    MaxLife += 10;
                    if (EquippedWeapon.Name == "Rusty Battle Axe")
                    {
                        EquippedWeapon.MaxDamage += 1;
                        EquippedWeapon.MinDamge += 1;
                    }
                    
                    break;
                case Race.HalfElf:

                    break;
                case Race.Human:
                    Block += 5;
                    HitChance = +5;
                    break;
                case Race.HalfOrc:
                    break;
                case Race.DragonBorn:
                    break;
                case Race.DarkElf:
                    break;
                case Race.Halfling:
                    break;
                case Race.Tiefling:
                    break;
                case Race.DemiHuman:
                    break;
                case Race.DescendantOfHigherPlain:
                    break;
                default:
                    break;
            }
        }
        //method
        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Elf:
                    description = "You're tall and huaty.";
                    break;
                case Race.Dwarf:
                    description = "You're short, have a big bushy beard, and drunk.";
                    break;
                case Race.HalfElf:
                    description = "Born of two worlds and shunned by both.";
                    break;
                case Race.Human:
                    description = "Boring.";
                    break;
                case Race.HalfOrc:
                    description = "You're big, green, and mad";
                    break;
                case Race.DragonBorn:
                    description = "You can fly and take lots of damage";
                    break;
                case Race.DarkElf:
                    description = "The shadows cling to you even in the light";
                    break;
                case Race.Halfling:
                    description = "You may have the size of a dwarf but the intillect of a human";
                    break;
                case Race.Tiefling:
                    description = "Demonic origin complete with hrns and tail.";
                    break;
                case Race.DemiHuman:
                    description = "Offspring of the demonic and hunman. You are part animal.";
                    break;
                case Race.DescendantOfHigherPlain:
                    description = "You may think you are holy do to your Aura but its just special efferts.";
                    break;
                    //seventhsactum.com
            }//end switch
            return string.Format("+|+|+|+|+ {0} +|+|+|+|+\nLife: {1} of {2}\nHit Chance: {3}%\nWeapon: {4}\n" +
                "Block: {5}\nDescription: {6}",
                Name,
                Life,
                MaxLife,
                HitChance,
                EquippedWeapon,
                Block,
                description);
        }//end To String()
        public override int CalcHitChance()
        {
            //return base.CalcHitChance() + EquippedWeapon.BonusHitChance;//works but long
            return HitChance + EquippedWeapon.BonusHitChance;
        }
        public override int CalcDamage()
        {
            //Random rand = new Random();
            //int damage = rand.Next(EquippedWeapon.MinDamge, EquippedWeapon.MaxDamage + 1);
            //return damage;

            return new Random().Next(EquippedWeapon.MinDamge, EquippedWeapon.MaxDamage + 1);
        }

    }//end class
}
