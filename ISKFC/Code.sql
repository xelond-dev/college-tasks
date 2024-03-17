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

INSERT INTO Payment_Methods (Payment_Type) VALUES ('��������'), ('�����'), ('�������')
GO

INSERT INTO Orders (Payment_Method_ID, Order_Date, Order_Time) VALUES (1, GETDATE(), GETDATE()), (2, GETDATE(), GETDATE()), (2, GETDATE(), GETDATE()), (1, GETDATE(), GETDATE()), (3, GETDATE(), GETDATE())
GO

INSERT INTO Products (Product_Name, Amount_In_Storage, Price) VALUES ('�������� �������� (�������)', 3, '301'), ('�������� ������', 3524, '299'), ('������� ����', 127, '420'), ('������ �� ��������', 1, '1200'), ('������� ������', 15, '788'), ('����', 6, '600')
GO

INSERT INTO ProductSelling (Order_ID, Product_ID) VALUES (3, 5), (3, 6), (3, 6), (3, 7), (3, 9), (4, 10), (5, 7), (5, 6), (6, 5), (6, 6), (6, 7), (7, 8), (7, 9) 
GO

CREATE VIEW View_Payment_Methods AS
SELECT 
    ID_Payment_Method AS '�����_����������_������',
    Payment_Type AS '���_�������'
FROM Payment_Methods;
GO

CREATE VIEW View_Orders 
AS
SELECT 
    ID_Order AS '�����_������',
    Payment_Method_ID AS '�����_����������_������',
    Order_Date AS '����_������'
FROM Orders;
GO

CREATE VIEW View_Products 
AS
SELECT 
    ID_Product AS '�����_��������',
    Product_Name AS '��������_��������',
    Amount_In_Storage AS '����������_��_������',
    Price AS '����'
FROM Products;
GO

CREATE VIEW View_ProductSelling 
AS
SELECT 
    ID_Selling AS '�����_�������',
    Product_ID AS '�����_��������',
    Order_ID AS '�����_������'
FROM ProductSelling;
GO