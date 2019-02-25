using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Random number generator with<-10,10> range.
    /// </summary>
    public static class RandomNumberGenerator
    {
        const int MIN_VALUE = -10;
        const int MAX_VALUE = 10;
        static Random random = new Random();

        /// <summary>
        /// Print class name without namespaces.
        /// </summary>
        public static void GetClassName()
        {
            Console.WriteLine(nameof(RandomNumberGenerator));
        }

        /// <summary>
        /// Get next random number between [-10,10] range.
        /// </summary>
        /// <returns>random number</returns>
        public static int Next()
        {
            return random.Next(MIN_VALUE, MAX_VALUE);
        }
    }
}
