using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;


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

            // Add System Reflection component

            Console.WriteLine("--------------------");

            Console.WriteLine("Reflection Example");

            Type thisType = player1.GetType();

            Type weaponType = player1.weapon1.GetType();

            Type pointsType = player1.totalPoints.GetType();

            Console.WriteLine(thisType.Name);

            Console.WriteLine(weaponType.Name);

            Console.WriteLine(pointsType.Name);



            Console.WriteLine("--------------------");

            // Using Reflection to get information of an Assembly:

            System.Reflection.Assembly info = typeof(int).Assembly;

            Console.WriteLine(info);

            Console.ReadLine();

            Console.WriteLine("--------------------");

            Player.selectWeapon myObj = new Player.selectWeapon();

            myObj.chooseWeapon(5);

            Console.WriteLine("Weapon with 5 points {0}", myObj.newWeapon.ToString());

            myObj.chooseWeapon(10);

            Console.WriteLine("Weapon with 10 points {0}", myObj.newWeapon.ToString());

            Console.ReadLine();


            var playerList = new List<PlayerInfo>()
            {
            new PlayerInfo(){weapon1 = 'a'},


            };

            
        }

        
    }
}
