// Пузырьковая сортировка
// 2 элемента отсортируем за 1 действие
// 3 элемента отсортируем за 2 действие
// 4 элемента отсортируем за 3 действие
// n элементов отсортируем за n-1 действие

using System.Diagnostics;// Для использования таймера

bool Check(int[] array) // Функция проверка отсортирован ли массив
{
    int size = array.Length;

    for(int i = 0; i < size - 1; i++)
    {
        if(array[i] > array[i + 1]) return false;
    }
    return true;
}
bool show = !true; // Делать проверку отсартированного массива

int n = 50_000;
int max = 100;

int[] array = new int[n];

for(int i = 0; i < n; i++)
{
    array[i] = Random.Shared.Next(max);
    //array[i] = n - i; // Задается массив в обратном порядке
}
if(show) Console.WriteLine($"[{string.Join(',' ,array)}]");
int[] arr1 = new int[n];
int[] arr2 = new int[n];
int[] arr3 = new int[n];

Array.Copy(array, arr1, n); // Созадем копию массива
Array.Copy(array, arr2, n); // Созадем копию массива
Array.Copy(array, arr3, n); // Созадем копию массива

if(show) Console.WriteLine($"arr1: [{string.Join(',' ,arr1)}]");

Stopwatch sw = new Stopwatch(); // Создаем таймер
sw.Start(); // Стартуем таймер
for(int k = 0; k < n-1; k++)
{
    for(int i = 0; i < n - 1 - k; i++)// уменьшаем количество просмотров массива, т.к. последний элемент стоит на совем месте и просматривать его нет смысла
    {
        if(arr1[i] > arr1[i+1])
        {
            int temp = arr1[i];
            arr1[i] = arr1[i+1];
            arr1[i+1] = temp;
        }
    }
}
sw.Stop(); // останавливаем таймер
System.Console.WriteLine($"arr1 - {Check(arr1)} {sw.ElapsedMilliseconds}ms");

if(show) Console.WriteLine($"arr1: [{string.Join(',' ,arr1)}]");
if(show) Console.WriteLine($"arr2: [{string.Join(',' ,arr2)}]");
//Console.ReadLine(); // Задержка перед выведением следующиего массива

sw.Reset(); // Сброс таймера
sw.Start();

for(int k = 0; k < n-1; k++)
{
    for(int i = 0; i < n - 1; i++)
    {
        if(arr2[i] > arr2[i+1])
        {
            int temp = arr2[i];
            arr2[i] = arr2[i+1];
            arr2[i+1] = temp;
        }
    }
}
sw.Stop();
System.Console.WriteLine($"arr2 - {Check(arr2)} {sw.ElapsedMilliseconds}ms");

//====

if(show) Console.WriteLine($"arr3: [{string.Join(',' ,arr3)}]");

sw = new Stopwatch(); // Создаем таймер
sw.Start(); // Стартуем таймер

for(int k = 0; k < n; k++)
{
    bool check = true;
    for(int i = 0; i < n - 1 - k; i++)// уменьшаем количество просмотров массива, т.к. последний элемент стоит на совем месте и просматривать его нет смысла
    {
        if(arr3[i] > arr3[i+1])
        {
            check = false;
            int temp = arr3[i];
            arr3[i] = arr3[i+1];
            arr3[i+1] = temp;
        }
    }
    if(check) break;
}
sw.Stop(); // останавливаем таймер
System.Console.WriteLine($"arr3 - {Check(arr3)} {sw.ElapsedMilliseconds}ms");

if(show) Console.WriteLine($"arr2: [{string.Join(',' ,arr2)}]");
// int j = 0;

// while(j < n) Console.Write(array[j++] + " ");