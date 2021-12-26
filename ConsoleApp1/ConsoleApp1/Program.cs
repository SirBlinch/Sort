
int i;
int boof;
Random rand = new Random();

Console.WriteLine("Укажите размер массива");

while (!int.TryParse(Console.ReadLine(),out i))
{
    Console.WriteLine("Необходимо ввести целое число");
}
Console.WriteLine($"Количество элементов в массиве = {i}");
int[] mass = new int[i];

Console.WriteLine("Массив содержит следующие элементы:");
for (int c = 0; c < i; c++)
{
    mass[c] = rand.Next(0,10);
    Console.Write($"{mass[c]}, ");
}
Console.WriteLine();
Console.WriteLine("Сортировка начата.");
Console.WriteLine("Вывожу промежуточные результаты:");

Vstavka(mass);

void Bable(int[] massive)
{ 
    for (int k = i - 1; k > 0; k--)
    {
        for (int r = 0; r < k; r++)
        {
            if (massive[r] > massive[r + 1])
            {
                boof = massive[r + 1];
                massive[r + 1] = massive[r];
                massive[r] = boof;
            }
            for (int l = 0; l < i; l++)
            {
                if (l == r)
                    Console.Write($"[{massive[l]}] ,");

                else
                    if (l == r + 1)
                    Console.Write($"[{massive[l]}] ,");

                else
                    Console.Write($"{massive[l]} ,");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine($"Рассортированный массив выглядит так: ");
    foreach (int t in massive)
    {
        Console.Write($"{t} ,");
    }
}

void Vstavka(int[] massive) 
{
    for (int k = 1; k < i;)
    {
        Console.WriteLine($"смотрим элемент - {k}");
        for (int r = k - 1; r >= 0; r--)
        {
            Console.WriteLine(r);

            if (massive[k] > massive[r]) 
            {
                


                Console.WriteLine("пора сортировать");
                boof = massive[k];
                for (int h = k; h > r; h--)
                {
                    massive[h] = massive[h - 1];
                }
                massive[r+1] = boof;
                break;
            }
            if (r == 0 && massive[k] < massive[r])
            {
                boof = massive[k];
                for (int h = k; h > r; h--)
                {
                    massive[h] = massive[h - 1];
                }
                massive[r] = boof;
                break;
            }
        }
        k++;
        foreach (int t in massive)
        {
            Console.Write($"{t} ,");
        }
        Console.WriteLine();

    }
    Console.WriteLine($"Рассортированный массив выглядит так: ");
    foreach (int t in massive)
    {
        Console.Write($"{t} ,");
    }

}