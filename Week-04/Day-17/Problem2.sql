USE BusinessDB;

SELECT * FROM Orders;

SELECT * FROM Order_Items;
SELECT * FROM Products;

INSERT INTO Orders 
VALUES (2,GETDATE(),4),
(1,GETDATE(),4);

UPDATE Orders SET order_status =1 WHERE order_id=1;

INSERT INTO Order_Items
VALUES
(14,3,3),
(15,1,3);



BEGIN TRANSACTION
BEGIN TRY
	--- Use SAVEPOINT before stock restoration.
	SAVE TRANSACTION CancelPoint;

	DECLARE @order_id INT = 1;

	 -- Check if order exists in Order_Items
    IF NOT EXISTS (
        SELECT 1
        FROM Order_Items oi
		JOIN Orders o
		ON oi.order_id = o.order_id
        WHERE oi.order_id = @order_id AND o.order_status IN (1,2)
    )
    BEGIN
        RAISERROR('Order ID not found in order details',16,1);
        ROLLBACK TRANSACTION CancelPoint;
        RETURN;
    END

	-- RESTORE STACKS

	UPDATE p
	SET p.stock_quantity = p.stock_quantity + oi.quantity
	FROM Products p
	JOIN Order_Items oi
	ON p.product_id = oi.product_id
	WHERE oi.order_id = @order_id;

	-- UPDATE STATUS
	UPDATE Orders
	SET order_status = 3
	WHERE order_id = @order_id;

	COMMIT TRANSACTION;
	PRINT 'Order Cancelled SuccessfullY'
END TRY
BEGIN CATCH
	-- If stock restoration fails, rollback to SAVEPOINT.
	ROLLBACK TRANSACTION  CancelPoint;
	RAISERROR('Something went wrong during order cancellation',16,1);
END CATCH
