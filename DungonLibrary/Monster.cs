using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        public string Description { get; set; }
        public int MaxDamage { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }//end MinDamage
        public Monster(string name, int maxLife, int life, int hitChance, int block,
            int minDamage, int maxDamage, string description)
        {
            Name = name;
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Life = life;
            MinDamage = minDamage;
            HitChance = hitChance;
            Block = block;
            Description = description;        
        }//endFQCTOR
        public override string ToString()
        {
            return string.Format($"+|+|+|+|+ Monster Stats +|+|+|+|+|+\n{Name}\nLife: {Life} of {MaxLife}\n" +
                $"Damage: {MinDamage} to {MaxDamage}\nBlock: {Block}%\nDescription:{Description}\n");
        }//end ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage

    }//end Class
}//end Dungeon Library
