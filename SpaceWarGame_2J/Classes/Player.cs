using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;      // LIST

namespace SpaceWarGame_2J.Classes
{
    public class Player
    {
        // fields
        private Vector2 position;
        private Texture2D texture;
        private float speed;

        private Rectangle collision;

        // weapon
        List<Bullet> bulletList = new List<Bullet>();
        int time = 0;
        int duration = 30;   // через сколько итераций вылетает пулька 500 мс

        // properties
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

        public void Update(ContentManager manager)
        {
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
    }
}

