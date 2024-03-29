﻿/*
Лайнландия представляет из себя одномерный мир, являющийся прямой, на котором распологаются N городов, 
последовательно пронумерованных от 0 до N - 1 . Направление в сторону от первого города к нулевому 
названо западным, а в обратную — восточным.
Когда в Лайнландии неожиданно начался кризис, все были жители мира стали испытывать глубокое смятение. 
По всей Лайнландии стали ходить слухи, что на востоке живётся лучше, чем на западе.
Так и началось Великое Лайнландское переселение. Обитатели мира целыми городами отправились на восток, 
покинув родные улицы, и двигались до тех пор, пока не приходили в город, 
в котором средняя цена проживания была меньше, чем в родном.

Формат ввода
В первой строке дано одно число N (2≤N≤105) — количество городов в Лайнландии. 
Во второй строке дано N чисел ai (0≤ai≤109) — средняя цена проживания в городах с нулевого по (N - 1)-ый соответственно.
Формат вывода
Для каждого города в порядке с нулевого по (N - 1)-ый выведите номер города, 
в который переселятся его изначальные жители. 
Если жители города не остановятся в каком-либо другом городе, 
отправившись в Восточное Бесконечное Ничто, выведите -1 .
Пример
Ввод	                Вывод
10                      -1 4 3 4 -1 6 9 8 9 -1
1 2 3 2 1 4 2 5 3 1

*/


using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        string[] costChar = Console.ReadLine()!.Split(' ');
        int[] cost = new int[n];
        for (int j = 0; j < n; j++)
        {
            cost[j] = Convert.ToInt32(costChar[j]);
        }

        int[] result = new int[n];
        Stack<int> tempIndex = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            if (tempIndex.Count > 0)
            {
                while (cost[tempIndex.Peek()] > cost[i] )
                {
                    result[tempIndex.Peek()] = i;
                    tempIndex.Pop();
                    if (tempIndex.Count==0) break;
                }
            }
            tempIndex.Push(i);
        }
        while (tempIndex.Count > 0)
        {
            result[tempIndex.Pop()] = -1;
        }
        System.Console.WriteLine(string.Join(" ", result));
    }
}
