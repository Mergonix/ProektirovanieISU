CREATE TABLE Property_Type
(ID_PropertyType INT IDENTITY PRIMARY KEY Not null,
DescriptionType NVARCHAR(100) Not null
)
go

CREATE PROCEDURE DELETEProperty_Type
@ID_PropertyType INT
AS
DELETE FROM Property_Type WHERE ID_PropertyType=@ID_PropertyType
go

CREATE PROCEDURE AddProperty_Type
@ID_PropertyType INT,
@DescriptionType NVARCHAR(100)
AS
INSERT INTO Property_Type VALUES(@DescriptionType)
go

CREATE PROCEDURE UpdateProperty_Type
@ID_PropertyType INT,
@DescriptionType NVARCHAR(100)
AS
Update Property_Type
SET DescriptionType=@DescriptionType
WHERE ID_PropertyType=@ID_PropertyType
go

CREATE PROCEDURE SelectProperty_Type
AS
SELECT ID_PropertyType AS [Код типа недвижимости], DescriptionType AS [Описание] FROM Property_Type
go