CREATE DATABASE FoodInventory;

USE FoodInventory;

CREATE TABLE Unit(
UnitId INT IDENTITY(1, 1) NOT NULL,
[UnitName] VARCHAR(20) NOT NULL DEFAULT('kg'),
PRIMARY KEY (UnitId)
);

CREATE TABLE ProdCategory(
ProdCategoryId INT IDENTITY(1, 1) NOT NULL,
[ProdCatName] VARCHAR(50) NOT NULL,
PRIMARY KEY (ProdCategoryId)
);

CREATE TABLE LocCategory(
LocCategoryId INT IDENTITY(1, 1) NOT NULL,
[LocCatName] VARCHAR(50) NOT NULL,
PRIMARY KEY (LocCategoryId)
);

CREATE TABLE [Location] (
LocationId INT IDENTITY(1, 1) NOT NULL,
[LocationName] VARCHAR(50) NOT NULL,
LocCategoryId INT NOT NULL,
PRIMARY KEY (LocationId),
FOREIGN KEY (LocCategoryId) REFERENCES LocCategory(LocCategoryId)
);

CREATE TABLE [Product] (
ProductId INT IDENTITY(1, 1) NOT NULL,
ProductName VARCHAR(50) NOT NULL,
[Description] VARCHAR(50),
ProdCategoryId INT NOT NULL,
LocationId INT NOT NULL,
PRIMARY KEY (ProductId),	
FOREIGN KEY (ProdCategoryId) REFERENCES ProdCategory(ProdCategoryId),
FOREIGN KEY (LocationId) REFERENCES [Location](LocationId)
);

ALTER TABLE [Product]
ADD
GetInDate DATETIME NOT NULL DEFAULT(GETDATE()),
BestBefore DATETIME NOT NULL DEFAULT(GETDATE())
GO

ALTER TABLE [Product]
ADD
Quantity FLOAT NOT NULL DEFAULT(1)
GO

ALTER TABLE [Product]
ADD
UnitId INT NOT NULL,
FOREIGN KEY (UnitId) REFERENCES [Unit](UnitId)
GO

INSERT INTO [Unit] (UnitName) VALUES ('dkg');
INSERT INTO [Unit] (UnitName) VALUES ('kg');
INSERT INTO [Unit] (UnitName) VALUES ('dl');
INSERT INTO [Unit] (UnitName) VALUES ('liter');
INSERT INTO [Unit] (UnitName) VALUES ('db');
INSERT INTO [Unit] (UnitName) VALUES ('egyéb');

INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Hús');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Felvágott');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Tejtermék');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Tojás');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Készétel');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Tartós');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Zölds, Gyüm');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Mélyhűtött');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Nasi');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Vegyiáru');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Egyéb');

INSERT INTO [LocCategory] (LocCatName) VALUES ('Fagyasztó');
INSERT INTO [LocCategory] (LocCatName) VALUES ('Hűtő');
INSERT INTO [LocCategory] (LocCatName) VALUES ('Lakás');
INSERT INTO [LocCategory] (LocCatName) VALUES ('Egyéb');

INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Nagyhűtő', 2);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Nagyfagyasztó', 1);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Kishűtő', 2);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Kisfagyasztó', 1);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Kamra', 3);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Mosókonyha', 3);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Garázs', 4);
INSERT INTO [Location] (LocationName, LocCategoryId) VALUES ('Egyéb', 4);

INSERT INTO [Product] ([ProductName], [Description], ProdCategoryId, LocationId, UnitId ) VALUES ('Csirkemell', 'pipihusi', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Karaj', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Pick csirkepárizsi', 2, 1, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Csirkemell', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Karaj', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Karaj', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Karaj', 1, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Pick csirkepárizsi', 2, 3, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Kaiser májas', 2, 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId, UnitId ) VALUES ('Krumpli', 5, 7, 1);

