// Сортировка подсчетом

int[] array = {3, 2, 1, 5, 9};

CountingSort(array);

Console.WriteLine(string.Join(", ", array));

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