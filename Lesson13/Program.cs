// Сортировка подсчетом

int[] array = {0, 2, 4, 10, 20, 5, 6, 1, 2};
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
    int[] sortedArray = new int[inputArray.Length];
    int[] counters = new int[max + 1];

    for(int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;
    }
    int index = 0;
    for(int i = 0; i < counters.Length; i++) 
    {
        for(int j = 0; j < counters[i]; j++) 
        {
            sortedArray[index] = i; 
            index++;
        }
    }
    return sortedArray;
}