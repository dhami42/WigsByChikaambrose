@echo off
echo ⚡ Quick Start - Skip Visual Studio Diagnostics...
echo.

echo 🔧 Visual Studio is running diagnostics (this is normal for .NET 9.0)
echo 💡 While waiting, let's run your project directly!
echo.

echo 🚀 Starting WigsByChikaambrose without waiting for Visual Studio...
echo.

set ASPNETCORE_ENVIRONMENT=Development
echo 🌐 Environment: %ASPNETCORE_ENVIRONMENT%
echo 🗄️  Database: Aiven PostgreSQL (ready)
echo 📱 URL: http://localhost:5257
echo.

echo 📦 Quick build...
dotnet build WigsByChikaambrose.Web.csproj --configuration Debug --verbosity minimal

if %ERRORLEVEL% NEQ 0 (
    echo ❌ Build failed! Check for errors.
    pause
    exit /b 1
)

echo ✅ Build successful!
echo.
echo 🌐 Starting your beautiful wig website...
echo 💡 Browser will open automatically
echo 🛑 Press Ctrl+C to stop when ready
echo.

timeout /t 2 /nobreak > nul

start http://localhost:5257
dotnet run --project WigsByChikaambrose.Web.csproj --urls "http://localhost:5257"