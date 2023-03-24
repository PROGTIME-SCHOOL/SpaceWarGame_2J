using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;    // LIST

using Microsoft.Xna.Framework.Content;   // для тетушки Контент 0_0

using SpaceWarGame_2J.Classes;

namespace SpaceWarGame_2J;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;         // художник 

    private Player player;
    private Space space;

    private List<Asteroid> asteroids = new List<Asteroid>();
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 600;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        player = new Player();
        space = new Space();
        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        player.LoadContent(Content);
        space.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update(Content);
        space.Update();

        if (asteroids.Count < 10)
        {
            Random random = new Random();

            int x = random.Next(0, 750);
            int y = -random.Next(0, 550);

            Vector2 position = new Vector2(x, y);

            Asteroid asteroid = new Asteroid(position);
            asteroid.LoadContent(Content);

            asteroids.Add(asteroid);
        }


        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[i].Update();

            // астеройд улетел
            if (asteroids[i].Position.Y > 600)
            {
                asteroids.RemoveAt(i);  // удаление по индексу
            }

            // астеройд столкнулся с игроком
            if (player.Collision.Intersects(asteroids[i].Collision))
            {
                asteroids.Remove(asteroids[i]);  // удаление по reference
            }

            // астеройд столкнулся с пулькой
            for (int k = 0; k < player.BulletList.Count; k++)
            {
                if (asteroids[i].Collision.Intersects(player.BulletList[k].Collision))
                {
                    asteroids.RemoveAt(i);
                    i--;

                    player.BulletList.RemoveAt(k);
                    k--;
                }
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        space.Draw(_spriteBatch);
        player.Draw(_spriteBatch);


        for (int i = 0; i < asteroids.Count; i++)
        {
            asteroids[i].Draw(_spriteBatch);
        }
        

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}