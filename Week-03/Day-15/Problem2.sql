USE EcommDb ;

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY IDENTITY(1,1),
    staff_name VARCHAR(100),
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

INSERT INTO staffs (staff_name, store_id)
VALUES
('Ravi Kumar',1),
('Priya Sharma',2),
('Arjun Reddy',3),
('Meena Patel',4),
('Kiran Das',5);

INSERT INTO orders (customer_id, store_id, staff_id, order_date)
VALUES
(1,1,1,'2024-01-10'),
(2,2,2,'2024-02-12'),
(3,3,3,'2024-03-15');

-- Create a view that shows product name, brand name, category name, model year and list price.
CREATE VIEW vw_product_details
AS
SELECT 
p.product_name,
b.brand_name,
c.category_name,
p.model_year,
p.price AS list_price
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;

SELECT *
FROM vw_product_details;


-- Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_order_details
AS
SELECT
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.staff_name,
o.order_date
FROM orders o
JOIN customers c
ON o.customer_id = c.customer_id
JOIN stores s
ON o.store_id = s.store_id
JOIN staffs st
ON o.staff_id = st.staff_id;

SELECT * FROM vw_order_details;

--- Create appropriate indexes on foreign key columns.

CREATE INDEX idx_products_brand_id
ON products(brand_id);

DROP INDEX idx_products_category_id ON products;

CREATE INDEX idx_products_category_id
ON products(category_id);

CREATE INDEX idx_orders_customer_id
ON orders(customer_id);

CREATE INDEX idx_orders_store_id
ON orders(store_id);

CREATE INDEX idx_orders_staff_id
ON orders(staff_id);


-- Test performance improvement using execution plan.

SELECT 
p.product_name,
b.brand_name,
c.category_name
FROM products p
JOIN brands b
ON p.brand_id = b.brand_id
JOIN categories c
ON p.category_id = c.category_id;