/*
Дан неориентированный граф, возможно, с петлями и кратными ребрами. 
Необходимо построить компоненту связности, содержащую первую вершину.

Формат ввода
В первой строке записаны два целых числа N (1 ≤ N ≤ 103) и M (0 ≤ M ≤ 5 * 105) — 
количество вершин и ребер в графе. 
В последующих M строках перечислены ребра — пары чисел, определяющие номера вершин, 
которые соединяют ребра.

Формат вывода
В первую строку выходного файла выведите число K — количество вершин в компоненте связности. 
Во вторую строку выведите K целых чисел — вершины компоненты связности, 
перечисленные в порядке возрастания номеров.

Пример
Ввод	Вывод
4 5     4
2 2     1 2 3 4
3 4
2 3
1 3
2 4


*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_31
{
    static void Main()
    {

        // функция поиска в глубину Dfs
        List<int> Dfs(List<int>[] graf, bool[] visited, int now, List<int>countV)
        {
            
            visited[now] = true;
            foreach (int neig in graf[now])
            {
                if (visited[neig] is not true)
                {
                    Dfs(graf, visited, neig,countV);
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
        List<int> countV = new List<int>();
        List<int>[] listAdjacency = new List<int>[v + 1]; // список смежности (индекс-вершина из которой можно попасть в другие-массив вершин)
        for (int j = 1; j <= v; j++)
        {
            listAdjacency[j] = new List<int>();
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
        for (int x = 1; x <= v; x++)
        {
            System.Console.WriteLine("x: " + x + ", listAdjacency[i]= " + string.Join(",", listAdjacency[x]));
        }

        int k = 1;

            countV = Dfs(listAdjacency, visited, k,countV);
            countV.Sort();
            Console.WriteLine("count= " + countV.Count());
            Console.WriteLine("res= " + string.Join(" ", countV));
    }
}
