@echo off
echo 🔧 Setting up Git for WigsByChikaambrose project...
echo.

echo 📋 Please enter your Git configuration:
echo.

set /p username="Enter your GitHub username: "
set /p email="Enter your GitHub email: "

echo.
echo 🔧 Configuring Git...
git config --global user.name "%username%"
git config --global user.email "%email%"

echo ✅ Git configured successfully!
echo.

echo 📂 Initializing repository (if needed)...
if not exist ".git" (
    git init
    echo ✅ Repository initialized
) else (
    echo ✅ Repository already exists
)

echo.
echo 📁 Adding files to Git...
git add .

echo.
echo 💾 Creating initial commit...
git commit -m "Add WigsByChikaambrose project with Aiven PostgreSQL database configuration"

echo.
echo 🌐 Ready to push to GitHub!
echo.
echo 📋 Next steps:
echo 1. Create a repository on GitHub.com named 'WigsByChikaambrose'
echo 2. Run: git remote add origin https://github.com/%username%/WigsByChikaambrose.git
echo 3. Run: git push -u origin main
echo.

pause