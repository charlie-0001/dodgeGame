using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodgeGame
{
    abstract internal class Entity(Sprite sprite, Controller controller)
    {
        public Sprite sprite { get; set; } = sprite;
        public Controller controller { get; set; } = controller;

        public virtual void Update()
        {

        }
    }
}
