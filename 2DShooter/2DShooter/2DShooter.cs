using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Identity.Client;

namespace _2DShooter._2DShooter
{

    class Canvas : Form
    {

        public Canvas()
        {
            this.DoubleBuffered = true;
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Canvas";
            this.Load += new System.EventHandler(this.Canvas_Load);
            this.ResumeLayout(false);

        }

        private void Canvas_Load(object sender, EventArgs e)
        {

        }
    }
    public abstract class _2DShooter
    {

        private Vector2 ScreenSize = new Vector2(512,512);
        private string Title = "New Game";
        private Canvas Window = null;
        private Thread GameloopThread = null;



        private static List<Shape2D> AllShapes = new List<Shape2D>();

        public Color BackgroundColor = Color.Beige; 

        public _2DShooter(Vector2 ScreenSize, string Title)
        {
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X,(int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
           
            
            

            GameloopThread = new Thread(Gameloop);
            GameloopThread.Start();

           OnLoad();
            
            Application.Run(Window);

        }


        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }


        public static void UnregisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

        void Gameloop()
        {
            OnLoad();

            while (GameloopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);

                }
                catch
                {
                    Console.WriteLine("Game is loading...");
                }
            }
            
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            g.Clear(BackgroundColor);

            foreach(Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }
            
        }

        // used to load sprites and objects into the game
        public abstract void OnLoad();

        public abstract void OnUpdate();

        public abstract void OnDraw();

    }
}
