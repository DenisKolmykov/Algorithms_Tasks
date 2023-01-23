// F. Забор
// ограничение по времени на тест0.5 секунд
// ограничение по памяти на тест64 мегабайта
// вводстандартный ввод
// выводстандартный вывод

// Необходимо с помощью забора огородить выпуклый участок максимальной площади. 
// Правила построения забора следующие: 
// Разрешается выстраивать непрерывный замкнутый забор из отрезков длины 1 и отрезков длины 2‾√
// ,соединенных концами между собой, при этом, в фиксированной декартовой системе координат 𝑂𝑥𝑦
// Необходимо использовать:
//  ровно 𝑛1 единичных отрезков, параллельных оси 𝑥,
//  ровно 𝑛2 единичных отрезков параллельных оси 𝑦
//  ровно 𝑛3 отрезков длины 2‾√ образующих угол в 45 градусов с положительной полуосью 𝑂𝑥
//  ровно 𝑛4 отрезков длины 2‾√ образующих угол в 135 градусов с положительной полуосью 𝑂𝑥

// Использование отрезков под углами, отличными от вышеперечисленных, не допускается.

// Входные данные
// Единственная строка содержит четыре целых числа 𝑛1
// n1, 𝑛2 , 𝑛3 и 𝑛4 (1⩽𝑛𝑖⩽100)

// Выходные данные
// Если забора, удовлетворяющего условиям задачи, нет, то выведите одну строку «impossible».

// В противном случае выведите ответ в виде строки из четырех цифр: 
// 1 — горизонтальный отрезок, 
// 2 — вертикальный, 
// 3 — диагональный под углом 45 градусов, 
// 4 — диагональный под углом 135 градусов, 
// соответствующих обходу забора по часовой стрелке, начиная с любого отрезка, из которых составлен забор. 
// Если ответов несколько — выведите любой.

// Примеры
// входные данные
// 5 7 1 4
// выходные данные
// 11144222311442222

int[,] FillArraySegmetsTypeQuantity(int row)
{
    int[,] arraySegmetsTypeQuantity = new int[row, 2]; // столбцов всегда 2: в первом - тип отрезка, во втором - количество

    for (int i = 0; i < row; i++)
    {
        Console.Write($"Введите количество отрезков {i + 1}-го типа: ");
        arraySegmetsTypeQuantity[i, 0] = i + 1;
        arraySegmetsTypeQuantity[i, 1] = int.Parse(Console.ReadLine()!);
    }
    Console.WriteLine();
    return arraySegmetsTypeQuantity;
}

string GetSequenceOfSegmentType(int segmentQuantity, int segmentType)
{
    string segmentSequence = string.Empty;

    for (int i = 0; i < segmentQuantity; i++)
    {
        segmentSequence = segmentSequence + segmentType;
    }
    return segmentSequence;
}

//--------------------------------------------

Console.Clear();

int countSegmentType = 4; // количество типов отрезков

int[,] segmetsTypeQuantity = new int[countSegmentType, 2]; // массив для количества отрезков каждого типа
segmetsTypeQuantity = FillArraySegmetsTypeQuantity(countSegmentType);

int n1 = segmetsTypeQuantity[0, 1];
int n2 = segmetsTypeQuantity[1, 1];
int n3 = segmetsTypeQuantity[2, 1];
int n4 = segmetsTypeQuantity[3, 1];

int countSegmentsHorizontally = n1 + n3 + n4; // "проекция" количества горизонтальных отрезков
int countSegmentsVertically = n2 + n3 + n4; //"проекция" количества вертикальных отрезков
// Таким образом фигура получается как бы "вписана" в прямоугольник 
// размером (countSegmentsHorizontally/2)х(countSegmentsVertically/2)

