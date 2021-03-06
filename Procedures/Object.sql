CREATE TABLE [Object]
(ID_Object INT IDENTITY PRIMARY KEY Not null,
DescriptionObject NVARCHAR(100) Not null
)
go

CREATE PROCEDURE DELETERealtor
@ID_Object INT
AS
DELETE FROM [Object] WHERE ID_Object=@ID_Object
go

CREATE PROCEDURE AddObject
@ID_Object INT,
@DescriptionObject NVARCHAR(100)
AS
INSERT INTO [Object] VALUES(@DescriptionObject)
go

CREATE PROCEDURE UpdateObject
@ID_Object INT,
@DescriptionObject NVARCHAR(100)
AS
Update [Object]
SET DescriptionObject=@DescriptionObject
WHERE ID_Object=@ID_Object
go

CREATE PROCEDURE SelectRealtor
AS
SELECT ID_Object AS [Код типа объекта], DescriptionObject AS [Описание объекта] FROM [Object]
go