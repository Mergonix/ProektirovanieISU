CREATE TABLE Users
(ID_Users INT IDENTITY PRIMARY KEY Not null,
Email NVARCHAR(100) Not null,
[Password] NVARCHAR(80),
Role_ID INT
)
go

CREATE PROCEDURE DELETEUsers
@ID_Users INT
AS
DELETE FROM Users WHERE @ID_Users=@ID_Users
go

CREATE PROCEDURE AddUsers
@ID_Users INT,
@Email NVARCHAR(100),
@Password NVARCHAR(80),
@Role_ID INT
AS
INSERT INTO Users VALUES(@Email,@Password,@Role_ID)
go

CREATE PROCEDURE UpdateUsers
@ID_Users INT,
@Email NVARCHAR(100),
@Password NVARCHAR(80),
@Role_ID INT
AS
Update Users
SET Email=@Email, [Password]=@Password, Role_ID=@Role_ID
WHERE ID_Users=@ID_Users
go

CREATE PROCEDURE SelectUsers
AS
SELECT ID_Users AS [Код ползователя], Email AS [Email], [Password] AS [Пароль], Role_ID AS [Код роли] FROM Users
go