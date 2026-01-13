using System.ComponentModel.DataAnnotations;

namespace WigsByChikaambrose.Models;

public enum WigType
{
    Lace,
    Synthetic,
    Human,
    Closure,
    Frontal,
    FullLace,
    LaceFront
}

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(2000)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(50)]
    public string SKU { get; set; } = string.Empty;
    
    public int StockQuantity { get; set; }
    public WigType WigType { get; set; }
    
    [StringLength(50)]
    public string Length { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string Color { get; set; } = string.Empty;
    
    [StringLength(50)]
    public string Texture { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
    public bool IsFeatured { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}

public class Category
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Slug { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class ProductImage
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(500)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [StringLength(200)]
    public string AltText { get; set; } = string.Empty;
    
    public bool IsPrimary { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}

public class Customer
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;
    
    [StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;
    
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    
    public string FullName => $"{FirstName} {LastName}";
}

public class Review
{
    public int Id { get; set; }
    
    [Range(1, 5)]
    public int Rating { get; set; }
    
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string Comment { get; set; } = string.Empty;
    
    public bool IsApproved { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}