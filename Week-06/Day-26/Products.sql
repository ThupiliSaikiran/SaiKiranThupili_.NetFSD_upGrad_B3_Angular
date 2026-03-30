CREATE DATABASE ProductsDB;

USE ProductsDB;

CREATE TABLE Products(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(100),
	Categoty VARCHAR(50),
	Price DECIMAL(10,2)
);

EXEC sp_rename 'Products.Categoty', 'Category', 'COLUMN';

INSERT INTO Products (ProductName, Categoty, Price) VALUES
('Laptop', 'Electronics', 55000.00),
('Smartphone', 'Electronics', 25000.00),
('Headphones', 'Accessories', 1500.00),
('Keyboard', 'Accessories', 800.00),
('Mouse', 'Accessories', 500.00),
('Office Chair', 'Furniture', 7000.00),
('Table', 'Furniture', 12000.00),
('Refrigerator', 'Appliances', 30000.00),
('Washing Machine', 'Appliances', 28000.00),
('LED TV', 'Electronics', 40000.00);

SELECT * FROM Products;

CREATE PROCEDURE sp_InsertProduct
	@ProductName VARCHAR(100),
	@Category VARCHAR(50),
	@Price DECIMAL(10,2)

AS
BEGIN
	INSERT INTO Products VALUES (@ProductName,@Category,@Price);
END
;


CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
	SELECT * FROM Products;
END
;

CREATE PROCEDURE sp_GetProductById
	@Productid INT
AS
BEGIN
	SELECT * FROM Products WHERE ProductId = @Productid;
END
;



CREATE PROCEDURE sp_UpdateProduct
	@ProductId INT,
	@ProductName VARCHAR(100),
	@Category VARCHAR(50),
	@Price DECIMAL(10,2)
AS
BEGIN
	UPDATE Products
	SET ProductName = @ProductName,
	Category = @Category,
	Price = @Price
	WHERE ProductId = @ProductId;
END
;

CREATE PROCEDURE sp_DeleteProduct
	@ProductId INT
AS
BEGIN
	DELETE FROM Products WHERE ProductId = @ProductId;
END
;