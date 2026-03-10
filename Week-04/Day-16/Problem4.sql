use RetailDB;

CREATE TABLE P4_Stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

INSERT INTO P4_Stores (store_name)
VALUES
('Chennai Store'),
('Hyderabad Store'),
('Bangalore Store');

CREATE TABLE P4_Products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    price DECIMAL(10,2)
);

INSERT INTO P4_Products (product_name, price)
VALUES
('Laptop', 50000),
('Mobile Phone', 20000),
('Tablet', 15000),
('Headphones', 2000),
('Smart Watch', 8000);

CREATE TABLE P4_Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_date DATE,
    order_status INT,

    FOREIGN KEY (store_id) REFERENCES P4_Stores(store_id)
);

INSERT INTO P4_Orders (store_id, order_date, order_status)
VALUES
(1, '2026-03-01', 4),
(1, '2026-03-02', 4),
(2, '2026-03-03', 2),
(2, '2026-03-04', 4),
(3, '2026-03-05', 4);

CREATE TABLE P4_Order_Items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    product_id INT,
    quantity INT,
    discount DECIMAL(5,2),

    FOREIGN KEY (order_id) REFERENCES P4_Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES P4_Products(product_id)
);

INSERT INTO P4_Order_Items (order_id, product_id, quantity, discount)
VALUES
(1, 1, 1, 10),
(1, 4, 2, 5),
(2, 2, 1, 0),
(2, 5, 1, 5),
(3, 3, 2, 10),
(4, 1, 1, 15),
(4, 4, 3, 0),
(5, 2, 2, 5);


 --Use a cursor to iterate through completed orders (order_status = 4).
--Calculate total revenue per order using order_items.
-- Store computed revenue in a temporary table.
-- Display store-wise revenue summary.



BEGIN TRY

BEGIN TRANSACTION

CREATE TABLE #Revenue (
    order_id INT,
    store_id INT,
    revenue DECIMAL(12,2)
);

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)

DECLARE order_cursor CURSOR
FOR 
SELECT order_id, store_id
FROM P4_Orders
WHERE order_status = 4;

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @revenue =
    SUM((oi.quantity * p.price) * (1 - oi.discount/100.0))
    FROM P4_Order_Items oi
    JOIN P4_Products p
    ON oi.product_id = p.product_id
    WHERE oi.order_id = @order_id;

    INSERT INTO #Revenue
    VALUES (@order_id, @store_id, @revenue);

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id;

END

CLOSE order_cursor
DEALLOCATE order_cursor

SELECT s.store_name, SUM(r.revenue) AS total_revenue
FROM #Revenue r
JOIN P4_Stores s
ON r.store_id = s.store_id
GROUP BY s.store_name;

COMMIT TRANSACTION

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Error Occurred'

END CATCH;