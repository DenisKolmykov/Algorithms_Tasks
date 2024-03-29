﻿/*
Лёша сидел на лекции. Ему было невероятно скучно. Голос лектора казался таким далеким и незаметным...
Чтобы окончательно не уснуть, он взял листок и написал на нём свое любимое слово. 
Чуть ниже он повторил своё любимое слово, без первой буквы. 
Ещё ниже он снова написал своё любимое слово, но в этот раз без двух первых и последней буквы.
Тут ему пришла в голову мысль — времени до конца лекции все равно ещё очень много, 
почему бы не продолжить выписывать всеми возможными способами это слово 
без какой-то части с начала и какой-то части с конца?
После лекции Лёша рассказал Максу, как замечательно он скоротал время. 
Максу стало интересно посчитать, сколько букв каждого вида встречается у Лёши в листочке. 
Но к сожалению, сам листочек куда-то запропастился.
Макс хорошо знает любимое слово Лёши, а ещё у него не так много свободного времени, 
как у его друга, так что помогите ему быстро восстановить, 
сколько раз Лёше пришлось выписать каждую букву.

Формат ввода
На вход подаётся строка, состоящая из строчных латинских букв — любимое слово Лёши.
Длина строки лежит в пределах от 5 до 100 000 символов.

Формат вывода
Для каждой буквы на листочке Лёши, выведите её, а затем через двоеточие и 
пробел сколько раз она встретилась в выписанных Лёшей словах (см. формат вывода в примерах). 
Буквы должны следовать в алфавитном порядке. Буквы, не встречающиеся на листочке, выводить не нужно.

Ввод	Вывод
hello   e: 8
        h: 5
        l: 17
        o: 5
Пояснение к первому примеру. Если любимое Лёшино слово — "hello", 
то на листочке у Лёши будут выписаны следующие слова:
"hello", "hell", "ello", "hel", "ell", "llo", "he", "el", "ll", "lo", "h", "e", "l", "l", "o"
Среди этих слов 8 раз встречается буква "e", 
5 раз — буква "h", 17 раз — буква "l" и 5 раз буква "o".
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{

    static void Main()
    {
        string word = Console.ReadLine()!;
        int len = word.Length;
        char[] wordToChar = word.ToCharArray();

        SortedDictionary<char, ulong> countSortChars = new SortedDictionary<char, ulong>();

        ulong count = 0;
        for (int i = 0; i < len; i++)
        {
            /*
            int cursorEnd = len - 1;
            int cursorStart = 0;
            int count = 0;
            while (cursorEnd >= i & cursorStart <= i)
            {
                if (cursorEnd == i)
                {
                    cursorStart++;
                    cursorEnd = len - 1;
                }
                else
                {
                    cursorEnd--;
                }
                count++;
            }
            */
            // этот алгорит нахождения count - оптимальный
            ulong pos = Convert.ToUInt64(i + 1);
            count = Convert.ToUInt64((Convert.ToUInt64(len) - pos) * pos + pos);

            if (!countSortChars.ContainsKey(wordToChar[i]))
            {
                countSortChars[wordToChar[i]] = count;
            }
            else
            {
                countSortChars[wordToChar[i]] = countSortChars[wordToChar[i]] + count;
            }
        }
        for (int j = 0; j < countSortChars.Count; j++)
        {
            Console.WriteLine(countSortChars.ElementAt(j).Key + ": " + countSortChars.ElementAt(j).Value);
        }
    }
}
// решение выше не эффективно
// необходимо подсчет count делать за меньшее кол-во проходов!
// для index = 2 (поз.3) - первая буква "l":
//  
// {1len +  (len-1-i)=2} + 
// {1(len-1)+(len-1-i)=2}
// {1(len-2)+(len-1-i)=2}
// = (len-поз)*поз + поз !!!


