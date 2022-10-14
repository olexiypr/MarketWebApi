namespace WebApi.Models;

public class FilterModel
{
    public int? CategoryId { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}