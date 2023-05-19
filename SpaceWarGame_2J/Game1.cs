using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;    // LIST

using Microsoft.Xna.Framework.Content;   // для тетушки Контент 0_0

using SpaceWarGame_2J.Classes;
using SpaceWarGame_2J.Classes.Elements;

namespace SpaceWarGame_2J;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;         // художник

    public static GameMode gameMode = GameMode.End;

    private Player player;
    private Space space;

    private List<Asteroid> asteroids = new List<Asteroid>();

    private List<Explosion> explosions = new List<Explosion>();

    private Label label = new Label("SpaceWarGame v 1.0", new Vector2(10, 570), Color.White);

    private Menu menu = new Menu();

    private HUD hud = new HUD();
    private ScreenEnd screenEnd = new ScreenEnd();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 800;
        _graphics.PreferredBackBufferHeight = 600;

        //_graphics.IsFullScreen = true;
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

        label.LoadContent(Content);

        menu.LoadContent(Content);

        hud.LoadContent(Content);
        screenEnd.LoadContent(Content);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here


        


        switch (gameMode)
        {
            case GameMode.Menu:
                space.Update();
                menu.Update(this);
                break;

            case GameMode.Play:
                player.Update(Content);
                space.Update();
                UpdateExplosions();
                UpdateAsteroids();
                UpdateCollision();
                hud.Update();

                if (!player.IsVisible)
                {
                    gameMode = GameMode.End;
                    screenEnd.SetScore(player.Score);   // на другой экран передаем score
                }

                break;

            case GameMode.Pause:
                break;

            case GameMode.End:
                screenEnd.Update();
                break;

            case GameMode.Exit:
                Exit();
                break;
        }


        


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Orange);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        switch (gameMode)
        {
            case GameMode.Menu:
                space.Draw(_spriteBatch);
                menu.Draw(_spriteBatch);
                break;

            case GameMode.Play:
                space.Draw(_spriteBatch);
                player.Draw(_spriteBatch);

                for (int i = 0; i < asteroids.Count; i++)
                {
                    asteroids[i].Draw(_spriteBatch);
                }

                for (int i = 0; i < explosions.Count; i++)
                {
                    explosions[i].Draw(_spriteBatch);
                }

                label.Draw(_spriteBatch);

                hud.Draw(_spriteBatch);

                break;

            case GameMode.Pause:
                break;

            case GameMode.End:

                space.Draw(_spriteBatch);
                screenEnd.Draw(_spriteBatch);

                break;
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }


    private void UpdateCollision()
    {
        // COLLISION
        for (int i = 0; i < asteroids.Count; i++)
        {
            // астеройд столкнулся с игроком
            if (player.Collision.Intersects(asteroids[i].Collision))
            {
                Explosion explosion = new Explosion(asteroids[i].Position);
                explosion.LoadContent(Content);
                explosions.Add(explosion);

                asteroids[i].IsVisible = false;

                player.Damage();
                hud.UpdateUI(player.Health);
            }

            // астеройд столкнулся с пулькой
            for (int k = 0; k < player.BulletList.Count; k++)
            {
                if (asteroids[i].Collision.Intersects(player.BulletList[k].Collision))
                {
                    Explosion explosion = new Explosion(asteroids[i].Position);
                    explosion.LoadContent(Content);
                    explosions.Add(explosion);

                    asteroids[i].IsVisible = false;

                    player.BulletList.RemoveAt(k);

                    player.Score++;
                    //k--;
                }
            }
        }
    }

    private void UpdateExplosions()
    {
        // explosions
        for (int i = 0; i < explosions.Count; i++)
        {
            explosions[i].Update();

            if (explosions[i].IsVisible == false)
            {
                explosions.RemoveAt(i);
                i--;
            }
        }
    }

    private void UpdateAsteroids()
    {
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
                asteroids[i].IsVisible = false;
            }

            if (asteroids[i].IsVisible == false)
            {
                asteroids.RemoveAt(i);
                i--;
            }
        }
    }

    public void Reset()
    {
        player.Reset();
        hud.UpdateUI(player.Health);
        asteroids.Clear();
        explosions.Clear();
    }
}