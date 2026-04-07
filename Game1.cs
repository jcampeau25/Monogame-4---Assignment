using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Monogame_4___Assignment
{
    
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Rectangle window;

        Rectangle shipRect;

        Texture2D starTexture, shipTexture;
        
        List<Star> closeStars, farStars;

        Random generator;

        KeyboardState keyboardState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();


            generator = new Random();

            shipRect = new Rectangle(50, 250, 150, 40);

            base.Initialize();

            closeStars = new List<Star>();
            for (int i = 0; i < 150; i++)
            {
                int x, y;
                x = generator.Next(window.Width);
                y = generator.Next(window.Height);
                Rectangle star = new Rectangle(x, y, 3, 3);
                closeStars.Add(new Star(starTexture, star, new  Vector2(-3, 0), Color.White));
            }

            farStars = new List<Star>();
            for (int i = 0; i < 75; i ++)
            {
                int x, y;
                x = generator.Next(window.Width);
                y = generator.Next(window.Height);
                Rectangle star = new Rectangle (x, y, 2, 2);
                farStars.Add(new Star(starTexture, star, new Vector2 (-2, 0), Color.Gray));
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            starTexture = Content.Load<Texture2D>("Images/White Circle");
            shipTexture = Content.Load<Texture2D>("Images/enterprise");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();

            foreach (Star star in closeStars)
            {
                star.Update();

                if (star.Location.Right < 0)
                    star.X = window.Width;
            }

            foreach (Star star in farStars)
            {
                star.Update();

                if (star.Location.Right < 0)
                    star.X = window.Width;
            }


            if (keyboardState.IsKeyDown(Keys.Down))
            {
                if (shipRect.Bottom < window.Height)
                    shipRect.Offset(0, 4);

            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                if (shipRect.Top > 0)
                    shipRect.Offset(0, -4);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                foreach (Star star in closeStars)
                {
                    star.X += 1;
                }

                foreach (Star star in farStars)
                {
                    star.X += 1;
                }
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                foreach (Star star in closeStars)
                {
                    star.X -= 1;
                }

                foreach (Star star in farStars)
                {
                    star.X -= 1;
                }
            }
            base.Update(gameTime);

            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();


            foreach (var star in closeStars)
                star.Draw(_spriteBatch);

            foreach (var star in farStars)
                star.Draw(_spriteBatch);

            _spriteBatch.Draw(shipTexture, shipRect, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
