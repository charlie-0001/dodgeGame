using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace dodgeGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        bool spacePressed;
        MovingSprite sprite;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D texture = Content.Load<Texture2D>("player");
            sprite = new MovingSprite(texture, Vector2.Zero, new Vector2(50, 50), new Vector2(0, 0));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!spacePressed && Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                spacePressed = true;
                Debug.WriteLine("Space was pressed.");
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                spacePressed = false;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Debug.WriteLine("LMB pressed.");
                Debug.WriteLine(Mouse.GetState().X + ',' + Mouse.GetState().Y);
            }

            sprite.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite.Texture, sprite.Rect, Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
