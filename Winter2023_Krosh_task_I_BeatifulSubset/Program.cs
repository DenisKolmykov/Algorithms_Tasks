// У Кроша есть множество из 𝑛 натуральных чисел от 1 до 𝑛. 
// Он называет подмножество этого множества из 𝑘 элементов красивым, 
// если наибольший общий делитель всех элементов подмножества равен 1. 
// Помогите ему посчитать количество красивых подмножеств из 𝑘 элементов. 
// Так как ответ может быть большим, выведите его остаток от деления на 10^9+7.

// Входные данные
// Вам даны числа 2≤𝑛≤1000000 и 2≤𝑘≤𝑛.

// для n=10 и k=2 красивых подмножеств = 31

int GetGcd(int[] arr) //метод для нахлждения НОД
{
    int numberA = 0;
    int numberB = 0;
    int nod = 0;

    int k = arr.Length - 1; // "минус 1" - т.к во входящем массиве последний элемент "проверочный" 

    nod = arr[0];

    for (int i = 1; i < k; i++)
    {
        numberA = nod;
        numberB = arr[i];

        if (nod == 1)
        {
            break;
        }

        while (numberA > 0 & numberB > 0)
        {
            if (numberA > numberB)
            {
                numberA = numberA % numberB;
            }
            else
            {
                numberB = numberB % numberA;
            }
        }
        nod = numberA + numberB;
    }
    return (nod);
}

double CreateArrayAndCountGcd(int n, int k)
{
    int gcd = 0;
    double countBunch = 0;
    int count = 0;

    int[] arr = new int[k + 1];

    for (int i = 0; i < k; i++)
    {
        arr[i] = 1;
    }

    arr[k] = n;

    bool b = true;

    while (arr[k] == n)
    {
        arr[0]++;
        for (int i = 0; i < k; i++)
        {
            if (arr[i] > n)
            {
                arr[i] = 1;
                arr[i + 1]++;
            }
        }

        for (int i = 0; i < k - 1; i++)
        {
            if (arr[i] >= arr[i + 1])
            {
                b = false;
            }
        }
        if (b)
        {
            //Console.WriteLine(string.Join(" ", arr));
            count++;
            gcd = Gcd(arr);
            if (gcd == 1)
            {
                countBunch++;
            }
        }
        b = true;
    }
    Console.WriteLine($"Всего уникальных подмножествиз из `{k}` элементов: {count}");
    //countBunch = countBunch % (Math.Pow(10, 9) + 7);
    return countBunch;
}

///////////////////////////////////////////

int n = 0;
int k = 0;

Console.Clear();

Console.Write("Введите натуральное число n (2≤ n ≤ 1000000) для множества `N` от 1 до n: ");
n = int.Parse(Console.ReadLine()!);

Console.Write("Введите натуральное число k 2≤ k ≤ n (количество элементов подмножества `K`: ");
k = int.Parse(Console.ReadLine()!);
Console.WriteLine();

double countBunch = CreateArrayAndCountGcd(n, k);
Console.WriteLine($"Количество красивых подмножеств из `{k}` элементов: {countBunch}");

/*
n=7, k=4

1234 1245 1256 1267  1345 1356 1367  1456 1467   1567 
1235 1246 1257       1346 1357       1457
1236 1247            1347
1237  

2345 2356 2367   2456 2467    2567
2346 2357        2457
2347      

3456 3467   3567
3457

4567

---- 35 уникальных и 35 с НОД = 1 -------
*/

