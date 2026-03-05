USE AutoDb;
CREATE TABLE P3_Stores 
(
	store_id INT PRIMARY KEY,
	store_name VARCHAR(50) NOT NULL
);

INSERT INTO P3_Stores VALUES
	(1,'Chennai Store'),
	(2,'Bangalore Store'),
	(3,'Hyderabad Store');

SELECT * FROM P3_Stores;

DROP TABLE P3_Stores;

CREATE TABLE P3_Orders
(
	order_id INT PRIMARY KEY,
	store_id INT NOT NULL
		FOREIGN KEY REFERENCES P3_Stores(store_id),

);
INSERT INTO P3_Orders VALUES
	(101,1),
	(102,1),
	(103,2),
	(104,3)
	;

SELECT * FROM P3_Orders;


CREATE TABLE P3_Order_Items
(
	order_id INT NOT NULL
		FOREIGN KEY REFERENCES P3_Orders(order_id),
	 product_name VARCHAR(50) NOT NULL,
	quantity INT NOT NULL,
	list_price INT NOT NULL,
	discount INT DEFAULT 0
);

INSERT INTO P3_Order_Items VALUES
	(101,'Laptop',2,50000,2000),
	(101,'Mouse',3,500,0),
	(102,'Laptop',1,50000,1000),
	(103,'Tablet',2,20000,500),
	(104,'Laptop',1,50000,0);

SELECT * FROM P3_Order_Items;


CREATE TABLE P3_Stocks
(
	store_id INT NOT NULL
		FOREIGN KEY REFERENCES P3_Stores(store_id),
	product_name VARCHAR(50) NOT NULL,
	quantity INT DEFAULT 0
);

INSERT INTO P3_Stocks ( store_id,product_name)VALUES
	(1,'Laptop');

INSERT INTO P3_Stocks VALUES 
	(1,'Mouse',5),
	(2,'Tablet',0),
	(3,'Laptop',10);

SELECT * FROM P3_Stocks;


-- 1. Identify products sold in each store using nested queries.
SELECT 
    s.store_name,
    oi.product_name,
    SUM(oi.quantity) AS total_quantity_sold
FROM
(
    SELECT o.store_id, oi.product_name, oi.quantity
    FROM P3_Orders o
    JOIN P3_Order_Items oi
        ON o.order_id = oi.order_id
) AS oi
JOIN P3_Stores s
    ON oi.store_id = s.store_id
GROUP BY s.store_name, oi.product_name;

-- 2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
SELECT DISTINCT o.store_id, oi.product_name
FROM P3_Orders o
JOIN P3_Order_Items oi
ON o.order_id = oi.order_id

EXCEPT

SELECT store_id, product_name
FROM P3_Stocks
WHERE quantity > 0;


SELECT 
    s.store_name,
    oi.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM
(
    SELECT o.store_id, oi.product_name, oi.quantity, oi.list_price, oi.discount
    FROM P3_Orders o
    JOIN P3_Order_Items oi
        ON o.order_id = oi.order_id
) AS oi
JOIN P3_Stores s
    ON oi.store_id = s.store_id
GROUP BY s.store_name, oi.product_name
ORDER BY s.store_name;



SELECT 
    s.store_name,
    t.product_name,
    SUM(t.quantity) AS total_quantity_sold
FROM
(
    SELECT o.store_id, oi.product_name, oi.quantity
    FROM P3_Orders o
    JOIN P3_Order_Items oi
        ON o.order_id = oi.order_id
) t
JOIN P3_Stores s
    ON t.store_id = s.store_id
JOIN P3_Stocks st
    ON t.store_id = st.store_id
    AND t.product_name = st.product_name
WHERE st.quantity = 0
GROUP BY s.store_name, t.product_name;



SELECT 
    s.store_name,
    oi.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM((oi.quantity * oi.list_price) - oi.discount) AS total_revenue
FROM P3_Orders o
JOIN P3_Order_Items oi
    ON o.order_id = oi.order_id
JOIN P3_Stores s
    ON o.store_id = s.store_id
JOIN P3_Stocks st
    ON o.store_id = st.store_id
    AND oi.product_name = st.product_name
WHERE st.quantity = 0
GROUP BY s.store_name, oi.product_name;