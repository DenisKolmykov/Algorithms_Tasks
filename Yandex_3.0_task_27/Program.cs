/*
В левом верхнем углу прямоугольной таблицы размером N×M находится черепашка. 
В каждой клетке таблицы записано некоторое число. 
Черепашка может перемещаться вправо или вниз, при этом маршрут черепашки заканчивается 
в правом нижнем углу таблицы.
Подсчитаем сумму чисел, записанных в клетках, через которую проползла черепашка 
(включая начальную и конечную клетку). 
Найдите наибольшее возможное значение этой суммы и маршрут, на котором достигается эта сумма.

Формат ввода
В первой строке входных данных записаны два натуральных числа N и M, 
не превосходящих 100 — размеры таблицы. Далее идет N строк, каждая из которых содержит M чисел, 
разделенных пробелами — описание таблицы. 
Все числа в клетках таблицы целые и могут принимать значения от 0 до 100.

Формат вывода
Первая строка выходных данных содержит максимальную возможную сумму, 
вторая — маршрут, на котором достигается эта сумма. 
Маршрут выводится в виде последовательности, которая должна содержать N-1 букву D, 
означающую передвижение вниз и 
M-1 букву R, означающую передвижение направо. 
Если таких последовательностей несколько, необходимо вывести ровно одну (любую) из них.

Пример
Ввод	        Вывод
5 5             74
9 9 9 9 9       D D R R R R D D
3 0 0 0 0
9 9 9 9 9
6 6 6 6 8
9 9 9 9 9
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_27
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
 
        for (int k = 1; k <= n; k++)
        {
            for (int l = 1; l <= m; l++)
            {
                int max = valueInMatrix[k, l] + dp[k, l - 1];
                int max1 = valueInMatrix[k, l] + dp[k - 1, l];
                if (max1 > max) max = max1;
                dp[k, l] = max;
                
                //System.Console.Write(dp[k, l] + " ");
            }
            //System.Console.WriteLine();
        }

        int e = n;
        int r = m;
        string result = string.Empty;
        while (e >= 1 && r > 1 || e > 1 && r >= 1)
        {
            if (dp[e - 1, r] >= dp[e, r - 1])
            {
                result = "D " + result;
                e--;
            }
            else
            {
                result = "R " + result;
                r--;
            }
        }

        Console.WriteLine(dp[n, m]);
        Console.WriteLine(result);
    }
}