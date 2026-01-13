using Microsoft.EntityFrameworkCore;
using WigsByChikaambrose.Data;
using WigsByChikaambrose.Services;
using WigsByChikaambrose.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel for Render deployment
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // Render uses port 8080
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure database connection for production
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Use PostgreSQL for production (Render's free database) or SQL Server for development
if (builder.Environment.IsProduction())
{
    // For Render deployment - use PostgreSQL
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString ?? 
            Environment.GetEnvironmentVariable("DATABASE_URL") ?? 
            "Host=localhost;Database=wigsby_chikaambrose;Username=postgres;Password=password"));
}
else
{
    // For development - use SQL Server
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString ?? "Server=(localdb)\\mssqllocaldb;Database=WigsByChikaambrose;Trusted_Connection=true;MultipleActiveResultSets=true"));
}

// Add services
builder.Services.AddScoped<IProductService, ProductService>();

// Add health checks for Render
builder.Services.AddHealthChecks();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    try
    {
        // Ensure database is created
        await context.Database.EnsureCreatedAsync();
        
        // Run migrations if any
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }
        
        await SeedDatabase(context);
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Add health check endpoint for Render
app.MapHealthChecks("/health");

// Configure for production deployment
if (app.Environment.IsProduction())
{
    app.UseForwardedHeaders();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Configure port for Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();

static async Task SeedDatabase(ApplicationDbContext context)
{
    if (context.Categories.Any())
    {
        return; // Database has been seeded
    }

    // Seed Categories
    var categories = new List<Category>
    {
        new Category { Name = "Lace Wigs", Description = "Premium lace front and full lace wigs", Slug = "lace-wigs", SortOrder = 1 },
        new Category { Name = "Synthetic Wigs", Description = "High-quality synthetic hair wigs", Slug = "synthetic-wigs", SortOrder = 2 },
        new Category { Name = "Human Hair Wigs", Description = "100% human hair wigs", Slug = "human-hair-wigs", SortOrder = 3 },
        new Category { Name = "Closures & Frontals", Description = "Hair closures and frontals", Slug = "closures-frontals", SortOrder = 4 }
    };

    context.Categories.AddRange(categories);
    await context.SaveChangesAsync();

    // Seed Products - Only the specific uploaded wigs
    var products = new List<Product>
    {
        new Product
        {
            Name = "Wavy Curly Bone Straight 24\" Premium Wig",
            Description = "Luxurious wavy curly bone straight wig in 24 inches. Premium quality with natural movement and versatile styling options. Perfect for special occasions and everyday glamour.",
            Price = 600.00m,
            SKU = "WCB-STR-24-001",
            StockQuantity = 12,
            WigType = WigType.LaceFront,
            Length = "24 inches",
            Color = "Natural Black",
            Texture = "Wavy Curly Bone Straight",
            IsFeatured = true,
            CategoryId = categories.First(c => c.Name == "Lace Wigs").Id
        },
        new Product
        {
            Name = "6x6 Closure Unit - Dark Chocolate Brown with Ash Blonde Highlights",
            Description = "Stunning 6x6 closure unit featuring rich dark chocolate brown base with beautiful ash blonde highlights. Professional salon quality with seamless blending and natural parting.",
            Price = 620.00m,
            SKU = "6X6-DCB-ABH-002",
            StockQuantity = 8,
            WigType = WigType.Closure,
            Length = "20 inches",
            Color = "Dark Chocolate Brown with Ash Blonde Highlights",
            Texture = "Body Wave",
            IsFeatured = true,
            CategoryId = categories.First(c => c.Name == "Closures & Frontals").Id
        },
        new Product
        {
            Name = "Copper Mix Unit 24\" Frontal",
            Description = "Gorgeous copper mix frontal unit in 24 inches. Vibrant copper tones with natural blending for a stunning, eye-catching look. Heat-resistant and easy to style.",
            Price = 600.00m,
            SKU = "CPR-MIX-24F-003",
            StockQuantity = 10,
            WigType = WigType.Frontal,
            Length = "24 inches",
            Color = "Copper Mix",
            Texture = "Loose Wave",
            IsFeatured = true,
            CategoryId = categories.First(c => c.Name == "Closures & Frontals").Id
        }
    };

    context.Products.AddRange(products);
    await context.SaveChangesAsync();

    // Seed Product Images with your actual uploaded wig images (renamed for web compatibility)
    var productImages = new List<ProductImage>();
    
    // Wavy Curly Bone Straight 24" Premium Wig
    productImages.Add(new ProductImage
    {
        ProductId = products[0].Id,
        ImageUrl = "/images/products/wavy-curly-bone-straight.jpeg",
        AltText = "Wavy Curly Bone Straight 24\" Premium Wig - Main Image",
        IsPrimary = true,
        SortOrder = 1
    });
    
    productImages.Add(new ProductImage
    {
        ProductId = products[0].Id,
        ImageUrl = "/images/products/6x6-closure-dark-chocolate-ash-blonde.jpeg",
        AltText = "Wavy Curly Bone Straight 24\" Premium Wig - Alternative View",
        IsPrimary = false,
        SortOrder = 2
    });
    
    // 6x6 Closure Unit - Dark Chocolate Brown with Ash Blonde Highlights
    productImages.Add(new ProductImage
    {
        ProductId = products[1].Id,
        ImageUrl = "/images/products/6x6-closure-dark-chocolate-ash-blonde.jpeg",
        AltText = "6x6 Closure Unit - Dark Chocolate Brown with Ash Blonde Highlights - Main Image",
        IsPrimary = true,
        SortOrder = 1
    });
    
    productImages.Add(new ProductImage
    {
        ProductId = products[1].Id,
        ImageUrl = "/images/products/wavy-curly-bone-straight.jpeg",
        AltText = "6x6 Closure Unit - Dark Chocolate Brown with Ash Blonde Highlights - Alternative View",
        IsPrimary = false,
        SortOrder = 2
    });
    
    // Copper Mix Unit 24" Frontal
    productImages.Add(new ProductImage
    {
        ProductId = products[2].Id,
        ImageUrl = "/images/copper-mix-24-frontal.jpeg",
        AltText = "Copper Mix Unit 24\" Frontal - Main Image",
        IsPrimary = true,
        SortOrder = 1
    });
    
    productImages.Add(new ProductImage
    {
        ProductId = products[2].Id,
        ImageUrl = "/wig 2.jpeg",
        AltText = "Copper Mix Unit 24\" Frontal - Alternative View",
        IsPrimary = false,
        SortOrder = 2
    });

    context.ProductImages.AddRange(productImages);
    await context.SaveChangesAsync();

    // Seed Sample Customer
    var customer = new Customer
    {
        FirstName = "Jane",
        LastName = "Doe",
        Email = "customer@example.com",
        PhoneNumber = "+234 8166309083"
    };

    context.Customers.Add(customer);
    await context.SaveChangesAsync();

    // Seed Sample Reviews for your specific products
    var reviews = new List<Review>
    {
        new Review
        {
            ProductId = products[0].Id, // Wavy Curly Bone Straight 24"
            CustomerId = customer.Id,
            Rating = 5,
            Title = "Absolutely stunning quality!",
            Comment = "This wavy curly bone straight wig is incredible! The 24-inch length is perfect and the texture is so natural. Worth every penny of the $600!",
            IsApproved = true
        },
        new Review
        {
            ProductId = products[1].Id, // 6x6 Closure Unit
            CustomerId = customer.Id,
            Rating = 5,
            Title = "Perfect closure unit!",
            Comment = "The dark chocolate brown with ash blonde highlights is exactly what I wanted. The 6x6 closure gives such a natural parting. Excellent quality for $620!",
            IsApproved = true
        },
        new Review
        {
            ProductId = products[2].Id, // Copper Mix Unit Frontal
            CustomerId = customer.Id,
            Rating = 5,
            Title = "Love the copper mix!",
            Comment = "This copper mix frontal is gorgeous! The 24-inch length and loose wave texture are perfect. The color is so vibrant and natural-looking. Highly recommend!",
            IsApproved = true
        }
    };

    context.Reviews.AddRange(reviews);
    await context.SaveChangesAsync();
}