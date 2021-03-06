CREATE TABLE Clients
(ID_Clients INT IDENTITY PRIMARY KEY Not null,
FirstName NVARCHAR(80) Not null,
LastName NVARCHAR(80) Not null,
Patronymic NVARCHAR(80) null,
DateBirth DATETIME Not null,
Telephone NVARCHAR(20) Not null,
Adress NVARCHAR(100) Not null,
Users_ID INT Not null
)
go

CREATE PROCEDURE DELETEClients
@ID_Clients INT
AS
DELETE FROM Clients WHERE ID_Clients=@ID_Clients
go

CREATE PROCEDURE AddClients
@ID_Clients INT,
@FirstName NVARCHAR(80),
@LastName NVARCHAR(80),
@Patronymic NVARCHAR(80),
@DateBirth DATETIME,
@Telephone NVARCHAR(20),
@Adress NVARCHAR(100),
@Users_ID INT
AS
INSERT INTO Clients VALUES(@FirstName,@LastName,@Patronymic,@DateBirth,@Telephone,@Adress,@Users_ID)
go

CREATE PROCEDURE UpdateClients
@ID_Clients INT,
@FirstName NVARCHAR(80),
@LastName NVARCHAR(80),
@Patronymic NVARCHAR(80),
@DateBirth DATETIME,
@Telephone NVARCHAR(20),
@Adress NVARCHAR(100),
@Users_ID INT
AS
Update Clients
SET FirstName=@FirstName, LastName=@LastName, Patronymic=@Patronymic, DateBirth=@DateBirth, Telephone=@Telephone, Adress=@Adress, Users_ID=@Users_ID 
WHERE ID_Clients=@ID_Clients
go

CREATE PROCEDURE SelectClients
AS
SELECT ID_Clients AS [Код клиента], FirstName AS [Имя], LastName AS [Фамилия], Patronymic AS [Отчество], DateBirth AS [Дата рождения], Telephone AS [Номер телефона], Adress AS [Адрес], Users_ID AS [Код пользователя] FROM Clients
go