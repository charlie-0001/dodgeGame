using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dodgeGame
{
    internal class EnemyController() : Controller([Actions.NOTHING], new Dictionary<Enum, Action> { })
    {
        private enum Actions
        {
            NOTHING
        }
    }
}
