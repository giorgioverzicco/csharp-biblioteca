namespace csharp_biblioteca;

public class Book : Item
{
    public int PageCount { get; }
    
    public Book(string title, int year, int pageCount)
        : base(title, year)
    {
        PageCount = pageCount;
    }
    
    public Book(string title, int year, int pageCount, string category, string shelf, Author author) 
        : base(title, year, category, shelf, author)
    {
        PageCount = pageCount;
    }

    public override string ToString()
    {
        return
            $"Code: {Code}\n" +
            $"Title: {Title}\n" +
            $"Year: {Year}\n" +
            $"Pages: {PageCount}\n";
    }
}