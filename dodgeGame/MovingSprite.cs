using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace dodgeGame
{
    internal class MovingSprite : Sprite
    {
        public Vector2 Velocity { get; set; }
        public MovingSprite(Texture2D texture, Vector2 position, Vector2 size, Vector2 velocity) : base(texture, position, size)
        {
            Velocity = velocity;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity * deltaTime;
        }
    }
}
