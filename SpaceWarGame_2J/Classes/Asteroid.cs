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

        public Asteroid()
        {
            position = new Vector2(0, 0);
            texture = null;
            speed = 3;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("asteroid");
        }

        public void Update()
        {
            position.Y += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

