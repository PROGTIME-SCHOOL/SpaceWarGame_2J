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
		private Label lblDistance;
		private Label lblGameTime;

		KeyboardState keyboardState;
		KeyboardState prevKeyboardState;

        public ScreenEnd()
		{
            labelHeader = new Label("THE END", new Vector2(350, 150), Color.White);

			lblScore = new Label("Score: 400", new Vector2(345, 200), Color.White);
            lblDistance = new Label("Distance: 0", new Vector2(345, 220), Color.White);
            lblGameTime = new Label("Game Time: 0", new Vector2(345, 240), Color.White);

            lblInfo = new Label("Press Enter to continue...", new Vector2(300, 290), Color.Orange);
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
			lblDistance.LoadContent(manager);
			lblGameTime.LoadContent(manager);
        }

		public void Draw(SpriteBatch spriteBatch)
		{
            labelHeader.Draw(spriteBatch);
			lblScore.Draw(spriteBatch);
            lblInfo.Draw(spriteBatch);

			lblDistance.Draw(spriteBatch);
			lblGameTime.Draw(spriteBatch);
        }

		public void UpdateUI(int score, int distance, double gameTime)
		{
			lblScore.text = "Score: " + score.ToString();
			lblDistance.text = "Distance: " + distance.ToString();
			lblGameTime.text = "Game Time: " + gameTime.ToString();
        }
	}
}

