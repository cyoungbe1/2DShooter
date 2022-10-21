using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DShooter._2DShooter;
using System.Drawing;
using System.Windows.Forms;

namespace _2DShooter
{
     class DemoGame : _2DShooter._2DShooter
    {

        Shape2D player;

        public DemoGame() : base(new Vector2(615,515), "2DShooter Demo") { }



        public override void OnLoad()
        {
            Console.WriteLine("Yay Onload works!"); // This is not working
            
            BackgroundColor = Color.Black;

           player  = new Shape2D (new Vector2(10,10), new Vector2(10,10), "Test"); 

        }

         public override void OnDraw()
        {
       
        }

      
        int frame = 0;
        float x = 0.03f;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame}");
            player.Position.X += x;
            frame++;
        }
    }
}
