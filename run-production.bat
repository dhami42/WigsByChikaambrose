@echo off
echo 🚀 Starting WigsByChikaambrose in Production Mode with Aiven PostgreSQL...
echo.

set ASPNETCORE_ENVIRONMENT=Production
set DATABASE_URL=postgres://avnadmin:AVNS_It8Wjir4KqYCYGHj6YHSSL@pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313/defaultdb?sslmode=require

echo 🔧 Environment: %ASPNETCORE_ENVIRONMENT%
echo 🗄️  Database: Aiven PostgreSQL (pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com)
echo.

echo 📦 Building application...
dotnet build WigsByChikaambrose.Web.csproj --configuration Release

if %ERRORLEVEL% NEQ 0 (
    echo ❌ Build failed!
    pause
    exit /b 1
)

echo ✅ Build successful!
echo.
echo 🌐 Starting application on http://localhost:5000...
echo 💡 Press Ctrl+C to stop the application
echo.

dotnet run --project WigsByChikaambrose.Web.csproj --configuration Release