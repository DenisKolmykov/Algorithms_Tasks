/*
Рассмотрим последовательность, состоящую из круглых, квадратных и фигурных скобок. 
Программа дожна определить, является ли данная скобочная последовательность правильной. 
Пустая последовательность явлется правильной. 
Если A – правильная, то последовательности (A), [A], {A} – правильные. 
Если A и B – правильные последовательности, то последовательность AB – правильная.

Формат ввода
В единственной строке записана скобочная последовательность, содержащая не более 100000 скобок.

Формат вывода
Если данная последовательность правильная, то программа должна вывести строку yes, иначе строку no.

Пример 1
Ввод	Вывод
()[]    yes

Пример 2
Ввод	Вывод
([)]    no

Пример 3
Ввод	Вывод
(       no

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{

    static void Main()
    {
        string brackets = Console.ReadLine()!;
        //char[] bracketsToChar = brackets.ToCharArray();
        Dictionary<int, int> isOpen = new Dictionary<int, int>
                                                        {
                                                         {91, 1}, {93, -1}, {123,1},{125,-1},{40,1},{41,-1}
                                                        };
        Stack<int> brStack = new Stack<int>();

        int i = 0;
        while (i < brackets.Length)
        {
            if (brStack.Count() > 0)
            {
                if ((brStack.Peek() / 10 == (int)brackets[i] / 10) && (isOpen[(int)brackets[i]] == -1))
                {
                    brStack.Pop();
                }
                else
                {
                    if ((isOpen[(int)brackets[i]] == -1))
                    {
                        Console.WriteLine("no");
                        return; // выходим из цикла
                    }
                    else
                    {
                        brStack.Push((int)brackets[i]);
                    }
                }
            }
            else
            {
                if (isOpen[(int)brackets[i]] == 1)
                {
                    brStack.Push((int)brackets[i]);
                }
                else
                {
                    Console.WriteLine("no");
                    return; // выходим из цикла
                }
            }
        i++;
        }
        if (brStack.Count() == 0) Console.WriteLine("yes");
        else Console.WriteLine("no");

    }
}


