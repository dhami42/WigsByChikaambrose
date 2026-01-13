using WigsByChikaambrose.Models;

namespace WigsByChikaambrose.Web.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string SKU { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public WigType WigType { get; set; }
    public string Length { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Texture { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public List<ProductImageViewModel> Images { get; set; } = new();
    public List<ReviewViewModel> Reviews { get; set; } = new();
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
    public bool IsInStock => StockQuantity > 0;
}

public class ProductImageViewModel
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string AltText { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
}

public class ReviewViewModel
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}