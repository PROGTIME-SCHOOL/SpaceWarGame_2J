using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace SpaceWarGame_2J.Classes
{
    public class Space
    {
        private Texture2D texture;
        private Vector2 position1;
        private Vector2 position2;
        private float speed;

        public Space()
        {
            texture = null;
            position1 = new Vector2(0, 0);
            
            speed = 1;
        }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("space");

            position2 = new Vector2(0, -texture.Height);
        }

        public void Update()
        {
            position1.Y += speed;
            position2.Y += speed;

            if (position2.Y >= 0)
            {
                position1.Y = 0;
                position2.Y = -texture.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }
    }
}

