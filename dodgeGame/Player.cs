using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace dodgeGame
{
    internal class Player(Sprite sprite, PlayerController controller, Vector2 velocity, int speed, int maxSpeed) : Entity(sprite, controller)
    {
        public Vector2 Velocity { get; set; } = velocity;
        public int Speed { get; set; } = speed;
        public int MaxSpeed { get; set; } = maxSpeed;

        // public int Slip { get; set; } = slip;

        public void Update(GameTime gameTime)
        {
            Debug.WriteLine("Working!");
            Velocity *= 0.9f;

            foreach (Keys key in Keyboard.GetState().GetPressedKeys())
            {
                controller.Movements[key]?.Invoke();
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Position += Velocity * deltaTime;
        }
    }
}
