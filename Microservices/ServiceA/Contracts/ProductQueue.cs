namespace ServiceOrder.Contracts;

public class ProductQueue
{
    public string Product { get; set; }

    public List<int> UserIds { get; set; }
}