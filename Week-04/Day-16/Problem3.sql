USE RetailDB;

CREATE TABLE P3_Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_name VARCHAR(100),
    order_date DATE,
    shipped_date DATE,
    order_status INT
);

INSERT INTO P3_Orders (customer_name, order_date, shipped_date, order_status)
VALUES
('Rahul', '2026-03-01', NULL, 1),
('Anita', '2026-03-02', NULL, 2),
('Kiran', '2026-03-03', '2026-03-05', 3),
('David', '2026-03-04', '2026-03-06', 3),
('Sara', '2026-03-05', NULL, 1);

SELECT * FROM P3_Orders;

UPDATE P3_Orders SET shipped_date='2026-03-06', order_status = 4 WHERE order_id=1;

-- Create an AFTER UPDATE trigger on orders.
-- Validate that shipped_date is NOT NULL when order_status = 4.
-- Prevent update if condition fails.


CREATE TRIGGER trg_validate_order_status
ON P3_Orders
AFTER UPDATE
AS
BEGIN 
	BEGIN TRY
		IF EXISTS
		(SELECT *
		FROM inserted
		WHERE order_status = 4 AND 
		shipped_date IS NULL
		)
		BEGIN
			RAISERROR('Cannot mark order as Completed because shipped_date is NULL',16,1);
			ROLLBACK TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		PRINT ERROR_MESSAGE();
	END CATCH
END;