// Чтобы фигура построилась (замкнулась), количество горизонтальных/вертикальных отрезков должно быть четным
// т.к. (при движении по часовой стрелке) каждому отрезку "вперед" по горизонтали/вертикали должен соответствовать отрезок "назад"
if (countSegmentsHorizontally % 2 > 0 || countSegmentsVertically % 2 > 0)
{
    Console.WriteLine("IMpossible\n");
}
else
{
    Console.WriteLine("Possible:");

    int perimeter = n1 + n2 + n3 + n4;

    // Т.к. фигура "вписана" в прямоугольник, 
    // то каждый отрезок "наклонного" типа (n3 и n4) "отрезает" от этого прямоугольника
    // площадь = площади прямоугольного треугольника с диагональю = количеству отрезков типа n3/n4.
    // Чтобы площадь фигуры была максимальной, 
    // "отрезаемые отрезки должны в сумме составлять минимальную площадь.
    // Минимальная площадь "отрезаемых" отрезков достигается 
    // при одинаковом (близком к одинаковому) количестве отрезков каждого типа "вперед" и "назад",
    // т.е. каждому "наклонному" отрезоку (n3 или n4), "вперед" должен соответствовать такойже отрезок "назад"
    // поэтому количество отрезков типов n3/n4 "вперед" и "назад" находим как n3/2 (n4/2)

    int countN3ForvardHorizontlly = n3 / 2;                             // количество отрезков типа n3 "вперед"
    int countN3ReverseHorizontally = n3 - countN3ForvardHorizontlly;    // количество отрезков типа n3 "назад"

    int countN4ForvardHorizontally = n4 / 2;                            // количество отрезков типа n4 "вперед"
    int countN4ReverseHorizontally = n4 - countN4ForvardHorizontally;   // количество отрезков типа n4 "вперед"

    // т.к. у нас 4 типа отрезков, и каждому отрезку "вперед" соответствует отрезок "назад"
    // то последовательность отрезков будет состоять из 8 комбинаций:
    // 1: количество отрезков "вперед" для типа 1 (по горизонтали)
    // 2: количество отрезков "назад" для типа 1 (по горизонтали)
    // 3: количество отрезков "вперед" для типа 3 (по горизонтали)
    // 4: количество отрезков "назад" для типа 3 (по горизонтали)
    // 5: количество отрезков "вперед" для типа 4 (по горизонтали)
    // 6: количество отрезков "назад" для типа 4 (по горизонтали)
    // 7: количество отрезков "вперед" для типа 2 (по вертикали)
    // 8: количество отрезков "назад" для типа 2 (по вертикали)

    // При этом, начинаем собирать комбинацию с левого верхнего угла прямоугольника (в который вписана фигура)
    // Примем старт с отрезка типа 3 (n3), 
    // тогда последовательность по горизонтали "вперед" будет замыкать отрезок типа 4
    // Последовательность "вперед" по горизонтали будет следующей:
    // количество отрезков "вперед" для типа 3 (по горизонтали) + 
    // количество отрезков "вперед" для типа 1 (по горизонтали) + // рассчитывается как (сторона прямоугольника по горизонтали) минус (тип 3 "вперед") минус (тип 4 "вперед")
    // количество отрезков "вперед" для типа 4 (по горизонтали)
    // Соответственно, последовательность "назад" по горизонтали будет следующей:
    // количество отрезков "назад" для типа 3 (по горизонтали) + 
    // количество отрезков "назад" для типа 1 (по горизонтали) +
    // количество отрезков "назад" для типа 4 (по горизонтали)

    // количество отрезков типа 4 (n4) по вертикали "вперед" будет рассчитываться:
    // вертикальная сторона прямоугольника (countSegmentsVertically) минус 
    // (количество отрезков "вперед" для типа 4 (по горизонтали)) минус
    // (количество отрезков "назад" для типа 3 (по горизонтали))

    int[] arrCombinationOfSegments = new int[8]{countN3ForvardHorizontlly,
                                                countSegmentsHorizontally / 2 - countN3ForvardHorizontlly - countN4ForvardHorizontally,
                                                countN4ForvardHorizontally,
                                                countSegmentsVertically / 2 - countN4ForvardHorizontally - countN3ReverseHorizontally,
                                                countN3ReverseHorizontally,
                                                countSegmentsHorizontally / 2 - countN3ReverseHorizontally - countN4ReverseHorizontally,
                                                countN4ReverseHorizontally,
                                                countSegmentsVertically / 2 - countN4ReverseHorizontally - countN3ForvardHorizontlly
                                                };

    int type1 = segmetsTypeQuantity[0, 0];
    int type2 = segmetsTypeQuantity[1, 0];
    int type3 = segmetsTypeQuantity[2, 0];
    int type4 = segmetsTypeQuantity[3, 0];
    // массив типов отрезков расположенных в соответвие с последовательностью комбинаций []arrCombinationOfSegments
    int[] arrSegmetsTypeWithCombination = new int[4] {type3,
                                                      type1,
                                                      type4,
                                                      type2};

    string resultFenceSequence = string.Empty; // строка для вывода последовательности забора
    for (int i = 0; i < 8; i++)
    {
        if (arrCombinationOfSegments[i] > 0)
        {
            int j = 0;
            if (i > 3)
            {
                j = i - 4;
            }
            else
            {
                j = i;
            }
            int type = arrSegmetsTypeWithCombination[j];
            resultFenceSequence = resultFenceSequence + GetSequenceOfSegmentType(arrCombinationOfSegments[i], type);
        }
    }
    Console.WriteLine(resultFenceSequence);
    Console.WriteLine();
}
