﻿/*
1. Коснтантные 0(1) - 0(2)
2. Логарифмические - Бинарный поиск
3. Линейные 0() - 0(2 * n)...
4. Линейно-логарифмические - быстрая сортировка
5. Квадратные - пузырьковая сортировка, сортировка выбором, сортировка вставками и др. алгоритмы
6. Кубические - трехмерный массивы
*/
// Напишите программу, которая считает сумму числе от 1 до n.
// 3. Линейный алгоритм
// Console.Clear();
// Console.Write("Введите число: ");
// int n = int.Parse(Console.ReadLine()!), result = 0;// ["345"] <- 345 - берет строку преобразовывает в число записывает в ту же самую ячейку
// //int n = Convert.ToInt32(Console.ReadLine());// ["123"] -> 123 -> [123] - берет строку преобразвывает в число и записывает в другую ячейку
// for(int i = 1; i <= n; i++) // 0(n)
//     result += i;
// Console.WriteLine($"Сумма числа от 1 до {n} равна {result}");

// 1. Константный алгоритм
Console.Clear();
Console.Write("Введите число: ");
int n = int.Parse(Console.ReadLine()!); // 0(1)
Console.WriteLine($"Сумма числа от 1 до {n} равна {(1 + n) / 2.0 * n}");

// 2. Логарифмический алгоритм
// Бинарный поиск (двоичный поиск) 
// Загадочное число равно 67
// от 1 до 100
// Число больше 50? - Да (от 50 до 100)
// Число больше 75? - Нет (от 50 до 75)
// Число больше 62? - Да (от 62 до 75)
// Число больше 68? - Нет (62 до 68)
// Число больше 65? - Да (от 65 до 68)
// Число больше 66? - Да (от 66 до 68)
// Число больше 67? - Нет (Ответ: 67)
// 7 попыток
// Сложность алгоритма бинарного поиска равен 0(log2(n))
// Если число будет от 1 до 1000, то log2(1000) ~ 10 попыток

// [34, 1, 2, -10, 56, 314, 13, 1, 2, 4, 90, -123, 32, 54, 652], n - количество элементов массива. Нужно сначала выбрать способ сортировки
// Сложность алгоритма будет 0(n * log2(n)) + 0(log2(0))

// Быстрая сортировка 0(n * log2(n)) (Рекурсивный подход)

// [34, -10, 23, 5, 2, 1]
// 1. Выбирается опорный элемент (в основном берется первый элемент массива)
// 2. Создается 2 массива. 1-ый массив содержит элементы меньше опорного, 2-ой массив
// содержит элементы больше или равно опорному.

// Быстрая сортировка
//  Опорный элемент 34              [-10, 1, 2, 5, 23, 34]
// [-10, 23, 5, 2, 1] + [34] + []
//  Опорный элемент -10             [-10, 1, 2, 5, 23]
// [] + [-10] + [23, 5, 2, 1]
// Опорный элемент 23               [1, 2, 5, 23]
// [5, 2, 1] + [23] + []
// Опорный элемент 5                [1, 2, 5]
// [2, 1] + [5] +[]
// Опорный элемент 2
// [1] + [2] + []
