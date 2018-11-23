using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Engine
{
    public class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
        public static int NumberBetween(int minVal, int maxVal)
        {
            byte[] randomNumber = new byte[1];
            _generator.GetBytes(randomNumber);
            double val = Convert.ToDouble(randomNumber[0]);
            double mult = Math.Max(0, (val / 255d) - 0.00000000001d);
            int range = maxVal - minVal + 1;
            double valInRange = Math.Floor(mult * range);
            return (int)(minVal + valInRange);
        }
    }
}
