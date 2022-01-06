
int i;                                                          //тут будем хранить рамер массива, оно же максимальное значение его элемента
int boof;                                                       //буферная переменная для хранения значений элемента массива
Random rand = new Random();                                     //создаём объект класса рандомизатора
                                                                //
Console.WriteLine("Укажите размер массива");                    //
                                                                //
while (!int.TryParse(Console.ReadLine(),out i))                 //запрашиваем разммер массива у пользователя и проверяем: соответствуует
{                                                               //ли введенное значение типу integer, если нет то выводим заданное
    Console.WriteLine("Необходимо ввести целое число");         //сообщение и запрашиваем еще раз
}                                                               //
Console.WriteLine($"Количество элементов в массиве = {i}");     //
int[] mass = new int[i];                                        //объявляем массив с именем mass, с заданным ранее числом элементов
                                                                //
MassGen();                                                      //
                                                                //
SwitchSort();

void MassGen()
{//
    for (int c = 0; c < i; c++)                                     //
    {                                                               //цикл в котором задаём каждому элементу массива случайное значение
        mass[c] = rand.Next(0, i);                                  //от нуля до числа равного количеству элементов в массиве
    }                                                               //
    for (int f = 0; f < i; f++)                                     //
    {                                                               //
        for (int d = 0; d < i;)                                     //цепочка циклов редактирующая массив так чтобы значения его элементов
        {                                                           //не повторялись
            if (f != d && mass[f] == mass[d])                       //
            {                                                       //
                mass[f] = rand.Next(0, i);                          //
                d = 0;                                              //
            }                                                       //
            else                                                    //
            {                                                       //
                d++;                                                //
            }                                                       //
        }                                                           //
    }                                                               //
    Console.WriteLine("Массив содержит следующие элементы:");       //
    foreach (int t in mass)                                         //
    {                                                               //
        Console.Write($"{t} ,");                                    //
    }                                                               //
    Console.WriteLine();
}

void SwitchSort()
{
    bool m = true;
    while (m)
    {
        m = false;
        Console.WriteLine("Выберите метод сортировки.");
        string svitch_input = Console.ReadLine();
        switch (svitch_input)
        {
            case "Bubble":
            case "1":
                Bubble(mass);
                break;
            case "Vstavka":
            case "2":
                Vstavka(mass);
                break;
            case "Shaker":
            case "3":
                Shaker(mass);
                break;
            case "DvorfSort":
            case "4":
                DvorfSort(mass);
                break;
            case "MergeSort":
            case "5":
                MergeSort(mass);
                break;
            case "help":
                Console.WriteLine("Для выбора пузырькового метода сортировки - введите комманду Bubble или 1.");
                Console.WriteLine("Для выбора метода сортировки Вставка - введите комманду Vstavka или 2.");
                Console.WriteLine("Для выбора метода сортировки Перемешиванием - введите комманду Shaker или 3.");
                Console.WriteLine("Для выбора Гномьего метода сортировки - введите комманду DvorfSort или 4.");
                Console.WriteLine("Для выбора метода сортировки Слиянием - введите комманду MergeSort или 5.");
                m = true;
                break;
            default:
                Console.WriteLine("Неправильно выбран метод.");
                Console.WriteLine("Для просмотра команд всех методов наберите команду help");
                m = true;
                break;
        }
    }
}

void Bubble(int[] massive)
{
    Console.WriteLine("Сортировка начата.");                        //
    Console.WriteLine("Вывожу промежуточные результаты:");          //
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
}                                   //
                                                                //
