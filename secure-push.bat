@echo off
echo 🔒 Preparing secure push to GitHub...
echo.

echo ⚠️  SECURITY CHECK: Removing sensitive database credentials from config files
echo.

echo 📁 Creating backup of original files...
if exist "appsettings.Production.json" (
    copy "appsettings.Production.json" "appsettings.Production.BACKUP.json"
    echo ✅ Backed up appsettings.Production.json
)

if exist "render.yaml" (
    copy "render.yaml" "render.BACKUP.yaml"
    echo ✅ Backed up render.yaml
)

echo.
echo 🔄 Replacing with secure versions...
if exist "appsettings.Production.SECURE.json" (
    copy "appsettings.Production.SECURE.json" "appsettings.Production.json"
    echo ✅ Updated appsettings.Production.json (credentials removed)
)

if exist "render.SECURE.yaml" (
    copy "render.SECURE.yaml" "render.yaml"
    echo ✅ Updated render.yaml (credentials removed)
)

echo.
echo 🔒 Security improvements applied:
echo - Database credentials removed from config files
echo - Original files backed up with .BACKUP extension
echo - Use environment variables in Render dashboard for DATABASE_URL
echo.

echo 📋 Your Aiven database connection string for Render:
echo postgres://avnadmin:AVNS_It8Wjir4KqYCYGHj6YHSSL@pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313/defaultdb?sslmode=require
echo.

echo ✅ Ready for secure GitHub push!
echo.
echo 📋 Next steps:
echo 1. Push code to GitHub (credentials now removed)
echo 2. In Render dashboard, set DATABASE_URL environment variable
echo 3. Deploy your application
echo.

pause