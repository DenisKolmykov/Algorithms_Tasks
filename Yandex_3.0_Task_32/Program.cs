/*
Дан неориентированный невзвешенный граф. 
Необходимо посчитать количество его компонент связности и вывести их.

Формат ввода
Во входном файле записано два числа N и M (0 < N ≤ 100000, 0 ≤ M ≤ 100000). 
В следующих M строках записаны по два числа i и j (1 ≤ i, j ≤ N), 
которые означают, что вершины i и j соединены ребром.

Формат вывода
В первой строчке выходного файла выведите количество компонент связности. 
Далее выведите сами компоненты связности в следующем формате: 
в первой строке количество вершин в компоненте, во второй - сами вершины в произвольном порядке.

Пример 1
Ввод	Вывод
6 4     3
3 1     3
1 2     1 2 3
5 4     2
2 3     4 5
        1
        6

Пример 2
Ввод	Вывод
6 4     2
4 2     5
1 4     1 2 3 4 6
6 4     1
3 6     5

*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_32
{
    static void Main()
    {

        // функция поиска в глубину Dfs
        List<int> Dfs(List<int>[] graf, bool[] visited, int now, List<int> countV)
        {
            visited[now] = true;
            foreach (int neig in graf[now])
            {
                if (visited[neig] is not true)
                {
                    Dfs(graf, visited, neig, countV);
                }
            }
            countV.Add(now);
            //System.Console.WriteLine(string.Join(", ",countV));
            return countV;
        }


        string inputStr = Console.ReadLine()!.TrimEnd(' ');
        int[] input = Array.ConvertAll(inputStr.Split(' '), Convert.ToInt32);
        int v = input[0]; // кол-во вершин
        int e = input[1]; // кол-во ребер
        bool[] visited = new bool[v + 1];
        List<List<int>> res = new List<List<int>>(); // список списков для сбора компонен с вершинами
        List<int> resCountV = new List<int>(); // список для каждой компоненты в который собираем вершины
        List<int>[] listAdjacency = new List<int>[v + 1]; // список смежности (индекс-вершина из которой можно попасть в другие-массив вершин)
        for (int j = 1; j <= v; j++)
        {
            listAdjacency[j] = new List<int>(); // инициализируем пустые списки для массива смежности
            visited[j] = false;

        }
        //System.Console.WriteLine("visited:");
        //System.Console.WriteLine(string.Join(", ",visited));
        for (int i = 1; i <= e; i++)
        {
            string inputVEStr = Console.ReadLine()!.TrimEnd(' ');
            int[] inputVE = Array.ConvertAll(inputVEStr.Split(' '), Convert.ToInt32);
            // сразу формируем список смежности
            listAdjacency[inputVE[0]].Add(inputVE[1]);
            if (inputVE[0] != inputVE[1])
            {
                listAdjacency[inputVE[1]].Add(inputVE[0]);
            }
        }

        //int component = 1;

        for (int k = 1; k <= v; k++)
        {
            if (visited[k] is not true)
            {
                List<int> countV = new List<int>();
                resCountV = Dfs(listAdjacency, visited, k, countV);
                //System.Console.WriteLine(string.Join(" ",countV));
                res.Add(resCountV);
                //System.Console.WriteLine("res: " + string.Join(" ",res[0]));
                //countV.Clear();
                //countV.Sort();
                //Console.WriteLine("count= " + countV.Count());
                //Console.WriteLine("res= " + string.Join(" ", countV));
                //component++;
            }


        }
        Console.WriteLine(res.Count());

        foreach (var list in res)
        //for (int x = 0; x < res.Count(); x++)
        {
            Console.WriteLine(list.Count());
            Console.WriteLine(string.Join(" ", list));
        }

    }
}