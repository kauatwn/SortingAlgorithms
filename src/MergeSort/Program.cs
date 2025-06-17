using System.Diagnostics;

var array = new int[1_000_000];
var tempArray = new int[array.Length];
FillArray(array);

Console.WriteLine($"Iniciando ordenação de um array com {array.Length:N0} elementos{Environment.NewLine}");

Stopwatch stopwatch = new();
stopwatch.Start();
MergeSort(array, tempArray, 0, array.Length - 1);
stopwatch.Stop();

Console.WriteLine("Ordenação concluída com sucesso!");
Console.WriteLine($"Tempo total de execução: {stopwatch.ElapsedMilliseconds:N0}ms");

return;

static void FillArray(int[] array)
{
    Random random = new();
    for (var i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(0, 10_000_000);
    }
}

// Método MergeSort principal (chamada inicial)
static void MergeSort(int[] array, int[] tempArray, int left, int right) // O(n log n) - Log-linear
{
    if (left < right)
    {
        // // Chance de overflow
        // int middle = (left + right) / 2;

        // Evita overflow
        int middle = left + (right - left) / 2;

        // Ordena a primeira metade do array (esquerda)
        MergeSort(array, tempArray, left, middle);

        // Ordena a segunda metade do array (direita)
        MergeSort(array, tempArray, middle + 1, right);

        // Combina as duas metades
        Merge(array, tempArray, left, middle, right);
    }

    return;

    // Método Merge otimizado (usa tempArray compartilhado)
    static void Merge(int[] array, int[] tempArray, int left, int middle, int right)
    {
        // Índice do subarray esquerdo
        int leftIndex = left;

        // Índice do subarray direito
        int rightIndex = middle + 1;

        // Índice do array temporário
        int mergePosition = left;

        // Copia a região a ser mesclada para tempArray
        Array.Copy(array, left, tempArray, left, middle - left + 1);

        // Combina os subarrays em ordem
        while (leftIndex <= middle && rightIndex <= right)
        {
            if (tempArray[leftIndex] <= array[rightIndex])
            {
                array[mergePosition++] = tempArray[leftIndex++];
            }
            else
            {
                array[mergePosition++] = array[rightIndex++];
            }
        }

        // Copia os elementos restantes (se houver)
        while (leftIndex <= middle)
        {
            array[mergePosition++] = tempArray[leftIndex++];
        }
    }
}