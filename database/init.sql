CREATE TABLE IF NOT EXISTS "Users" (
    "Id" UUID PRIMARY KEY,
    "Email" TEXT NOT NULL,
    "PasswordHash" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Reports" (
    "Id" UUID PRIMARY KEY,
    "Type" TEXT,
    "Description" TEXT,
    "Latitude" DOUBLE PRECISION,
    "Longitude" DOUBLE PRECISION
);
CREATE TABLE "Media" (
    "Id" UUID PRIMARY KEY,
    "FilePath" TEXT,
    "Status" TEXT,
    "CreatedAt" TIMESTAMP
);
