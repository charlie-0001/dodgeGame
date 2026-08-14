using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace dodgeGame.Entities
{
    internal class Player(Sprite sprite, PlayerController controller, Vector2 velocity, int speed, int maxSpeed) : Entity(sprite, kills: false, isActive: true)
    {
        public Controller Controller { get; set; } = controller;
        public Vector2 Velocity { get; set; } = velocity;
        public int Speed { get; set; } = speed;
        public int MaxSpeed { get; set; } = maxSpeed;

        // public int Slip { get; set; } = slip;

        public override void Update(GameTime gameTime)
        {
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
            if (other is Enemy enemy)
            {
                Destroy();
            }
        }
    }
}
