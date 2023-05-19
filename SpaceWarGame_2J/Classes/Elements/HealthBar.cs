using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace SpaceWarGame_2J.Classes.Elements
{
	public class HealthBar
	{
		private Texture2D texture;		
		private Vector2 position;
		private int width;
		private int height;
		private int value;
		private int widthOneSection;

		public int Value
		{
			get { return value; }
			set { this.value = value; }
		}

		public HealthBar()
		{
			position = new Vector2(10, 10);
			width = 200;
			height = 30;
			value = 11;

			widthOneSection = width / value;
        }

		public void LoadContent(ContentManager manager)
		{
			texture = manager.Load<Texture2D>("healthbar");
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			
			Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y,
                widthOneSection * value, height);

			spriteBatch.Draw(texture, destinationRectangle, Color.White);
		}
	}
}

