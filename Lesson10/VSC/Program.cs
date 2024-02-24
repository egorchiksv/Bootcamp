/* Гонка между алгоритмами.
Дан массив 1000 элементов. Заполнены от 0 до 100 000

Сортировка пузырьком:
1. Время выполнения: О (n^2) 1000 * 1000 = 1 е^6
2. Память: О(n)
3. Количество операций: 1000 * 1000 ~ 1 000 000

Быстрая сортировка:
1. Время выполнения: О(n*log n) 1000 * log 1000 = 6907
2. Память: О(n)
3. Количество операций: 1000 * log 1000 ~ 9965

Сортировка выбором:
1. Время выполения: О(n^2/2)
2. Память: О(n+1)
3. Количество операций: 1000 * 1000 / 2 ~ 500 000

Сортировка подсчетом:
1. Время выполения: О(n+k), где k - количество уникальных элементов
2. Память: О(n+k)
3. Количество операций: ~ 2 000

Самый быстрый получается быстрая сортировка, т.к. хоть сортировка подсчетом имеет меньшее количество опертаций, но за счет выделения большого количества памяти уходит много времени
на само выдление памяти.*/

const int THREADS_NUMBER = 4; //число потоков
const int N = 100000; //размер массива
object lock_object = new object();

//сортировка подсчетом
//int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
//int[] sortedArray = CountingSortExtended(array);
Random rand = new Random();
int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray();
int[] resParallel = new int[N];

Array.Copy(resSerial, resParallel, N);

//Console.WriteLine(string.Join(", ", resSerial));

CountingSortExtended(resSerial);
PrepareParallelCountingSort(resParallel);
Console.WriteLine(EqualityMatrix(resSerial, resParallel));

//Console.WriteLine(string.Join(", ", resSerial));
//Console.WriteLine(string.Join(", ", resParallel));



void PrepareParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];

    int eachThreadCalc = N / THREADS_NUMBER;
    var threadsParall = new List<Thread>();

    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsParall.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParall[i].Start();
    }

    foreach(var thread in threadsParall)
    {
        thread.Join();
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}


void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        lock (lock_object)
        {
            counters[inputArray[i] + offset]++;
        }
    }
}

void CountingSortExtended(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = -min;
    int[] counters = new int[max + offset + 1];


    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++;
        }
    }
}

bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;

    for (int i = 0; i < N; i++)
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }

    return res;
}