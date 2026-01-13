# WigsByChikaambrose - Deployment Guide

## 🚀 Deploying to Render

This guide will help you deploy your WigsByChikaambrose application to Render using Docker.

### Prerequisites

1. **GitHub Account**: Your code should be in a GitHub repository
2. **Render Account**: Sign up at [render.com](https://render.com)
3. **Docker** (for local testing): Install Docker Desktop

### 📁 Files Added for Deployment

- `Dockerfile` - Container configuration
- `docker-compose.yml` - Local development with PostgreSQL
- `render.yaml` - Render deployment configuration
- `appsettings.Production.json` - Production settings
- `.dockerignore` - Files to exclude from Docker build
- `deploy.sh` - Deployment helper script

### 🔧 Step-by-Step Deployment

#### 1. Prepare Your Repository

```bash
# Add all deployment files to git
git add .
git commit -m "Add Docker and Render deployment configuration"
git push origin main
```

#### 2. Create Render Services

1. **Go to Render Dashboard**: https://dashboard.render.com
2. **Create PostgreSQL Database**:
   - Click "New +" → "PostgreSQL"
   - Name: `wigsby-chikaambrose-db`
   - Plan: Free
   - Region: Oregon (or your preferred region)
   - Note the connection details

3. **Create Web Service**:
   - Click "New +" → "Web Service"
   - Connect your GitHub repository
   - Choose your WigsByChikaambrose repository
   - Configuration:
     - **Environment**: Docker
     - **Plan**: Free
     - **Region**: Oregon (same as database)
     - **Branch**: main
     - **Dockerfile Path**: `./Dockerfile`

#### 3. Configure Environment Variables

In your Render web service settings, add these environment variables:

```
ASPNETCORE_ENVIRONMENT=Production
ASPNETCORE_URLS=http://+:8080
DATABASE_URL=[Your PostgreSQL connection string from step 2]
```

The DATABASE_URL should look like:
```
postgresql://username:password@hostname:port/database_name
```

#### 4. Deploy

1. Click "Create Web Service"
2. Render will automatically build and deploy your application
3. Monitor the build logs for any issues
4. Once deployed, your app will be available at: `https://your-app-name.onrender.com`

### 🧪 Local Testing with Docker

Test your Docker setup locally before deploying:

```bash
# Build the image
docker build -t wigsby-chikaambrose .

# Run with docker-compose (includes PostgreSQL)
docker-compose up

# Or run just the app (you'll need to configure a database)
docker run -p 8080:8080 wigsby-chikaambrose
```

Visit http://localhost:8080 to test locally.

### 🔍 Health Checks

The application includes a health check endpoint at `/health` that Render uses to monitor your application.

### 📊 Database Migrations

The application automatically:
- Creates the database schema on startup
- Seeds initial data (categories, products, sample reviews)
- Handles both SQL Server (development) and PostgreSQL (production)

### 🛠️ Troubleshooting

#### Build Failures
- Check the Render build logs
- Ensure all NuGet packages are compatible with .NET 9.0
- Verify Dockerfile syntax

#### Database Connection Issues
- Verify DATABASE_URL environment variable
- Check PostgreSQL database is running
- Ensure connection string format is correct

#### Application Startup Issues
- Check application logs in Render dashboard
- Verify port 8080 is configured correctly
- Check health endpoint: `https://your-app.onrender.com/health`

### 🔒 Security Considerations

- Database credentials are managed by Render
- HTTPS is automatically provided by Render
- Application runs as non-root user in container
- Static files are served securely

### 💰 Cost Considerations

**Free Tier Limitations**:
- Web service sleeps after 15 minutes of inactivity
- PostgreSQL database: 1GB storage, 1 month retention
- 750 hours/month compute time

**Upgrade Options**:
- Paid plans provide always-on services
- Larger database storage and longer retention
- Custom domains and advanced features

### 🎯 Production Optimizations

The deployment includes:
- Multi-stage Docker build for smaller images
- Production logging configuration
- Health checks for monitoring
- Automatic database migrations
- Static file optimization
- Security headers and HTTPS

### 📞 Support

If you encounter issues:
1. Check Render documentation: https://render.com/docs
2. Review application logs in Render dashboard
3. Test locally with Docker first
4. Check GitHub repository for updates

---

## 🎉 Your WigsByChikaambrose website is now ready for the world!

Once deployed, your beautiful wig e-commerce platform will be accessible globally with:
- ✅ Professional hosting on Render
- ✅ PostgreSQL database
- ✅ HTTPS security
- ✅ Automatic deployments from GitHub
- ✅ Health monitoring
- ✅ Scalable infrastructure