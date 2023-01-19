namespace Scaffold.Domain.Seedwork;

public class PagedModel<TModel>
{
    private const int MaxPageSize = 500;

    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public int CurrentPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<TModel> Items { get; set; }

    public PagedModel()
    {
        Items = new List<TModel>();
    }

    public PagedModel(int currentPage, int totalItems, int totalPages, IEnumerable<TModel> items)
    {
        CurrentPage = currentPage;
        TotalItems = totalItems;
        TotalPages = totalPages;
        Items = items;
    }
}