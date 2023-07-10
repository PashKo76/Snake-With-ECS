using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class Entity
    {
        public PositionComponent? position;
        public MovementComponent? movement;
        public VisibilityComponent? visibility;
        static public Entity CreateTailSegment()
        {
            return new()
            {
                movement = new() { Dx = 0, Dy = 0 },
                position = new() { X = -1, Y = -1 },
                visibility = new() { Icon = '#' }
            };
        }
        static public Entity CreateApple()
        {
            return new()
            {
                position = new() { X = -1, Y = -1 },
                visibility = new() { Icon = '$' }
            };
        }
        static public Entity CreateHead()
        {
            return new()
            {
                movement = new() { Dx = 1, Dy = 0 },
                position = new() { X = Render.Width / 2, Y = Render.Height / 2 },
                visibility = new() { Icon = '@' }
            };
        }
    }
}
