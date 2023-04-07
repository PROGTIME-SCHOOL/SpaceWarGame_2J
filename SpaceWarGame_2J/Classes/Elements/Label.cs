using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceWarGame_2J.Classes.Elements
{
	public class Label
	{
		private SpriteFont spriteFont;
		private Vector2 position;
		private Color color;
		private string text;

		public Label()
		{
			spriteFont = null;
			position = new Vector2(0, 0);
			color = Color.White;
			text = "Hello!";
		}

		public void LoadContent(ContentManager content)
		{
			spriteFont = content.Load<SpriteFont>("");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(spriteFont, text, position, color);
		}
	}
}

