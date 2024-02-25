using BenchmarkDotNet.Running;
using ListOfSorting;

namespace TestSortList
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[] { 1, 2, -1, 15, 1000, -5, 2432, 1 };
            //ListOfSortingAlgs.CountingSort(arr);
            //Console.WriteLine(string.Join(", ", arr));
            BenchmarkRunner.Run<ListOfSortingBenchmark>();
        }
    }
}
