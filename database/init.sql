CREATE TABLE "Reports" (
    "Id" UUID PRIMARY KEY,
    "Type" TEXT,
    "Description" TEXT,
    "Latitude" DOUBLE PRECISION,
    "Longitude" DOUBLE PRECISION,
    "Urgency" TEXT,
    "CreatedAt" TIMESTAMP
);