# Sorting Algorithms

Este repositório contém anotações e implementações para explorar e entender algoritmos de ordenação e sua complexidade computacional.

## Pré-requisitos

Escolha uma das seguintes opções para executar o projeto:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)

## Como Executar

Você pode executar o projeto de duas formas:

1. **Com Docker** (recomendado para evitar configurações locais)
2. **Localmente com .NET SDK** (caso já tenha o ambiente .NET configurado)

### Clone o Projeto

Clone este repositório em sua máquina local:

```bash
git clone https://github.com/kauatwn/SortingAlgorithms.git
```

### Executar com Docker

1. Navegue até a pasta raiz do projeto:

    ```bash
    cd SortingAlgorithms/
    ```

2. Construa a imagem Docker:

    ```bash
    docker compose build
    ```

3. Execute o container desejado (substitua `<algorithm>` por: `bubblesort`, `insertionsort`, `mergesort`, `quicksort` ou `selectionsort`):

    ```bash
    docker compose run --rm <algorithm>
    ```

### Executar Localmente com .NET SDK

1. Navegue até o projeto do algoritmo desejado (substitua `<project>` por: `BubbleSort`, `InsertionSort`, `MergeSort`, `QuickSort` ou `SelectionSort`):

    ```bash
    cd src/<project>/
    ```

2. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

3. Inicie a aplicação:

    ```bash
    dotnet run
    ```

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

```plaintext
SortingAlgorithms/
└── src/
    ├── BubbleSort/
    ├── InsertionSort/
    ├── MergeSort/
    ├── QuickSort/
    └── SelectionSort/
```
