namespace Scaffold.Domain.Seedwork;

public abstract class BaseQueryParameters
{
    public int Page { get; set; }
    public int Limit { get; set; }
    public string Sort { get; set; }
    public string Order { get; set; }
    
    protected BaseQueryParameters()
    {
        Page = 1;
        Limit = 50;
        Sort = "id";
        Order = "asc";
    }
}