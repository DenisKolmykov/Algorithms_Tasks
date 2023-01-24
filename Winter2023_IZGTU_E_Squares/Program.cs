/*
E. Квадраты
ограничение по времени на тест0.25 секунд
ограничение по памяти на тест4 мегабайта

Обратите внимание на нестандартное ограничение по памяти в этой задаче.

Дана таблица размера 𝑛×𝑚
, каждая ячейка которой покрашена либо в чёрный, либо в белый цвет. 
Найдите количество квадратов, состоящих полностью из чёрных ячеек. Размеры квадратов могут быть любыми.

Входные данные
Первая строка содержит два целых числа 𝑛 и 𝑚 (3⩽𝑛,𝑚⩽3000) — количество строк и столбцов таблицы соответственно. 
Далее следуют 𝑛 строк содержащие по 𝑚 символов «#» (чёрный цвет) и «.» (белый цвет).

Выходные данные
Выведите одно целое число — количество квадратов, состоящих полностью из чёрных ячеек.

входные данные
3 3
#.#
.##
###
выходные данные
8
*/

string GetPaintRow(int row, int columns) // построчный ввод символов для "закраски
{
    char cellInRowForPaint;
    string paintRow = string.Empty;

    Console.Write($"Введите закраску ячеек (`#`-черный,`.` - белый) по строке {row}: ");

    for (int i = 0; i < columns; i++)
    {
        do
        {
            cellInRowForPaint = Console.ReadKey(true).KeyChar;
        }
        while (cellInRowForPaint != '#' && cellInRowForPaint != '.');
        Console.Write(cellInRowForPaint);
        paintRow = paintRow + cellInRowForPaint;
    }
    Console.WriteLine();
    return paintRow;
}

void PrintCharArr(string[] arrRow, int columns) // вывод сформированной и "закрашенной" таблицы
{
    int row = arrRow.Length;
    string rowToChar = string.Empty;

    char[,] printArr = new char[row, columns];

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            rowToChar = arrRow[i];
            printArr[i, j] = rowToChar[j];
            Console.Write(printArr[i, j] + " ");
        }
        Console.WriteLine();
    }
}

int[,] FillPaintArrToNum(string[] arrRow, int columns) // создание клона массива, но цифрового (закрашеннай ячейка = 1)
{
    int row = arrRow.Length;
    int cellInRowToNum;
    string rowToChar = string.Empty;

    int[,] paintArrWithNums = new int[row, columns];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            rowToChar = arrRow[i];

            if (rowToChar[j].Equals('#'))
            {
                cellInRowToNum = 1;
            }
            else
            {
                cellInRowToNum = 0;
            }
            paintArrWithNums[i, j] = cellInRowToNum;
        }
    }
    return paintArrWithNums;
}

/*
void PrintNumericArr(int[,] arr) // вывод цифрового клона (для проверки)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i, j] + " ");
        }
        Console.WriteLine();
    }
}
*/

int GetCountSquareInPaint(int[,] arrPaintWithNums) // подсчет количества закрашенных квадратов
{
    int row = arrPaintWithNums.GetLength(0);
    int columns = arrPaintWithNums.GetLength(1);
    int sideOfSquare = 0;
    int sumSquare = 0;
    int sumAverage = 0;
    int countSquare = 0;

    if (row <= columns) sideOfSquare = row; // определяем наибольший возможный размер квадрата
    else sideOfSquare = columns;

    for (int i = 0; i < row; i++)
    {                           // двойной цикл перебора начальных ячеек для "построения" квадрата
        for (int j = 0; j < columns; j++)
        {
            for (int k = 1; k <= sideOfSquare; k++) // цикл на количество возможных квадратов со стороной k
            {
                sumSquare = 0; // перед каждой сменой начальной точки - обнуляем сумму в квадратах

                if (k + i > row || k + j > columns) // проверка чтоб сформированный квадрат не вышел за пределы исходной таблицы
                {
                    break;
                }
                for (int m = i; m < k + i; m++)
                {                               // перебор ячеек исходной таблицы внутри квадратов
                    for (int n = j; n < k + j; n++)
                    {
                        sumSquare = sumSquare + arrPaintWithNums[m, n]; // считаем сумму всех элементов внутри квадрата
                    }
                }
                sumAverage = sumSquare / (k * k); // если среднее арифметическое = 1, то в квадрате во всех ячейках значение = 1

                if (sumAverage == 1) // если все ячейки в квадрате = 1 - то считаем такой квадрат
                {
                    countSquare++;
                }
            }
        }
    }
    return countSquare;
}


Console.Clear();

Console.Write("Введите количество строк: ");
int row = int.Parse(Console.ReadLine()!);
Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);
Console.WriteLine();


string[] arrRow = new string[row];
for (int k = 0; k < row; k++)
{
    arrRow[k] = GetPaintRow(k + 1, columns);
}

Console.WriteLine();
Console.Write($"Сформирована таблица {row}x{columns}");
Console.WriteLine();

PrintCharArr(arrRow, columns);
Console.WriteLine();

int[,] arrPaintWithNums = new int[row, columns];
arrPaintWithNums = FillPaintArrToNum(arrRow, columns);

/*
PrintNumericArr(arrPaintWithNums);
Console.WriteLine();
*/

Console.WriteLine("Количество закрашенных квадратов = " + GetCountSquareInPaint(arrPaintWithNums));
Console.WriteLine();