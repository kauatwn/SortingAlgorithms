﻿using System.Globalization;

string[] array =
[
    "Brasil", "Japão", "Canadá", "Austrália", "Argentina", "Índia", "Itália", "México", "África do Sul", "China",
    "França", "Alemanha", "Rússia", "Reino Unido", "Espanha", "Portugal", "Egito", "Nigéria", "Coreia do Sul",
    "Tailândia", "Vietnã", "Indonésia", "Turquia", "Países Baixos", "Bélgica", "Suíça", "Suécia", "Noruega",
    "Dinamarca", "Finlândia", "Polônia", "Ucrânia", "Grécia", "Colômbia", "Peru", "Chile", "Venezuela", "Cuba",
    "Costa Rica", "Panamá", "Equador", "Bolívia", "Paraguai", "Uruguai", "Nova Zelândia", "Filipinas", "Malásia",
    "Singapura", "Israel", "Arábia Saudita", "Irã", "Iraque"
];

Console.WriteLine("Array gerado:");
Console.WriteLine($"[{string.Join(", ", array)}]{Environment.NewLine}");

Console.WriteLine("Array ordenado:");
InsertionSort(array);
Console.WriteLine($"[{string.Join(", ", array)}]{Environment.NewLine}");

return;

static void InsertionSort(string[] array) // O(n^2) - Quadrática
{
    var comparer = StringComparer.Create(new CultureInfo("pt-BR"),
        CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);

    for (var i = 1; i < array.Length; i++)
    {
        string currentValue = array[i];
        int previousIndex = i - 1;

        while (previousIndex >= 0 && comparer.Compare(array[previousIndex], currentValue) > 0)
        {
            ShiftRight(array, previousIndex);
            previousIndex--;
        }

        array[previousIndex + 1] = currentValue;
    }

    return;

    static void ShiftRight(string[] array, int previousIndex)
    {
        array[previousIndex + 1] = array[previousIndex];
    }
}