namespace CodeAcademyNET8.Advanced___OOP.Classes.Generics;

internal class MySelfMadeList<T>
{
    private T[] _array;
    private int _size;

    public MySelfMadeList(int initialSize = 5)
    {
        _size = initialSize;
        _array = new T[_size];
        Length = 0;
    }

    public int Length { get; private set; }

    public void Add(T value)
    {
        if (Length == _size) ResizeArray();

        _array[Length++] = value;
    }

    public void Remove(T value)
    {
        for (var i = 0; i < Length; i++)
            if (EqualityComparer<T>.Default.Equals(_array[i], value))
            {
                for (var j = i; j < Length - 1; j++)
                    _array[j] = _array[j + 1];

                _array[--Length] = default!;
                return;
            }

        Console.WriteLine("Value not found!");
    }

    public void Clear()
    {
        for (var i = 0; i < Length; i++) _array[i] = default!;
        Length = 0;
    }

    public void Print()
    {
        for (var i = 0; i < Length; i++) Console.WriteLine(_array[i]);
    }

    private void ResizeArray()
    {
        _size += _size / 2;
        var newArray = new T[_size];
        Array.Copy(_array, newArray, _array.Length);
        _array = newArray;
    }
}