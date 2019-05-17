using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_TransportCompany.Extensions
{
    public static class ColorHelper
    {
        private static readonly uint ColorBase = 0x00444444;
        private static readonly uint ColorDiff = 0x00888888;
        private static readonly int UniqueColors = 100;

        public static string GetColorByID(int id)
        {
            var factor = (id % UniqueColors) / (float)UniqueColors;
            var result = ColorBase + (uint)(ColorDiff * factor);
            return string.Format("#{0:X6}", result);
        }
    }
}
