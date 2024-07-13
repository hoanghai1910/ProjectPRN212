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

INSERT INTO Shoes (ShoesName, CategoryID, BrandID, Size, Color, Price, StockQuantity)
VALUES ('Air Max 270', 
        (SELECT CategoryID FROM Category WHERE CategoryName = 'Sneakers'), 
        (SELECT BrandID FROM Brand WHERE BrandName = 'Nike'), 
        10.5, 'Black', 150, 100),
       
       ('UltraBoost', 
        (SELECT CategoryID FROM Category WHERE CategoryName = 'Running Shoes'), 
        (SELECT BrandID FROM Brand WHERE BrandName = 'Adidas'), 
        9.0, 'White', 180, 75),
       
       ('Classic Suede', 
        (SELECT CategoryID FROM Category WHERE CategoryName = 'Casual Shoes'), 
        (SELECT BrandID FROM Brand WHERE BrandName = 'Puma'), 
        8.0, 'Blue', 100, 50),
       
       ('Zig Kinetica', 
        (SELECT CategoryID FROM Category WHERE CategoryName = 'Sports Shoes'), 
        (SELECT BrandID FROM Brand WHERE BrandName = 'Reebok'), 
        11.0, 'Red', 120, 80),
       
       ('HOVR Phantom', 
        (SELECT CategoryID FROM Category WHERE CategoryName = 'Running Shoes'), 
        (SELECT BrandID FROM Brand WHERE BrandName = 'Under Armour'), 
        10.0, 'Gray', 140, 60);

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

INSERT INTO Customer (CustomerName, Email, Password, PhoneNumber, Address)
VALUES ('John Doe', 'congminh23092004@gmail.com', '23092004', '123-456-7890', '123 Main St, City, Country');

INSERT INTO Brand (BrandName)
VALUES ('Nike'),
       ('Adidas'),
       ('Puma'),
       ('Reebok'),
       ('Under Armour');

INSERT INTO Category (CategoryName)
VALUES ('Sneakers'),
       ('Running Shoes'),
       ('Boots'),
       ('Sandals'),
       ('Formal Shoes'),
       ('Casual Shoes'),
       ('Sports Shoes');

