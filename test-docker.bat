@echo off
echo 🐳 Testing Docker build for WigsByChikaambrose...
echo.

echo 📦 Building Docker image...
docker build -t wigsby-chikaambrose-test .

if %ERRORLEVEL% NEQ 0 (
    echo ❌ Docker build failed!
    pause
    exit /b 1
)

echo ✅ Docker build successful!
echo.
echo 🧪 Testing container startup...
docker run -d -p 8080:8080 --name wigsby-test wigsby-chikaambrose-test

timeout /t 10 /nobreak > nul

docker ps | findstr wigsby-test > nul
if %ERRORLEVEL% EQU 0 (
    echo ✅ Container is running successfully!
    echo 🌐 Test at: http://localhost:8080
    echo.
    echo Press any key to stop the test container...
    pause > nul
    docker stop wigsby-test
    docker rm wigsby-test
    echo 🧹 Test container cleaned up.
) else (
    echo ❌ Container failed to start. Checking logs...
    docker logs wigsby-test
    docker rm wigsby-test
)

echo.
echo 🎉 Docker test complete!
pause