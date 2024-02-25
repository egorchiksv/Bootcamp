namespace ListOfSorting
{
    public class ListOfSortingAlgs
    {
        const int THREADS_NUMBER = 8;
        const int N = 1000;

        public static void Multiplication(int[,] a, int[,] b, int[,] r)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
        }

        public static void ParallelMultiplying(int[,] firstMatrix, int[,] secondMatrix, int[,] resultMatrix, int startPos, int endPos)
        {
            for (int i = startPos; i < endPos; i++)
                for (int j = 0; j < N; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < N; k++)
                    {
                        resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
        }

        public static void GoParallelMulThread(int[,] a, int[,] b, int[,] r)
        {
            int eachThreadCalc = N / THREADS_NUMBER;
            var threadsParall = new List<Thread>();
            for (int i = 0; i < THREADS_NUMBER; i++)
            {
                int startPos = i * eachThreadCalc;
                int endPos = i == THREADS_NUMBER - 1 ? N : (i + 1) * eachThreadCalc;
                threadsParall.Add(new Thread(() => ParallelMultiplying(a, b, r, startPos, endPos)));
                threadsParall[i].Start();
            }

            for (int i = 0; i < THREADS_NUMBER; i++)
            {
                threadsParall[i].Join();
            }
        }

        public static void GoParallelMulTask(int[,] a, int[,] b, int[,] r)
        {
            int eachThreadCalc = N / THREADS_NUMBER;
            var tasksParall = new List<Task>();
            for (int i = 0; i < THREADS_NUMBER; i++)
            {
                int startPos = i * eachThreadCalc;
                int endPos = i == THREADS_NUMBER - 1 ? N : (i + 1) * eachThreadCalc;
                tasksParall.Add(new Task(() => ParallelMultiplying(a, b, r, startPos, endPos)));
                tasksParall[i].Start();
            }
            Task.WaitAll(tasksParall.ToArray());
        }


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
    }
}

