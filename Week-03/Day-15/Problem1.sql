CREATE DATABASE EcommDb;

USE EcommDb;

CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(100) NOT NULL
);

DROP TABLE Categories;

CREATE TABLE brands (
    brand_id INT PRIMARY KEY IDENTITY(1,1),
    brand_name VARCHAR(100) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    phone VARCHAR(15),
    email VARCHAR(100),
    city VARCHAR(50)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100),
    phone VARCHAR(15),
    email VARCHAR(100),
    city VARCHAR(50)
);

INSERT INTO categories (category_name)
VALUES
('Cars'),
('Bikes'),
('Trucks'),
('Electric Vehicles'),
('Accessories');

INSERT INTO brands (brand_name)
VALUES
('Toyota'),
('Honda'),
('BMW'),
('Tesla'),
('Ford');

INSERT INTO products (product_name, brand_id, category_id, model_year, price)
VALUES
('Camry',1,1,2023,30000),
('Civic',2,1,2022,25000),
('X5',3,1,2023,60000),
('Model 3',4,4,2023,45000),
('F150',5,3,2022,40000);


INSERT INTO customers (first_name, last_name, phone, email, city)
VALUES
('Sai','Kiran','9876543210','sai@email.com','Chennai'),
('Ravi','Kumar','9123456780','ravi@email.com','Hyderabad'),
('Arjun','Reddy','9000000000','arjun@email.com','Chennai'),
('Rahul','Sharma','9888888888','rahul@email.com','Delhi'),
('Priya','Nair','9777777777','priya@email.com','Bangalore');

INSERT INTO stores (store_name, phone, email, city)
VALUES
('Chennai Auto Store','9876541111','chennai@store.com','Chennai'),
('Hyderabad Auto Store','9876542222','hyd@store.com','Hyderabad'),
('Bangalore Auto Store','9876543333','blr@store.com','Bangalore'),
('Delhi Auto Store','9876544444','delhi@store.com','Delhi'),
('Mumbai Auto Store','9876545555','mumbai@store.com','Mumbai');

SELECT * FROM stores;

--Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.product_name,b.brand_name,c.category_name
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON c.category_id = p.category_id;


-- Retrieve all customers from a specific city.
SELECT *
FROM customers
WHERE city = 'Chennai';

-- Display total number of products available in each category.

SELECT 
c.category_name,
COUNT(p.product_id) AS total_products
FROM categories c
LEFT JOIN products p
ON c.category_id = p.category_id
GROUP BY c.category_name;
