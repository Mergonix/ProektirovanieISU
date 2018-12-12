CREATE TABLE [Services]
(ID_Services INT IDENTITY PRIMARY KEY Not null,
[Description] NVARCHAR(100) Not null
)
go

CREATE PROCEDURE DELETEServices
@ID_Services INT
AS
DELETE FROM [Services] WHERE ID_Services=@ID_Services
go

CREATE PROCEDURE AddServices
@ID_Services INT,
@Description NVARCHAR(100)
AS
INSERT INTO [Services] VALUES(@Description)
go

CREATE PROCEDURE UpdateServices
@ID_Services INT,
@Description NVARCHAR(100)
AS
Update [Services]
SET [Description]=@Description
WHERE ID_Services=@ID_Services
go

CREATE PROCEDURE SelectServices
AS
SELECT ID_Services AS [Код вида сделки], [Description] AS [Описание] FROM Services
go