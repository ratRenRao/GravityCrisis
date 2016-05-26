using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine.Assertions;

namespace Assets.Scripts
{
    class Tests
    {
        public void Run()
        {
            CheckRandomNormalizedNumbers();
        }

        private void CheckRandomNormalizedNumbers()
        {
            float sum = 0f;
            int itterations = 10000;

            for (int i = 0; i < itterations; i++)
            {
                var nextFloat = Utilities.GenerateRandomGaussianNumber(5, 1);
                sum += nextFloat;
            }

            var mean = sum/itterations;

            Assert.IsTrue(Math.Abs(mean) < 5.02);
        }
    }
}
