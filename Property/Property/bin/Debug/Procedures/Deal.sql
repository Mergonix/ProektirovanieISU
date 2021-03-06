CREATE TABLE Deal
(ID_Deal INT IDENTITY PRIMARY KEY Not null,
DateDeal DATETIME null,
Realty_ID INT Not null,
Realtor_ID INT Not null,
Services_ID INT Not null
)
go

CREATE PROCEDURE DELETEDeal
@ID_Deal INT
AS
DELETE FROM Deal WHERE ID_Deal=@ID_Deal
go

CREATE PROCEDURE AddDeal
@ID_Deal INT,
@DescriptionHouse NVARCHAR(100)
AS
INSERT INTO Deal VALUES(@DescriptionHouse)
go

CREATE PROCEDURE UpdateDeal
@ID_Deal INT,
@DateDeal DATETIME,
@Realty_ID INT,
@Realtor_ID INT,
@Services_ID INT
AS
Update Deal
SET DateDeal=@DateDeal, Realty_ID=@Realty_ID, Realtor_ID=@Realtor_ID, Services_ID=@Services_ID
WHERE ID_Deal=@ID_Deal
go

CREATE PROCEDURE SelectDeal
AS
SELECT ID_Deal AS [Код сделки], DateDeal AS [Дата сделки], Realty_ID AS [Код недвижимости], Realtor_ID AS [Код риелтора], Services_ID AS [Код вида сделки] FROM Deal
go