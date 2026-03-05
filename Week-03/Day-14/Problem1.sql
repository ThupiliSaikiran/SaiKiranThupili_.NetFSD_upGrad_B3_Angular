CREATE DATABASE AutoDb;
USE AutoDb;

CREATE TABLE products
(
	product_id INT PRIMARY KEY,
	product_name VARCHAR(50) NOT NULL,
	category VARCHAR(20) NOT NULL,
	model_year INT NOT NULL,
	list_price INT NOT NULL
);

INSERT INTO products VALUES (1, 'Pulsar 150', 'Bike', 2020, 120000);

INSERT INTO products VALUES (2, 'Apache RTR 160', 'Bike', 2021, 140000);

INSERT INTO products VALUES (3, 'Yamaha R15', 'Bike', 2022, 180000);

INSERT INTO products VALUES (4, 'Swift', 'Car', 2021, 650000);

INSERT INTO products VALUES (5, 'Alto', 'Car', 2020, 500000);

INSERT INTO products VALUES (6, 'Hyundai i20', 'Car', 2022, 750000);

INSERT INTO products VALUES (7, 'Volvo 9400', 'Bus', 2019, 3500000);

SELECT * FROM products;


SELECT CONCAT(product_name,'(',model_year,')') AS [Product],
list_price AS Price,
 (SELECT AVG(list_price)
FROM products p2
	WHERE p1.category = p2.category) AS Average,

list_price - (SELECT AVG(list_price)
	FROM products p2
	WHERE p1.category = p2.category)
	AS Difference
FROM products p1
WHERE list_price > (
	SELECT AVG(list_price)
	FROM products p2
	WHERE p1.category = p2.category
)
;