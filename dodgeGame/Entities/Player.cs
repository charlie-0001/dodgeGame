using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace dodgeGame.Entities
{
    internal class Player(Sprite sprite, PlayerController controller, Vector2 velocity, int speed, int maxSpeed, Texture2D onDeathTexture = null) : Entity(sprite, kills: false, isActive: true)
    {
        public Controller Controller { get; set; } = controller;
        public Vector2 Velocity { get; set; } = velocity;
        public int Speed { get; set; } = speed;
        public int MaxSpeed { get; set; } = maxSpeed;
        public Texture2D onDeathTexture { get; set; } = onDeathTexture;
        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        Direction direction { get; set; } = Direction.DOWN; 

        // public int Slip { get; set; } = slip;

        public override void Update(GameTime gameTime)
        {
            // collisions
            bool result;
            Raycast newRaycast = new Raycast(RaycastDirection.UP, Sprite.Rect.Height/2 + 1, Sprite.Rect.Width, 
                new Vector2(Sprite.Position.X + Sprite.Rect.Width/2, Sprite.Position.Y + Sprite.Rect.Height/2));
            foreach (Entity entity in Game1.Entities)
            {
                if (!(entity is Wall)) { continue; }
                result = newRaycast.RaycastResult(entity);
                if (result == true)
                {
                    Debug.WriteLine("Raycast collision detected!");
                }
            }

            // movement
            Velocity *= 0.85f;

            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                if (!Controller.Movements.ContainsKey(key)) { continue; }
                Controller.Movements[key]?.Invoke();
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Position += Velocity * deltaTime;
        }

        public override void OnCollision(Entity other)
        {
            switch (other)
            {
                case (Enemy enemy):
                    if (onDeathTexture != null && enemy.Kills)
                    {
                        Particle explosion = new Particle(new Sprite(onDeathTexture, Sprite.Position, Sprite.Size), 1);
                        Game1.Entities.Add(explosion);
                        Destroy();
                    }
                    break;
                case (Wall wall):
                    // add logic later
                    break;
            }
        }
    }
}
