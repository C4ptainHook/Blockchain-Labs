using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_2102.TB.BBD.RandomWrappers
{
    internal class RandomWrapper : IRandomNumerical<int>
    {
        private readonly Random _random = new();
        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }
    }
}
