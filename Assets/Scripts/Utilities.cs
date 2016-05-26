using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    static class Utilities
    {
        /// <summary>
        /// Generates a number from on a normal distribution/Gaussian curve.
        /// </summary>
        /// <param name="mean">The number statistically most likely to be returned, with a deviation of 0</param>
        /// <param name="deviation">How quickly the statistical frequency of numbers diminish as they move away from the mean</param>
        /// <returns></returns>
        public static float GenerateRandomGaussianNumber(float mean, float deviation)
        {
            /*
            double v1, v2;
            float s;
            var random = new Random();
            do
            {
                v1 = 2.0d * random.NextDouble() - 1.0d;
                v2 = 2.0d * random.NextDouble() - 1.0d;
                s = (float) (v1 * v1 + v2 * v2);
            } while (s >= 1.0d || s == 0d);

            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

            return v1 * s;
            */

            float v1, v2, s;
            do
            {
                v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0f || s == 0f);

            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

            var result = (v1*s) * deviation + mean;
            return result;
        }
    }
}
