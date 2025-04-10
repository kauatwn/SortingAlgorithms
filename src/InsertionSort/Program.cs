var array = new int[10];
FillArray(array);

Console.WriteLine("Array gerado:");
PrintArray(array);

Console.WriteLine("Array ordenado:");
int swapCount = InsertionSort(array);
PrintArray(array);

Console.WriteLine($"Total de trocas: {swapCount}");

return;

static void FillArray(int[] array)
{
    var random = new Random();
    for (var i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(0, 100);
    }
}

static void PrintArray(int[] array)
{
    Console.Write("[");
    for (var i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]:D2}");
        if (i < array.Length - 1)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine($"]{Environment.NewLine}");
}

static int InsertionSort(int[] array) // O(n^2) - Quadrática
{
    var swapCount = 0;
    for (var i = 1; i < array.Length; i++) // O(n)
    {
        int current = array[i];
        int j = i - 1;

        while (j >= 0 && array[j] > current) // O(n)
        {
            array[j + 1] = array[j];
            j--;
            swapCount++;
        }

        array[j + 1] = current;
    }

    return swapCount;
}