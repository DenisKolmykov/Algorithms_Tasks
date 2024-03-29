﻿/*
Петя и Вася — одноклассники и лучшие друзья, поэтому они во всём помогают друг другу. 
Завтра у них контрольная по математике, и учитель подготовил целых K вариантов заданий.

В классе стоит один ряд парт, за каждой из них (кроме, возможно, последней) 
на контрольной будут сидеть ровно два ученика. 
Ученики знают, что варианты будут раздаваться строго по порядку: 
правый относительно учителя ученик первой парты получит вариант 1, левый — вариант 2, 
правый ученик второй парты получит вариант 3 (если число вариантов больше двух) и т.д. 
Так как K может быть меньше чем число учеников N, то после варианта K снова выдаётся вариант 1. 
На последней парте в случае нечётного числа учеников используется только место 1.

Петя самым первым вошёл в класс и сел на своё любимое место. 
Вася вошёл следом и хочет получить такой же вариант, что и Петя, при этом сидя к нему как можно ближе. 
То есть между ними должно оказаться как можно меньше парт, 
а при наличии двух таких мест с равным расстоянием от Пети Вася сядет позади Пети, 
а не перед ним. Напишите программу, которая подскажет Васе, 
какой ряд и какое место (справа или слева от учителя) ему следует выбрать. 
Если же один и тот же вариант Вася с Петей писать не смогут, то выдайте одно число  - 1.

Формат ввода
В первой строке входных данных находится количество учеников в классе 2 ≤ N ≤ 109. 
Во второй строке — количество подготовленных для контрольной вариантов заданий 2 ≤ K ≤ N. 
В третьей строке — номер ряда, на который уже сел Петя, в четвёртой — цифра 1, 
если он сел на правое место, и 2, если на левое.

Формат вывода
Если Вася никак не сможет писать тот же вариант, что и Петя, то выведите  - 1. 
Если решение существует, то выведите два числа — номер ряда, на который следует сесть Васе, 
и 1, если ему надо сесть на правое место, или 2, если на левое. 
Разрешается использовать только первые N мест в порядке раздачи вариантов.

Пример 1
Ввод	Вывод
25      2 2
2
1
2

Пример 2
Ввод	Вывод
25      -1
13
7
1

Примечания
В первом примере вариантов 2, поэтому наилучшее место для Васи находится сразу за Петей. 
Во втором примере Петя будет единственным, кто получит вариант 13.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Task_04
{
    static void Main()
    {
        int studentsCount = Convert.ToInt32(Console.ReadLine()!);
        int variantCount = Convert.ToInt32(Console.ReadLine()!);
        int deskPetya = Convert.ToInt32(Console.ReadLine()!);
        int placePetya = Convert.ToInt32(Console.ReadLine()!);
        
        /* можно через массив - но большие значания вводных и ограничения памяти и скорости
        int n = studentsCount;
        if (studentsCount % 2 != 0) n = studentsCount + 1;
        
        int[,] classroom = new int[n, 3]; //массив для распредления вариантов по партам
        int v = 1;
        for (int i = 1; i <= n; i = i + 2)
        {
            if (v > variantCount)
            {
                v = 1;
            }
            classroom[i, 1] = v;
            classroom[i, 2] = v + 1;
            v = v + 2;
        }
        
        //int variantPetya = classroom[deskPetya, placePetya];
        */

        int placePetyaCount = (deskPetya - 1) * 2 + placePetya;
        System.Console.WriteLine("placePetyaCount =" + placePetyaCount);

        int findPlaceForvardCount = 0;
        int findDeskForvard = 0;
        int findPlaceForvard = 0;

        int findPlacePastCount = 0;
        int findDeskPast = 0;
        int findPlacePast = 0;

        int resutDesk = -1;
        int resultPlace = 0;

        int variantPetya = placePetyaCount;
        if (variantCount < placePetyaCount)
        {
            if (placePetyaCount % variantCount == 0) variantPetya = variantCount;
            else variantPetya = placePetyaCount % variantCount;
        }
        System.Console.WriteLine("variantPetya = " + variantPetya);

        findPlaceForvardCount = placePetyaCount - variantCount; //variantPetya;//variantCount
        findDeskForvard = findPlaceForvardCount / 2 + findPlaceForvardCount % 2;
        if (findPlaceForvardCount % 2 == 0) findPlaceForvard = 2;
        else findPlaceForvard = 1;
        System.Console.WriteLine(findDeskForvard + " " + findPlaceForvard);

        findPlacePastCount = placePetyaCount + variantCount;//variantPetya; //variantCount
        findDeskPast = findPlacePastCount / 2 + findPlacePastCount % 2;
        if (findPlacePastCount % 2 == 0) findPlacePast = 2;
        else findPlacePast = 1;
        System.Console.WriteLine(findDeskPast + " " + findPlacePast);
        System.Console.WriteLine("findPlacePastCount = " + findPlacePastCount + ", " + findPlaceForvardCount);

        if ((findDeskForvard < 1) && (findPlacePastCount <= studentsCount))
        {
            resutDesk = findDeskPast;
            resultPlace = findPlacePast;
            System.Console.WriteLine("взяли из 1го IF");
        }
        else if ((findPlacePastCount > studentsCount) && (findDeskForvard >= 1))
        {
            resutDesk = findDeskForvard;
            resultPlace = findPlaceForvard;
            System.Console.WriteLine("взяли из 2го IF");
        }
        else if (findDeskForvard < 1 && findPlacePastCount > studentsCount)
        {
            resutDesk = -1;
            System.Console.WriteLine("взяли из 3го IF");
        }
        else if (((deskPetya - findDeskForvard) >= (findDeskPast - deskPetya)))
        {
            resutDesk = findDeskPast;
            resultPlace = findPlacePast;
            System.Console.WriteLine("взяли из 4го IF");
        }

        else if ( ((deskPetya - findDeskForvard) < (findDeskPast - deskPetya)))
        {
            resutDesk = findDeskForvard;
            resultPlace = findPlaceForvard;
            System.Console.WriteLine("взяли из 5го IF");
        }

        if (resutDesk == -1) Console.WriteLine("-1");
        else Console.WriteLine(resutDesk + " " + resultPlace);
    }
}
