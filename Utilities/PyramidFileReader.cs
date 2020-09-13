using System.IO;

namespace AssetFinancingStudy
{
    public static class PyramidFileReader
    {
        private const char DELIMITER = ' ';

        /* 
         * Manages pyramid data extraction from file and returns the pyramid
         */
        public static int[,] ReadPyramid(string filename)
        {
            StreamReader r = new StreamReader(filename);

            var rows = CountLines(r);
            var pyramid = FillMatrix(rows, r);
            r.Close();

            return pyramid;
        }

        /* 
         * Returns the amount of lines in the file
         */
        private static int CountLines(StreamReader r)
        {
            int lines = 0;

            while ((_ = r.ReadLine()) != null)
            {
                lines++;
            }

            return lines;
        }

        /* 
         * Reads the file and returns pyramid 
         * structure in matrix (2D array) format
         */
        private static int[,] FillMatrix(int matrixSize, StreamReader r)
        {
            string row;
            string[] rowElements;

            int[,] matrix = new int[matrixSize, matrixSize];

            r.BaseStream.Seek(0, SeekOrigin.Begin);

            int j = 0;
            while ((row = r.ReadLine()) != null)
            {
                rowElements = row.Split(DELIMITER);
                for (int i = 0; i < rowElements.Length; i++)
                {
                    matrix[j, i] = int.Parse(rowElements[i]);
                }
                j++;
            }

            return matrix;
        }

    }
}
