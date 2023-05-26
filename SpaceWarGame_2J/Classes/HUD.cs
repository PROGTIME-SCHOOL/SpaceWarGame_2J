using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using SpaceWarGame_2J.Classes.Elements;

namespace SpaceWarGame_2J.Classes
{
	public class HUD   // Head Up Display
	{
		private HealthBar healthBar;
		
		private Label label;

		private Label lblGameTime;
		private Label lblDistance;

		public HUD()
		{
			healthBar = new HealthBar();

			label = new Label("uu", new Vector2(800, 0), Color.Orange);
			//healthBar.Value = 3;

			lblDistance = new Label("Distance", new Vector2(10, 60), Color.White);
            lblGameTime = new Label("Time", new Vector2(10, 80), Color.White);
        }

		public void LoadContent(ContentManager manager)
		{
			healthBar.LoadContent(manager);
			lblDistance.LoadContent(manager);
			lblGameTime.LoadContent(manager);
		}

		public void Update()
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			healthBar.Draw(spriteBatch);
			lblDistance.Draw(spriteBatch);
			lblGameTime.Draw(spriteBatch);
		}

		public void UpdateUI(int value, int distance, double gameTime)
		{
			healthBar.Value = value;

			lblDistance.text = $"Distance: {distance}";
			lblGameTime.text = $"Game Time: {gameTime}";
		}



	}
}

