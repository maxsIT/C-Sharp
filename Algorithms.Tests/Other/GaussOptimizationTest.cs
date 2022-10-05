using Algorithms.Other;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests.Other
{
    public static class GaussOptimizationTest
    {
        [Test]
        public static void Verify_Gauss_Optimization()
        {
            // Arrange
            var gaussOptimization = new GaussOptimization();

            // Declaration of the constants that are used in the function
            var coefficients = new List<double> { 0.3, 0.6, 2.6, 0.3, 0.2, 1.4 };

            // Description of the function
            var func = (double x1, double x2) =>
            {
                if (x1 > 1 || x1 < 0 || x2 > 1 || x2 < 0)
                {
                    return 0;
                }

                return coefficients[0] + coefficients[1] * x1 + coefficients[2] * x2 + coefficients[3] * x1 * x2 +
                    coefficients[4] * x1 * x1 + coefficients[5] * x2 * x2;
            };

            // The parameter that identifies how much step size will be decreased each iteration
            double n = 2.4;

            // Default values of x1 and x2. These values will be used for the calculation of the next
            // coordinates by Gauss optimization method
            double x1 = 0.5, x2 = 0.5;

            // Default optimization step
            double step = 0.5;

            // This value is used to control the accuracy of the optimization. In case if the error is less
            // than eps, optimization will be stopped
            double eps = Math.Pow(0.1, 10);

            // Act
            gaussOptimization.Optimize(func, n, step, eps, ref x1, ref x2);

            // Assert
            Assert.AreEqual(0.85714285709636828, x1);
            Assert.AreEqual(1, x2);
        }
    }
}
