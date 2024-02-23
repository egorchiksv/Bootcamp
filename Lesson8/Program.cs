/* Быстрая сортировка О(log2(n)) 


array = [7, 4, 1, 3, 5, 2, 8, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6] + [7] + [8]
pivot 7 
[4, 1, 3, 5, 2, 8, 6] + [7] + [8]

array = [4, 1, 3, 5, 2, 6] = [] + [1] + [2] + [3] + [] + [4] + [] + [5] + [6]
pivot = 4
[1, 3, 2] + [4] + [5, 6]

array = [1, 3, 2] = [] + [1] + [2] + [3] + []
pivot = 1

[] + [1] + [3, 2]

array = [3, 2]
pivot = 3
[2] + [3] + []

array = [5, 6]
pivot = 5
[] + [5] + [6]
*/
T[] Concat<T>(params T[][] arrays)  // 1. Функция объединения массивов. arrays - это количество массивов. T - это указывается, что можем передавать любой тип данных, 
                                    // это обобщенный тип данных
{
    var result = new T[arrays.Sum(a => a.Length)]; // 2. result - это массив содержащий количество элементов, которое передается внутри Concat. 
                                                   // В Concat приходят массивы с 5элементов+2элемента+8элементов. В итоге result будет состоять из 15 элементов. 
                                                   // Изначально будет пустым. var - это создание элементов неопределенного типа, т.к. изначально не занем, 
                                                   // какой тип данных будет хранить в себе массивы
    int offset = 0;
    foreach(T[] array in arrays) // 3. Цикл соединение всех массивов
    {
        array.CopyTo(result, offset); // 4. В массив array копируем массив начиная с позиции offset
        offset += array.Length; // 5. Для того, чтобы следующее копирование с позиции, где закончили копирование элементов массива array
    }
    return result;
}
/* Работа функции Concat. 
Пример
1. Есть массивы {1, 2, 3} {4, 5} {6, 7}
2. Количество элементов в новом массиве будет равное 7
4. Массив result = {1, 2, 3, null, null, null, null}
5. Далее увеличиваем позицию offset на 3.
4. Следующий массив будет копироваться с элемента 3 и result = {1, 2, 3, 4, 5, null, null}
5. Далее позицию offset увеличиваем еще на 2 элемента.
4. Следующий массив будем копировать с элемента 5 и result = {1, 2, 3, 4, 5, 6, 7}
*/


int[] quickSort(int[] array)
{
    if(array.Length < 2)
    {
        return array; // Если в массиве 2 элемента, то это базовый случай
    }
    else
    {
        int pivot = array[0];
        int count = 0;
        foreach(int element in array)
        {
            if(element < pivot) // Цикл для подсчета количества элементов меньше опорного
                count++;        //
        }
        int[] less = new int[count]; //Массив после подсчета количества элементов меньше опорного
        int j = 0;
        for(int i = 0; i < array.Length; i++) // Цикл перезаписи элементов в новый массив, которые меньше опорного
        {
            if(array[i] < pivot)
            {
                less[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach(int element in array) // Цикл для подсчета количества элементов больше опорного
        {
            if(element > pivot)
            {
                count++;
            }
        }
        int[] greater = new int[count]; //Массив после подсчета количества элементов больше опорного
        j = 0;
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] > pivot)
            {
                greater[j] = array[i];
                j++;
            }
        }
        count = 0;
        foreach(int element in array) // Цикл для подсчета количества элементов равным опорному
        {
            if(element == pivot)
            {
                count++;
            }
        }
        int[] pivotArray = new int[count]; //Массив после подсчета количества элементов равным опорному
        for(int i = 0; i < count; i++)
        {
            pivotArray[i] = pivot;
        }
        int[] result = Concat(quickSort(less), pivotArray, quickSort(greater)); // Функция объединения массивов
        return result;
    }
}

Console.Clear();
int[] array = {7, 4, 1, 3, 2, 5, 8, 6, 7, 7, 7};
Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]"); // Вывод массива одной функцией Join. Берет каждый элемент массива и соединяет его в единую строку
Console.WriteLine($"Отсортированный массив: [{string.Join(", ", quickSort(array))}]");