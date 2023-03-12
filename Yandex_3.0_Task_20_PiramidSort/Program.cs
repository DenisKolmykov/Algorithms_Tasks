/*
Отсортируйте данный массив. Используйте пирамидальную сортировку.

Формат ввода
Первая строка входных данных содержит количество элементов в массиве N, N ≤ 105. 
Далее задаются N целых чисел, не превосходящих по абсолютной величине 109.

Формат вывода
Выведите эти числа в порядке неубывания.

Пример 1
Ввод	Вывод
1       1 
1

Пример 2
Ввод	Вывод
2       1 3
3 1
 
*/


using System;
using System.Collections.Generic;
using System.Linq;
public class Test
{
    static void Main()
    {
        //List<long> arrNum = new List<long>(n);

        string arrLen = Console.ReadLine()!;
        int n = Convert.ToInt32(arrLen); // кол-во чисел в массиве
        long [] arrNum = new long [n];
        //string[] arrNumStr = Console.ReadLine()!.Split(' ');
        arrNum = Array.ConvertAll(Console.ReadLine()!.Split(' '),Convert.ToInt64);
        //List<long> arrNum = new List<long>();
        //arrNum.Capacity=n;
        //arrNum.Add(Convert.ToInt64(Console.ReadLine()!.Split(' ')));
        /*
        for (int i = 0; i < n; i++)
        {
            //arrNum.Add(Convert.ToInt64(arrNumStr[i]));
            arrNum[i]=Convert.ToInt64(arrNumStr[i]);
        }
        */
        //long[] sortArr = new long[n];
        int k = n;


        //for (int c = 0; c < n; c++)
        while ((k - 2) / 2 >= 0)
        {
            //k = arrNum.Count();
            System.Console.WriteLine("k= " + k );
            if (k > 1)
            {

                //int index = (k - 2) / 2;

                System.Console.WriteLine("index= " + (k - 2) / 2);

                //for (int j = (k - 2) / 2; j >= 0; j--)
                int j = (k - 2) / 2;
                while (j >= 0)
                {
                    System.Console.WriteLine("j= " + j);

                    //int rigthIndex = 2 * j + 2;
                    //int leftIndex = 2 * j + 1;
                    int compare = 2 * j + 1;
                    if ((2 * j + 2) <= (k - 1)) // проверка  - есть ли второй лист или только левый
                    {
                        System.Console.WriteLine("перед while: leftIndex= " + (2 * j + 1) + ", rigthIndex= " + (2 * j + 2));
                        if (arrNum[2 * j + 1] < arrNum[2 * j + 2]) compare = 2 * j + 2;
                    }

                    //while (compare < k & arrNum[j] > arrNum[compare])
                    //{
                    System.Console.WriteLine("вошли в while");
                    //leftIndex = 2 * j + 1;
                    /*
                    if ((2 * j + 2) <= (k - 1)) // проверка  - есть ли второй лист или только левый
                    {
                        //rigthIndex = 2 * j + 2;
                        System.Console.WriteLine("leftIndex= " + (2 * j + 1) + ", rigthIndex= " + (2 * j + 2));
                        if (arrNum[2 * j + 1] > arrNum[2 * j + 2]) compare = 2 * j + 2;
                        else compare = 2 * j + 1;
                        System.Console.WriteLine(" после проверки compare= " + compare);
                    }
                    */
                    if ((compare < k & arrNum[j] < arrNum[compare]))
                    {
                        System.Console.WriteLine("до свопа: arrNum[j]= " + arrNum[j] + ", arrNum[compare]= " + arrNum[compare]);
                        (arrNum[j], arrNum[compare]) = (arrNum[compare], arrNum[j]);

                        System.Console.WriteLine("после свопа");

                        System.Console.WriteLine("после свопа: arrNum[j]= " + arrNum[j] + ", arrNum[compare]= " + arrNum[compare]);
                        //index = (j - 2) / 2;
                        //rigthIndex = 2 * index + 2;

                        System.Console.WriteLine("после свопа (перед выходом/новым While): " + string.Join(" ", arrNum));
                    }
                    j--;
                }
            }
            //sortArr[c] = arrNum[0];
            (arrNum[k - 1], arrNum[0]) = (arrNum[0], arrNum[k - 1]);
            //arrNum.RemoveAt(k - 1);
            k--;
            System.Console.WriteLine("после удаления: " + string.Join(" ", arrNum));
        }
        System.Console.WriteLine(string.Join(" ", arrNum));
    }
}
