-- Create the database
CREATE DATABASE MyShoesShop;
GO

-- Use the newly created database
USE MyShoesShop;
GO

-- Create the Cards table
CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
	Password NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(200)
);

CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL
);
CREATE TABLE Brand (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName NVARCHAR(50) NOT NULL
);

CREATE TABLE Shoes (
    ShoesID INT PRIMARY KEY IDENTITY(1,1),
    ShoesName NVARCHAR(100) NOT NULL,
    CategoryID INT,
	BrandID INT,
    Size DECIMAL(10,2) NOT NULL,
    Color NVARCHAR(20) NOT NULL,
    Price INT NOT NULL,
    StockQuantity INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID),
	FOREIGN KEY (BrandID) REFERENCES Brand(BrandID)
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATETIME NOT NULL,
    CustomerID INT,
    TotalAmount INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE OrderDetail (
    OrderID INT,
    ShoesID INT,
    Quantity INT NOT NULL,
    Price INT NOT NULL,
    PRIMARY KEY (OrderID, ShoesID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (ShoesID) REFERENCES Shoes(ShoesID)
);

