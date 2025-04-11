var array = new int[10];
var tempArray = new int[array.Length];
FillArray(array);

Console.WriteLine("Array gerado:");
PrintArray(array);

Console.WriteLine("Array ordenado:");
MergeSort(array, 0, array.Length - 1, tempArray);
PrintArray(array);

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

// Método MergeSort principal (chamada inicial)
static void MergeSort(int[] array, int left, int right, int[] tempArray) // O(n log n) - Log-linear
{
    if (left < right)
    {
        // // Chance de overflow
        // int middle = (left + right) / 2;

        // Evita overflow
        int middle = left + (right - left) / 2;

        // Ordena a primeira metade do array (esquerda)
        MergeSort(array, left, middle, tempArray);

        // Ordena a segunda metade do array (direita)
        MergeSort(array, middle + 1, right, tempArray);

        // Combina as duas metades
        Merge(array, left, middle, right, tempArray);
    }

    return;

    // Método Merge otimizado (usa tempArray compartilhado)
    static void Merge(int[] array, int left, int middle, int right, int[] tempArray)
    {
        // Índice do subarray esquerdo
        int leftIndex = left;

        // Índice do subarray direito
        int rightIndex = middle + 1;

        // Índice do array temporário
        int mergePosition = left;

        // Copia a região a ser mesclada para tempArray
        Array.Copy(array, left, tempArray, left, right - left + 1);

        // Combina os subarrays em ordem
        while (leftIndex <= middle && rightIndex <= right)
        {
            if (tempArray[leftIndex] <= tempArray[rightIndex])
            {
                array[mergePosition++] = tempArray[leftIndex++];
            }
            else
            {
                array[mergePosition++] = tempArray[rightIndex++];
            }
        }

        // Copia os elementos restantes (se houver)
        while (leftIndex <= middle)
        {
            array[mergePosition++] = tempArray[leftIndex++];
        }
    }
}