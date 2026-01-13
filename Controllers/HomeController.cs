using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WigsByChikaambrose.Models;
using WigsByChikaambrose.Services;
using WigsByChikaambrose.Web.ViewModels;

namespace WigsByChikaambrose.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _productService.GetFeaturedProductsAsync();
            
            var viewModel = featuredProducts.Select(p => new ProductViewModel
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
                Images = p.Images.Where(i => i.IsPrimary).Select(i => new ProductImageViewModel
                {
                    Id = i.Id,
                    ImageUrl = i.ImageUrl,
                    AltText = i.AltText,
                    IsPrimary = i.IsPrimary
                }).ToList()
            }).ToList();

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
