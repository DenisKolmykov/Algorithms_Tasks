/*
По данному числу N определите количество последовательностей из нулей и единиц длины N, 
в которых никакие три единицы не стоят рядом.

Формат ввода
Во входном файле написано натуральное число N, не превосходящее 35.

Формат вывода
Выведите количество искомых последовательностей. Гарантируется, что ответ не превосходит 231-1.
*/

using System;
using System.Collections.Generic;
using System.Linq;
public class Task_21
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        if (n == 0) Console.WriteLine('0');
        else
        {
            int[] dp = new int[n + 3];
            /*
            5
            0 0 0 0 
            0 0 0 1
            0 0 1 0
            0 1 0 0
            1 0 0 0
            0 0 1 1
            0 1 0 1
            1 0 0 1
            0 0 1 1
            0 1 1 0
            1 0 1 0
            1 1 0 0
            1 1 0 1
            1 0 1 1


            0 0
            0 1
            1 0
            1 1

            0 0 0
            0 0 1
            0 1 0
            1 0 0
            0 1 1
            1 0 1
            1 1 0

            */
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;

            for (int i = 3; i < n + 3; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }
            Console.WriteLine(dp[n + 2]);
            System.Console.WriteLine(string.Join(", ", dp));
        }


    }
}