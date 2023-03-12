/*
В неориентированном графе требуется найти минимальный путь между двумя вершинами.

Формат ввода
Первым на вход поступает число N – количество вершин в графе (1 ≤ N ≤ 100). Затем записана матрица смежности (0 обозначает отсутствие ребра, 1 – наличие ребра). Далее задаются номера двух вершин – начальной и конечной.

Формат вывода
Выведите сначала L – длину кратчайшего пути (количество ребер, которые нужно пройти), а потом сам путь. Если путь имеет длину 0, то его выводить не нужно, достаточно вывести длину.

Необходимо вывести путь (номера всех вершин в правильном порядке). Если пути нет, нужно вывести -1.

Пример
Ввод	                Вывод
10                      2
0 1 0 0 0 0 0 0 0 0     5 2 4
1 0 0 1 1 0 1 0 0 0
0 0 0 0 1 0 0 0 1 0
0 1 0 0 0 0 1 0 0 0
0 1 1 0 0 0 0 0 0 1
0 0 0 0 0 0 1 0 0 1
0 1 0 1 0 1 0 0 0 0
0 0 0 0 0 0 0 0 1 0
0 0 1 0 0 0 0 1 0 0
0 0 0 0 1 1 0 0 0 0
5 4

*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_36
{
    static void Main()
    {
        // функция поиска в ширину Wfs
        int[] Wfs(List<int>[] graf, int[] visited, int now, Queue<int> vertexQueue, ref int[] prev)
        {

            foreach (int neig in graf[now])

            {
                vertexQueue.Enqueue(now);

                if (visited[neig] == -1 || visited[neig] > (visited[now] + 1))
                {
                    visited[neig] = visited[now] + 1;

                    //System.Console.WriteLine($"visited {neig} = {visited[neig]}");

                    vertexQueue.Enqueue(neig);
                    prev[neig] = now;
                    Wfs(graf, visited, neig, vertexQueue, ref prev);
                }

            }

            //System.Console.WriteLine();
            vertexQueue.Dequeue();
            //System.Console.WriteLine(string.Join(" ", visited));

            return (visited);
        }


        int n = Convert.ToInt32(Console.ReadLine()!);

        // ввод матрицы смежности
        string[] inputRowMatrixAdjacencyStr = new string[n];
        for (int i = 0; i < n; i++)
        {
            inputRowMatrixAdjacencyStr[i] = Console.ReadLine()!.TrimEnd(' ');
        }

        // формируем список смежности
        int[] visited = new int[n + 1]; // массив посещенных вершин
        int[] prev = new int[n + 1]; // массив предыдущих индексов
        List<int>[] listAdjacency = new List<int>[n + 1]; // список смежности (индекс-вершина из которой можно попасть в другие-массив вершин)
        for (int k = 0; k < n; k++)
        {
            int[] rowInputMatrix = Array.ConvertAll(inputRowMatrixAdjacencyStr[k].Split(' '), Convert.ToInt32);

            listAdjacency[k + 1] = new List<int>();
            visited[k + 1] = -1; // "-1" вершина еще не посещалась


            for (int l = 0; l < n; l++)
            {
                if (rowInputMatrix[l] == 1)
                    listAdjacency[k + 1].Add(l + 1);
            }
        }

        string inputStr = Console.ReadLine()!.TrimEnd(' ');
        int[] input = Array.ConvertAll(inputStr.Split(' '), Convert.ToInt32);
        int start = input[0]; // вершина начала
        int finish = input[1]; // вершина выхода


        visited[start] = 0;
        prev[start] = -1;
        Queue<int> vertexQueue = new Queue<int>();
        vertexQueue.Enqueue(start);
        visited = Wfs(listAdjacency, visited, start, vertexQueue, ref prev);

        Console.WriteLine(visited[finish]);
        if (visited[finish] > 1)
        {
            List<int> result = new List<int>();
            int g = finish;
            while (prev[g] > 0)
            {
                result.Add(g);
                g = prev[g];
            }
            result.Add(start);
            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }

    }
}