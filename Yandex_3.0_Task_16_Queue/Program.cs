/*
Научитесь пользоваться стандартной структурой данных queue для целых чисел. 
Напишите программу, содержащую описание очереди и моделирующую работу очереди, 
реализовав все указанные здесь методы. 
Программа считывает последовательность команд и в зависимости от команды выполняет 
ту или иную операцию. После выполнения каждой команды программа должна вывести одну строчку.

Возможные команды для программы:
push n
Добавить в очередь число n (значение n задается после команды). Программа должна вывести ok.
pop
Удалить из очереди первый элемент. Программа должна вывести его значение.
front
Программа должна вывести значение первого элемента, не удаляя его из очереди.
size
Программа должна вывести количество элементов в очереди.
clear
Программа должна очистить очередь и вывести ok.
exit
Программа должна вывести bye и завершить работу.

Перед исполнением операций front и pop программа должна проверять, содержится ли в очереди хотя бы один элемент. 
Если во входных данных встречается операция front или pop, и при этом очередь пуста, то программа должна вместо числового значения вывести строку error.

Формат ввода
Вводятся команды управления очередью, по одной на строке

Формат вывода
Требуется вывести протокол работы очереди, по одному сообщению на строке
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{

    static void Main()
    {
        Queue<int> myQueue = new Queue<int>();
        string com = string.Empty;
        int n = 0;
        int i = 1;

        while (i > 0)
        {
            string[] command = Console.ReadLine()!.Split(' ');
            int len = command.Length;

            if (len == 1)
            {
                com = command[0];
                if (com.Equals("push"))
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                com = command[0];
                n = Convert.ToInt32(command[1]);
            }

            if (com.Equals("push"))
            {
                myQueue.Enqueue(n);
                Console.WriteLine("ok");
            }
            if (com.Equals("pop"))
            {
                if (myQueue.Count > 0)
                {
                    Console.WriteLine(myQueue.Dequeue());
                }
                else Console.WriteLine("error");
            }
            if (com.Equals("front"))
            {
                if (myQueue.Count > 0)
                {
                    Console.WriteLine(myQueue.Peek());
                }
                else Console.WriteLine("error");
            }
            if (com.Equals("size"))
            {
                Console.WriteLine(myQueue.Count);
            }
            if (com.Equals("clear"))
            {
                myQueue.Clear();
                Console.WriteLine("ok");
            }
            if (com.Equals("exit"))
            {
                Console.WriteLine("bye");
                i = 0;
            }
        }
    }
}