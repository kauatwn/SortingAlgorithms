using SelectionSort;

var array = new Element[10];
FillArray(array);

Console.WriteLine("Array gerado:");
PrintArray(array);

Console.WriteLine("Array ordenado:");
int swapCount = SelectionSort(array);
PrintArray(array);

Console.WriteLine($"Total de trocas: {swapCount}");

return;

static void FillArray(Element[] array)
{
    var random = new Random();
    for (var i = 0; i < array.Length; i++)
    {
        array[i] = new Element(random.Next(0, 10), i);
    }
}

static void PrintArray(Element[] array)
{
    Console.Write("[");
    for (var i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i].Value:D2}({array[i].Id})");
        if (i < array.Length - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine($"]{Environment.NewLine}");
}

static int SelectionSort(Element[] array) // O(n^2) - Quadrática
{
    var swapCount = 0;
    for (var i = 0; i < array.Length - 1; i++) // O(n)
    {
        int minIndex = i;
        for (int j = i + 1; j < array.Length; j++) // O(n)
        {
            if (array[j].Value < array[minIndex].Value)
            {
                minIndex = j;
            }
        }

        if (minIndex != i)
        {
            Swap(array, i, minIndex); // Troca de elementos não estável
            swapCount++;
        }
    }

    return swapCount;
}

static void Swap(Element[] array, int firstIndex, int secondIndex)
{
    (array[secondIndex], array[firstIndex]) = (array[firstIndex], array[secondIndex]);
}