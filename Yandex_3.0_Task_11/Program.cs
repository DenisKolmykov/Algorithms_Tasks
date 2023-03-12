/*
Научитесь пользоваться стандартной структурой данных stack для целых чисел. 
Напишите программу, содержащую описание стека и моделирующую работу стека, 
реализовав все указанные здесь методы. Программа считывает последовательность команд и 
в зависимости от команды выполняет ту или иную операцию. 
После выполнения каждой команды программа должна вывести одну строчку. 
Возможные команды для программы:

push n
Добавить в стек число n (значение n задается после команды). Программа должна вывести ok.

pop
Удалить из стека последний элемент. Программа должна вывести его значение.

back
Программа должна вывести значение последнего элемента, не удаляя его из стека.

size
Программа должна вывести количество элементов в стеке.

clear
Программа должна очистить стек и вывести ok.

exit
Программа должна вывести bye и завершить работу.

Перед исполнением операций back и pop программа должна проверять, 
содержится ли в стеке хотя бы один элемент. 
Если во входных данных встречается операция back или pop, и при этом стек пуст, 
то программа должна вместо числового значения вывести строку error.

Формат ввода
Вводятся команды управления стеком, по одной на строке

Формат вывода
Программа должна вывести протокол работы стека, по одному сообщению на строке
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{

    static void Main()
    {
        Stack<int> myStack = new Stack<int>();
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
                myStack.Push(n);
                Console.WriteLine("ok");
            }
            if (com.Equals("pop"))
            {
                if (myStack.Count > 0)
                {
                    Console.WriteLine(myStack.Pop());
                }
                else Console.WriteLine("error");
            }
            if (com.Equals("back"))
            {
                if (myStack.Count > 0)
                {
                    Console.WriteLine(myStack.Peek());
                }
                else Console.WriteLine("error");
            }
            if (com.Equals("size"))
            {
                Console.WriteLine(myStack.Count);
            }
            if (com.Equals("clear"))
            {
                myStack.Clear();
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
