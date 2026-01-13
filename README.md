# WigsByChikaambrose - E-commerce Platform

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