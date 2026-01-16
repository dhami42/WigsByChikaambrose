# Render Deployment Instructions

## Step 1: Set Database Environment Variable in Render

Your application is currently failing on Render because it doesn't have the database connection string. Follow these steps:

### 1. Go to Render Dashboard
- Visit: https://dashboard.render.com/
- Log in to your account

### 2. Select Your Web Service
- Find and click on "wigsby-chikaambrose" service

### 3. Add Environment Variable
- Click on "Environment" in the left sidebar
- Click "Add Environment Variable" button
- Add the following:

**Key**: `DATABASE_URL`

**Value**: 
```
Host=pg-7b4c9ee-damiolorode-46c3.e.aivencloud.com;Port=23313;Database=defaultdb;Username=avnadmin;Password=YOUR_AIVEN_PASSWORD_HERE;SSL Mode=Require;Trust Server Certificate=true
```

**Important**: Replace `YOUR_AIVEN_PASSWORD_HERE` with your actual Aiven database password (starts with AVNS_...)

### 4. Save and Redeploy
- Click "Save Changes"
- Render will automatically redeploy your application
- Wait for the deployment to complete (usually 2-5 minutes)

### 5. Verify Deployment
- Once deployed, visit your Render URL
- The application should now connect to the Aiven PostgreSQL database successfully
- You should see your three wig products displayed

## Troubleshooting

If the deployment still fails:

1. **Check Logs**: Go to "Logs" tab in Render dashboard to see detailed error messages
2. **Verify Environment Variable**: Make sure DATABASE_URL is set correctly with no extra spaces
3. **Check Branch**: Ensure Render is deploying from the `master` branch (not `main`)
4. **Manual Deploy**: Try clicking "Manual Deploy" > "Deploy latest commit"

## Current Status

✅ Code pushed to GitHub successfully  
⏳ Waiting for Render environment variable configuration  
⏳ Waiting for Render redeployment  

## Local Development

Your local application should work fine with the `appsettings.Development.LOCAL.json` file that contains the Aiven credentials.

To run locally:
```bash
dotnet run --project WigsByChikaambrose.Web.csproj
```

Or use Visual Studio and press F5.

## Security Note

The actual database password is stored in:
- Local development: `appsettings.Development.LOCAL.json` (not in Git)
- Production: Render environment variables (secure)
- Never commit the actual password to Git
