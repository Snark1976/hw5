bool flag;
Random rand = new();
do
{
    Console.Write("Введите номер задачи (34, 36 или 38) для проверки или все, что угодно, для выхода: ");
    flag = Console.ReadLine() switch
    {
        "34" => Task34(),
        "36" => Task36(),
        "38" => Task38(),
        _ => false
    };
}
while (flag);

bool Task34()
{
    Console.Write("Введите длину массива: ");
    // ! добавляю для подавления подчеркиваний nullable ReadLine(). Просто очень не люблю, 
    // когда есть в коде любые предупреждения.
    int len = Convert.ToInt32(Console.ReadLine()!);
    int[] array = CreateAndWriteArray(len, 100, 1000);
    Console.WriteLine($"Количество четных в массиве: {array.Where(x => x % 2 == 0).Count()}");
    return true;
}

bool Task36()
{
    Console.Write("Введите длину массива: ");
    int len = Convert.ToInt32(Console.ReadLine()!);
    int[] array = CreateAndWriteArray(len, -99, 100);
    Console.WriteLine($"Сумма элементов, стоящих на нечётных позиция: {array.Where((x, i) => i % 2 == 0).Sum()}");
    return true;
}

bool Task38()
{
    Console.Write("Введите длину массива: ");
    int len = Convert.ToInt32(Console.ReadLine()!);
    double[] array = CreateAndWriteArrayOfDouble(len, -99, 100);
    Console.WriteLine($"Разность между максимальным и минимальным равна: {array.Max() - array.Min()}");
    return true;;
}

int[] CreateAndWriteArray(int len, int minValue, int maxValue)
{
    int[] result = new int[len];
    for (int i = 0; i < len; i++)
        result[i] = rand.Next(minValue, maxValue);
    Console.WriteLine($"Массив заполнен случайными целыми числами: [{string.Join("; ", result)}]");
    return result;
}

double[] CreateAndWriteArrayOfDouble(int len, int minValue = 0, int maxValue = 1)
{
    double[] result = new double[len];
    for (int i = 0; i < len; i++)
        result[i] = rand.NextDouble() * (maxValue - minValue) + minValue;
    Console.WriteLine($"Массив заполнен случайными действительными числами: [{string.Join("; ", result)}]");
    return result;
}
