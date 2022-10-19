using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DShooter._2DShooter
{
    public class Shape2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = ""; 
        

        public Shape2D(Vector2 position, Vector2 Scale, string Tag)
        {
          this.Position = position;
          this.Scale = Scale;
          this.Tag = Tag;

          _2DShooter.RegisterShape(this);  
        }


        

    }
}
