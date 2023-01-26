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



int GetFindIndexOfWord(string encryptedMessage, int length, int wordPosition)
{
    char firstLetterInWord = encryptedMessage[wordPosition];
    int i = length - 1 - wordPosition;
    int newWordIndex = 0;

    while (i > 0)
    {
        if (firstLetterInWord.Equals(encryptedMessage[i]))
        {
            newWordIndex = length - i;
            i = -1;
        }
        i--;
    }
    return newWordIndex;
}

int[] FillNumericArrOfIndexOfWord(string encryptedMessage)
{
    int wordPosition = 0;
    string stringOfIndexOfWords = string.Empty;
    int length = encryptedMessage.Length;

    while (wordPosition < length / 2)
    {
        wordPosition = GetFindIndexOfWord(encryptedMessage, length, wordPosition);
        stringOfIndexOfWords = stringOfIndexOfWords + wordPosition + " ";
    }

    string[] stringArrayOfIndexOfWord = stringOfIndexOfWords.Split(" ").ToArray();
    int[] numericArrayOfIndexOfWord = new int[stringArrayOfIndexOfWord.Length - 1];

    for (int i = 0; i < numericArrayOfIndexOfWord.Length; i++)
    {
        numericArrayOfIndexOfWord[i] = Convert.ToInt32(stringArrayOfIndexOfWord[i]);
    }
    Console.WriteLine(numericArrayOfIndexOfWord.Length);
    return numericArrayOfIndexOfWord;
}

void PrintResults(string encryptedMessage, int[] arrOfIndex)
{
    int len = arrOfIndex.Length;
    int firstIndexOfNewWord = 0;

    for (int i = 0; i < len; i++)
    {
        string word = string.Empty;
        for (int j = firstIndexOfNewWord; j < arrOfIndex[i]; j++)
        {
            word = word + encryptedMessage[j];
        }

        Console.WriteLine(word);
        firstIndexOfNewWord = arrOfIndex[i];
    }
}

DateTime dt = DateTime.Now;

string encryptedMessage = "xaabaababaaabxaa";

int[] arrOfIndex = FillNumericArrOfIndexOfWord(encryptedMessage);

PrintResults(encryptedMessage, arrOfIndex);

Console.WriteLine(DateTime.Now - dt);