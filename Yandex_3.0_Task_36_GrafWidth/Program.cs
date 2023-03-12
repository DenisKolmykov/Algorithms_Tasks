/*
В неориентированном графе требуется найти длину минимального пути между двумя вершинами.

Формат ввода
Первым на вход поступает число N – количество вершин в графе (1 ≤ N ≤ 100). 
Затем записана матрица смежности (0 обозначает отсутствие ребра, 1 – наличие ребра). 
Далее задаются номера двух вершин – начальной и конечной.

Формат вывода
Выведите L – длину кратчайшего пути (количество ребер, которые нужно пройти).

Если пути нет, нужно вывести -1.

Пример 1
Ввод	                Вывод
10                         2
0 1 0 0 0 0 0 0 0 0
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

Пример 2
Ввод	        Вывод
5               3
0 1 0 0 1
1 0 1 0 0
0 1 0 0 0
0 0 0 0 0
1 0 0 0 0
3 5

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
        int[] Wfs(List<int>[] graf, int[] visited, int now, Queue<int> vertexQueue)
        {

            foreach (int neig in graf[now])

            {
                vertexQueue.Enqueue(now);

                if (visited[neig] == -1 || visited[neig]>(visited[now] + 1))
                {
                    visited[neig] = visited[now] + 1;
                    vertexQueue.Enqueue(neig);
                    Wfs(graf, visited, neig, vertexQueue);
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

        Queue<int> vertexQueue = new Queue<int>();
        vertexQueue.Enqueue(start);
        visited = Wfs(listAdjacency, visited, start, vertexQueue);
 
        Console.WriteLine(visited[finish]);
    }
}