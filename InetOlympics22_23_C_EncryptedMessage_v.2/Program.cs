/*
C. Зашифрованное сообщение
ограничение по времени на тест1 секунда
ограничение по памяти на тест256 мегабайт

Во время расследования Бенуа Бланк обнаружил подозрительную записку, оставленную кем-то на месте преступления. 
Текст в записке 𝑡 на первый взгляд не имел никакого смысла, но после долгого анализа записки Бланк пришел к выводу, 
что сообщение осмысленно, но зашифровано.
Шифр, использованный в записке, довольно нестандартный. 
Каждое слово было зашифровано отдельно, после чего все слова были склеены вместе, 
чтобы не было понятно, где какое слово начинается и заканчивается. 
Поэтому первым делом детектив решил восстановить, где находятся границы слов, а после уже взяться за их расшифровку.

Известно, что текст на записке был получен следующим образом: 
набор зашифрованных слов 𝑤1,𝑤2,…,𝑤𝑛 был продублирован в развернутом виде, 
после чего выписан без пробелов. 
Иными словами, 𝑡=(𝑤1+…+𝑤𝑛)+(𝑤𝑛+…+𝑤1) , где знак '+' обозначает конкатенацию.

Помогите Бенуа Бланку восстановить исходный набор зашифрованных слов. 
Поскольку Бланк считает, что сообщение содержало много слов, из всех способов разбить 𝑡
на слова в соответствии с условием выберите тот, в котором количество слов максимально.

Входные данные
Во вводе дана единственная строка 𝑡 из маленьких латинских букв — зашифрованный текст (1⩽|𝑡|⩽106).

Выходные данные
В первой строке выведите целое число 𝑛 — максимально возможное количество слов в зашифрованном тексте. 
В следующих 𝑛 строках перечислите сами слова по одному на каждой строке.

Если ответов с максимальным 𝑛 несколько, выведите любой из них.
Гарантируется, что ответ существует.

Примеры:
входные данные
abaccaba
выходные данные
4
a
b
a
c
----
входные данные
guesswhoitisisitwhoguess
выходные данные
4
guess
who
it
is
---
входные данные
xaabaababaaabxaa
выходные данные
5
xaa
b
a
a
ba
--
*/


//using System.Linq;

string GetFindWord(string encryptedMessage)
{
    int length = encryptedMessage.Length;
    char firstLetterInWord = encryptedMessage[0];
    string word = string.Empty;
    int i = length - 1;

    while (i > 0)
    {
        if (firstLetterInWord.Equals(encryptedMessage[i]))
        {
            for (int j = 0; j < length - i; j++)
            {
                word = word + encryptedMessage[j];
            }
            i = -1;
        }
        i--;
    }
    return word;
}


string GetFinalMessage(string encryptedMessage)
{
    string word = string.Empty;
    string finalMessage = string.Empty;

    while (encryptedMessage.Length > 0)
    {
        word = GetFindWord(encryptedMessage);
        encryptedMessage = encryptedMessage.Substring(0, encryptedMessage.Length - word.Length);
        encryptedMessage = encryptedMessage.Substring(word.Length);
        finalMessage = finalMessage + word + " ";
    }
    return finalMessage;
}

void PrintWordsAndCount(string finalMessage)
{
    string[] finalWords = finalMessage.Split(" ").ToArray();
    Console.WriteLine(finalWords.Length - 1); // "-1" - because add an extra space to string finalWords

    for (int i = 0; i < finalWords.Length - 1; i++)
        Console.WriteLine(finalWords[i]);
}

DateTime dt = DateTime.Now;
//Console.Clear();

// Console.Write("Inter encrypted message (string without space): ");
// string encryptedMessage = Console.ReadLine()!;

string encryptedMessage = "xaabaababaaabxaa";

//Console.WriteLine(encryptedMessage);
string finalMessage = GetFinalMessage(encryptedMessage);

PrintWordsAndCount(finalMessage);

Console.WriteLine(DateTime.Now - dt);