CREATE DATABASE Samokat
GO

USE Samokat
GO


CREATE TRIGGER Payment_Methods_Delete_Trigger
ON Payment_Methods
INSTEAD OF DELETE
AS
BEGIN
    DELETE FROM Users
    WHERE ID_Priority_Payment_Method IN (SELECT ID FROM deleted);

	DELETE FROM Orders
    WHERE ID_Payment_Method IN (SELECT ID FROM deleted);

	DELETE FROM Purchase_Receipts
    WHERE ID_Payment_Method IN (SELECT ID FROM deleted);
	
	DELETE FROM Payment_Methods WHERE ID IN (SELECT ID FROM deleted);
END;


CREATE TABLE Payment_Methods (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Payment_Method VARCHAR(48) NOT NULL
);
GO

INSERT INTO Payment_Methods (Payment_Method)
VALUES
('Наличными курьеру'),
('Банковской картой'),
('СБП'),
('BTC'),
('LTC'),
('XPay');

CREATE TABLE Users (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(28) NOT NULL,
	Passowrd VARCHAR(65) NOT NULL,
	First_Name VARCHAR(48),
	--Phone_Number INT NOT NULL,
	ID_Priority_Payment_Method INT,
	FOREIGN KEY (ID_Priority_Payment_Method) REFERENCES Payment_Methods (ID)
);
GO

