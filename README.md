# WigsByChikaambrose - Premium Wig E-commerce Platform

A beautiful, modern e-commerce website for premium wigs built with ASP.NET Core 9.0, featuring a world-class design with 3D effects, dark mode, and responsive layout.

## ✨ Features

- **Premium Wig Catalog**: Curated collection of high-quality wigs
- **Modern UI/UX**: Beautiful design with 3D effects and animations
- **Dark/Light Mode**: Toggle between themes
- **Responsive Design**: Works perfectly on all devices
- **Product Management**: Categories, detailed product pages, reviews
- **Professional Styling**: Feminine color palette with deep brand visibility
- **Contact Integration**: Cyprus-based business contact information

## 🚀 Quick Start

### Local Development

```bash
# Clone the repository
git clone <your-repo-url>
cd WigsByChikaambrose

# Restore packages
dotnet restore WigsByChikaambrose.Web.csproj

# Run the application
dotnet run --project WigsByChikaambrose.Web.csproj
```

Visit `http://localhost:5257` to see your application.

### Docker Development

```bash
# Build and run with Docker Compose (includes PostgreSQL)
docker-compose up

# Or build Docker image manually
docker build -t wigsby-chikaambrose .
docker run -p 8080:8080 wigsby-chikaambrose
```

## 🌐 Deployment

### Deploy to Render

This project is ready for deployment on Render with Docker:

1. **Push to GitHub**: Ensure your code is in a GitHub repository
2. **Create Render Account**: Sign up at [render.com](https://render.com)
3. **Follow Deployment Guide**: See [DEPLOYMENT.md](DEPLOYMENT.md) for detailed instructions

The project includes:
- ✅ `Dockerfile` for containerization
- ✅ `render.yaml` for automatic deployment
- ✅ PostgreSQL support for production
- ✅ Health checks and monitoring
- ✅ Production-ready configuration

### Environment Variables

For production deployment, configure:
- `ASPNETCORE_ENVIRONMENT=Production`
- `DATABASE_URL=<your-postgresql-connection-string>`

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core 9.0 MVC
- **Database**: SQL Server (dev) / PostgreSQL (production)
- **ORM**: Entity Framework Core 9.0
- **Frontend**: Bootstrap 5, Custom CSS with 3D effects
- **Deployment**: Docker, Render-ready
- **Features**: Health checks, logging, responsive design

## 📁 Project Structure

```
WigsByChikaambrose/
├── Controllers/          # MVC Controllers
├── Data/                # Entity Framework DbContext
├── Models/              # Data models and entities
├── Services/            # Business logic services
├── ViewModels/          # View-specific models
├── Views/               # Razor views and layouts
├── wwwroot/             # Static files (CSS, JS, images)
├── Dockerfile           # Docker configuration
├── docker-compose.yml   # Local development with PostgreSQL
├── render.yaml          # Render deployment configuration
└── DEPLOYMENT.md        # Detailed deployment guide
```

## 🎨 Design Features

- **Feminine Color Palette**: Pink, rose gold, and warm gradients
- **Deep Brand Colors**: High-contrast brand visibility in all themes
- **3D Effects**: Interactive product cards with hover animations
- **Glassmorphism**: Modern glass-like UI elements
- **Responsive Layout**: Mobile-first design approach
- **Dark Mode**: Complete theme switching capability

## 📞 Contact Information

- **Email**: chika.ambrose@gmail.com
- **Phone**: +234 8166309083
- **Location**: Limassol Marina District, Cyprus

## 🔧 Development

### Prerequisites

- .NET 9.0 SDK
- SQL Server (for local development)
- Docker (optional, for containerized development)

### Database

The application uses Entity Framework Core with automatic migrations and seeding. On first run, it will:
- Create the database schema
- Seed categories and products
- Add sample customer reviews

### Custom Styling

The project features extensive custom CSS with:
- CSS variables for theme support
- 3D animations and transitions
- Responsive breakpoints
- Custom scrollbars and UI elements

## 📄 License

This project is proprietary software for WigsByChikaambrose business.

---

**Ready to deploy your world-class wig e-commerce platform!** 🎉 - E-commerce Platform

A comprehensive e-commerce platform for a wig business built with ASP.NET Core MVC 9.0, featuring:

## Features Implemented

### Core Architecture
- **Clean Architecture**: Separated into Core, Infrastructure, and Web layers
- **Entity Framework Core**: Database management with SQL Server
- **Repository Pattern**: Data access abstraction
- **Dependency Injection**: Service registration and management

### Business Entities
- **Products**: Wig catalog with categories, images, and reviews
- **Customers**: User management and profiles
- **Orders**: Order processing and tracking
- **Cart**: Shopping cart functionality
- **Bookings**: Installation appointment scheduling
- **Reviews**: Customer feedback system

### Web Features
- **Product Catalog**: Browse wigs by type, category, and search
- **Product Details**: Detailed product pages with image galleries
- **Responsive Design**: Bootstrap-based UI with custom styling
- **Navigation**: Intuitive menu structure

## Project Structure

```
WigsByChikaambrose.sln
├── WigsByChikaambrose.Web (ASP.NET Core MVC 9.0)
│   ├── Controllers/
│   ├── Views/
│   ├── ViewModels/
│   └── wwwroot/
├── WigsByChikaambrose.Core (Class Library)
│   ├── Entities/
│   ├── Interfaces/
│   ├── Enums/
│   └── Constants/
├── WigsByChikaambrose.Infrastructure (Class Library)
│   ├── Data/
│   ├── Repositories/
│   └── Services/
└── WigsByChikaambrose.Tests (xUnit Test Project)
```

## Getting Started

1. **Prerequisites**
   - .NET 9.0 SDK
   - SQL Server or SQL Server LocalDB

2. **Database Setup**
   - The application uses Entity Framework Code First
   - Database will be created automatically on first run
   - Sample data is seeded automatically

3. **Running the Application**
   ```bash
   dotnet run --project WigsByChikaambrose.Web.csproj
   ```

## Next Steps

The foundation is in place for expanding with:
- User authentication and authorization
- Payment processing integration
- Order management system
- Booking calendar functionality
- Admin dashboard
- Email notifications
- Image upload and management

## Technology Stack

- **Backend**: ASP.NET Core MVC 9.0
- **Database**: Entity Framework Core with SQL Server
- **Frontend**: Bootstrap 5, jQuery, Font Awesome
- **Architecture**: Clean Architecture with Repository Pattern
- **Testing**: xUnit (ready for implementation)

This provides a solid foundation for a complete e-commerce platform with room for future enhancements and features.