// Сортировка подсчетом

int[] array = {-10, -5, -9, 0, 2, 5, 1, 0, 1};
int[] sortedArray = CountingSortExtendet(array);

//CountingSort(array);

Console.WriteLine(string.Join(", ", sortedArray));

void CountingSort(int[] inputArray)
{
    int[] counters = new int[10]; // массив повторений

    for(int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;// Тоже самое, что ниже 2 строки
        /*int ourNumber = inputArray[i];
        couters[ourNumber]++;*/
    }

    int index = 0;
    for(int i = 0; i < counters.Length; i++) // Обход всего массива повторений
    {
        for(int j = 0; j < counters[i]; j++) // Для вставки количества повторяющихся цифр
        {
            inputArray[index] = i; // Записываем в исходный массив повторения
            index++;
        }

    }
}

int[] CountingSortExtendet(int[] inputArray) // Рассширенный метод
{
    int max = inputArray.Max(); // Метод нахождение максимального элемента
    int min = inputArray.Min();

    int offset = - min;
    int[] sortedArray = new int[inputArray.Length];
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
            sortedArray[index] = i - offset; 
            index++;
        }
    }
    return sortedArray;
}