INSERT INTO Users (Username, Passowrd, First_Name)
VALUES 
    ('user', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Денис'),
    ('elenalen', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 'Елена');


CREATE TABLE Addresses (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	City VARCHAR(64) NOT NULL, -- Город
	Street VARCHAR(64) NOT NULL, -- Улица
	House_Number INT NOT NULL, -- Номер дома
	Entrance_Number INT NOT NULL, -- Подъезд
	Intercom VARCHAR(16), -- Домофон
	Floor_Number INT, -- Этаж
	Apartment_Number INT, -- Кварира
	Postal_Code INT -- Почтовый индекс
);
GO

INSERT INTO Addresses (City, Street, House_Number, Entrance_Number, Intercom, Floor_Number, Apartment_Number, Postal_Code)
VALUES
    ('Москва', 'Профсоюзная', 123, 1, '1234', 5, 10, 123456),
    ('Санкт-Петербург', 'Невский проспект', 55, 2, '5678', 3, 7, 654321),
    ('Екатеринбург', 'Ленина', 78, 3, '4321', 2, 4, 987654);


CREATE TABLE Product_Categories (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Category_Name VARCHAR(48) NOT NULL
);
GO

INSERT INTO Product_Categories (Category_Name)
VALUES
	('Хлебо-булочные изделия'),
	('Холодные закуски'),
	('Горячие закуски'),
	('Морепродукты'),
	('Напитки')

CREATE TABLE Product_Brands (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Brand_Name VARCHAR(48) NOT NULL
);
GO

INSERT INTO Product_Brands (Brand_Name)
VALUES
	('Селяночка'),
	('Makfa'),
	('Borilla'),
	('Жигулевское'),
	('Океанство')

CREATE TABLE Products (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Product_Name VARCHAR(48) NOT NULL,
	ID_Product_Category INT NOT NULL,
	ID_Product_Brand INT NOT NULL,
	Amount_In_Storage INT NOT NULL,
	Product_Description VARCHAR(256),
	Price INT NOT NULL,
	FOREIGN KEY (ID_Product_Category) REFERENCES Product_Categories (ID),
	FOREIGN KEY (ID_Product_Brand) REFERENCES Product_Brands (ID)
);
GO

INSERT INTO Products (Product_Name, ID_Product_Category, ID_Product_Brand, Amount_In_Storage, Product_Description, Price)
VALUES
	('Пиво', 5, 4, 300, 'Вкусное', 120),
	('Гречка', 1, 1, 250, 'Больно стоять', 80),
	('Макароны', 1, 3, 530, 'Ням-Ням', 140),
	('Мука', 1, 2, 900, 'Белая', 120),
	('Кальмарчик', 4, 5, 320, 'Плавало', 600)

CREATE TABLE Product_Reviews (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	ID_User INT,
	--First_Name VARCHAR(32),
	--Review_Content VARCHAR(256),
	ID_Product INT NOT NULL,
	Final_Review INT NOT NULL,		
	FOREIGN KEY (ID_User) REFERENCES Users (ID),
	FOREIGN KEY (ID_Product) REFERENCES Products (ID),
);
GO

INSERT INTO Product_Reviews (ID_User, ID_Product, Final_Review)
VALUES
	(1, 1, 5),
	(2, 4, 3)

CREATE TABLE Order_Statuses (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Order_Status VARCHAR (48) NOT NULL
);
GO

INSERT INTO Order_Statuses (Order_Status)
VALUES
	('Собираем заказ'),
	('Заказ у курьера'),
	('Доставлен')


CREATE TABLE Employee_Positions(
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Position VARCHAR(48) NOT NULL
);
GO

INSERT INTO Employee_Positions(Position)
VALUES
('Курьер'),
('Кассир'),
('Админ');

SELECT * FROM Employee_Positions

CREATE TABLE Employees (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	Last_Name VARCHAR(48),
	First_Name VARCHAR(48),
	Middle_Name VARCHAR(48),
	Username VARCHAR(22) UNIQUE,
	PasswordHash VARCHAR(65),
	ID_Position INT NOT NULL,
	Age INT,
	Experience INT,
	FOREIGN KEY (ID_Position) REFERENCES Employee_Positions (ID),
);
GO

INSERT INTO Employees (Last_Name, First_Name, Middle_Name, Username, PasswordHash, ID_Position, Age, Experience)
VALUES 
	('Владимир', 'Владимирович', 'Ельцин', 'mcpoh', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '2', '12','0'),
    ('Мысев', 'Дмитрий', 'Александрович', 'miseff', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', '3', '22','11');


select * from Employees

CREATE TABLE Orders (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	ID_User INT NOT NULL,
	ID_Addresses INT NOT NULL,
	ID_Payment_Method INT NOT NULL,
	ID_Order_Status INT NOT NULL,
	Comment VARCHAR(256),
	ID_Deliverer INT NOT NULL,
	Final_Price INT,
	Created_In DATE,
	FOREIGN KEY (ID_User) REFERENCES Users (ID),
	FOREIGN KEY (ID_Addresses) REFERENCES Addresses (ID),
	FOREIGN KEY (ID_Payment_Method) REFERENCES Payment_Methods (ID),
	FOREIGN KEY (ID_Order_Status) REFERENCES Order_Statuses (ID),
	FOREIGN KEY (ID_Deliverer) REFERENCES Employees (ID)
);
GO

INSERT INTO Orders (ID_User, ID_Addresses, ID_Payment_Method, ID_Order_Status, Comment, ID_Deliverer, Final_Price, Created_In)
VALUES

('1','3','2','2','Привезут точно во время','1',600,'2024-03-21'),
('2','2','3','3','Скоро будет готово','2',140,'2024-06-21')

CREATE TABLE Orders_Context (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	ID_Order INT NOT NULL,
	ID_Product INT NOT NULL,
	FOREIGN KEY (ID_Order) REFERENCES Orders (ID),
	FOREIGN KEY (ID_Product) REFERENCES Products (ID),
);
GO

INSERT INTO Orders_Context (ID_Order, ID_Product)
VALUES

('1', '5'),
('2', '3')


CREATE TABLE Deliverer_Reviews (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	ID_User INT,
	--First_Name VARCHAR(32),
	--Review_Content VARCHAR(256),
	ID_Deliverer INT NOT NULL,
	Final_Review INT NOT NULL,		
	FOREIGN KEY (ID_User) REFERENCES Users (ID),
	FOREIGN KEY (ID_Deliverer) REFERENCES Employees (ID),
);
GO

INSERT INTO Deliverer_Reviews (ID_User, ID_Deliverer, Final_Review)
VALUES
	(1, 1, 5),
	(1, 2, 4)


CREATE TABLE Purchase_Receipts (
	ID INT PRIMARY KEY IDENTITY(1, 1),
	ID_Order INT,
	ID_Payment_Method INT,
	Paid_In DATE,
	FOREIGN KEY (ID_Order) REFERENCES Orders (ID),
	FOREIGN KEY (ID_Payment_Method) REFERENCES Payment_Methods (ID)
);
GO
	INSERT INTO Purchase_Receipts (ID_Order, ID_Payment_Method, Paid_In)
	VALUES
	(1, 3, '2024-03-21'),
	(2, 1, '2024-03-23')


SELECT * FROM Payment_Methods;
SELECT * FROM Users;
SELECT * FROM Addresses;
SELECT * FROM Product_Categories;
SELECT * FROM Product_Brands;
SELECT * FROM Products;
SELECT * FROM Product_Reviews;
SELECT * FROM Order_Statuses;
SELECT * FROM Employee_Positions;
SELECT * FROM Employees;
SELECT * FROM Orders;
SELECT * FROM Orders_Context;
SELECT * FROM Deliverer_Reviews;
SELECT * FROM Purchase_Receipts;
