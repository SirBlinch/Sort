Dialog dialog = new Dialog();
MassGen massGen = new MassGen();

dialog.Talk();
Massive myMass = new Massive(dialog.talkResult.sizeMass, dialog.talkResult.tipeSort,massGen.GenMass(dialog.talkResult.sizeMass));
myMass.PrintMass();

ISortable ?sorter = null;
SwitchSort();

myMass.sortMass = sorter.Sort(myMass.mass, myMass.massSize);
myMass.PrintSortMass();

void SwitchSort()
{
    bool m = true;
    while (m)
    {
        m = false;
        int svitch_input = myMass.tipeSort;
        switch (svitch_input)
        {
            case 1:
                sorter = new Bubble();
                break;
            case 2:
                sorter = new Vstavka();
                break;
            case 3:
                sorter = new Shaker();
                break;
            case 4:
                sorter = new DvorfSort();
                break;
            case 5:
                sorter = new MergeSort();
                break;
            case 0:
                Console.WriteLine("Для выбора пузырькового метода сортировки - введите комманду или 1.");
                Console.WriteLine("Для выбора метода сортировки Вставка - введите комманду или 2.");
                Console.WriteLine("Для выбора метода сортировки Перемешиванием - введите комманду или 3.");
                Console.WriteLine("Для выбора Гномьего метода сортировки - введите комманду или 4.");
                Console.WriteLine("Для выбора метода сортировки Слиянием - введите комманду или 5.");
                m = true;
                break;
            default:
                Console.WriteLine("Неправильно выбран метод.");
                Console.WriteLine("Для просмотра команд всех методов введите 0");
                Console.WriteLine("Укажите индекс метода сортировки");
                while (!int.TryParse(Console.ReadLine(), out myMass.tipeSort))
                {
                    Console.WriteLine("Необходимо ввести целое число");
                }
                m = true;
                break;
        }
    }
}

interface ISortable
{
    public int[] Sort(int[] mass,int massSize);
}

class Dialog
{
    public TalkResult talkResult = new TalkResult();
    //public int[] talkResult = new int[2];
    public void Talk()
    {

        Console.WriteLine("Укажите размер массива");
        while (!int.TryParse(Console.ReadLine(), out talkResult.sizeMass))
        {
            Console.WriteLine("Необходимо ввести целое число");
        }
        Console.WriteLine($"Количество элементов в массиве = {talkResult.sizeMass}");
        Console.WriteLine("Укажите индекс метода сортировки");
        while (!int.TryParse(Console.ReadLine(), out talkResult.tipeSort))
        {
            Console.WriteLine("Необходимо ввести целое число");
        }
    }
}

class TalkResult
{
   public int sizeMass;
   public int tipeSort;
}

class MassGen
{
    public int[] GenMass(int size)
    {
        Random rand = new Random();                                     //создаём объект класса рандомизатора
                                                                        //
        int[] mass = new int[size];                                        //объявляем массив с именем mass, с заданным ранее числом элементов

        for (int c = 0; c < size; c++)                                     //
        {                                                               //цикл в котором задаём каждому элементу массива случайное значение
            mass[c] = rand.Next(0, size);                                  //от нуля до числа равного количеству элементов в массиве
        }                                                               //
        for (int f = 0; f < size; f++)                                     //
        {                                                               //
            for (int d = 0; d < size;)                                     //цепочка циклов редактирующая массив так чтобы значения его элементов
            {                                                           //не повторялись
                if (f != d && mass[f] == mass[d])                       //
                {                                                       //
                    mass[f] = rand.Next(0, size);                          //
                    d = 0;                                              //
                }                                                       //
                else                                                    //
                {                                                       //
                    d++;                                                //
                }                                                       //
            }                                                           //
        }
        return mass;
    }
}

class Massive
{
    public int massSize;
    public int tipeSort;
    public int[] mass;
    public int[]? sortMass;

    public void PrintMass()
    {
        Console.WriteLine("Ваш не сортированный массив выглядит так:");
        Console.Write(String.Join(",", mass));
        Console.WriteLine();
    }
    public void PrintSortMass()
    {
        Console.WriteLine($"Была выбрана сортировка методом '{tipeSort}'");
        Console.WriteLine("Сортированный массив выглядит так:");
        if (sortMass == null)
        {
            Console.Write("А никак, его еще не сортировали!!");
            Console.WriteLine();

        }
        else Console.WriteLine(String.Join(",", sortMass));
             Console.WriteLine();

    }

    public Massive(int massSize,int tipeSort, int[] mass)
        {
        this.massSize = massSize;
        this.tipeSort = tipeSort;
        this.mass = mass;
        }


}


