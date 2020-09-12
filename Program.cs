using System;

namespace AssetFinancingStudy
{
    class Program
    {
        private const string FILE_PATH = "C:/Users/Gediminas/source/repos/AssetFinancingStudy/DataSets/TestData.txt";
        private const string SEPARATOR = ", ";

        static void Main()
        {
            var pyramid = FileReader.ReadPyramidNumbers(FILE_PATH);
            var pyramidManager = new PyramidManager(pyramid);

            pyramidManager.PreparePyramid();
            var pathSequence = pyramidManager.GetPathSequence();
            var path = string.Join(SEPARATOR, pathSequence);
            
            Console.WriteLine("Max sum: " + pyramidManager.GetPyramidApex());
            Console.WriteLine("Path: " + path.ToString());
        }
    }
}
