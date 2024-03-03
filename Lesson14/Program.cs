// Сортировка подсчетом
const int THREADS_NUMBER = 10; // Число потоков
const int N = 100000; // Размер массива
object locker = new object(); // Объект для создания блокировки при синхронизации потоков

//int[] array = {-10, -5, -9, 0, 2, 5, 1, 0, 1};
//int[] sortedArray = CountingSortExtendet(array);
Random rand = new Random();
int[] resSerial = new int[N].Select(r => rand.Next(0, 5)).ToArray();// Каждый элемент получается через Random(0, 5), вставляется в переменную r, переменная r вставляется в массив arr. Так заполняется массив размерностью N
int[] resParalel = new int[N];

Array.Copy(resSerial, resParalel, N); // Копирование N элементов массива resSerial в resParalel

//Console.WriteLine(string.Join(", ", resSerial));

CountingSortExtendet(resSerial);
PreparaParallelCountingSort(resParalel);
Console.WriteLine(EqualityMatrix(resSerial, resParalel));

//Console.WriteLine(string.Join(", ", resSerial));
//Console.WriteLine(string.Join(", ", resParalel));



void PreparaParallelCountingSort(int[] inputArray)
{
    int max = inputArray.Max();
    int min = inputArray.Min();

    int offset = - min;
    int[] counters = new int[max + offset + 1];

    int eachThreadCalc = N / THREADS_NUMBER; // Вычисляем количество вычислений, т.е. делим количество элемнтов на количество потоков
    var threadsParall = new List<Thread>(); // Задаем список-коллекция, в который мы можем динамически вставлять и удалять элементы. Список в нашем случае обычный массив

    for(int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        if(i == THREADS_NUMBER - 1) endPos = N;
        threadsParall.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
        threadsParall[i].Start();// Запустили поток
    }

    foreach(var thread in threadsParall)
    {
        thread.Join();// Ждем выполенние
    }

    int index = 0;
    for(int i = 0; i < counters.Length; i++) 
    {
        for(int j = 0; j < counters[i]; j++) 
        {
           inputArray[index] = i - offset; 
           index++;
        }
    }
}


void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
    for(int i = startPos; i < endPos; i++)
    {
        lock(locker) // Пока пишет один поток этот поток ставит на locker блокировку, другой записать не может. locker ставит блокировку, только когда заходит в него блокировку. locker ставить блокировку на команду в скобках фигурных. Даннаы метод применяестя для сихронизации вычислений в потоках
        {
            counters[inputArray[i] + offset]++;// Сама гонка алгоритмов
        }
    }
}

void CountingSortExtendet(int[] inputArray) // Рассширенный метод
{
    int max = inputArray.Max(); // Метод нахождение максимального элемента
    int min = inputArray.Min();

    int offset = - min;
    int[] counters = new int[max + offset + 1];

    for(int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }
    
    int index = 0;
    for(int i = 0; i < counters.Length; i++) 
    {
        for(int j = 0; j < counters[i]; j++) 
        {
            inputArray[index] = i - offset; 
            index++;
        }
    }
}

bool EqualityMatrix(int[] fmatrix, int[] smatrix)
{
    bool res = true;

    for(int i = 0; i < N; i++)
    {
        res = res && (fmatrix[i] == smatrix[i]);
    }

    return res;
}