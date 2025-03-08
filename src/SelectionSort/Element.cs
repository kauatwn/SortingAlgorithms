namespace SelectionSort;

internal readonly struct Element(int value, int id)
{
    public int Value { get; } = value;
    public int Id { get; } = id;
}