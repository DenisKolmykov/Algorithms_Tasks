/*
В дощечке в один ряд вбиты гвоздики. Любые два гвоздика можно соединить ниточкой. 
Требуется соединить некоторые пары гвоздиков ниточками так, 
чтобы к каждому гвоздику была привязана хотя бы одна ниточка, 
а суммарная длина всех ниточек была минимальна.

Формат ввода
В первой строке входных данных записано число N — количество гвоздиков (2 ≤ N ≤ 100). 
В следующей строке заданы N чисел — координаты всех гвоздиков (неотрицательные целые числа, 
не превосходящие 10000).

Формат вывода
Выведите единственное число — минимальную суммарную длину всех ниточек.

Пример
Ввод	            Вывод
6                   5
3 13 12 4 14 6
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_25
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        int[] arrCoord = new int[n + 1];
        string[] arrCoordStr = Console.ReadLine()!.Split(' ');
        for (int i = 1; i <= n; i++)
        {
            arrCoord[i] = Convert.ToInt32(arrCoordStr[i - 1]);
        }
        Array.Sort(arrCoord);
        //System.Console.WriteLine(string.Join(" ", arrCoord));

        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1]=0;
        if ( n<4)
        {
            for (int k = 2; k <=n; k++)
            {
                dp[k] =arrCoord[k] - arrCoord[k-1] +dp[k-1];
            }
        }
        else
        {
            dp[2] = arrCoord[2] - arrCoord[1];
            dp[3] = arrCoord[3] - arrCoord[2] + dp[2];
            //System.Console.WriteLine("DP2= "+dp[2]+", DP3= "+dp[3]);

            for (int j = 4; j <= n; j++)
            {
                int min = arrCoord[j] - arrCoord[j - 1] + Math.Min(dp[j - 1], dp[j - 2]);
                //System.Console.WriteLine($"arrCoord[{j}]= {arrCoord[j]}, arrCoord[{j-1}] {arrCoord[j-1]}, dp[{j-1}] = {dp[j-1]}, dp[{j-2}]= {dp[j-2]}, min= {min}");
                int min1 = arrCoord[j] - arrCoord[j - 2] + dp[j - 1];
                //System.Console.WriteLine($"arrCoord[{j}]= {arrCoord[j]}, arrCoord[{j-2}] {arrCoord[j-2]}, dp[{j-1}]= {dp[j-1]}, min1= {min1}");
                if (min1 < min) min = min1;
                dp[j] = min;
                //System.Console.WriteLine(j+", "+dp[j]);
            }
        }
        System.Console.WriteLine(dp[n]);
    }
}
