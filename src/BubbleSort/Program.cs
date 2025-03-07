var array = new int[10];
FillArray(array);

Console.WriteLine("Array gerado:");
PrintArray(array);

Console.WriteLine("Array ordenado:");
int swapCount = BubbleSort(array);
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

    Console.WriteLine("]");
    Console.WriteLine();
}

static int BubbleSort(int[] array) // O(n^2)
{
    var swapCount = 0;
    for (var i = 0; i < array.Length; i++) // O(n)
    {
        var swapped = false;
        for (var j = 0; j < array.Length - 1 - i; j++) // O(n)
        {
            if (array[j] > array[j + 1])
            {
                Swap(array, j, j + 1);
                swapped = true;
                swapCount++;
            }
        }

        if (!swapped)
        {
            break;
        }
    }

    return swapCount;
}

static void Swap(int[] array, int i, int j)
{
    // Usando tupla implícita para trocar valores
    (array[j], array[i]) = (array[i], array[j]);

    //// Usando variável temporária (forma tradicional)
    //int temp = array[i];
    //array[i] = array[j];
    //array[j] = temp;
}