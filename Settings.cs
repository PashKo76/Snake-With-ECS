using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal record Settings
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public int ApplesCount { get; init; }
        public int TimeToReaction { get; init; }
    }
}
