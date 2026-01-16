@echo off
echo 🚀 Opening WigsByChikaambrose in Visual Studio...
echo.

echo 📂 Project Location: %CD%
echo 🗄️  Database: Aiven PostgreSQL (configured)
echo 🌐 Development URL: http://localhost:5257
echo 🌐 Production URL: http://localhost:5000
echo.

echo 🔧 Opening Visual Studio with WigsByChikaambrose solution...
start "" "WigsByChikaambrose.sln"

echo.
echo ✅ Visual Studio should now be opening with your project!
echo.
echo 📋 To run in Visual Studio:
echo 1. Wait for Visual Studio to fully load
echo 2. Select "WigsByChikaambrose (Development)" from the dropdown
echo 3. Press F5 or click the green "Start" button
echo 4. Your beautiful wig website will open in the browser!
echo.
echo 🗄️  Database: Already configured with your Aiven PostgreSQL
echo 💡 The app will automatically create tables and seed your wig products
echo.

pause