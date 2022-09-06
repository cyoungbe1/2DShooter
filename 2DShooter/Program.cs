using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DShooter
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.weapon1 = 'a';
            player1.weapon2 = 'b';
            player1.weapon3 = 'c';
            player1.item1 = 'd';
            player1.item2 = 'e';
            player1.totalPoints = 0;

            player1.name = "badassbob";

            Console.Clear();
            Console.WriteLine("name " + player1.name, "Total Points" + player1.totalPoints, "Item 1" + player1.item1, "Item 2" + player1.item2, "Weapon 1" + player1.weapon1, "Weapon2" + player1.weapon2, "Weapon 3" + player1.weapon3);
        }
    }
}
