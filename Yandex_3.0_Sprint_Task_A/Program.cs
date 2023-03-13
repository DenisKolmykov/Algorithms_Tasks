/*
Для ускорения работы служб доставки под городом Длинноградом был прорыт тоннель, 
по которому ходит товарный поезд, останавливающийся на промежуточных станциях возле логистических центров. 
На станциях к концу поезда могут быть присоединены вагоны с определенными товарами, 
а также от его конца может быть отцеплено некоторое количество вагонов или может быть проведена ревизия, 
во время которой подсчитывается количество вагонов с определенным товаром.
Обработайте операции в том порядке, в котором они производились, и ответьте на запросы ревизии.

Формат ввода
В первой строке вводится число 
N(1≤N≤100000) — количество операций, произведенных над поездом.
В каждой из следующих N строк содержится описание операций. 
Каждая операция может иметь один из трех типов:add <количество вагонов> <название товара> — 
добавить в конец поезда <количество вагонов> с грузом <название товара>. 
Количество вагонов не может превышать 10^9
, название товара — одна строка из строчных латинских символов длиной до 20.
d
e
l
e
t
e
 <количество вагонов> — отцепить от конца поезда <количество вагонов>. Количество отцепляемых вагонов не превосходит длины поезда.
g
e
t
 <название товара> — определить количество вагонов с товаром <название товара> в поезде. Название товара — одна строка из строчных латинских символов длиной до 20.

Формат вывода
На каждый запрос о количестве вагонов с определенным товаром выведите одно число — количество вагонов с таким товаром. Запросы надо обрабатывать в том порядке, как они поступали.
Пример 1
Ввод	Вывод
7
add 10 oil
add 20 coal
add 5 oil
get coal
get oil
add 1 coal
get coal
20
15
21
Пример 2
Ввод	Вывод
6
add 5 oil
get coal
add 7 liverstock
delete 10
get oil
get liverstock
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_Sprint_A

{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()!);
        string[] input = new string[n];
        for (int i = 0; i < n; i++)
        {
            input[i] = Console.ReadLine()!.TrimEnd(' ');
        }
        Dictionary<string, ulong> train = new Dictionary<string, ulong>();
        Stack<string> stackNameTrain = new Stack<string>();
        Stack<ulong> stackCountTrain = new Stack<ulong>();

        for (int j = 0; j < n; j++)
        {
            string[] inputCommand = input[j].Split(' ');

            if (inputCommand[0].Equals("add"))
            {
                string nameAdd = inputCommand[2];
                ulong countTrain = Convert.ToUInt64(inputCommand[1]);
                if (countTrain != 0)
                {
                    if (!train.ContainsKey(nameAdd))
                    {
                        train[nameAdd] = countTrain;
                    }
                    else
                    {
                        train[nameAdd] = train[nameAdd] + countTrain;
                    }
                    stackNameTrain.Push(nameAdd);
                    stackCountTrain.Push(countTrain);
                }
            }
            if (inputCommand[0].Equals("delete"))
            {
                ulong del = Convert.ToUInt64(inputCommand[1]);
                while (del > 0)
                {
                    ulong temp = stackCountTrain.Pop();
                    string name = stackNameTrain.Peek();
                    if (del >= temp)
                    {
                        del = del - temp;
                        name = stackNameTrain.Pop();
                        train[name] = train[name] - temp;
                    }
                    else
                    {
                        temp = temp - del;
                        train[name] = train[name] - del;
                        stackCountTrain.Push(temp);
                        del = 0;
                    }
                }
            }
            if (inputCommand[0].Equals("get"))
            {
                string nameGet = inputCommand[1];
                if (!train.ContainsKey(nameGet)) Console.WriteLine("0");
                else Console.WriteLine(train[nameGet]);
            }
        }
    }
}

