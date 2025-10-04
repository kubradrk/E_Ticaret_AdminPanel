use E_TicaretDB

GO
CREATE PROCEDURE AddOrder
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    DECLARE @CurrentStock INT;
    SELECT @CurrentStock = Stock FROM Products WHERE ProductID = @ProductID;

    IF @Quantity <= @CurrentStock
    BEGIN
        INSERT INTO Orders(CustomerID, ProductID, Quantity, OrderDate)
        VALUES(@CustomerID, @ProductID, @Quantity, GETDATE());

        UPDATE Products
        SET Stock = Stock - @Quantity
        WHERE ProductID = @ProductID;
    END
    ELSE
    BEGIN
        RAISERROR('Yeterli stok yok!', 16, 1);
    END
END
GO
