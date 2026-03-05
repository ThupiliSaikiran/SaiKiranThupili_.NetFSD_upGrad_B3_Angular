USE AutoDb;

CREATE TABLE Customers
(
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50) NOT NULL
);

CREATE TABLE Orders
(
	order_id INT IDENTITY(101,1),
	customer_id INT NOT NULL
		FOREIGN KEY REFERENCES Customers(customer_id),
	order_value INT NOT NULL
);

INSERT INTO customers (customer_id, first_name, last_name) VALUES
(1, 'Sai', 'Kiran'),
(2, 'Rahul', 'Kumar'),
(3, 'Priya', 'Sharma'),
(4, 'John', 'David'),
(5, 'Anita', 'Reddy');




INSERT INTO orders ( customer_id, order_value) VALUES
( 1, 6000),
( 1, 7000),
( 2, 3000),
(2, 2500),
(3, 2000);

INSERT INTO orders ( customer_id, order_value) VALUES
	(5,11000);

SELECT  CONCAT(c.first_name,' ',c.last_name) AS Full_Name,
SUM(o.order_value) AS total_order_value ,
CASE
	WHEN SUM(o.order_value) > 10000 THEN 'Premium' 
	WHEN SUM(o.order_value) BETWEEN 5000 AND 10000 THEN 'Regular' 
	ELSE  'Basic' 
END AS Costumer_Sub
FROM customers c
JOIN orders o
ON c.customer_id = o.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name

UNION 

SELECT  CONCAT(first_name,' ',last_name) AS Full_Name,
NULL AS total_order_value ,
'Basic'  AS Costumer_Sub
FROM customers 
WHERE customer_id NOT IN 
(
	SELECT customer_id FROM orders
)

ORDER BY total_order_value DESC
;



SELECT * FROM customers;

SELECT * FROM ORDERS;