#!/bin/bash

echo "Setting up WarSafe..."
docker compose up -d --build

echo "System running:"
echo "Backend: http://localhost:5000"
echo "AI: http://localhost:8000"
