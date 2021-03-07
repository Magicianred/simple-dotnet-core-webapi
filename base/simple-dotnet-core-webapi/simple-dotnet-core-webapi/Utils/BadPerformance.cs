using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace simple_dotnet_core_webapi.Utils
{
    public static class BadPerformance
    {
        public static int BOOST_BAD_PERFORMANCE = 50;

        public static void MakeDelay(int minValue, int maxValue, int multiplyingFactor)
        {
            Random r = new Random();
            var delay = r.Next(minValue, maxValue) * multiplyingFactor * BOOST_BAD_PERFORMANCE;
            Thread.Sleep(delay);
        }
    }
}
