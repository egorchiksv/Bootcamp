// int n = 5;
// int [] array = new int[n];
// for(int i = 0; i < n; i++)
//     array[i] = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("[" + string.Join(", ", array) + "]");

// Сложность алгоритм 0(1) О-натация
// [4, 5, 3, 1, 2]
// Найти сумму элементов. Нужно 5 действий. Сложность 0(n)
// Нужно отсортировать
// [1, 2, 3, 4, 5] - O(n*logn)
// ((5+1)/2() * 5 - 0(1)
// n < n * log(n) + 1
// int summa = 0;
// for(int i = 0; i < n; i++)
//     summa += array[i];
//     Console.WriteLine(summa);

// O(n^2)
int n = Convert.ToInt32(Console.ReadLine());
int [,] matrix = new int [n, n];
for(int i = 0; i < n; i++)
{
    for(int j = i; j < n; j++)
    {
        matrix[i, j] = (i + 1) * (j + 1);
        matrix[j, i] = (i + 1) * (j + 1);
    }
}

for(int i = 0; i < n; i++)
{
    for(int j = 0; j < n; j++)
    {
        Console.Write(matrix[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}