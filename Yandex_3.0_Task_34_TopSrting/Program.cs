/*
Дан ориентированный граф. Необходимо построить топологическую сортировку.

Формат ввода
В первой строке входного файла два натуральных числа N и M (1 ≤ N, M ≤ 100 000) — 
количество вершин и рёбер в графе соответственно. Далее в M строках перечислены рёбра графа. 
Каждое ребро задаётся парой чисел — номерами начальной и конечной вершин соответственно.

Формат вывода
Выведите любую топологическую сортировку графа в виде последовательности номеров вершин 
(перестановка чисел от 1 до N). Если топологическую сортировку графа построить невозможно, выведите -1.

Пример
Ввод	Вывод
6 6     4 6 3 1 2 5
1 2
3 2
4 2
2 5
6 5
4 6

*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_34
{
    static void Main()
    {
        // функция поиска в глубину Dfs
        List<int> Dfs(List<int>[] graf, int[] visited, int now, List<int> countV)
        {
            visited[now] = 1;
            foreach (int neig in graf[now])
            {
                if (visited[neig] == 0)
                {
                    Dfs(graf, visited, neig, countV);
                }
                if (visited[neig] == 1)
                {
                    countV.Clear();
                    return countV;
                }

            }
            countV.Add(now);
            visited[now] = 2;

            return countV;
        }


        string inputStr = Console.ReadLine()!.TrimEnd(' ');
        int[] input = Array.ConvertAll(inputStr.Split(' '), Convert.ToInt32);
        int v = input[0]; // кол-во вершин
        int e = input[1]; // кол-во ребер
        int[] visited = new int[v + 1];
        List<List<int>> res = new List<List<int>>(); // список списков для сбора компонен с вершинами
        List<int> resCountV = new List<int>(); // список для каждой компоненты в который собираем вершины
        List<int>[] listAdjacency = new List<int>[v + 1]; // список смежности (индекс-вершина из которой можно попасть в другие-массив вершин)
        for (int j = 1; j <= v; j++)
        {
            listAdjacency[j] = new List<int>(); // инициализируем пустые списки для массива смежности
        }

        for (int i = 1; i <= e; i++)
        {
            string inputVEStr = Console.ReadLine()!.TrimEnd(' ');
            int[] inputVE = Array.ConvertAll(inputVEStr.Split(' '), Convert.ToInt32);
            // сразу формируем список смежности
            listAdjacency[inputVE[0]].Add(inputVE[1]);

        }

        List<int> countV = new List<int>();
        bool flag = true;
        for (int k = 1; k <= v; k++)
        {
            if (visited[k] == 0)
            {
                resCountV = Dfs(listAdjacency, visited, k, countV);
                if (resCountV.Count() == 0)
                {
                    flag = false;
                    break;
                }
            }
        }
        if (flag)
        {
            resCountV.Reverse();
            Console.WriteLine(string.Join(" ", resCountV));
        }
        else Console.WriteLine("-1");
    }
}