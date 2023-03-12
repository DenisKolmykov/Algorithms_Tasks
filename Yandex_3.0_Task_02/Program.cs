/*
Красотой строки назовем максимальное число идущих подряд одинаковых букв. 
(красота строки abcaabdddettq равна 3)

Сделайте данную вам строку как можно более красивой, 
если вы можете сделать не более k операций замены символа.

Формат ввода
В первой строке записано одно целое число k (0 ≤ k ≤ 109)

Во второй строке дана непустая строчка S (|S| ≤ 2 ⋅ 105). 
Строчка S состоит только из маленьких латинских букв.

Формат вывода
Выведите одно число — максимально возможную красоту строчки, которую можно получить.

Пример 1
Ввод	Вывод
2       4
abcaz

Пример 2
Ввод	Вывод
2       3
helto

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_02
{
    static void Main()
    {
        int k = Convert.ToInt32(Console.ReadLine()!);
        string inputStr = Console.ReadLine()!.TrimEnd(' ');

        Dictionary<char, int> dictionaryStr = inputStr.GroupBy(x => x)
               .ToDictionary(x => x.Key, x => x.Count());
        
        int resLen = 0;
        int length = inputStr.Length;
        foreach (KeyValuePair<char, int> keyValuePair in dictionaryStr)
        {
            char a = keyValuePair.Key;
            //char a='a';

            int j = 0;
            int repl = k;
        
            for (int i = 0; i < length; i++)
            {
                int len = 0;

                while (repl >= 0 && j < length)
                {
                    System.Console.WriteLine("compare "+a+" and "+inputStr[j]);
                    if (!a.Equals(inputStr[j]))
                    {
                        repl--;
                    }
                    j++;
                    System.Console.WriteLine("after compare: k= "+repl);
                }
                if (j==length && inputStr[j-1]==a) j=length+1;
                len = j-i-1;
                System.Console.WriteLine("len = "+ len+" resLen= "+resLen);
                if (resLen < len) resLen = len;
                System.Console.WriteLine("after if: len = "+ len+" resLen= "+resLen);
                
                System.Console.WriteLine("before if k= "+repl);
                if (!a.Equals(inputStr[i]))
                    repl++;
                System.Console.WriteLine("after if k = "+repl);
            }
            System.Console.WriteLine("---exit for---");
        }
        Console.WriteLine(resLen);  
        System.Console.WriteLine(length); 
    }
}