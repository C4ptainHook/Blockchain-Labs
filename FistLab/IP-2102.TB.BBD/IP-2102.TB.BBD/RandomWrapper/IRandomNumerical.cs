using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace IP_2102.TB.BBD.RandomWrappers
{
    internal interface IRandomNumerical<T> where T : INumber<T>
    {
        int Next(T minValue, T maxValue);
        int Next(T maxValue);
    }
}
