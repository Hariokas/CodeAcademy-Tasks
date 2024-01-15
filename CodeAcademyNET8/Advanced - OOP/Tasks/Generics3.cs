using static CodeAcademyNET8.Helpers;

namespace CodeAcademyNET8.Advanced___OOP.Tasks;

internal class Generics3
{
    public static void RunTasks()
    {
        Task1();
        Task2();
        //Task3();
        //Task4();
    }

    private static void Task1()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var readOnlyList = new ReadOnlyList<int>(list);

        readOnlyList.FindAllMatches(x => x > 2);

        readOnlyList.PrintList();

        Separator();
    }

    private static void Task2()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var typeTList = new TypeTList<int>(list);

        typeTList.PrintAllItems();

        Separator();
    }
}

// Task 1
internal class ReadOnlyList<T>
{
    private readonly List<T> _list;

    public ReadOnlyList(List<T> list)
    {
        Validator.EnsureNotNull(list);
        _list = list;
    } 

    public void PrintList()
    {
        foreach (var item in _list)
            Console.WriteLine(item);
    }

    public T[] GetArray()
    {
        return _list.ToArray();
    }

    public T FindOneMatch(Predicate<T> predicate)
    {
        Validator.EnsureNotNull(predicate);
        var matches = _list.FindAll(predicate);

        //if (matches.Count == 0)
        //    throw new Exception("No matches found");
        //if (matches.Count > 1)
        //    throw new Exception("More than one match found");
        //return matches[0];

        // ReShaper RULEZZZ!
        return matches.Count switch
        {
            0 => throw new Exception("No matches found"),
            > 1 => throw new Exception("More than one match found"),
            _ => matches[0]
        };
    }

    public T[]? FindAllMatches(Predicate<T> predicate)
    {
        Validator.EnsureNotNull(predicate);
        var matches = _list.FindAll(predicate);

        return matches.Count switch
        {
            0 => default,
            > 1 => throw new Exception("More than one match found"),
            _ => matches.ToArray()
        };
    }

    public bool CheckType(T item)
    {
        return _list.Contains(item);
    }
}

// Task 2
internal class TypeTList<T>(List<T>? list = null)
{
    private readonly List<T> _items = list ?? new List<T>();

    public void PrintAllItems()
    {
        foreach (var item in _items)
            Console.WriteLine(item);
    }

    public T[] GetArray()
    {
        return _items.ToArray();
    }

    public void AddItem(T item)
    {
        Validator.EnsureNotNull(item);
        _items.Add(item);
    }

    public void AddItem(List<T> itemList)
    {
        Validator.EnsureNotNull(itemList);
        _items.AddRange(itemList);
    }

    public void RemoveItem(T item)
    {
        Validator.EnsureNotNull(item);
        _items.Remove(item);
    }

    public void RemoveItemByIndex(int index)
    {
        _items.RemoveAt(index);
    }

    public void RemoveRepeatedItems(T item)
    {
        Validator.EnsureNotNull(item);
        _items.RemoveAll(x => x.Equals(item));
    }
}

internal static class Validator
{
    public static void EnsureNotNull<T>(T value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));
    }
}