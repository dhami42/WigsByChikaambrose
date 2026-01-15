@echo off
echo 🔍 Testing Aiven PostgreSQL Database Connection...
echo.

set ASPNETCORE_ENVIRONMENT=Production
set DATABASE_URL=postgres://avnadmin:AVNS_It8Wjir4KqYCYGHj6YHSSL@pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313/defaultdb?sslmode=require

echo 🗄️  Database: pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313
echo 👤 User: avnadmin
echo 🔐 SSL: Required
echo.

echo 📦 Building application...
dotnet build WigsByChikaambrose.Web.csproj --configuration Release --verbosity quiet

if %ERRORLEVEL% NEQ 0 (
    echo ❌ Build failed!
    pause
    exit /b 1
)

echo ✅ Build successful!
echo.
echo 🔌 Testing database connection...
echo 💡 This will attempt to connect and create/seed the database
echo.

timeout /t 3 /nobreak > nul

dotnet run --project WigsByChikaambrose.Web.csproj --configuration Release --urls "http://localhost:5001"