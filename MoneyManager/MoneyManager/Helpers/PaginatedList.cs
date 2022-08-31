namespace MoneyManager.Helpers;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int FirstPage { get; private set; }
    public int LastPage { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        FirstPage = 1;
        LastPage = TotalPages;

        this.AddRange(items);
    }

    public bool HasPreviousPage
    {
        get
        {
            return (PageIndex > 1);
        }
    }

    public bool HasNextPage
    {
        get
        {
            return (PageIndex < TotalPages);
        }
    }

    public static Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count();
        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult(new PaginatedList<T>(items, count, pageIndex, pageSize));
    }
}
