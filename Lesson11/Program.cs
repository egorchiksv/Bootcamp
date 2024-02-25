// Умножение матриц
const int N = 1000; // Размер матрицы
const int THREADS_NUMBERS = 10; // Задание количество потоков

int[,] serialMulRes = new int[N, N]; // Результат выполнения умножения матриц в однопотоке
int[,] threadMulRes = new int[N, N]; // Результат параллельного умножения матриц

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PreparePallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));


int[,] MatrixGenerator(int rows, int columns)
{
    Random _rang = new Random(); // Объявляем объект, который делает рандомные числа
    int[,] res = new int[rows, columns];
    for(int i = 0; i < res.GetLength(0); i++)
    {
        for(int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rang.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul (int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы"); // Исключение, в случае разных размеров матриц. Останавливает выполнение программы
    for(int i = 0; i < a.GetLength(0); i++)
    {
        for(int j = 0; j < b.GetLength(1); j++)
        {
            for(int k = 0; k > b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PreparePallelMatrixMul(int[,] a, int[,] b)
{
    if(a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");
    int eachTreadCalc = N / THREADS_NUMBERS; // Количество вычислений на каждый поток
    var threadsList = new List<Thread>(); // Список для хранения потоков. В List будет лежать поток
    for(int i = 0; i < THREADS_NUMBERS; i++)
    {
        int startPos = i * eachTreadCalc;
        int endPos = (i + 1) * eachTreadCalc;
        // если последний пото  
        if(i == THREADS_NUMBERS - 1) endPos = N;
        threadsList.Add(new Thread(() => PreparallelMatrixMul(a, b, startPos, endPos))); // Создание потока и делаем вызов нашей матрицы
        threadsList[i].Start(); // Запуск потока
    }
    for(int i = 0; i < THREADS_NUMBERS; i++)
    {
        threadsList[i].Join(); // Ждем окончание потоков, склеивает отдельный поток с главным потоком, т.е. отдельный поток, который мы запустили где-то отдельно
    }
}

void PreparallelMatrixMul (int[,] a, int[,] b, int startPos, int endPos)
{
    for(int i = startPos; i < endPos; i++)
    {
        for(int j = 0; j < b.GetLength(1); j++)
        {
            for(int k = 0; k > b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)
{
    bool res = true;
    for(int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for(int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i, j] == smatrix[i, j]);
        }
    }
    return res;
}