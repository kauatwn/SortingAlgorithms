using System.Text;

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
    Random random = new();
    for (var i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(0, 100);
    }
}

static void PrintArray(int[] array)
{
    StringBuilder sb = new();

    sb.Append('[');
    for (var i = 0; i < array.Length; i++)
    {
        sb.Append($"{array[i]:D2}");
        if (i < array.Length - 1) sb.Append(", ");
    }

    sb.AppendLine($"]{Environment.NewLine}");
    Console.Write(sb);
}

static int BubbleSort(int[] array) // O(n^2) - Quadrática
{
    var swapCount = 0;
    for (var pass = 0; pass < array.Length; pass++)
    {
        var hasSwapped = false;
        for (var compareIndex = 0; compareIndex < array.Length - 1 - pass; compareIndex++)
        {
            if (array[compareIndex] > array[compareIndex + 1])
            {
                Swap(array, compareIndex, compareIndex + 1);
                hasSwapped = true;
                swapCount++;
            }
        }

        if (!hasSwapped)
        {
            break;
        }
    }

    return swapCount;

    static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        (array[secondIndex], array[firstIndex]) = (array[firstIndex], array[secondIndex]);
    }
}