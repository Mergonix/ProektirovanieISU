CREATE TABLE House_Type
(ID_HouseType INT IDENTITY PRIMARY KEY Not null,
DescriptionHouse NVARCHAR(100) Not null
)
go

CREATE PROCEDURE DELETEHouseType
@ID_HouseType INT
AS
DELETE FROM House_Type WHERE ID_HouseType=@ID_HouseType
go

CREATE PROCEDURE AddHouseType
@ID_HouseType INT,
@DescriptionHouse NVARCHAR(100)
AS
INSERT INTO House_Type VALUES(@DescriptionHouse)
go

CREATE PROCEDURE UpdateHouseType
@ID_HouseType INT,
@DescriptionHouse NVARCHAR(100)
AS
Update House_Type
SET DescriptionHouse=@DescriptionHouse
WHERE ID_HouseType=@ID_HouseType
go

CREATE PROCEDURE SelectHouseType
AS
SELECT ID_HouseType AS [Код вида дома], DescriptionHouse AS [Описание дома] FROM House_Type
go