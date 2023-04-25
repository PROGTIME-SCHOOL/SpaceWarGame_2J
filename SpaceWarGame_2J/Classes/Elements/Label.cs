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

		public Color Color { get { return color; } set { color = value; } }

		public Label(string text, Vector2 position, Color color)
		{
			this.position = position;
			this.text = text;
			this.color = color;
		}

		public Label()
		{
			spriteFont = null;
			position = new Vector2(0, 0);
			color = Color.White;
			text = "Hello!";
		}

		public void LoadContent(ContentManager content)
		{
			spriteFont = content.Load<SpriteFont>("GameFont");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(spriteFont, text, position, color);
		}
	}
}

