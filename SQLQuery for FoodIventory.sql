CREATE DATABASE FoodInventory;

USE FoodInventory;

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
[ProductName] VARCHAR(50) NOT NULL,
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


INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Hús');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Felvágott');
INSERT INTO [ProdCategory] (ProdCatName) VALUES ('Tejtermék');
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

INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Csirkemell', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Karaj', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Pick csirkepárizsi', 2, 1);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Csirkemell', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Csirkemell', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Csirkemell', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Csirkemell', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Karaj', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Karaj', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Karaj', 1, 2);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Pick csirkepárizsi', 2, 3);
INSERT INTO [Product] ([ProductName], ProdCategoryId, LocationId ) VALUES ('Kaiser májas', 2, 2);

CREATE PROCEDURE Inventory_GetList
AS
	SELECT
		ProductId,
		ProductName,
		ProdCategoryId,
		LocationId,
		GetInDate,
		BestBefore
	FROM
		[FoodInventory].[dbo].[Product]
GO
