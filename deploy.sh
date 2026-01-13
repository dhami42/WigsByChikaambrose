#!/bin/bash

# WigsByChikaambrose Deployment Script for Render

echo "🚀 Starting WigsByChikaambrose deployment process..."

# Build Docker image
echo "📦 Building Docker image..."
docker build -t wigsby-chikaambrose .

# Test the image locally (optional)
echo "🧪 Testing Docker image locally..."
docker run -d -p 8080:8080 --name wigsby-test wigsby-chikaambrose

# Wait a moment for the container to start
sleep 5

# Check if the container is running
if docker ps | grep -q wigsby-test; then
    echo "✅ Docker image is working correctly!"
    docker stop wigsby-test
    docker rm wigsby-test
else
    echo "❌ Docker image failed to start. Check the logs:"
    docker logs wigsby-test
    docker rm wigsby-test
    exit 1
fi

echo "🎉 Deployment preparation complete!"
echo ""
echo "📋 Next steps for Render deployment:"
echo "1. Push your code to GitHub"
echo "2. Connect your GitHub repo to Render"
echo "3. Use the render.yaml file for automatic deployment"
echo "4. Set up the PostgreSQL database in Render"
echo "5. Your app will be available at: https://your-app-name.onrender.com"