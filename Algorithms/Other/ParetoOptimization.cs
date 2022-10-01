using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Other
{
    /// <summary>
    /// Almost all real complex decision-making task is described by more than one criterion.
    /// Therefore, the methods of multicriteria optimization are important. For a wide range
    /// of tasks multicriteria optimization, described by some axioms of "reasonable"
    /// behavior in the process of choosing from a set of possible solutions X, each set of
    /// selected solutions Sel X should be contained in a set optimal for Pareto.
    /// </summary>
    public class ParetoOptimization
    {
        /// <summary>
        /// Performs decision optimizations by using Paretor's optimization algorithm.
        /// </summary>
        /// <param name="matrix">Contains a collection of the criterias sets.</param>
        public void Optimize(List<List<decimal>> matrix)
        {
            int i = 0;
            while (i < matrix.Count)
            {
                for (int j = i + 1; j < matrix.Count; j++)
                {
                    decimal directParwiseDifference = GetMinimalPairwiseDifference(matrix[i], matrix[j]);
                    decimal indirectParwiseDifference = GetMinimalPairwiseDifference(matrix[j], matrix[i]);
                    /*
                     * in case all criteria of one set are larger that the criteria of another, this
                     * decision is not optimal and it has to be removed
                    */
                    if (directParwiseDifference >= 0)
                    {
                        matrix.RemoveAt(j);
                        i--;
                        break;
                    }
                    else if (indirectParwiseDifference >= 0)
                    {
                        matrix.RemoveAt(i);
                        i--;
                        break;
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Calculates the smallest difference between criteria of input decisions.
        /// </summary>
        /// <param name="arr1">Criterias of the first decision.</param>
        /// <param name="arr2">Criterias of the second decision.</param>
        /// <returns>Values that represent the smallest difference between criteria of input decisions.</returns>
        private decimal GetMinimalPairwiseDifference(List<decimal> arr1, List<decimal> arr2)
        {
            decimal min = decimal.MaxValue;
            if (arr1.Count != arr2.Count)
            {
                return min;
            }

            for (int i = 0; i < arr1.Count; i++)
            {
                decimal difference = arr1[i] - arr2[i];
                if (min > difference)
                {
                    min = difference;
                }
            }

            return min;
        }
    }
}
