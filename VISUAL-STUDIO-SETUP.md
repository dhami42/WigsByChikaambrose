# Visual Studio Setup Guide - WigsByChikaambrose

## 🚀 Running Your Project in Visual Studio

### **Quick Start:**
1. **Run**: `run-in-visual-studio.bat` (opens Visual Studio automatically)
2. **Wait** for Visual Studio to load completely
3. **Select Profile**: "WigsByChikaambrose (Development)" from dropdown
4. **Press F5** or click the green "Start" button
5. **Enjoy** your beautiful wig website!

### 📋 **Launch Profiles Available:**

#### **1. WigsByChikaambrose (Development)** ⭐ *Recommended*
- **URL**: http://localhost:5257
- **Environment**: Development
- **Database**: Aiven PostgreSQL
- **Features**: Full debugging, hot reload

#### **2. WigsByChikaambrose (Production)**
- **URL**: http://localhost:5000
- **Environment**: Production
- **Database**: Aiven PostgreSQL
- **Features**: Production simulation

#### **3. HTTPS Profile**
- **URL**: https://localhost:7203
- **Environment**: Development
- **Features**: SSL/HTTPS testing

#### **4. Docker Profile**
- **URL**: http://localhost:8080
- **Environment**: Docker container
- **Features**: Container testing

### 🗄️ **Database Configuration:**

Your project is **already configured** with:
- ✅ **Aiven PostgreSQL** connection in both Development and Production
- ✅ **Automatic database creation** on first run
- ✅ **Sample data seeding** with your 3 premium wigs
- ✅ **Entity Framework migrations** handled automatically

**Connection Details:**
```
Host: pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com:23313
Database: defaultdb
SSL: Required
```

### 🎯 **What Happens When You Run:**

1. **Visual Studio starts** the application
2. **Database connection** established to Aiven PostgreSQL
3. **Tables created** automatically (Categories, Products, etc.)
4. **Sample data seeded**:
   - Wavy Curly Bone Straight 24" ($600)
   - 6x6 Closure Unit Dark Chocolate Brown with Ash Blonde Highlights ($620)
   - Copper Mix Unit 24" Frontal ($600)
5. **Browser opens** with your beautiful wig website
6. **Ready for customers!**

### 🔧 **Visual Studio Features:**

#### **Debugging:**
- ✅ Set breakpoints in controllers and services
- ✅ Step through database operations
- ✅ Inspect variables and objects
- ✅ Hot reload for instant changes

#### **IntelliSense:**
- ✅ Full code completion
- ✅ Error detection
- ✅ Refactoring tools
- ✅ Database context awareness

#### **Package Management:**
- ✅ NuGet packages already configured
- ✅ Entity Framework Core 9.0
- ✅ PostgreSQL provider (Npgsql)
- ✅ All dependencies resolved

### 🌐 **Your Website Features:**

When running in Visual Studio, you'll have access to:
- **Beautiful homepage** with your wig products
- **Product catalog** with filtering and search
- **Product details** pages with images
- **About page** with your business story
- **Contact page** with Cyprus location
- **Dark/Light mode** toggle
- **Responsive design** for all devices
- **Professional styling** with 3D effects

### 🛠️ **Troubleshooting:**

#### **If Visual Studio doesn't open:**
1. Right-click `WigsByChikaambrose.sln`
2. Select "Open with Visual Studio"
3. Or open Visual Studio manually and use File → Open → Project/Solution

#### **If database connection fails:**
- Check your internet connection
- Verify Aiven database is accessible
- Connection string is already configured correctly

#### **If build fails:**
1. Clean solution: Build → Clean Solution
2. Rebuild: Build → Rebuild Solution
3. Restore packages: Tools → NuGet Package Manager → Package Manager Console → `dotnet restore`

#### **If port is in use:**
- Visual Studio will automatically find an available port
- Or change the port in `Properties/launchSettings.json`

### 🎨 **Development Tips:**

#### **Making Changes:**
- **Views**: Edit `.cshtml` files for UI changes
- **Styling**: Modify `wwwroot/css/site.css` for design updates
- **Logic**: Update controllers and services for functionality
- **Database**: Modify models and run migrations

#### **Hot Reload:**
- Changes to views and CSS apply instantly
- Code changes require rebuild (Ctrl+Shift+B)

#### **Testing:**
- Use different launch profiles to test various scenarios
- Test both Development and Production environments
- Verify database operations in SQL logs

### 📱 **Mobile Testing:**
- Visual Studio includes mobile emulation
- Test responsive design on different screen sizes
- Your wig website works perfectly on all devices

---

## ✅ **Ready to Develop!**

Your WigsByChikaambrose project is fully configured for Visual Studio development with:
- 🗄️ Live Aiven PostgreSQL database
- 🎨 Beautiful responsive design
- 🛍️ Complete e-commerce functionality
- 🌐 Production-ready deployment configuration

**Just press F5 and start building your wig empire!** 🚀👑