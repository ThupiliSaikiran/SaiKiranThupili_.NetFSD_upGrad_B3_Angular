USE AutoDb;
CREATE TABLE P4_Customers
(
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(50) NOT NULL
);

INSERT INTO P4_Customers VALUES
(1,'Rahul'),
(2,'Anita'),
(3,'Kiran'),
(4,'Priya'),
(5,'Arjun');

SELECT * FROM P4_Customers;

CREATE TABLE P4_Orders
(
    order_id INT PRIMARY KEY,

    customer_id INT
        FOREIGN KEY REFERENCES P4_Customers(customer_id),

    order_status INT,

    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

INSERT INTO P4_Orders VALUES
(101,1,2,'2023-01-10','2023-01-15','2023-01-14'),
(102,1,2,'2023-02-01','2023-02-06','2023-02-08'),
(103,2,1,'2024-01-05','2024-01-10',NULL),
(104,3,3,'2022-02-01','2022-02-05',NULL),
(105,4,2,'2023-05-01','2023-05-06','2023-05-05'),
(106,3,3,'2022-01-10','2022-01-15',NULL),
(107,5,2,'2023-07-01','2023-07-05','2023-07-06'),
(108,5,2,'2023-07-10','2023-07-15','2023-07-14');

SELECT * FROM P4_Orders;

-- 1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
CREATE TABLE P4_Archived_Orders
(
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

INSERT INTO P4_Archived_Orders
SELECT * 
FROM P4_Orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

SELECT * FROM P4_Archived_Orders;

-- 2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
DELETE FROM P4_Orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR,-1,GETDATE());

-- 3. Use nested query to identify customers whose all orders are completed.



SELECT customer_name
FROM P4_Customers
WHERE customer_id NOT IN
(
    SELECT customer_id
    FROM P4_Orders
    WHERE order_status <> 2
);

-- 4. Display order processing delay (DATEDIFF between shipped_date and order_date).

SELECT 
order_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM P4_Orders;

-- 5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.

SELECT 
order_id,
order_date,
required_date,
shipped_date,
CASE 
	WHEN shipped_date > required_date THEN 'Delayed'
	ELSE 'On Time'
END AS order_status_result
FROM P4_Orders;


SELECT 
order_id,
customer_id,
order_date,
required_date,
shipped_date,

DATEDIFF(DAY, order_date, shipped_date) AS processing_delay,

CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS delivery_status

FROM P4_Orders;