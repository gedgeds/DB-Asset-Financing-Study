using System;
using System.Collections.Generic;

namespace AssetFinancingStudy
{
    public class PyramidManager
    {
        private readonly int[,] pyramid;

        public int[,] Pyramid => pyramid;

        public PyramidManager(int[,] pyramid)
        {
            this.pyramid = pyramid;
        }

        public void PreparePyramid()
        {
            RemoveInvalidPaths();
            CalculateSubPyramidsSums();
        }

        public int GetPyramidApex()
        {
            return Pyramid[0,0];
        }

        public List<int> GetPathSequence()
        {
            var pathSequence = new List<int>();
            var rows = Pyramid.GetLength(0);
            var j = 0;

            for (var i = 0; i < rows-1; i++)
            {
                var pathElement = Pyramid[i, j] - Math.Max(Pyramid[i + 1, j], Pyramid[i + 1, j + 1]);
                pathSequence.Add(pathElement);
                j = (Math.Max(Pyramid[i + 1, j], Pyramid[i + 1, j + 1]) == Pyramid[i + 1, j]) ? j : j + 1;
            }
            pathSequence.Add(Math.Max(Pyramid[rows - 1, j], Pyramid[rows - 1, j + 1]));

            return pathSequence;
        }

        private void RemoveInvalidPaths()
        {
            bool isCurrentRowEven, isCurrentNumberEven;

            var isApexEven = (Pyramid[0, 0] % 2 == 0) ? true : false;
            var rows = Pyramid.GetLength(0);

            for (var i = 0; i < rows; i++)
            {
                isCurrentRowEven = (i % 2 == 1) ? true : false;

                for (var j = 0; j <= i; j++)
                {
                    isCurrentNumberEven = (Pyramid[i, j] % 2 == 0) ? true : false;
                    Pyramid[i, j] = 
                        ((!isApexEven && isCurrentRowEven && isCurrentNumberEven) ||
                        (!isApexEven && !isCurrentRowEven && !isCurrentNumberEven) ||
                        (isApexEven && !isCurrentRowEven && isCurrentNumberEven) ||
                        (isApexEven && isCurrentRowEven && !isCurrentNumberEven)) ? Pyramid[i, j] : 0;
                }
            }
        }

        private void CalculateSubPyramidsSums()
        {
            var rows = Pyramid.GetLength(0);

            for (var i = rows - 2; i >= 0; i--)
            {
                for (var j = 0; j <= i; j++)
                {
                    Pyramid[i, j] = (Pyramid[i, j] == 0) ? Pyramid[i, j] : Pyramid[i, j] + Math.Max(Pyramid[i + 1, j], Pyramid[i + 1, j + 1]);
                }
            }
        }

    }
}
