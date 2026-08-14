using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodgeGame.Entities
{
    internal class Enemy(Sprite sprite) : Entity(sprite, kills: true, isActive: true)
    {

    }
}
