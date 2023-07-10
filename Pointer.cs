using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_With_ECS
{
    internal class Pointer<T> //Ersatz pointer from c++
    {
        public T Value;
        public Pointer(T Value)
        {
            this.Value = Value;
        }
        public Pointer<T> Clone()
        {
            return new Pointer<T>(Value);
        }
    }
}
