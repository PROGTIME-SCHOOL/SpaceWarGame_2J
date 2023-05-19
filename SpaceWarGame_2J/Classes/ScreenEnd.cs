using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SpaceWarGame_2J.Classes.Elements;

namespace SpaceWarGame_2J.Classes
{
	public class ScreenEnd
	{
		private Label labelHeader;
		private Label lblScore;
		private Label lblInfo;

		KeyboardState keyboardState;
		KeyboardState prevKeyboardState;

        public ScreenEnd()
		{
            labelHeader = new Label("THE END", new Vector2(350, 150), Color.White);
			lblScore = new Label("Score: 400", new Vector2(345, 200), Color.White);
            lblInfo = new Label("Press Enter to continue...", new Vector2(300, 250), Color.Orange);
        }

		public void Update()
		{
			keyboardState = Keyboard.GetState();

			if (prevKeyboardState.IsKeyDown(Keys.Enter) &&
				keyboardState.IsKeyUp(Keys.Enter))
			{
				Game1.gameMode = GameMode.Menu;
			}

			prevKeyboardState = keyboardState;
        }

		public void LoadContent(ContentManager manager)
		{
            labelHeader.LoadContent(manager);
			lblScore.LoadContent(manager);
            lblInfo.LoadContent(manager);
        }

		public void Draw(SpriteBatch spriteBatch)
		{
            labelHeader.Draw(spriteBatch);
			lblScore.Draw(spriteBatch);
            lblInfo.Draw(spriteBatch);
        }

		public void SetScore(int score)
		{
			lblScore.text = "Score: " + score.ToString();
        }
	}
}

