using System.Text;
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
    StringBuilder sb = new();

    sb.Append('[');
    for (var i = 0; i < array.Length; i++)
    {
        sb.Append($"{array[i].Value:D2}({array[i].Id})");
        if (i < array.Length - 1) sb.Append(", ");
    }

    sb.AppendLine($"]{Environment.NewLine}");
    Console.Write(sb);
}

static int SelectionSort(Element[] array) // O(n^2) - Quadrática
{
    var swapCount = 0;

    for (var currentPosition = 0; currentPosition < array.Length - 1; currentPosition++)
    {
        int minIndex = currentPosition;
        for (int comparisonIndex = currentPosition + 1; comparisonIndex < array.Length; comparisonIndex++)
        {
            if (array[comparisonIndex].Value < array[minIndex].Value) minIndex = comparisonIndex;
        }

        if (minIndex != currentPosition)
        {
            Swap(array, currentPosition, minIndex); // Troca de elementos não estável
            swapCount++;
        }
    }

    return swapCount;

    static void Swap(Element[] array, int firstIndex, int secondIndex) =>
        (array[secondIndex], array[firstIndex]) = (array[firstIndex], array[secondIndex]);
}