CREATE DATABASE RetailDB;

USE RetailDB;

CREATE TABLE Stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100) NOT NULL,
    city VARCHAR(100)
);

INSERT INTO Stores (store_name, city)
VALUES
('Chennai Store', 'Chennai'),
('Hyderabad Store', 'Hyderabad'),
('Bangalore Store', 'Bangalore');

CREATE TABLE Products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100) NOT NULL,
    price DECIMAL(10,2) NOT NULL
);

INSERT INTO Products (product_name, price)
VALUES
('Laptop', 50000),
('Mobile Phone', 20000),
('Tablet', 15000),
('Headphones', 2000),
('Smart Watch', 8000),
('Keyboard', 1500),
('Mouse', 800);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_date DATE,

    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);


INSERT INTO Orders (store_id, order_date)
VALUES
(1, '2026-03-01'),
(1, '2026-03-03'),
(2, '2026-03-05'),
(3, '2026-03-06'),
(2, '2026-03-07'),
(3, '2026-03-08');

CREATE TABLE Order_Items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(5,2),

    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Order_Items (order_id, product_id, quantity, discount)
VALUES
(1, 1, 1, 10),   
(1, 4, 2, 5),   
(2, 2, 1, 0),    
(2, 5, 1, 5),    
(3, 3, 2, 10),   
(4, 1, 1, 15),   
(4, 6, 3, 0),    
(5, 7, 4, 0),    
(6, 2, 2, 5); 

-- Create a stored procedure to generate total sales amount per store.

CREATE PROCEDURE sp_sales_amout
AS
BEGIN
	SELECT s.store_name,
		SUM(oi.quantity * p.price) AS total_price
	FROM Stores s
	JOIN Orders AS o
	ON s.store_id = o.store_id
	JOIN Order_Items oi
	ON oi.order_id = o.order_id
	JOIN Products p
	ON p.product_id = oi.product_id
	GROUP BY s.store_name;

END;

EXEC sp_sales_amout;


--Create a stored procedure to retrieve orders by date range.

CREATE PROCEDURE sp_orders_by_date_range
	@StartDate DATE,
	@EndDate DATE
AS
BEGIN 
	SELECT p.product_name,s.store_name,oi.quantity
	FROM Stores s
	JOIN Orders AS o
	ON s.store_id = o.store_id
	JOIN Order_Items oi
	ON oi.order_id = o.order_id
	JOIN Products p
	ON p.product_id = oi.product_id
	WHERE o.order_date BETWEEN @StartDate AND @EndDate
END;

EXEC sp_orders_by_date_range '2026-03-08','2026-03-09';

--Create a scalar function to calculate total price after discount.

CREATE FUNCTION total_price_after_disc
(
	@Total_Price DECIMAL(10,2),
	@Discount_Price DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
BEGIN
	DECLARE @Final_Price DECIMAL(10,2)
	SET  @Final_Price = @Total_Price - (@Total_Price * @Discount_Price/100)
	RETURN @Final_Price
END

;

SELECT dbo.total_price_after_disc(1000,10) AS Final_Price;

--- Create a table-valued function to return top 5 selling products.

CREATE FUNCTION top_5_selling_prods()
RETURNS TABLE
AS
RETURN 
(
	SELECT TOP 5 p.product_name,SUM(oi.quantity) AS total_quantity_sold
	FROM Products p
	JOIN Order_Items AS oI
	ON p.product_id = oi.product_id
	GROUP BY p.product_name
	ORDER BY total_quantity_sold DESC

)
;

SELECT * FROM top_5_selling_prods();