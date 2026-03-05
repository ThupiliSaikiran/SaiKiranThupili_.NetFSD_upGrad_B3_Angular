SELECT *
FROM P4_Products;

SELECT *
FROM P4_Stocks;

SELECT *
FROM P4_Store;

USE Day_3_Hands_On;

CREATE TABLE P4_order_items
(
	order_id INT PRIMARY KEY,
	product_id INT NOT NULL,
	quantity INT,
	FOREIGN KEY (product_id) REFERENCES P4_Products(Id)
);

INSERT INTO P4_order_items VALUES (101, 1, 2);
INSERT INTO P4_order_items VALUES (102, 1, 3);
INSERT INTO P4_order_items VALUES (103, 2, 5);

SELECT *
FROM P4_order_items;

SELECT 
    p.Name AS product_name,
    s.Name AS store_name,
    st.quantity AS available_stock,
    ISNULL(SUM(oi.quantity),0) AS total_quantity_sold
FROM P4_Stocks st
INNER JOIN products p
    ON st.product_id = p.Id
INNER JOIN P4_Store s
    ON st.store_id = s.Id
LEFT JOIN P4_order_items oi
    ON st.product_id = oi.product_id
GROUP BY 
    p.Name,
    s.Name,
    st.quantity
ORDER BY 
    p.Name;