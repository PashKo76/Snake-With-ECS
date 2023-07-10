using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class Heap
    {
        public static (int, int) Calc(PositionComponent from, PositionComponent to)
        {
            return (
                to.X - from.X,
                to.Y - from.Y
                );
        }
    }
}