void Vstavka(int[] massive) 
{
    Console.WriteLine("Сортировка начата.");                        //
    Console.WriteLine("Вывожу промежуточные результаты:");          //

    for (int k = 1; k < i;)
    {
        for (int l = 0; l < i; l++)
        {
            if (l == k)
                Console.Write($"[{massive[l]}], ");
            else
                Console.Write($"{massive[l]}, ");

        }
        Console.WriteLine();
        for (int r = k - 1; r >= 0; r--)
        {
            

            if (massive[k] > massive[r]) 
            {
           
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


    }
    Console.WriteLine($"Рассортированный массив выглядит так: ");
    foreach (int t in massive)
    {
        Console.Write($"{t} ,");
    }

}                                  //
                                                                //
void Shaker(int[] massive)
{
    Console.WriteLine("Сортировка начата.");                        //
    Console.WriteLine("Вывожу промежуточные результаты:");          //

    int front = i-1;
    int beck = 0;
    while (beck != front)
    {
        for (int r = beck; r < front; r++)
        {
            if (massive[r] > massive[r + 1])
            {
                boof = massive[r + 1];
                massive[r + 1] = massive[r];
                massive[r] = boof;
            }
        }
        front--;
        if (front == beck) break;
        for (int r = front; r > beck; r--)
        {
            if (massive[r] < massive[r - 1])
            {
                boof = massive[r - 1];
                massive[r - 1] = massive[r];
                massive[r] = boof;
            }
        }
        beck++;
    }
    Console.WriteLine($"Рассортированный массив выглядит так: ");
    foreach (int t in massive)
    {
        Console.Write($"{t} ,");
    }
}                                   //
                                                                //
void DvorfSort(int[] massive)                                   //
{
    Console.WriteLine("Сортировка начата.");                    //
    Console.WriteLine("Вывожу промежуточные результаты:");      //
                                                                //
    for (int k = 0; k < i; k++)                                 //
    {                                                           //
                                                                //
        Console.WriteLine($"Смотрим элемент - {k}");            //
        if (k != 0 && massive[k] < massive[k - 1])              //
        {                                                       //
            int j = k;                                          //
            Console.WriteLine("Берем в работу");                //
            for (; j > 0 && massive[j] < massive[j - 1]; j--)   //Интересный факт: это условие будет корректно работать только в 
            {                                                   //таком виде т.к. проверка условий идет последовательно и если 
                boof = massive[j];                              //поменять выражения местами то при j == 0 программа попытается 
                massive[j] = massive[j - 1];                    //сравнить элементы с индексами 0 и -1, что вызовет ошибку. При 
                massive[j - 1] = boof;                          //данной же записи сначала будет проверяться истинность выражения
            }                                                   //j>0, что, в свою очередь, возвратит false и выведет программу 
            Console.WriteLine($"Ставим на позицию [{j}]");      //изцикла while без проверки остальных условий.
        }                                                       //
        Console.WriteLine("Идем на следующий");                 //
    }                                                           //
    Console.WriteLine($"Рассортированный массив выглядит так: ");//
    foreach (int t in massive)                                  //
    {                                                           //
        Console.Write($"{t} ,");                                //
    }
}                                //

void MergeSort (int[] massive)
{
    int centr = massive.Length / 2;
    var massSeg = new ArraySegment<int>(massive);

    int[] arrX = massSeg.Slice(0, centr).ToArray();
    int[] arrY = massSeg.Slice(centr).ToArray();

    Console.WriteLine(string.Join(",", arrX));
    Console.WriteLine(string.Join(",", arrY));

    Recur(arrX, arrY);

    int[] Recur(int[] arrX, int[] arrY)
    {
        
        int[] g;
        if (arrX.Length > 1)
        {
            Console.WriteLine($"На обработку для рекурсии arrX поступил массив:");
            Console.WriteLine(String.Join(",", arrX));       
            Console.WriteLine();
            int massCentr = arrX.Length / 2;
            var massSeg = new ArraySegment<int>(arrX);
            int[] arrX_X = massSeg.Slice(0, massCentr).ToArray();
            int[] arrX_Y = massSeg.Slice(massCentr).ToArray();
            Console.WriteLine("После обработки на рекурсию уходят массивы:");
            Console.Write("arrX_X: ");
            Console.WriteLine(String.Join(",",arrX_X));
            Console.Write("arrX_Y: ");
            Console.WriteLine(String.Join(",",arrX_Y));
            Console.WriteLine();
            Console.WriteLine($"уходим на рекурсию arrX");

            arrX = Recur(arrX_X, arrX_Y);

            Console.WriteLine($"Вышли из рекурсии arrX");
        }
        if (arrY.Length > 1)
        {
            Console.WriteLine($"На обработку для рекурсии arrY поступил массив:");
            Console.WriteLine(String.Join(",",arrY));
            Console.WriteLine();
            int massCentr = arrY.Length / 2;
            var massSeg = new ArraySegment<int>(arrY);
        
            int[] arrY_X = massSeg.Slice(0, massCentr).ToArray();
            int[] arrY_Y = massSeg.Slice(massCentr).ToArray();
            Console.WriteLine("После обработки на рекурсию уходят массивы:");
            Console.Write("arrY_X: ");
            Console.WriteLine(String.Join(",",arrY_X));
            Console.Write("arrY_Y: ");
            Console.WriteLine(String.Join(",", arrY_Y));
            Console.WriteLine();

            Console.WriteLine($"уходим на рекурсию arrY");

            arrY = Recur(arrY_X, arrY_Y);

            Console.WriteLine($"Вышли из рекурсии arrY");
        }
        Console.WriteLine($"Условия перехода на новую итерацию рекурсии не выполнились");
        Console.WriteLine("На выход направляются массивы:");
        Console.Write("arrX:");
        Console.WriteLine(String.Join(",", arrX));
        Console.Write("arrY:");
        Console.WriteLine(String.Join(",",arrY));
        Console.WriteLine();
        int rezLength = arrX.Length + arrY.Length;
        g = new int[rezLength];
        int schX = 0;
        int schY = 0;
        for (int i = 0; i < rezLength; i++)
        {
            if (schX < arrX.Length && schY < arrY.Length)
            {
                if (arrX[schX] < arrY[schY])
                {
                    g[i] = arrX[schX];
                    schX++;
                }
                else
                {
                    g[i] = arrY[schY];
                    schY++;
                }
            }
            else
            {
                if (schX == arrX.Length)
                {
                    g[i] = arrY[schY];
                    schY++;
                }
                else
                {
                    g[i] = arrX[schX];
                    schX++;
                }
            }
        }
        Console.WriteLine("Отсортированный массив выглядит так:");
        Console.WriteLine(String.Join(",",g));
        return g;
        //sort and concatinate arrX and arrY
    }
}



