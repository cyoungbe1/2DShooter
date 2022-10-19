using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DShooter._2DShooter;
using System.Drawing;

namespace _2DShooter
{
     class DemoGame : _2DShooter._2DShooter
    {


        public DemoGame() : base(new Vector2(615,515), "2DShooter Demo") { }



        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            Shape2D player = new Shape2D(new Vector2(10,10), new Vector2(10,10), "Test"); 

        }

         public override void OnDraw()
        {
       
        }

      
        int frame = 0;
        public override void OnUpdate()
        {
            Console.WriteLine($"Frame Count: {frame}");
            frame++;
        }
    }
}
