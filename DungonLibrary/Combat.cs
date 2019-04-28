using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rando = new Random();
            int diceRoll = rando.Next(1, 101);
            System.Threading.Thread.Sleep(30);//to increase randomnization
            if (diceRoll<=attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//Enc DoAttck()

        public static void DoBattle(Player player, Monster monster)
        {
            Random rando = new Random();
            int diceRoll = rando.Next(1, 101);
            System.Threading.Thread.Sleep(30);//to increase randomnization
            if (diceRoll<=50)
            {
                DoAttack(player, monster);
                if (monster.Life > 0)
                {
                    DoAttack(monster, player);
                }//end if
            }
            else
            {
                DoAttack(monster, player);
                if (player.Life > 0)
                {
                    DoAttack(player, monster);
                }
            }
            
        }//end DoBattle()
    }
}
