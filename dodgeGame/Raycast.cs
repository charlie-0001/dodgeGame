using dodgeGame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace dodgeGame
{
    enum RaycastDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    internal class Raycast(RaycastDirection direction, int length, int width, Vector2 position)
    {
        /*
         * This will place an invisible Rect in front of an object and if it intersects with a wall it will return True
        */
        public RaycastDirection Direction { get; set; } = direction;
        public int Length { get; set; } = length;
        public int Width { get; set; } = width;
        public Vector2 Position { get; set; } = position;
        public Rectangle Rect
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, 1  /* width */, 100 /* length */); }
            set { }
        } 



        public bool RaycastResult(Entity other)
        {
            switch (Direction)
            {
                case RaycastDirection.UP:
                    Rect = new Rectangle((int)Position.X, (int)Position.Y, 1, -Length);
                    if (Rect.Intersects(other.Sprite.Rect)) { return true; } else { return false; }

                case RaycastDirection.DOWN: // FINISH THESE.
                    return false;

                case RaycastDirection.LEFT: // Also, make sure the raycast comes from the center of the player
                    return false;

                case RaycastDirection.RIGHT:
                    return false;

                default:
                    return false;
            }
        }
    }
}
