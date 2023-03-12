/*
Даны две последовательности, требуется найти и вывести их наибольшую общую подпоследовательность.

Формат ввода
В первой строке входных данных содержится число N – длина первой последовательности (1 ≤ N ≤ 1000). 
Во второй строке заданы члены первой последовательности (через пробел) – целые числа, 
не превосходящие 10000 по модулю.

В третьей строке записано число M – длина второй последовательности (1 ≤ M ≤ 1000). 
В четвертой строке задаются члены второй последовательности (через пробел) – целые числа, 
не превосходящие 10000 по модулю.

Формат вывода
Требуется вывести наибольшую общую подпоследовательность данных последовательностей, через пробел.

Пример 1
Ввод	    Вывод
3           2 3
1 2 3
3 
2 3 1

Пример 2
Ввод	    Вывод
3           1
1 2 3
3 
3 2 1

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_30
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        string sequence1Str = Console.ReadLine()!.TrimEnd(' ');
        int[] sequence1 = Array.ConvertAll( sequence1Str.Split(' '),Convert.ToInt32);

        int m = Convert.ToInt32(Console.ReadLine()!);
        string sequence2Str = Console.ReadLine()!.TrimEnd(' ');
        int[] sequence2 = Array.ConvertAll( sequence2Str.Split(' '),Convert.ToInt32);
        
        int[,] dp = new int[n + 1, m + 1];
        List<int> ans = new List<int>();

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (sequence1[i - 1] == sequence2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        //System.Console.WriteLine(dp[n, m]);

        int k = n;
        int l = m;
        while (k > 0 && l > 0)
        {
            if (sequence1[k - 1] == sequence2[l - 1])
            {
                ans.Insert(0, sequence1[k - 1]);
                k--;
                l--;
            }
            else if (dp[k - 1, l] == dp[k, l])
            {
                k--;
            }
            else
            {
                l--;
            }
        }
        
        Console.WriteLine(string.Join(" ", ans));
    }
}
