
USE RetailDB;

CREATE TABLE Stocks (
    product_id INT PRIMARY KEY,
    stock_quantity INT NOT NULL,

    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Stocks VALUES
(1,50),
(2,40),
(3,30),
(4,25),
(5,20),
(6,60),
(7,70);

SELECT * FROM Stocks;

-- Create an AFTER INSERT trigger on order_items.
-- Reduce the corresponding quantity in stocks table.
-- Prevent stock from becoming negative.
-- If stock is insufficient, rollback the transaction with a custom error message.


CREATE TRIGGER trg_CheckStockBeforeOrder
ON Order_Items
AFTER INSERT 
AS 
BEGIN
BEGIN TRY
	IF EXISTS
		(
		SELECT *
		FROM inserted i
		JOIN Stocks s
		ON i.product_id = s.product_id
		WHERE s.stock_quantity < i.quantity
		)
	BEGIN
		RAISERROR ('Not enough Stocks available',16,1)
		ROLLBACK TRANSACTION;
	END
	ELSE
	BEGIN
		UPDATE s
		SET s.stock_quantity = s.stock_quantity - i.quantity
		FROM inserted i
		JOIN Stocks s
		ON i.product_id = s.product_id
	END
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;
	PRINT ERROR_MESSAGE();
END CATCH
END;

INSERT INTO Order_Items VALUES 
	(1, 1, 10, 10);








