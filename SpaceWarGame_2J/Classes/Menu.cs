using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using SpaceWarGame_2J.Classes.Elements;

namespace SpaceWarGame_2J.Classes
{
	public class Menu
	{
		private List<Label> listLabel;
		private int selected = 0;

		private KeyboardState keyboardState;
		private KeyboardState prevKeyboardState;

		public Menu()
		{
			listLabel = new List<Label>()
			{
				new Label(text: "Play", position: new Vector2(0,0), color: Color.White),
                new Label("Settings", new Vector2(0,40), Color.White),
                new Label("Info", new Vector2(0,80), Color.White),
                new Label("Exit", new Vector2(0,120), Color.White)
            };
		}

		public void LoadContent(ContentManager manager)
		{
			foreach (Label label in listLabel)
			{
                label.LoadContent(manager);
			}
		}

		public void Update(Game1 game1)
		{
			keyboardState = Keyboard.GetState();

			// down
            if (keyboardState.IsKeyDown(Keys.S) && prevKeyboardState.IsKeyUp(Keys.S))
			{
				if (selected < 3)
				{
                    selected++;
                }
			}

			// up
            if (keyboardState.IsKeyDown(Keys.W) && prevKeyboardState.IsKeyUp(Keys.W))
            {
                if (selected > 0)
                {
                    selected--;
                }
            }

            prevKeyboardState = keyboardState;


			// action
			if (keyboardState.IsKeyDown(Keys.Enter))
			{
				switch(selected)
				{
					case 0:             // play
						Game1.gameMode = GameMode.Play;
						game1.Reset();
						break;
                    case 1:				// settings
                        break;
                    case 2:				// info
                        break;
                    case 3:             // exit
						Game1.gameMode = GameMode.Exit;
                        break;
                }
			}

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			listLabel[selected].Color = Color.Yellow;

			for (int i = 0; i < listLabel.Count; i++)
			{
				listLabel[i].Draw(spriteBatch);
				listLabel[i].Color = Color.White;
			}
        }
	}
}

