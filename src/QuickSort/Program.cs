using System.Diagnostics;

var array = new int[1_000_000];
FillArray(array);
Console.WriteLine($"Iniciando ordenação de um array com {array.Length:N0} elementos{Environment.NewLine}");

Stopwatch stopwatch = new();
stopwatch.Start();
QuickSort(array, 0, array.Length - 1);
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

// QuickSort com esquema de particionamento de Hoare
static void QuickSort(int[] array, int left, int right)
{
    if (left < right)
    {
        // Particiona o array
        int partitionIndex = Partition(array, left, right);

        // Ordena a primeira metade do array (esquerda)
        QuickSort(array, left, partitionIndex);

        // Ordena a segunda metade do array (direita)
        QuickSort(array, partitionIndex + 1, right);
    }

    return;

    // Método Partition otimizado (escolhe o pivô como o elemento do meio)
    static int Partition(int[] array, int left, int right)
    {
        // // Chance de overflow
        // int middle = (left + right) / 2;

        // Evita overflow
        int middle = left + (right - left) / 2;

        // Escolhe o pivô como o elemento do meio
        int pivot = array[middle];

        // Índice do subarray esquerdo
        int leftIndex = left - 1;

        // Índice do subarray direito
        int rightIndex = right + 1;

        while (true)
        {
            do
            {
                leftIndex++;
            } while (array[leftIndex] < pivot);

            do
            {
                rightIndex--;
            } while (array[rightIndex] > pivot);

            // Verifica se os índices se cruzaram e retorna o índice do pivô
            if (leftIndex >= rightIndex)
            {
                return rightIndex;
            }

            // Troca os elementos se os índices não se cruzaram
            Swap(array, leftIndex, rightIndex);
        }

        static void Swap(int[] array, int firstIndex, int secondIndex) =>
            (array[secondIndex], array[firstIndex]) = (array[firstIndex], array[secondIndex]);
    }
}