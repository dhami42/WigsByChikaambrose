using Microsoft.AspNetCore.Mvc;
using WigsByChikaambrose.Services;
using WigsByChikaambrose.Models;
using WigsByChikaambrose.Web.ViewModels;

namespace WigsByChikaambrose.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(WigType? wigType, int? categoryId, string? search)
    {
        var products = await GetFilteredProducts(wigType, categoryId, search);
        
        var viewModel = products.Select(p => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            SKU = p.SKU,
            StockQuantity = p.StockQuantity,
            WigType = p.WigType,
            Length = p.Length,
            Color = p.Color,
            Texture = p.Texture,
            IsFeatured = p.IsFeatured,
            CategoryName = p.Category?.Name ?? "",
            Images = p.Images.Select(i => new ProductImageViewModel
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                AltText = i.AltText,
                IsPrimary = i.IsPrimary
            }).ToList()
        }).ToList();

        ViewBag.CurrentWigType = wigType;
        ViewBag.CurrentCategoryId = categoryId;
        ViewBag.CurrentSearch = search;

        return View(viewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            SKU = product.SKU,
            StockQuantity = product.StockQuantity,
            WigType = product.WigType,
            Length = product.Length,
            Color = product.Color,
            Texture = product.Texture,
            IsFeatured = product.IsFeatured,
            CategoryName = product.Category?.Name ?? "",
            Images = product.Images.OrderBy(i => i.SortOrder).Select(i => new ProductImageViewModel
            {
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                AltText = i.AltText,
                IsPrimary = i.IsPrimary
            }).ToList(),
            Reviews = product.Reviews.Where(r => r.IsApproved).Select(r => new ReviewViewModel
            {
                Id = r.Id,
                Rating = r.Rating,
                Title = r.Title,
                Comment = r.Comment,
                CustomerName = r.Customer.FullName,
                CreatedAt = r.CreatedAt
            }).ToList()
        };

        if (viewModel.Reviews.Any())
        {
            viewModel.AverageRating = viewModel.Reviews.Average(r => r.Rating);
            viewModel.ReviewCount = viewModel.Reviews.Count;
        }

        return View(viewModel);
    }

    private async Task<IEnumerable<Product>> GetFilteredProducts(
        WigType? wigType, int? categoryId, string? search)
    {
        if (!string.IsNullOrEmpty(search))
        {
            return await _productService.SearchProductsAsync(search);
        }
        
        if (wigType.HasValue)
        {
            return await _productService.GetProductsByTypeAsync(wigType.Value);
        }
        
        if (categoryId.HasValue)
        {
            return await _productService.GetProductsByCategoryAsync(categoryId.Value);
        }
        
        return await _productService.GetAllProductsAsync();
    }
}