using dodgeGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace dodgeGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Entity> entities = new List<Entity>();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D enemyTexture = Content.Load<Texture2D>("enemy1");
            Sprite enemySprite = new Sprite(enemyTexture, new Vector2(100, 100), new Vector2(100, 100));

            EnemyController enemyController = new EnemyController();
            Enemy enemy = new Enemy(enemySprite);
            entities.Add(enemy);

            Texture2D playerTexture = Content.Load<Texture2D>("player");
            Sprite playerSprite = new Sprite(playerTexture, Vector2.Zero, new Vector2(50, 50));

            PlayerController playerController = new PlayerController();
            Player player = new Player(playerSprite, playerController, Vector2.Zero, 20, 300);
            playerController.BindPlayer(player);
            entities.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }

            for (int i = 0; i < entities.Count; i++)
            {
                for (int j = i + 1; j < entities.Count; j++)
                {
                    Entity a = entities[i];
                    Entity b = entities[j];

                    if (a.Sprite.Rect.Intersects(b.Sprite.Rect))
                    {
                        a.OnCollision(b);
                        b.OnCollision(a);
                    }
                }
            }

            entities.RemoveAll(e => !e.IsActive);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (Entity entity in entities)
            {
                _spriteBatch.Draw(entity.Sprite.Texture, entity.Sprite.Rect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
