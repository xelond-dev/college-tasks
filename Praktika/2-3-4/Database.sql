CREATE DATABASE XPrimary;

DROP DATABASE XPrimary

USE XPrimary;

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
    FOREIGN KEY (Payment_Method_ID) REFERENCES Payment_Methods(ID_Payment_Method)
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
    Quantity INT NOT NULL,
    FOREIGN KEY (Product_ID) REFERENCES Products(ID_Product),
    FOREIGN KEY (Order_ID) REFERENCES Orders(ID_Order)
);
GO

drop table Payment_Methods;
drop table Orders;
drop table Products;
drop table ProductSelling;

CREATE VIEW vw_Orders AS
SELECT 
    ID_Order AS 'ID_Order',
    Payment_Method_ID AS 'Payment_Method_ID',
    Order_Date AS 'Order_Date',
    Order_Time AS 'Order_Time'
FROM Orders;

SELECT * FROM vw_Payment_Methods

CREATE VIEW vw_Products AS
SELECT 
    ID_Product AS 'ID_Product',
    Product_Name AS 'Product_Name',
    Amount_In_Storage AS 'Amount_In_Storage',
    Price AS 'Price'
FROM Products;


CREATE VIEW vw_ProductSelling AS
SELECT 
    ID_Selling AS 'ID_Selling',
    Product_ID AS 'Product_ID',
    Order_ID AS 'Order_ID',
    Quantity AS 'Quantity'
FROM ProductSelling;


CREATE VIEW vw_Payment_Methods AS
SELECT 
    ID_Payment_Method AS 'ID_Payment_Method',
    Payment_Type AS 'Payment_Type'
FROM Payment_Methods;

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



INSERT INTO Payment_Methods (Payment_Type)
VALUES ('Наличные'), ('Банковская карта'), ('Выставить счет'), ('Криптовалюта'), ('XPay');

SELECT * FROM Products

SELECT * FROM Payment_Methods


INSERT INTO Products (Product_Name, Amount_In_Storage, Price)
VALUES 
('Фуа-гра с трюфелями', 20, 7500),
('Стейк из вагю', 15, 15000),
('Лобстер биск', 25, 4000),
('Трюфельный ризотто', 30, 5500),
('Блины с икрой', 10, 10000),
('Морской плэттер', 20, 12000),
('Конфи утки с вишневым соусом', 15, 6500),
('Рулет из черной трески с горьким шоколадом', 12, 8500),
('Паста с черным трюфелем', 18, 7000),
('Филе форели в кокосовом молоке', 20, 9000),
('Тартар из красного морского окуня с авокадо', 15, 8000),
('Фаршированные раки с кремом из краба', 10, 13000),
('Печеные мидии с белым вином и чесноком', 25, 4500);


INSERT INTO Orders (Payment_Method_ID, Order_Date, Order_Time)
VALUES 
(1, '2024-03-21', '10:00'),
(2, '2024-03-21', '11:30'),
(3, '2024-03-21', '13:45'),
(4, '2024-03-21', '15:20'),
(5, '2024-03-21', '17:00');


INSERT INTO ProductSelling (Product_ID, Order_ID, Quantity)
VALUES
(1, 3, 2), 
(3, 3, 1),
(5, 3, 3);


INSERT INTO ProductSelling (Product_ID, Order_ID, Quantity)
VALUES
(2, 4, 1),
(4, 4, 2),
(6, 4, 1); 


INSERT INTO ProductSelling (Product_ID, Order_ID, Quantity)
VALUES
(7, 5, 2),
(9, 5, 1),
(10, 5, 3);

INSERT INTO ProductSelling (Product_ID, Order_ID, Quantity)
VALUES
(8, 1, 1),
(12, 1, 2)
(13, 1, 1); 

INSERT INTO ProductSelling (Product_ID, Order_ID, Quantity)
VALUES
(11, 2, 2),
(1, 2, 1),
(3, 2, 1);
