using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace dodgeGame
{
    internal class Sprite(Texture2D texture, Vector2 position, Vector2 size)
    {
        public Texture2D Texture { get; set; } = texture;
        public Vector2 Position { get; set; } = position;
        public Vector2 Size { get; set; } = size;
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            }
        }
    }
}
