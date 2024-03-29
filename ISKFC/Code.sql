CREATE DATABASE KFC;
GO

USE KFC;
GO

CREATE TABLE Payment_Methods (
	ID_Payment_Method INT PRIMARY KEY IDENTITY(1,1),
	Payment_Type VARCHAR(16) NOT NULL
);
GO

CREATE TABLE Orders (
	ID_Order INT PRIMARY KEY IDENTITY(1,1),
	Payment_Method_ID INT,
	Order_Date DATE,
	Order_Time TIME,
	FOREIGN KEY (Payment_Method_ID) REFERENCES Payment_Methods(ID_Payment_Method),
);
GO

CREATE TABLE Products (
	ID_Product INT PRIMARY KEY IDENTITY(1,1),
	Product_Name VARCHAR(48) NOT NULL,
	Amount_In_Storage INT NOT NULL,
	Price INT NOT NULL
);
GO

CREATE TABLE ProductSelling (
	ID_Selling INT PRIMARY KEY IDENTITY(1,1),
	Product_ID INT,
	Order_ID INT,
	FOREIGN KEY (Product_ID) REFERENCES Products(ID_Product),
	FOREIGN KEY (Order_ID) REFERENCES Orders(ID_Order),
);
GO


DROP TABLE ProductSelling
DROP TABLE Products
DROP TABLE Orders
DROP TABLE Payment_Methods

CREATE TRIGGER tgr_delete_product
ON Products
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM ProductSelling WHERE Product_ID IN (SELECT ID_Product FROM deleted);
	DELETE FROM Products WHERE ID_Product IN (SELECT ID_Product FROM deleted);
END;

CREATE TRIGGER tgr_delete_order
ON Orders
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM ProductSelling WHERE Order_ID IN (SELECT ID_Order FROM deleted);
	DELETE FROM Orders WHERE ID_Order IN (SELECT ID_Order FROM deleted);
END;

CREATE TRIGGER tgr_delete_payment_method
ON Payment_Methods
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM Orders WHERE Payment_Method_ID IN (SELECT ID_Payment_Method FROM deleted);
	DELETE FROM Payment_Methods WHERE ID_Payment_Method IN (SELECT ID_Payment_Method FROM deleted);
END;




INSERT INTO Payment_Methods (Payment_Type) VALUES ('Наличные'), ('Карта'), ('Биткоин')
GO

INSERT INTO Orders (Payment_Method_ID, Order_Date, Order_Time) VALUES (1, GETDATE(), GETDATE()), (2, GETDATE(), GETDATE()), (2, GETDATE(), GETDATE()), (1, GETDATE(), GETDATE()), (3, GETDATE(), GETDATE())
GO

INSERT INTO Products (Product_Name, Amount_In_Storage, Price) VALUES ('Крысиный хвостики (НОВИНКА)', 3, '301'), ('Крылышки Острые', 3524, '299'), ('Плавник рыбы', 127, '420'), ('Бургер по Мысевски', 1, '1200'), ('Мыльные пузыри', 15, '788'), ('Утюг', 6, '600')
GO

INSERT INTO ProductSelling (Order_ID, Product_ID) VALUES (3, 5), (3, 6), (3, 6), (3, 7), (3, 9), (4, 10), (5, 7), (5, 6), (6, 5), (6, 6), (6, 7), (7, 8), (7, 9) 
GO

CREATE VIEW View_Payment_Methods AS
SELECT 
    ID_Payment_Method AS 'ID_Payment_Method',
    Payment_Type AS 'Payment_Type'
FROM Payment_Methods;
GO

CREATE VIEW View_Orders 
AS
SELECT 
    ID_Order AS 'ID_Order',
    Payment_Method_ID AS 'Payment_Method_ID',
    Order_Date AS 'Order_Date'
FROM Orders;
GO

CREATE VIEW View_Products 
AS
SELECT 
    ID_Product AS 'ID_Product',
    Product_Name AS 'Product_Name',
    Amount_In_Storage AS 'Amount_In_Storage',
    Price AS 'Price'
FROM Products;
GO

CREATE VIEW View_ProductSelling 
AS
SELECT 
    ID_Selling AS 'ID_Selling',
    Product_ID AS 'Product_ID',
    Order_ID AS 'Order_ID'
FROM ProductSelling;
GO

DROP VIEW View_Payment_Methods
DROP VIEW View_Orders
DROP VIEW View_Products
DROP VIEW View_ProductSelling

SELECT 
    O.ID_Order,
    O.Order_Date,
    O.Order_Time,
    PM.Payment_Type,
    PS.Quantity,
    P.Product_Name,
    P.Amount_In_Storage,
    P.Price
FROM 
    Orders O
INNER JOIN 
    Payment_Methods PM ON O.Payment_Method_ID = PM.ID_Payment_Method
INNER JOIN 
    ProductSelling PS ON O.ID_Order = PS.Order_ID
INNER JOIN 
    Products P ON PS.Product_ID = P.ID_Product;

	SELECT 
    O.ID_Order,
    O.Order_Date,
    O.Order_Time,
    PM.Payment_Type,
    PS.Quantity,
    P.Product_Name,
    P.Amount_In_Storage,
    P.Price
FROM 
 INNER JOIN 
    Payment_Methods PM ON O.Payment_Method_ID = PM.ID_Payment_Method
INNER JOIN 
    ProductSelling PS ON O.ID_Order = PS.Order_ID
INNER JOIN 
    Products P ON PS.Product_ID = P.ID_Product;



SELECT * FROM Orders 
INNER JOIN Payment_Methods ON Orders.Payment_Method_ID = Payment_Methods.ID_Payment_Method 
INNER JOIN ProductSelling ON Orders.ID_Order = ProductSelling.Order_ID 
INNER JOIN Products ON ProductSelling.Product_ID = Products.ID_Product