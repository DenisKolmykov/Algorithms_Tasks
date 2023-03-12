/*
У одного из студентов в комнате живёт кузнечик, который очень любит прыгать по клетчатой одномерной доске. 
Длина доски — N клеток. К его сожалению, он умеет прыгать только на 1, 2, …, k клеток вперёд.

Однажды студентам стало интересно, сколькими способами кузнечик может допрыгать 
из первой клетки до последней. Помогите им ответить на этот вопрос.

Формат ввода
В первой и единственной строке входного файла записано два целых числа — N и k .

Формат вывода
Выведите одно число — количество способов, которыми кузнечик может допрыгать 
из первой клетки до последней.

Пример
Ввод	Вывод
8 2     21

*/

using System;
using System.Collections.Generic;
using System.Linq;
public class Task_22
{
    static void Main()
    {
        string[] input = Console.ReadLine()!.Split(' ');
        int n = Convert.ToInt32(input[0]);
        int k = Convert.ToInt32(input[1]);

        int[] dp = new int[n+1];

        dp[0] = 1;

        if (k > n) k = n;
        for (int i = 1; i <= n; i++)
        {
            int j = 0;
            while (j <= i & j <= k)
            {
                dp[i] = dp[i] + dp[i - j];
                j++;              
            }
        }
        Console.WriteLine(dp[n-1]);
        System.Console.WriteLine(string.Join(", ", dp));
    }
}