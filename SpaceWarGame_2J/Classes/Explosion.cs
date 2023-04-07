using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace SpaceWarGame_2J.Classes
{
	public class Explosion
	{
		private Texture2D texture;
		private Vector2 position;
		private bool isVisible = true;
		private Rectangle sourceRectangle;   // часть тестуры
		private int numFrame = 0;

		private int duration = 3; // через какое время переключаемся
		private int time = 0;      // для накапливания

		public bool IsVisible
		{
			get { return isVisible; }
		}

		public Explosion(Vector2 position)
		{
			sourceRectangle = new Rectangle(numFrame * 117, 0, 117, 117);

			this.position = position;
		}

		public void LoadContent(ContentManager manager)
		{
			texture = manager.Load<Texture2D>("explosion3");
		}

		public void Update()
		{
			time++;

			if (time >= duration)
			{
				time = 0;

				numFrame++;
			}

			if (numFrame == 17)   // loop animation
			{
				//numFrame = 0;
				isVisible = false;
			}

            sourceRectangle = new Rectangle(numFrame * 117, 0, 117, 117);
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, sourceRectangle, Color.White);
		}
	}
}

