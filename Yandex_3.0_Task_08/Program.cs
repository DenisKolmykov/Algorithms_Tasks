/*
На клетчатой плоскости закрашено K клеток. 
Требуется найти минимальный по площади прямоугольник, со сторонами, 
параллельными линиям сетки, покрывающий все закрашенные клетки.

Формат ввода
Во входном файле, на первой строке, находится число K (1 ≤ K ≤ 100). 
На следующих K строках находятся пары чисел Xi и Yi – координаты закрашенных клеток (|Xi|, |Yi| ≤ 109).

Формат вывода
Выведите в выходной файл координаты левого нижнего и правого верхнего углов прямоугольника.

Пример
Ввод	Вывод
3       1 1 5 10
1 1
1 10
5 5

*/


using System;
using System.Collections.Generic;
using System.Linq;
public class Test
{
    static void Main()
    {
        string arrLen = Console.ReadLine()!;
        int k = Convert.ToInt32(arrLen); // кол-во закрашенных клеток
        int[] arrX = new int[k];
        int[] arrY = new int[k];
        for (int i = 0; i < k; i++)
        {
            string [] arrCoord = Console.ReadLine()!.Split(' ');
            arrX[i] = Convert.ToInt32(arrCoord[0]);
            arrY[i] = Convert.ToInt32(arrCoord[1]);
        }
        int minX = arrX.Min();
        int maxX = arrX.Max();
        int maxY = arrY.Max();
        int minY = arrY.Min();
        System.Console.WriteLine(minX + " " + minY + " " + maxX + " " + maxY);
    }
}
