﻿using System;
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

		public HUD()
		{
			healthBar = new HealthBar();

			label = new Label("uu", new Vector2(800, 0), Color.Orange);
			//healthBar.Value = 3;
		}

		public void LoadContent(ContentManager manager)
		{
			healthBar.LoadContent(manager);
		}

		public void Update()
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			healthBar.Draw(spriteBatch);
		}

		public void UpdateUI(int value)
		{
			healthBar.Value = value;
		}

	}
}

