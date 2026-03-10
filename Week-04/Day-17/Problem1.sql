CREATE DATABASE BusinessDB;

USE BusinessDB;

CREATE TABLE Stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100),
    city VARCHAR(100)
);

INSERT INTO Stores (store_name, city)
VALUES
('Chennai Store', 'Chennai'),
('Hyderabad Store', 'Hyderabad'),
('Bangalore Store', 'Bangalore');

CREATE TABLE Products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    price DECIMAL(10,2),
    stock_quantity INT
);

INSERT INTO Products (product_name, price, stock_quantity)
VALUES
('Laptop', 50000, 10),
('Mobile Phone', 20000, 15),
('Tablet', 15000, 8),
('Headphones', 2000, 25),
('Smart Watch', 8000, 12);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_date DATE,
    order_status INT,

    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

INSERT INTO Orders (store_id, order_date, order_status)
VALUES
(1, '2026-03-01', 1),
(2, '2026-03-02', 1),
(3, '2026-03-03', 1);

CREATE TABLE Order_Items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,

    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Order_Items (order_id, product_id, quantity)
VALUES
(1, 1, 2),
(1, 4, 3),
(2, 2, 1),
(2, 5, 2),
(3, 3, 2);

--Create a trigger to reduce stock quantity after order insertion.
--- Rollback transaction if stock quantity is insufficient.

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN 
	IF EXISTS
	(
	SELECT 1
	FROM inserted i
	JOIN Products p
	ON i.product_id = p.product_id
	WHERE i.quantity > p.stock_quantity
	)
	BEGIN
		RAISERROR ('Stock is insufficient for this order',16,1);
		ROLLBACK TRANSACTION;
		RETURN
	END

	UPDATE p
	SET p.stock_quantity = p.stock_quantity - i.quantity
	FROM inserted i
	JOIN Products p
	ON i.product_id = p.product_id
END ;

--Write a transaction to insert data into orders and order_items tables.
--Check stock availability before confirming order.


BEGIN TRY
BEGIN TRANSACTION

INSERT INTO Orders (store_id,order_date,order_status)
VALUES (2,GETDATE(),1);

DECLARE @order_id INT = SCOPE_IDENTITY();

INSERT INTO Order_Items (order_id, product_id, quantity)
VALUES (@order_id,1,2),(@order_id,2,299);

COMMIT TRANSACTION

PRINT 'Transaction Completed'
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION

PRINT 'Order failed due to insufficient stock'
END CATCH

SELECT * FROM Order_Items;
SELECT * FROM Orders;