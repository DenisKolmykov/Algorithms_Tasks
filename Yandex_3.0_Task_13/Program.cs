/*
 постфиксной записи (или обратной польской записи) операция записывается после двух операндов. Например, сумма двух чисел A и B записывается как A B +. Запись B C + D * обозначает привычное нам (B + C) * D, а запись A B C + D * + означает A + (B + C) * D. Достоинство постфиксной записи в том, что она не требует скобок и дополнительных соглашений о приоритете операторов для своего чтения.
Формат ввода
В единственной строке записано выражение в постфиксной записи, содержащее цифры и операции +, -, *. Цифры и операции разделяются пробелами. В конце строки может быть произвольное количество пробелов.
Формат вывода
Необходимо вывести значение записанного выражения.
Пример
Ввод	        Вывод
8 9 + 1 7 - *   -102

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{

    static void Main()
    {
        string[] reversPolRec = Console.ReadLine()!.Split(' ');
        int len = reversPolRec.Length;
        double result = 0;

        Stack<double> numbers = new Stack<double>();

        if (reversPolRec[0].Equals("-") || reversPolRec[0].Equals("+")) numbers.Push(0);
        if (reversPolRec[0].Equals("*")) numbers.Push(1);
        
        for (int i = 0; i < len; i++)
        {
            if (double.TryParse(reversPolRec[i], out _))
            {
                double x = Convert.ToDouble(reversPolRec[i]);
                numbers.Push(x);
            }

            else
            {
                double firstNum = numbers.Peek();
                numbers.Pop();
                if (reversPolRec[i].Equals("-")) result = numbers.Peek() - firstNum;
                if (reversPolRec[i].Equals("+")) result = numbers.Peek() + firstNum;
                if (reversPolRec[i].Equals("*")) result = numbers.Peek() * firstNum;
               
                numbers.Pop();
                numbers.Push(result);
            }
            
        }
        Console.WriteLine(result);
    }
}
