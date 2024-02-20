// Сортировка Выбором О(n^2)

/*
[45, 23, -10, 5, 3, 9, 1]
min = -10
[-10, 23, 45, 5, 3, 9, 1]
min = 1
[-10, 1, 45, 5, 3, 9, 23]
min = 3
[-10, 1, 3, 5, 45, 9, 23]
min = 5
[-10, 1, 3, 5, 45, 9, 23]
min = 9
[-10, 1, 3, 5, 9, 45, 23]
min = 23
[-10, 1, 3, 5, 9, 23, 45]
*/
void InputArray(int[] array)
{
    for(int i = 0; i < array.Length; i++)
        array[i] = new Random().Next(-20, 21); // [-20; 20]
}

int[] sortVibor(int[] array)
{
    for(int i = 0; i < array.Length; i++)// Счетчики цикла лучше всего обзывать i, j, k, m, n
    {
        int indexmin = i;
        for(int j = i; j < array.Length; j++)
        {
            if(array[j] < array[indexmin])
                indexmin = j;
        }
        if(array[indexmin] == array[i])
            continue; // Позволяет перейти к следующему индексу i, т.е. переход к следующей операции цикла. Или пропустить шаг.

        int temp = array[i];
        array[i] = array[indexmin];
        array[indexmin] = temp;
    }
    return array;
}

Console.Clear();
Console.Write("Введите кол-во элементов массива: ");
int n = int.Parse(Console.ReadLine()!); // Функция Parse () разрешает переводить строку, которая состоит из цифр, в целое число. ! говорит о том, что не будет введено значение null (убираем предупреждение у себя в программе)
int[] array = new int[n];
InputArray(array);
Console.WriteLine($"Начальный массив: [{string.Join(", ", array)}]"); // Команда join используется для связывания элементов из разных 
Console.WriteLine($"Конечный массив: [{string.Join(", ", sortVibor(array))}]"); //исходных последовательностей, не имеющих прямых связей в объектной модели.
Console.WriteLine(Convert.ToInt32('a')); // Выдает код симовла из кодировки, которая установлена в VSC. char != string. ' ' указывается сивол (char)