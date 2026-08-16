using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodgeGame.Entities
{
    internal class Wall(Sprite sprite) : Entity(sprite, kills: false, isActive: true)
    {

    }
}
