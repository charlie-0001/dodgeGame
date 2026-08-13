using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace dodgeGame
{
    internal class PlayerController : Controller
    {
        public PlayerController() : base([Keys.W, Keys.S, Keys.A, Keys.D], new Dictionary<Enum, Action>{}) { }

        public void BindPlayer(Player player)
        {
            Movements[Keys.A] = () =>
            {
                if (player.Velocity.X > -player.MaxSpeed)
                {
                    player.Velocity += new Vector2(-player.Speed, 0);
                }
            };

            Movements[Keys.D] = () =>
            {
                if (player.Velocity.X < player.MaxSpeed)
                {
                    player.Velocity += new Vector2(player.Speed, 0);
                }
            };

            Movements[Keys.W] = () =>
            {
                if (player.Velocity.Y > -player.MaxSpeed)
                {
                    player.Velocity += new Vector2(0, -player.Speed);
                }
            };

            Movements[Keys.S] = () =>
            {
                if (player.Velocity.Y < player.MaxSpeed)
                {
                    player.Velocity += new Vector2(0, player.Speed);
                }
            };
        }
    }
}

