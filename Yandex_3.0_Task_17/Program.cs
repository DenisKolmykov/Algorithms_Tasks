/*
В игре в пьяницу карточная колода раздается поровну двум игрокам. 
Далее они вскрывают по одной верхней карте, и тот, чья карта старше, забирает себе обе вскрытые карты,
которые кладутся под низ его колоды. Тот, кто остается без карт – проигрывает. 
Для простоты будем считать, что все карты различны по номиналу, а также, 
что самая младшая карта побеждает самую старшую карту ("шестерка берет туза"). 
Игрок, который забирает себе карты, сначала кладет под низ своей колоды карту первого игрока, 
затем карту второго игрока (то есть карта второго игрока оказывается внизу колоды). 

Напишите программу, которая моделирует игру в пьяницу и определяет, кто выигрывает. 
В игре участвует 10 карт, имеющих значения от 0 до 9, большая карта побеждает меньшую, 
карта со значением 0 побеждает карту 9.

Формат ввода
Программа получает на вход две строки: первая строка содержит 5 чисел, 
разделенных пробелами — номера карт первого игрока, вторая – аналогично 5 карт второго игрока. 
Карты перечислены сверху вниз, то есть каждая строка начинается с той карты, 
которая будет открыта первой.

Формат вывода
Программа должна определить, кто выигрывает при данной раздаче, и 
вывести слово first или second, после чего вывести количество ходов, сделанных до выигрыша. 
Если на протяжении 106 ходов игра не заканчивается, программа должна вывести слово botva.

Пример 1
Ввод	    Вывод
1 3 5 7 9   second 5
2 4 6 8 0

Пример 2
Ввод	    Вывод
2 4 6 8 0   first 5
1 3 5 7 9

Пример 3
Ввод	    Вывод
1 7 3 9 4   second 23
5 8 0 2 6

*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    static void Main()
    {
        string[] firstPlayerStr = Console.ReadLine()!.Split(' ');
        string[] secondPlayerStr = Console.ReadLine()!.Split(' ');

        Queue<int> firstPlayer = new Queue<int>();
        Queue<int> secondPlayer = new Queue<int>();
        for (int j = 0; j < 5; j++)
        {
            firstPlayer.Enqueue(Convert.ToInt32(firstPlayerStr[j]));
            secondPlayer.Enqueue(Convert.ToInt32(secondPlayerStr[j]));
        }

        int count = 0;
        while (firstPlayer.Count() < 0 || secondPlayer.Count() < 0 || count < 1000000)
        {
            if (firstPlayer.Count() == 0 || secondPlayer.Count() == 0) break;

            int cardFirstPlayer = firstPlayer.Dequeue();
            int cardSecondPlayer = secondPlayer.Dequeue();

            if (cardFirstPlayer == 0 && cardSecondPlayer == 9)
            {
                cardFirstPlayer = 10;
            }
            if (cardFirstPlayer == 9 && cardSecondPlayer == 0)
            {
                cardSecondPlayer = 10;
            }

            if (cardFirstPlayer < cardSecondPlayer)
            {
                if (cardSecondPlayer == 10) cardSecondPlayer = 0;

                secondPlayer.Enqueue(cardFirstPlayer);
                secondPlayer.Enqueue(cardSecondPlayer);
            }
            else
            {
                if (cardFirstPlayer == 10) cardFirstPlayer = 0;
                firstPlayer.Enqueue(cardFirstPlayer);
                firstPlayer.Enqueue(cardSecondPlayer);
            }
            count++;
        }

        if (count >= 1000000)
        {
            Console.WriteLine("botva");
        }
        else if (firstPlayer.Count == 0)
        {
            Console.WriteLine("second " + count);
        }
        else if (secondPlayer.Count == 0)
        {
            Console.WriteLine("first " + count);
        }
    }
}