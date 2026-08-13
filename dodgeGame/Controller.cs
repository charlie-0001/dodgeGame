using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodgeGame
{
    abstract internal class Controller(List<Enum> actions, Dictionary<Enum, Action> movements)
    {
        public List<Enum> Actions { get; set; } = actions;
        public Dictionary<Enum, Action> Movements { get; set; } = movements;
    }
}
