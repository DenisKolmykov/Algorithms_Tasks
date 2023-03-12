/*
В этой задаче вам необходимо самостоятельно 
(не используя соответствующие классы и функции стандартной библиотеки) 
организовать структуру данных Heap для хранения целых чисел, 
над которой определены следующие операции: 
a) Insert(k) – добавить в Heap число k ; 
b) Extract достать из Heap наибольшее число (удалив его при этом).

Формат ввода
В первой строке содержится количество команд N (1 ≤ N ≤ 100000), 
далее следуют N команд, каждая в своей строке. 
Команда может иметь формат: “0 <число>” или “1”, обозначающий, 
соответственно, операции Insert(<число>) и Extract. 
Гарантируется, что при выполенении команды Extract в структуре находится по крайней мере один элемент.

Формат вывода
Для каждой команды извлечения необходимо отдельной строкой вывести число, 
полученное при выполнении команды Extract.

Пример 1
Ввод	    Вывод
2           10000
0 10000
1

Пример 2
Ввод	    Вывод
14          345
0 1         4346
0 345       2435
1           365
0 4346      235
1           5
0 2435      1
1
0 235
0 5
0 365
1
1
1
1
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    static void Main()
    {
        List<int> myHeap = new List<int>();
        List<int> myExtract = new List<int>();

        string com = string.Empty;

        string countComStr = Console.ReadLine()!;
        int n = Convert.ToInt32(countComStr); // кол-во команд
        int num = 0; // число для добавления

        for (int c = 1; c <= n; c++) // ввод комманд
        {
            string[] command = Console.ReadLine()!.Split(' ');
            int len = command.Length;

            if (len == 1)
            {
                com = command[0];
                if (com.Equals("0"))
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                com = command[0];
                num = Convert.ToInt32(command[1]);
            }

            if (com.Equals("0")) // Insert
            {
                if (myHeap.Count > 0)
                {
                    myHeap.Add(num);
                    System.Console.WriteLine("до замены: " + string.Join(", ", myHeap));
                    int indexTemp = myHeap.Count - 1;
                    System.Console.WriteLine("ndexTemp= " + indexTemp + " (indexTemp - 1) / 2=" + (indexTemp - 1) / 2);
                    System.Console.WriteLine("myHeap[indexTemp]=" + myHeap[indexTemp] + " myHeap[(indexTemp - 1) / 2]= " + myHeap[(indexTemp - 1) / 2]);
                    while ((myHeap[indexTemp] > myHeap[(indexTemp - 1) / 2]) & ((indexTemp) > 0))
                    {
                        (myHeap[indexTemp], myHeap[(indexTemp - 1) / 2]) = (myHeap[(indexTemp - 1) / 2], myHeap[indexTemp]);
                        System.Console.WriteLine("после замены: " + string.Join(", ", myHeap));
                        indexTemp = (indexTemp - 1) / 2;
                    }
                }
                else
                {
                    myHeap.Add(num);
                    System.Console.WriteLine("добавили элемент в пустой массив: " + string.Join(", ", myHeap));
                }
                System.Console.WriteLine("КУЧА после завершения добавления: " + string.Join(", ", myHeap));

            }

            if (com.Equals("1")) // Extract
            {
                myExtract.Add(myHeap[0]);
                System.Console.WriteLine("записали в массив для удаления число: " + myHeap[0]);
                System.Console.WriteLine("КУЧА до свопа:" + string.Join(", ", myHeap));
                (myHeap[myHeap.Count - 1], myHeap[0]) = (myHeap[0], myHeap[myHeap.Count - 1]);
                System.Console.WriteLine("КУЧА после свопа:" + string.Join(", ", myHeap));
                System.Console.WriteLine("удаляем элемент с индексом: " + (myHeap.Count - 1) + " эл= " + myHeap[myHeap.Count - 1]);
                myHeap.RemoveAt(myHeap.Count - 1);
                System.Console.WriteLine("КУЧА после удаления и до просеивания:" + string.Join(", ", myHeap));
                if (myHeap.Count > 1)
                {
                    int indexTempDelete = 0;
                    int leftIndex = 2 * indexTempDelete + 1;
                    int rigthIndex = 0;
                    int compare = leftIndex;
                    if ((2 * indexTempDelete + 2) <= (myHeap.Count - 1)) // проверка  - если второй лист или только левый
                    {
                        rigthIndex = 2 * indexTempDelete + 2;
                        if (myHeap[leftIndex] < myHeap[rigthIndex]) compare = rigthIndex;
                    }
                    while (compare <= (myHeap.Count - 1) && myHeap[indexTempDelete] < myHeap[compare])
                    {

                        System.Console.WriteLine("вошли в цикл проcеивания");
                        
                        System.Console.WriteLine("myHeap[leftIndex]=" + myHeap[leftIndex] + "<?myHeap[rigthIndex]=" + myHeap[rigthIndex] + ", compare= " + compare);
                        System.Console.WriteLine("куча в процессе просеивания до свопа: " + string.Join(", ", myHeap));
                        (myHeap[indexTempDelete], myHeap[compare]) = (myHeap[compare], myHeap[indexTempDelete]);

                        System.Console.WriteLine("куча в процессе просеивания после свопа: " + string.Join(", ", myHeap));
                        indexTempDelete = compare;

                        leftIndex = 2 * indexTempDelete + 1;
                        compare = leftIndex;
                        if ((2 * indexTempDelete + 2) <= (myHeap.Count - 1)) // проверка  - если второй лист или только левый
                        {
                            rigthIndex = 2 * indexTempDelete + 2;
                            if (myHeap[leftIndex] < myHeap[rigthIndex]) compare = rigthIndex;
                        }
                        System.Console.WriteLine("indexDelete после просеивания=" + indexTempDelete + " , compare =" + compare);

                    }

                }
                System.Console.WriteLine("КУЧА после просеивания :" + string.Join(", ", myHeap));
            }
        }
        for (int j = 0; j < myExtract.Count(); j++)
        {
            Console.WriteLine(myExtract[j]);
        }
    }
}