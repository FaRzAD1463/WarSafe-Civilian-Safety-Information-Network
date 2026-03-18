#!/bin/bash

echo "Running locally..."

cd backend/WarSafe.API
dotnet run &
cd ../../ai-service
uvicorn app.main:app --reload &
