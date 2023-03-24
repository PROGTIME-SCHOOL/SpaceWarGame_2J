using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace SpaceWarGame_2J.Classes
{
	public class Bullet
	{
		private Vector2 position;
		private Texture2D texture;
		private int speed;
		private Rectangle destinationRectangle;
		private Rectangle collision;

		public Rectangle Collision
		{
			get { return collision; }
		}


		public Vector2 Position
		{
			get { return position; }
		}

		public Bullet(Vector2 position)
		{
			this.position = position;

			speed = 5;
			texture = null;
		}

		public void LoadContent(ContentManager manager)
		{
			texture = manager.Load<Texture2D>("asteroid");
		}

		public void Update()
		{
			destinationRectangle = new Rectangle((int)position.X,
				(int)position.Y, 15, 15);

			collision = destinationRectangle;

			position.Y -= speed;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, destinationRectangle, Color.GreenYellow);
			
		}
	}
}

