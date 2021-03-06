CREATE TABLE Realty
(ID_Realty INT IDENTITY PRIMARY KEY Not null,
TotalArea DECIMAL(10, 2) Not null,
Flor INT Not null,
Flors INT null,
Price DECIMAL(10, 2) Not null,
Descript NVARCHAR(1000) Not null,
City NVARCHAR(100) Not null,
Street NVARCHAR(100) Not null,
NumberRooms INT null,
NumberHouse NVARCHAR(10) Not null,
Apartment NVARCHAR(10) null,
[Status] NVARCHAR(25) null,
PropertyType_ID INT Not null,
[Object_ID] INT Not null,
HouseType_ID INT Not null,
Clients_ID INT Not null
)
go

CREATE PROCEDURE DELETERealty
@ID_Realty INT
AS
DELETE FROM Realty WHERE ID_Realty=@ID_Realty
go

CREATE PROCEDURE AddRealty
@ID_Realty INT,
@TotalArea DECIMAL(10, 2),
@Flor INT,
@Flors INT,
@Price DECIMAL(10, 2),
@Descript NVARCHAR(1000),
@City NVARCHAR(100),
@Street NVARCHAR(100),
@NumberRooms INT,
@NumberHouse NVARCHAR(10),
@Apartment NVARCHAR(10),
@Status NVARCHAR(25),
@PropertyType_ID INT,
@Object_ID INT,
@HouseType_ID INT,
@Clients_ID INT
AS
INSERT INTO Realty VALUES(@TotalArea,@Flor,@Flors,@Price,@Descript,@City,@Street,@NumberRooms,@NumberHouse,@Apartment,@Status,@PropertyType_ID,@Object_ID,@HouseType_ID,@Clients_ID)
go

CREATE PROCEDURE UpdateRealty
@ID_Realty INT,
@TotalArea DECIMAL(10, 2),
@Flor INT,
@Flors INT,
@Price DECIMAL(10, 2),
@Descript NVARCHAR(1000),
@City NVARCHAR(100),
@Street NVARCHAR(100),
@NumberRooms INT,
@NumberHouse NVARCHAR(10),
@Apartment NVARCHAR(10),
@Status NVARCHAR(25),
@PropertyType_ID INT,
@Object_ID INT,
@HouseType_ID INT,
@Clients_ID INT
AS
Update Realty
SET TotalArea=@TotalArea, Flor=@Flor, Flors=@Flors, Price=@Price, Descript=@Descript, City=@City, Street=@Street, NumberRooms=@NumberRooms, NumberHouse=@NumberHouse, Apartment=@Apartment, [Status]=@Status, PropertyType_ID=@PropertyType_ID, [Object_ID]=@Object_ID, HouseType_ID=@HouseType_ID, Clients_ID=@Clients_ID
WHERE ID_Realty=@ID_Realty
go

CREATE PROCEDURE SelectServices
AS
SELECT ID_Realty AS [Код недвижемости], TotalArea AS [Площадь], Flor AS [Этаж], Flors AS [Этажность], Price AS [Цена], Descript AS [Описание],
City AS [Город], Street AS [Улица], NumberRooms AS [Номер квартиры], NumberHouse AS [Номер дома], Apartment AS [Апартаменты], 
[Status] AS [Статус], PropertyType_ID AS [Код типа недвижимости], [Object_ID] AS [Код объекта], HouseType_ID AS [Код типа дома], Clients_ID AS [Код клиента] FROM Realty
go