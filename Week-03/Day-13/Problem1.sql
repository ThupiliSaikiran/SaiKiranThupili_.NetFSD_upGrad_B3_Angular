CREATE DATABASE Day_3_Hands_On;

USE Day_3_Hands_On;

CREATE TABLE Customers 
(
	customer_id INT PRIMARY KEY,
	first_name VARCHAR(20) NOT NULL,
	last_name VARCHAR(20) NOT NULL,
	email VARCHAR(50)

);

INSERT INTO Customers VALUES
	(1, 'Sai', 'Kiran', 'sai@gmail.com'),
	(2, 'Rahul', 'Kumar', 'rahul@gmail.com'),
	(3, 'Anil', 'Sharma', 'anil@gmail.com'),
	(4, 'Priya', 'Reddy', 'priya@gmail.com')
	;
INSERT INTO Customers VALUES (5,'Pawan','Kalyan','pawan@gmail.com');

CREATE TABLE OrderDetails 
(
	order_id INT PRIMARY KEY,
	customer_id INT NOT NULL,
	order_date DATE NOT NULL,
	order_status INT CHECK(order_status BETWEEN 1 and 4),
	FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
	
);

INSERT INTO OrderDetails VALUES
	(101, 1, '2026-03-01', 1),
	(102, 2, '2026-03-02', 4),
	(103, 3, '2026-03-04', 1),
	(104, 4, '2026-03-05', 4)
	;

INSERT INTO OrderDetails VALUES (105, 1, '2026-03-20', 2);

-- 1. Retrieve customer first name, last name, order_id, order_date, and order_status.
--2. Display only orders with status Pending (1) or Completed (4).
--3. Sort the results by order_date in descending order.
SELECT C.first_name,C.last_name,O.order_id,O.order_date,O.order_status
FROM Customers C
INNER JOIN OrderDetails O
ON C.customer_id = O.customer_id
WHERE O.order_status = 1 OR O.order_status=4
ORDER BY O.order_date DESC
;



SELECT * FROM Customers;
SELECT * FROM OrderDetails;