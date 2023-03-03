using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceWarGame_2J.Classes
{
    public class Player
    {
        // fields
        private Vector2 position;
        private Texture2D texture;
        private float speed;

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
        }

        public void Update()
        {
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
        }
    }
}

