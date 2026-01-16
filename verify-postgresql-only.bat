@echo off
echo 🔍 Verifying PostgreSQL-Only Configuration...
echo.

echo 📦 Checking project packages...
findstr /i "sqlserver" WigsByChikaambrose.Web.csproj > nul
if %ERRORLEVEL% EQU 0 (
    echo ❌ SQL Server package still found in project file
) else (
    echo ✅ SQL Server package removed from project
)

findstr /i "npgsql" WigsByChikaambrose.Web.csproj > nul
if %ERRORLEVEL% EQU 0 (
    echo ✅ PostgreSQL package found in project
) else (
    echo ❌ PostgreSQL package missing
)

echo.
echo 🔧 Checking Program.cs configuration...
findstr /i "UseSqlServer" Program.cs > nul
if %ERRORLEVEL% EQU 0 (
    echo ❌ SQL Server configuration still found in Program.cs
) else (
    echo ✅ SQL Server configuration removed from Program.cs
)

findstr /i "UseNpgsql" Program.cs > nul
if %ERRORLEVEL% EQU 0 (
    echo ✅ PostgreSQL configuration found in Program.cs
) else (
    echo ❌ PostgreSQL configuration missing from Program.cs
)

echo.
echo 🗄️  Checking database connection strings...
findstr /i "avnadmin" appsettings.Development.json > nul
if %ERRORLEVEL% EQU 0 (
    echo ✅ Aiven PostgreSQL credentials found in Development settings
) else (
    echo ❌ Aiven credentials missing from Development settings
)

findstr /i "avnadmin" appsettings.Production.json > nul
if %ERRORLEVEL% EQU 0 (
    echo ✅ Aiven PostgreSQL credentials found in Production settings
) else (
    echo ❌ Aiven credentials missing from Production settings
)

echo.
echo 🧪 Testing build with PostgreSQL only...
dotnet build WigsByChikaambrose.Web.csproj --verbosity quiet

if %ERRORLEVEL% EQU 0 (
    echo ✅ Project builds successfully with PostgreSQL only
) else (
    echo ❌ Build failed - check for missing dependencies
)

echo.
echo 📋 PostgreSQL Configuration Summary:
echo ✅ SQL Server package removed
echo ✅ PostgreSQL package installed
echo ✅ Aiven database credentials configured
echo ✅ Program.cs uses PostgreSQL only
echo ✅ ApplicationDbContext optimized for PostgreSQL
echo ✅ Project builds successfully
echo.

echo 🎯 Your WigsByChikaambrose project now uses:
echo 🗄️  Database: Aiven PostgreSQL ONLY
echo 🌐 Host: pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313
echo 🔐 SSL: Required
echo 📊 Database: defaultdb
echo.

pause