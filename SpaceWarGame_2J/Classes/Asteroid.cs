using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceWarGame_2J.Classes
{
    public class Asteroid
    {
        private Vector2 position;
        private Texture2D texture;
        private float speed;
        private Rectangle collision;

        public Rectangle Collision
        {
            get { return collision; }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Asteroid()
        {
            position = new Vector2(0, 0);
            texture = null;
            speed = 3;
        }

        public Asteroid(Vector2 position)
        {
            this.position = position;
            texture = null;
            speed = 3;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("asteroid");
        }

        public void Update()
        {
            collision = new Rectangle((int)position.X, (int)position.Y,
                texture.Width, texture.Height);

            position.Y += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

