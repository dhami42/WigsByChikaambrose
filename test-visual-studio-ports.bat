@echo off
echo 🔍 Testing Visual Studio Launch Settings...
echo.

echo 📋 Current Launch Profiles:
echo 1. WigsByChikaambrose (Development) - Port 5257
echo 2. WigsByChikaambrose (HTTPS) - Port 7203/5257  
echo 3. WigsByChikaambrose (Production) - Port 5000
echo.

echo 🧪 Testing Development Profile (Port 5257)...
echo.
set ASPNETCORE_ENVIRONMENT=Development
echo Environment: %ASPNETCORE_ENVIRONMENT%
echo Expected Port: 5257
echo Database: Aiven PostgreSQL
echo.

echo 🚀 Starting with Visual Studio launch profile...
echo 💡 This should open at http://localhost:5257
echo 🛑 Press Ctrl+C to stop when ready
echo.

timeout /t 3 /nobreak > nul

start http://localhost:5257
dotnet run --project WigsByChikaambrose.Web.csproj --launch-profile "WigsByChikaambrose"