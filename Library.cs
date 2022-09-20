namespace csharp_biblioteca;

public class Library
{
    private readonly List<Item> _items = new();

    public void Add(Item item)
    {
        if (_items.Contains(item))
            throw new ArgumentException("This item is already in this library.");
        
        _items.Add(item);
    }

    public Item FindByCode(string code)
    {
        Item? item = _items.Find(x => x.Code == code);

        if (item is null)
            throw new InvalidOperationException("Impossible to find this item in the library.");
        
        return item;
    }

    public List<Item> FindByTitle(string title)
    {
        List<Item> items = _items.FindAll(x => x.Title.Contains(title));
        return items;
    }
}