using BenchmarkDotNet.Attributes;
using ListOfSorting;

namespace TestSortList
{
    [MemoryDiagnoser]
    [RankColumn]
    public class ListOfSortingBenchmark
    {
        const int N = 1000;
        private static readonly int[,] firstMatrix;
        private static readonly int[,] secondMatrix;
        private static int[,] serialResMatrix;
        private static int[,] parallelThreadResMatrix;
        private static int[,] parallelTaskResMatrix;
        private static readonly Random _rand = new Random();

        public static int[,] MatrixGenerator(int rows, int columns)
        {
            Random _rand = new Random();
            int[,] res = new int[rows, columns];
            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    res[i, j] = _rand.Next(50);
                }
            }
            return res;
        }

        static ListOfSortingBenchmark()
        {
            firstMatrix = MatrixGenerator(N, N);
            secondMatrix = MatrixGenerator(N, N);
            serialResMatrix = new int[N, N];
            parallelThreadResMatrix = new int[N, N];
        }

        [Benchmark]
        public void TestSerialMul()
        {
            ListOfSortingAlgs.Multiplication(firstMatrix, secondMatrix, serialResMatrix);
        }

        [Benchmark]
        public void TestParallelMulThread()
        {
            ListOfSortingAlgs.GoParallelMulThread(firstMatrix, secondMatrix, parallelThreadResMatrix);
        }

        [Benchmark]
        public void TestParallelMulTask()
        {
            ListOfSortingAlgs.GoParallelMulTask(firstMatrix, secondMatrix, parallelThreadResMatrix);
        }
    }
}
