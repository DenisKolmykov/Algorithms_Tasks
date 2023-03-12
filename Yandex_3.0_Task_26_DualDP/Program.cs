/*
В каждой клетке прямоугольной таблицы N×M записано некоторое число. 
Изначально игрок находится в левой верхней клетке. 
За один ход ему разрешается перемещаться в соседнюю клетку либо вправо, 
либо вниз (влево и вверх перемещаться запрещено). 
При проходе через клетку с игрока берут столько килограммов еды, 
какое число записано в этой клетке (еду берут также за первую и последнюю клетки его пути).
Требуется найти минимальный вес еды в килограммах, отдав которую игрок может попасть в правый нижний угол.

Формат ввода
Вводятся два числа N и M — размеры таблицы (1≤N≤20, 1≤M≤20). 
Затем идет N строк по M чисел в каждой — размеры штрафов в килограммах 
за прохождение через соответствующие клетки (числа от 0 до 100).
Формат вывода
Выведите минимальный вес еды в килограммах, отдав которую можно попасть в правый нижний угол.
Пример
Ввод	            Вывод
5 5                    11
1 1 1 1 1
3 100 100 100 100
1 1 1 1 1
2 2 2 2 1
1 1 1 1 1
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_26
{
    static void Main()
    {
        string[] nm = Console.ReadLine()!.Split(' ');
        int n = Convert.ToInt32(nm[0]);
        int m = Convert.ToInt32(nm[1]);

        int[,] valueInMatrix = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++)
        {
            string[] valueRow = Console.ReadLine()!.Split(' ');
            for (int j = 1; j <= m; j++)
            {
                valueInMatrix[i, j] = Convert.ToInt32(valueRow[j - 1]);
            }
        }
        //System.Console.WriteLine("\n");
        int[,] dp = new int[n + 1, m + 1];
        for (int x = 1; x <= n; x++)
        {
            valueInMatrix[x, 1] = valueInMatrix[x, 1] + valueInMatrix[x - 1, 1];
        }
        for (int y = 1; y <= m; y++)
        {
            valueInMatrix[1, y] = valueInMatrix[1, y] + valueInMatrix[1, y - 1];
        }

        for (int k = 1; k <= n; k++)
        {
            for (int l = 1; l <= m; l++)
            {
                dp[k, l] = Math.Min((valueInMatrix[k, l] + dp[k, l - 1]), (valueInMatrix[k, l] + dp[k - 1, l]));
                //System.Console.Write(dp[k, l] + " ");
            }
            //System.Console.WriteLine();
        }
Console.WriteLine(dp[n,m]);
    }
}