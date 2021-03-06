CREATE TABLE [Role]
(ID_Role INT IDENTITY PRIMARY KEY Not null,
[Name] NVARCHAR(100) Not null
)
go

CREATE PROCEDURE DELETERole
@ID_Role INT
AS
DELETE FROM [Role] WHERE ID_Role=@ID_Role
go

CREATE PROCEDURE AddRole
@ID_Role INT,
@Name NVARCHAR(100)
AS
INSERT INTO [Role] VALUES(@Name)
go

CREATE PROCEDURE UpdateRole
@ID_Role INT,
@Name NVARCHAR(100)
AS
Update [Role]
SET [Name]=@Name
WHERE ID_Role=@ID_Role
go

CREATE PROCEDURE SelectRole
AS
SELECT ID_Role AS [Код роли], [Name] AS [Наименование] FROM [Role]
go