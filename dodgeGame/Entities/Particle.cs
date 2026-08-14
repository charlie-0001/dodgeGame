using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace dodgeGame.Entities
{
    internal class Particle(Sprite sprite, float duration, bool flipbookEnabled = false, float flipTime = 0, List<Sprite> flipSprites = null)
        : Entity(sprite, kills: false, isActive: true)
    {
        float Duration { get; set; } = duration;
        bool FlipbookEnabled { get; set; } = flipbookEnabled;
        float FlipTime { get; set; } = flipTime;
        List<Sprite> FlipSprites { get; set; } = flipSprites;
        public override void Update(GameTime gameTime)
        {
            Duration -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Duration <= 0)
            {
                Destroy();
            }

            // add flipbook logic later
        }
        public override void Destroy()
        {
            IsActive = false;
        }
    }

}
