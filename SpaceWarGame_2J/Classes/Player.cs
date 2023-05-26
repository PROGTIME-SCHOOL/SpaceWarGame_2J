using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;      // LIST
using System;

namespace SpaceWarGame_2J.Classes
{
    public class Player
    {
        // fields
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        private int health = 10;
        private bool isVisible = true;
        private int score = 0;

        private Rectangle collision;

        private int distance = 0;   // сколько корабль пролетит
        private double timeInGame = 0;   // сколько времени провел в игре

        // weapon
        List<Bullet> bulletList = new List<Bullet>();
        int time = 0;
        int duration = 30;   // через сколько итераций вылетает пулька 500 мс

        // properties

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Distance { get { return distance; } }

        public double TimeInGame
        {
            get { return Math.Round(timeInGame, 2); }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Health { get { return health; } }
        public bool IsVisible { get { return isVisible; } }

        public Rectangle Collision
        {
            get { return collision; }
        }

        public List<Bullet> BulletList
        {
            get { return bulletList; }
        }


        // constructors
        public Player()
        {
            position = new Vector2(350, 400);
            texture = null;
            speed = 5;
            
        }

        // methods
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Draw(spriteBatch);
            }
        }

        public void Update(ContentManager manager, GameTime gameTime)
        {
            timeInGame += gameTime.ElapsedGameTime.TotalSeconds;
            distance += (int)speed;
           
            //System.Diagnostics.Debug.WriteLine("My TIME: " + Math.Round(timeInGame, 2));


            collision =
                new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);


            #region Управление

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D))
            {
                position.X += speed;
            }

            if (state.IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }

            if (state.IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }

            if (state.IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }

            #endregion

            if (position.X < 0)
            {
                position.X = 0;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
            }

            if (position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }

            if (position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }


            // weapon

            time++;

            if (duration == time)
            {
                Bullet bullet = new Bullet(position);
                bullet.LoadContent(manager);
                bulletList.Add(bullet);

                time = 0;
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].Update();

                if (bulletList[i].Position.Y < -50)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Damage()
        {
            health--;

            if (health < 0)
            {
                health = 0;

                isVisible = false;
            }
        }

        public void Reset()
        {
            health = 10;
            position = new Vector2(350, 400);
            isVisible = true;
            bulletList.Clear();
            score = 0;

            distance = 0;
            timeInGame = 0;
        }
    }
}

