CREATE TABLE Realtor
(ID_Realtor INT IDENTITY PRIMARY KEY Not null,
FirstName NVARCHAR(80) Not null,
LastName NVARCHAR(80) Not null,
Telephone NVARCHAR(20) Not null,
Patronymic NVARCHAR(80) null,
Users_ID INT Not null
)
go

CREATE PROCEDURE DELETERealtor
@ID_Realtor INT
AS
DELETE FROM Realtor WHERE ID_Realtor=@ID_Realtor
go

CREATE PROCEDURE AddRealtor
@ID_Realtor INT,
@FirstName NVARCHAR(80),
@LastName NVARCHAR(80),
@Telephone NVARCHAR(20),
@Patronymic NVARCHAR(80),
@Users_ID INT
AS
INSERT INTO Realtor VALUES(@FirstName,@LastName,@Telephone,@Patronymic,@Users_ID)
go

CREATE PROCEDURE UpdateRealtor
@ID_Realtor INT,
@FirstName NVARCHAR(80),
@LastName NVARCHAR(80),
@Telephone NVARCHAR(20),
@Patronymic NVARCHAR(80),
@Users_ID INT
AS
Update Realtor
SET FirstName=@FirstName, LastName=@LastName, Patronymic=@Patronymic, Telephone=@Telephone, Users_ID=@Users_ID
WHERE ID_Realtor=@ID_Realtor
go

CREATE PROCEDURE SelectRealtor
AS
SELECT ID_Realtor AS [Код риелтора], FirstName AS [Имя], LastName AS [Фамилия], Patronymic AS [Отчество], Telephone AS [Номер телефона], Users_ID AS [Код пользователя] FROM Realtor
go