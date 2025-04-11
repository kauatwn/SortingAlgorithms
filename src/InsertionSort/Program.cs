var array = new int[10];
FillArray(array);

Console.WriteLine("Array gerado:");
PrintArray(array);

Console.WriteLine("Array ordenado:");
int shiftCount = InsertionSort(array);
PrintArray(array);

Console.WriteLine($"Total de deslocamentos à direita: {shiftCount}");

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
    var shiftCount = 0;
    for (var i = 1; i < array.Length; i++) // O(n)
    {
        int current = array[i];
        int previousIndex = i - 1;

        while (previousIndex >= 0 && array[previousIndex] > current) // O(n)
        {
            ShiftRight(array, previousIndex);
            previousIndex--;
            shiftCount++;
        }

        array[previousIndex + 1] = current;
    }

    return shiftCount;

    static void ShiftRight(int[] array, int previousIndex)
    {
        array[previousIndex + 1] = array[previousIndex];
    }
}