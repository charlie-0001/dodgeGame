using dodgeGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace dodgeGame
{
    public class Game1 : Game
    {
        public static ContentManager ContentService { get; private set; }
        internal static List<Entity> Entities { get; private set; } = new List<Entity>();
        internal static Player Player { get; private set; }

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Sprite explosionTexture;
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
            ContentService = Content;
            
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy1");
            Sprite enemySprite = new Sprite(enemyTexture, new Vector2(100, 100), new Vector2(100, 100));

            EnemyController enemyController = new EnemyController();
            Enemy enemy = new Enemy(enemySprite);
            Entities.Add(enemy);

            Texture2D playerTexture = Content.Load<Texture2D>("player");
            Sprite playerSprite = new Sprite(playerTexture, Vector2.Zero, new Vector2(50, 50));

            Texture2D playerDeathTexture = Content.Load<Texture2D>("explosion");

            PlayerController playerController = new PlayerController();
            Player player = new Player(playerSprite, playerController, Vector2.Zero, 20, 300, playerDeathTexture);
            Player = player;
            playerController.BindPlayer(player);
            Entities.Add(player);

            Texture2D wallTexture = Content.Load<Texture2D>("wall");
            Sprite wallSprite = new Sprite(wallTexture, new Vector2(150, 150), new Vector2(200, 200));
            Wall wall = new Wall(wallSprite);
            Entities.Add(wall);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Entity entity in Entities)
            {
                entity.Update(gameTime);
            }

            for (int i = 0; i < Entities.Count; i++)
            {
                for (int j = i + 1; j < Entities.Count; j++)
                {
                    Entity a = Entities[i];
                    Entity b = Entities[j];

                    if (a.Sprite.Rect.Intersects(b.Sprite.Rect))
                    {
                        a.OnCollision(b);
                        b.OnCollision(a);
                    }
                }
            }

            Entities.RemoveAll(e => !e.IsActive);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (Entity entity in Entities)
            {
                _spriteBatch.Draw(entity.Sprite.Texture, entity.Sprite.Rect, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
