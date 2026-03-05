CREATE TABLE Store
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL

);

INSERT INTO Store VALUES
	(1,'Chennai Store'),
	(2,'Bangalore Store'),
	(3,'Hyderabad Store')
;

SELECT *
FROM Store;

CREATE TABLE Orders
(
	Id INT PRIMARY KEY,
	Store_id INT NOT NULL,
	Order_status INT NOT NULL CHECK(Order_status BETWEEN 1 AND 4),
	FOREIGN KEY (Store_id) REFERENCES Store(Id)

);
SELECT * FROM Orders;

INSERT INTO Orders VALUES
(101,1,4),
(102,1,4),
(103,2,4),
(104,2,2),
(105,3,4),
(106,3,1),
(107,1,4),
(108,2,4);




CREATE TABLE Order_Items
(
	order_id INT NOT NULL,
	product_id INT NOT NULL,
	quantity INT NOT NULL,
	list_price INT NOT NULL,
	discount DECIMAL(4,2) NOT NULL DEFAULT 0,
	FOREIGN KEY (order_id) REFERENCES Orders(Id)
);

INSERT INTO Order_Items VALUES
(101,1,2,500,0.10),
(101,2,1,800,0.05),
(102,3,1,1200,0.00),
(103,4,2,600,0.10),
(105,5,1,700,0.15),
(107,6,3,400,0.00),
(108,7,2,650,0.05);

INSERT INTO Order_Items VALUES
(104,10,2,500,0.10),
(106,11,1,700,0.05);

SELECT *
FROM Order_Items;


-- 1. Display store_name and total sales amount.
-- 2. Calculate total sales using (quantity * list_price * (1 - discount)).
-- 3. Include only completed orders (order_status = 4).
-- 4. Group results by store_name.
-- 5. Sort total sales in descending order.


SELECT s.Name AS store_name ,
SUM(oi.quantity * oi.list_price * (1- oi.discount)) AS Total_sales
FROM Store AS s
INNER JOIN Orders o
ON s.Id = o.Store_id
INNER JOIN Order_Items oi
ON o.Id = oi.order_id
WHERE o.Order_status = 4
GROUP BY s.Name
ORDER BY Total_sales DESC;
