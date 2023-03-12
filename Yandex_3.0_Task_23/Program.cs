/*
Имеется калькулятор, который выполняет следующие операции:

умножить число X на 2;
умножить число X на 3;
прибавить к числу X единицу.
Определите, какое наименьшее количество операций требуется, чтобы получить из числа 1 число N.

Формат ввода
Во входном файле написано натуральное число N, не превосходящее 106.

Формат вывода
В первой строке выходного файла выведите минимальное количество операций. 
Во второй строке выведите числа, последовательно получающиеся при выполнении операций. 
Первое из них должно быть равно 1, а последнее N. Если решений несколько, выведите любое.

Пример 1
Ввод	Вывод
1       0
        1

Пример 2
Ввод	Вывод
5       3
        1 3 4 5

*/

using System;
using System.Collections.Generic;
using System.Linq;
public class Task_23
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        int[] dp = new int[n + 1];
        int[] prev = new int[n + 1];
        List<int> prevReverce = new List<int>();
        dp[0] = -1;
        prev[0] = -1;
        int min = dp[0];
        for (int i = 1; i <= n; i++)
        {
            min = dp[i - 1];
            prev[i] = i - 1;
            //dp[i] = min + 1;

            if (i % 2 == 0 && dp[i / 2] <= min)
            {
                min = dp[i / 2];
                prev[i] = i / 2;
            }
            if (i % 3 == 0 && dp[i / 3] < min)
            {
                min = dp[i / 3];
                prev[i] = i / 3;
            }
            dp[i] = min + 1;
        }
        Console.WriteLine(dp[n]);
        int m = n;
        while (prev[m] >= 1)
        {
            prevReverce.Insert(0, prev[m]);
            m = prev[m];
        }
        prevReverce.Add(n);
        Console.WriteLine(string.Join(" ", prevReverce));
    }
}