using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace dodgeGame.Entities
{
    abstract internal class Entity(Sprite sprite, bool kills, bool isActive)
    {
        public Sprite Sprite { get; set; } = sprite;
        public bool Kills { get; set; } = kills;
        public bool IsActive { get; set; } = isActive;


        public virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void OnCollision(Entity other)
        {

        }

        public virtual void Destroy()
        {
            IsActive = false;
        }
    }
}