USE FoodInventory;
GO
CREATE PROCEDURE Inventory_GetList
AS
	SELECT
		ProductId,
		ProductName,
		[Description],
		ProdCategoryId,
		LocationId,
		GetInDate,
		BestBefore,
		Quantity,
		UnitId
	FROM
		[FoodInventory].[dbo].[Product]
GO

USE FoodInventory;
GO
CREATE PROCEDURE ProdCategory_GetList
AS
	SELECT
		ProdCategoryId,
		ProdCatName
	FROM
		[FoodInventory].[dbo].[ProdCategory]
GO

USE FoodInventory;
GO
CREATE PROCEDURE Locations_GetList
AS
	SELECT
		LocationId,
		LocationName,
		LocCategoryId
	FROM
		[FoodInventory].[dbo].[Location]
GO

USE FoodInventory;
GO
CREATE PROCEDURE LocCategory_GetList
AS
	SELECT
		LocCategoryId,
		LocCatName		
	FROM
		[FoodInventory].[dbo].[LocCategory]
GO

USE FoodInventory;
GO
CREATE PROCEDURE Unit_GetList
AS
	SELECT
		UnitId,
		UnitName		
	FROM
		[FoodInventory].[dbo].[Unit]
GO

USE FoodInventory;
GO
CREATE PROCEDURE Inventory_Update_Item
@ProductId INT,
@ProductName VARCHAR(50),
@Description VARCHAR(50),
@ProdCategoryId INT,
@LocationId INT,
@GetInDate DATETIME,
@BestBefore DATETIME,
@Quantity FLOAT,
@UnitId INT
AS
	UPDATE [Product]
	SET 	
		ProductName = @ProductName,
		[Description] = @Description,
		ProdCategoryId = @ProdCategoryId,
		LocationId = @LocationId,
		GetInDate = @GetInDate,
		BestBefore = @BestBefore,
		Quantity = @Quantity,
		UnitId = @UnitId
	WHERE ProductId = @ProductId
GO

USE FoodInventory;
GO
CREATE PROCEDURE Inventory_Upsert_Item
@ProductId INT,
@ProductName VARCHAR(50),
@Description VARCHAR(50),
@ProdCategoryId INT,
@LocationId INT,
@GetInDate DATETIME,
@BestBefore DATETIME,
@Quantity FLOAT,
@UnitId INT
AS
	MERGE INTO Product Target
	USING
	(
	SELECT
		@ProductId ProductId,
		@ProductName ProductName,
		@Description [Description],
		@ProdCategoryId ProdCategoryId,
		@LocationId LocationId,
		@GetInDate GetInDate,
		@BestBefore BestBefore,
		@Quantity Quantity,
		@UnitId UnitId	
	) AS SOURCE
	ON
	(
		TARGET.ProductId = SOURCE.ProductId
	)
	WHEN MATCHED THEN
		UPDATE SET
			TARGET.ProductName = SOURCE.ProductName,
			TARGET.[Description] = SOURCE.[Description],
			TARGET.ProdCategoryId = SOURCE.ProdCategoryId,
			TARGET.LocationId = SOURCE.LocationId,
			TARGET.GetInDate = SOURCE.GetInDate,
			TARGET.BestBefore = SOURCE.BestBefore,
			TARGET.Quantity = SOURCE.Quantity,
			TARGET.UnitId = SOURCE.UnitId
	WHEN NOT MATCHED By TARGET THEN
		INSERT (
			ProductName,
			[Description],
			ProdCategoryId,
			LocationId,
			GetInDate,
			BestBefore,
			Quantity,
			UnitId		
		)
		VALUES(
			ProductName,
			[Description],
			ProdCategoryId,
			LocationId,
			GetInDate,
			BestBefore,
			Quantity,
			UnitId		
		);
GO

USE FoodInventory;
GO
CREATE PROCEDURE Inventory_Delete_Item
@ProductId INT
AS
	DELETE FROM Product Where ProductId = @ProductId
GO

USE FoodInventory;
GO
CREATE PROCEDURE Inventory_EmptyTable
AS
	DELETE FROM Product
GO

DELETE FROM Unit