class Bubble : ISortable
{
   public int[] Sort(int[] massive,int massSize)
    {
        int [] resMas = (int[])massive.Clone();
        int boof;
        Console.WriteLine("Сортировка начата.");
        Console.WriteLine("Вывожу промежуточные результаты:");
        for (int k = massSize - 1; k > 0; k--)
        {
            for (int r = 0; r < k; r++)
            {
                if (resMas[r] > resMas[r + 1])
                {
                    boof = resMas[r + 1];
                    resMas[r + 1] = resMas[r];
                    resMas[r] = boof;
                }
                for (int l = 0; l < massSize; l++)
                {
                    if (l == r)
                        Console.Write($"[{resMas[l]}] ,");

                    else
                        if (l == r + 1)
                        Console.Write($"[{resMas[l]}] ,");

                    else
                        Console.Write($"{resMas[l]} ,");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine($"Рассортированный массив выглядит так: ");
        foreach (int t in massive)
        {
            Console.Write($"{t} ,");
        }
        return resMas;
    }
}

class Vstavka : ISortable
{
    public int[] Sort(int[] massive, int massSize)
    {
        int[] resMas = (int[])massive.Clone();
        int boof;
        Console.WriteLine("Сортировка начата.");                       
        Console.WriteLine("Вывожу промежуточные результаты:");         

        for (int k = 1; k < massSize;)
        {
            for (int l = 0; l < massSize; l++)
            {
                if (l == k)
                    Console.Write($"[{resMas[l]}], ");
                else
                    Console.Write($"{resMas[l]}, ");

            }
            Console.WriteLine();
            for (int r = k - 1; r >= 0; r--)
            {


                if (resMas[k] > resMas[r])
                {

                    boof = resMas[k];
                    for (int h = k; h > r; h--)
                    {
                        resMas[h] = resMas[h - 1];
                    }
                    resMas[r + 1] = boof;
                    break;
                }
                if (r == 0 && resMas[k] < resMas[r])
                {
                    boof = resMas[k];
                    for (int h = k; h > r; h--)
                    {
                        resMas[h] = resMas[h - 1];
                    }
                    resMas[r] = boof;
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
        return resMas;

    }
}

class Shaker : ISortable
{
    public int[] Sort(int[] massive, int massSize)
    {
        int[] resMas = (int[])massive.Clone();
        int boof;
        Console.WriteLine("Сортировка начата.");                        //
        Console.WriteLine("Вывожу промежуточные результаты:");          //

        int front = massSize - 1;
        int beck = 0;
        while (beck != front)
        {
            for (int r = beck; r < front; r++)
            {
                if (resMas[r] > resMas[r + 1])
                {
                    boof = resMas[r + 1];
                    resMas[r + 1] = resMas[r];
                    resMas[r] = boof;
                }
            }
            front--;
            if (front == beck) break;
            for (int r = front; r > beck; r--)
            {
                if (resMas[r] < resMas[r - 1])
                {
                    boof = resMas[r - 1];
                    resMas[r - 1] = resMas[r];
                    resMas[r] = boof;
                }
            }
            beck++;
        }
        Console.WriteLine($"Рассортированный массив выглядит так: ");
        foreach (int t in resMas)
        {
            Console.Write($"{t} ,");
        }
        return resMas;

    }
}

class DvorfSort : ISortable
{
    public int[] Sort(int[] massive, int massSize)
    {
        int[] resMas = (int[])massive.Clone();
        int boof;
        Console.WriteLine("Сортировка начата.");                    //
        Console.WriteLine("Вывожу промежуточные результаты:");      //
                                                                    //
        for (int k = 0; k < massSize; k++)                                 //
        {                                                           //
                                                                    //
            Console.WriteLine($"Смотрим элемент - {k}");            //
            if (k != 0 && resMas[k] < resMas[k - 1])              //
            {                                                       //
                int j = k;                                          //
                Console.WriteLine("Берем в работу");                //
                for (; j > 0 && resMas[j] < resMas[j - 1]; j--)   //Интересный факт: это условие будет корректно работать только в 
                {                                                   //таком виде т.к. проверка условий идет последовательно и если 
                    boof = resMas[j];                              //поменять выражения местами то при j == 0 программа попытается 
                    resMas[j] = resMas[j - 1];                    //сравнить элементы с индексами 0 и -1, что вызовет ошибку. При 
                    resMas[j - 1] = boof;                          //данной же записи сначала будет проверяться истинность выражения
                }                                                   //j>0, что, в свою очередь, возвратит false и выведет программу 
                Console.WriteLine($"Ставим на позицию [{j}]");      //изцикла while без проверки остальных условий.
            }                                                       //
            Console.WriteLine("Идем на следующий");                 //
        }                                                           //
        Console.WriteLine($"Рассортированный массив выглядит так: ");//
        foreach (int t in resMas)                                  //
        {                                                           //
            Console.Write($"{t} ,");                                //
        }
        return resMas;

    }
}

class MergeSort : ISortable
{
    public int[] Sort(int[] massive, int massSize)
    {
        int[] g;
        int[] resMas = (int[])massive.Clone();
        int boof;
        int centr = resMas.Length / 2;
        var massSeg = new ArraySegment<int>(resMas);

        int[] arrX = massSeg.Slice(0, centr).ToArray();
        int[] arrY = massSeg.Slice(centr).ToArray();

        
        Recur(arrX, arrY);

        int[] Recur(int[] arrX, int[] arrY)
        {

            
            if (arrX.Length > 1)
            {
               
                int massCentr = arrX.Length / 2;
                var massSeg = new ArraySegment<int>(arrX);
                int[] arrX_X = massSeg.Slice(0, massCentr).ToArray();
                int[] arrX_Y = massSeg.Slice(massCentr).ToArray();
                
                arrX = Recur(arrX_X, arrX_Y);

               
            }
            if (arrY.Length > 1)
            {
               
                int massCentr = arrY.Length / 2;
                var massSeg = new ArraySegment<int>(arrY);

                int[] arrY_X = massSeg.Slice(0, massCentr).ToArray();
                int[] arrY_Y = massSeg.Slice(massCentr).ToArray();
               
                arrY = Recur(arrY_X, arrY_Y);

            }
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
            return g;
        }
        return g;

    }
}

