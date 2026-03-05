CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
);

INSERT INTO Categories VALUES
	(1,'Smartphones'),
	(2,'Laptops'),
	(3,'Cameras')
;

SELECT * FROM Categories;

CREATE TABLE Brands
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
);

INSERT INTO Brands VALUES
	(1, 'Apple'),
	(2,'Samsung'),
	(3,'Dell')
;

SELECT * FROM Brands;

CREATE TABLE Products
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Brand_id INT NOT NULL,
	Category_id INT NOT NULL,
	Model_year INT ,
	List_price INT NOT NULL,
	FOREIGN KEY (Brand_id) REFERENCES Brands(Id),
	FOREIGN KEY (Category_id) REFERENCES Categories(Id)
);

INSERT INTO Products VALUES
(1, 'iPhone 14', 1, 1, 2023, 900),
(2, 'Galaxy S23', 2, 1, 2023, 850),
(3, 'Dell XPS 13', 3, 2, 2023, 1200),
(4, 'MacBook Air', 1, 2, 2022, 1100),
(5, 'Samsung Galaxy Book', 2, 2, 2023, 950),
(6, 'Canon EOS M50', 1, 3, 2022, 700),
(7, 'Samsung NX Camera', 2, 3, 2021, 650),
(8, 'Dell Pro Webcam', 3, 3, 2022, 300);

SELECT *
FROM Products;

-- 1. Display product_name, brand_name, category_name, model_year, and list_price.
-- Filter products with list_price greater than 500.
-- 3. Sort results by list_price in ascending order.

SELECT p.Name AS Product_Name,
b.Name AS Brand_Name,
c.Name AS Category_name,
p.Model_year AS Model_year,
p.List_price AS list_price
FROM Products p
INNER JOIN Brands b
ON b.id = p.Brand_id
INNER JOIN Categories c
ON c.id = p.Category_id
WHERE p.list_price > 500
ORDER BY p.List_price
;




