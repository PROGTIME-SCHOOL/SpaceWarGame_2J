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

        // constructors
        public Player()
        {
            position = new Vector2(0, 0);
            texture = null;
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
            position.X = position.X + 1;
        }
    }
}

