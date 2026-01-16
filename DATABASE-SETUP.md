# Database Configuration Setup

This project uses PostgreSQL (Aiven cloud database) for all environments.

## Local Development Setup

To run the application locally with the Aiven database:

1. Create a file named `appsettings.Development.LOCAL.json` in the project root
2. Add the following content with your Aiven credentials:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Host=pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com;Port=23313;Database=defaultdb;Username=avnadmin;Password=YOUR_PASSWORD_HERE;SSL Mode=Require;Trust Server Certificate=true"
  },
  "AllowedHosts": "*"
}
```

3. Replace `YOUR_PASSWORD_HERE` with your actual Aiven database password
4. This file is in `.gitignore` and will NOT be pushed to GitHub

## Render Deployment Setup

For deployment on Render.com:

1. Go to your Render dashboard
2. Select your web service
3. Go to "Environment" tab
4. Add a new environment variable:
   - **Key**: `DATABASE_URL`
   - **Value**: `Host=pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com;Port=23313;Database=defaultdb;Username=avnadmin;Password=YOUR_PASSWORD;SSL Mode=Require;Trust Server Certificate=true`

5. Save and redeploy

## Security Notes

- **NEVER** commit database passwords to Git
- Use `.LOCAL.json` files for local development (ignored by Git)
- Use environment variables for production deployment
- The `appsettings.Development.json` and `appsettings.Production.json` files in the repository contain placeholder values only

## Current Aiven Database Details

- **Host**: pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com
- **Port**: 23313
- **Database**: defaultdb
- **Username**: avnadmin
- **Password**: (stored securely in local files and Render environment variables)
- **SSL Mode**: Require
