using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class PositionComponent
    {
        public int X;
        public int Y;
        static public bool operator !=(PositionComponent f, PositionComponent s)
        {
            return !(f == s);
        }
        static public bool operator ==(PositionComponent f, PositionComponent s)
        {
            return f.X == s.X && f.Y == s.Y;
        }
    }
}
