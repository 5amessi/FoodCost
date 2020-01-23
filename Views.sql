USE [FoodCost]
GO
/****** Object:  View [dbo].[BeginningEndingMonthView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BeginningEndingMonthView]
AS
SELECT        dbo.Kitchens_Setup.Name AS KitchenName, dbo.BeginningEndingMonth.Year, dbo.BeginningEndingMonth.Month, dbo.BeginningEndingMonth.FromDate, dbo.BeginningEndingMonth.ToDate, 
                         dbo.BeginningEndingMonth.Restaurant_ID, dbo.BeginningEndingMonth.Kitchen_ID, dbo.BeginningEndingMonth.Item_ID, dbo.BeginningEndingMonth.Qty, dbo.BeginningEndingMonth.Cost
FROM            dbo.BeginningEndingMonth INNER JOIN
                         dbo.Kitchens_Setup ON dbo.BeginningEndingMonth.Restaurant_ID = dbo.Kitchens_Setup.RestaurantID AND dbo.BeginningEndingMonth.Kitchen_ID = dbo.Kitchens_Setup.Code


GO
/****** Object:  View [dbo].[BinAdjView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BinAdjView]
AS
SELECT        dbo.Adjacment_Items.AdjacmentableQty, dbo.Adjacment_Items.Variance, dbo.Adjacment_tbl.Adjacment_Date, dbo.Adjacment_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, dbo.Adjacment_tbl.KitchenID AS Kitchen_ID, 
                         dbo.Adjacment_tbl.Resturant_ID AS Restaurant_ID, dbo.Adjacment_Items.Qty, dbo.Store_Setup.Name AS RestaurantName, dbo.Kitchens_Setup.Name AS KitchenName, dbo.Adjacment_Items.Cost, dbo.Setup_Items.Unit, 
                         dbo.Adjacment_Items.Adjacment_ID, dbo.Setup_Items.Category
FROM            dbo.Adjacment_Items INNER JOIN
                         dbo.Adjacment_tbl ON dbo.Adjacment_Items.Adjacment_ID = dbo.Adjacment_tbl.Adjacment_ID INNER JOIN
                         dbo.Store_Setup ON dbo.Adjacment_tbl.Resturant_ID = dbo.Store_Setup.Code INNER JOIN
                         dbo.Setup_Items ON dbo.Adjacment_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Kitchens_Setup ON dbo.Adjacment_tbl.KitchenID = dbo.Kitchens_Setup.Code AND dbo.Adjacment_tbl.Resturant_ID = dbo.Kitchens_Setup.RestaurantID

GO
/****** Object:  View [dbo].[BinCard]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BinCard]
AS
SELECT        dbo.RO_Items.Item_ID, dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Serial, dbo.RO_Items.Net_Price, dbo.RO.Receiving_Date AS Date, dbo.RO.Type, dbo.RO_Items.RO_No, dbo.RO.Kitchen_ID, 
                         dbo.Kitchens_Setup.Name AS KitchenName, dbo.Kitchens_Setup.Code, '' AS TransDetails, '' AS ItemName, dbo.RO_Items.Price_Without_Tax, dbo.RO_Items.Tax, dbo.RO_Items.Price_With_Tax, dbo.RO.Resturant_ID, 
                         '' AS RestaurantName, '' as Cost, '' as [Net Cost], 0.0 AS OnHand, 0.0 AS Min, 0.0 AS Max, '' AS BCost, '' AS ECost, '' AS BQty, '' AS EQty
FROM            dbo.RO INNER JOIN
                         dbo.RO_Items ON dbo.RO.RO_Serial = dbo.RO_Items.RO_No INNER JOIN
                         dbo.Kitchens_Setup ON dbo.RO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.RO.RO_Serial = dbo.Kitchens_Setup.Name2 INNER JOIN
                         dbo.Setup_Items ON dbo.RO_Items.Item_ID = dbo.Setup_Items.Code


GO
/****** Object:  View [dbo].[GeneratedRecipesView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GeneratedRecipesView]
AS
SELECT        dbo.GenerateRecipe_Items.Generate_ID, dbo.GenerateRecipe_tbl.Generate_Date, dbo.GenerateRecipe_tbl.Resturant_ID AS Restaurant_ID, dbo.GenerateRecipe_tbl.Kitchen_ID, dbo.GenerateRecipe_Items.Item_ID, 
                         dbo.GenerateRecipe_Items.ItemQty, dbo.Kitchens_Setup.Name AS KitchenName
FROM            dbo.GenerateRecipe_Items INNER JOIN
                         dbo.GenerateRecipe_tbl ON dbo.GenerateRecipe_Items.Generate_ID = dbo.GenerateRecipe_tbl.Generate_ID INNER JOIN
                         dbo.Kitchens_Setup ON dbo.GenerateRecipe_tbl.Resturant_ID = dbo.Kitchens_Setup.RestaurantID AND dbo.GenerateRecipe_tbl.Kitchen_ID = dbo.Kitchens_Setup.Code
WHERE        (dbo.GenerateRecipe_Items.Item_ID IS NOT NULL)

GO
/****** Object:  View [dbo].[InventoryStats]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[InventoryStats]
AS
SELECT        dbo.Items.ItemID, dbo.Items.Qty, dbo.Items.Units, dbo.Items.Last_Cost, dbo.Items.Current_Cost, dbo.Items.ShufledID, dbo.Items.MinNumber, dbo.Items.MaxNumber, dbo.Items.Net_Cost, 
                         dbo.Store_Setup.Name AS ResturantName, dbo.Kitchens_Setup.Name AS KitchenName, dbo.Setup_Items.Name AS ItemName, dbo.Items.RestaurantID AS Restaurant_ID, dbo.Items.KitchenID AS Kitchen_ID
FROM            dbo.Items INNER JOIN
                         dbo.Store_Setup ON dbo.Items.RestaurantID = dbo.Store_Setup.Code INNER JOIN
                         dbo.Kitchens_Setup ON dbo.Items.KitchenID = dbo.Kitchens_Setup.Code AND dbo.Items.RestaurantID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Setup_Items ON dbo.Items.ItemID = dbo.Setup_Items.Code






GO
/****** Object:  View [dbo].[POItems]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[POItems]
AS
SELECT        dbo.PO.PO_No, dbo.PO_Items.Item_ID, dbo.PO.Vendor_ID, dbo.PO.PaymentTerm_ID, dbo.PO.Create_Date, dbo.PO.Delivery_Date, dbo.PO.Post_Date, dbo.PO.Last_Modified_Date, dbo.PO.Approval_Date, dbo.PO.WS, 
                         dbo.PO.Comment, dbo.PO_Items.Qty, dbo.PO_Items.Unit, dbo.PO_Items.Serial, dbo.PO_Items.Net_Price, dbo.Setup_Items.Name AS ItemName, dbo.Store_Setup.Name AS RestaurantName, 
                         dbo.Kitchens_Setup.Name AS KitchenName, dbo.Vendors.Name AS VendorName, dbo.PO.Kitchen_ID, dbo.PO.Restaurant_ID, dbo.PO_Items.PO_Serial, dbo.PO_Items.Price_Without_Tax, dbo.PO_Items.Tax, 
                         dbo.PO_Items.Price_With_Tax, dbo.PO_Items.Tax_Included
FROM            dbo.PO INNER JOIN
                         dbo.PO_Items ON dbo.PO.PO_Serial = dbo.PO_Items.PO_Serial INNER JOIN
                         dbo.Setup_Items ON dbo.PO_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Kitchens_Setup ON dbo.PO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.PO.Restaurant_ID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID INNER JOIN
                         dbo.Store_Setup ON dbo.Kitchens_Setup.RestaurantID = dbo.Store_Setup.Code





GO
/****** Object:  View [dbo].[POView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[POView]
AS
SELECT        dbo.PO.PO_No, dbo.PO.PaymentTerm_ID, dbo.PO.Create_Date, dbo.PO.Delivery_Date, dbo.PO.Post_Date, dbo.PO.Last_Modified_Date, dbo.PO.Approval_Date, dbo.PO.WS, dbo.PO.Comment, 
                         dbo.Store_Setup.Code AS StoreID, dbo.Kitchens_Setup.Name AS KitchenName, dbo.Vendors.Name AS VendorName, dbo.Store_Setup.Name AS ResturantName, dbo.PO.Restaurant_ID, dbo.PO.Kitchen_ID, dbo.PO.Ship_To, 
                         dbo.PO.Vendor_ID, dbo.PO.Total_Price, dbo.PO.PO_Serial
FROM            dbo.PO INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID INNER JOIN
                         dbo.Kitchens_Setup ON dbo.PO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.PO.Restaurant_ID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Store_Setup ON dbo.Kitchens_Setup.RestaurantID = dbo.Store_Setup.Code





GO
/****** Object:  View [dbo].[ReceiveItemsView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceiveItemsView]
AS
SELECT        dbo.RO.RO_Serial, dbo.RO.Transactions_No, dbo.RO.Status, dbo.RO.Receiving_Date, dbo.RO.Resturant_ID AS Restaurant_ID, dbo.RO.Kitchen_ID, dbo.RO.WS, dbo.RO.Type, dbo.RO.Comment, dbo.RO_Items.Item_ID, 
                         dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Serial, dbo.RO_Items.Net_Price, dbo.Setup_Items.Name AS ItemName, dbo.Store_Setup.Name AS RestaurantName, dbo.Kitchens_Setup.Name AS KitchenName, 
                         dbo.RO.RO_No, dbo.RO_Items.Price_Without_Tax, dbo.RO_Items.Tax, dbo.RO_Items.Price_With_Tax, dbo.RO_Items.QtyOnHand_To, dbo.RO_Items.Cost_To, dbo.RO_Items.QtyOnHand_From, dbo.RO_Items.Cost_From, 
                         dbo.RO.Create_Date, dbo.RO.Post_Date, dbo.RO.UserID, dbo.RO.Last_Modified_Date, dbo.RO.Approval_Date, dbo.Setup_Items.Category
FROM            dbo.RO INNER JOIN
                         dbo.RO_Items ON dbo.RO.RO_Serial = dbo.RO_Items.RO_No INNER JOIN
                         dbo.Setup_Items ON dbo.RO_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Kitchens_Setup ON dbo.RO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.RO.Resturant_ID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Store_Setup ON dbo.Kitchens_Setup.RestaurantID = dbo.Store_Setup.Code

GO
/****** Object:  View [dbo].[ReceiveOrderView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceiveOrderView]
AS
SELECT        dbo.RO.RO_Serial, dbo.RO.Transactions_No, dbo.RO.Status, dbo.RO.Receiving_Date, dbo.RO.Resturant_ID AS Restaurant_ID, dbo.RO.Kitchen_ID, dbo.RO.WS, dbo.RO.Type, dbo.RO.Comment, dbo.Store_Setup.Code AS StoreID, 
                         dbo.Kitchens_Setup.Name AS KitchenName, dbo.Store_Setup.Name AS ResturantName
FROM            dbo.RO INNER JOIN
                         dbo.Kitchens_Setup ON dbo.RO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.RO.Resturant_ID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Store_Setup ON dbo.Kitchens_Setup.RestaurantID = dbo.Store_Setup.Code






GO
/****** Object:  View [dbo].[RecipesItemsView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RecipesItemsView]
AS
SELECT        dbo.Setup_RecipeItems.Name AS ItemName, dbo.Setup_Recipes.Code, dbo.Setup_Recipes.Name AS RecipeName, dbo.Setup_RecipeCategory.Name AS CatName, dbo.Setup_RecipeSubCategories.Name AS SubCatName, 
                         dbo.Setup_RecipeItems.Qty, dbo.Setup_RecipeItems.Recipe_Unit, dbo.Setup_RecipeItems.Cost, dbo.Setup_RecipeItems.Total_Cost, dbo.Setup_RecipeItems.Cost_Precentage, dbo.Setup_RecipeItems.Recipe_Code, 
                         dbo.Setup_Recipes.Category_ID, dbo.Setup_Recipes.SubCategory_ID
FROM            dbo.Setup_RecipeItems INNER JOIN
                         dbo.Setup_Recipes ON dbo.Setup_RecipeItems.Recipe_Code = dbo.Setup_Recipes.Code INNER JOIN
                         dbo.Setup_RecipeSubCategories ON dbo.Setup_Recipes.SubCategory_ID = dbo.Setup_RecipeSubCategories.Code INNER JOIN
                         dbo.Setup_RecipeCategory ON dbo.Setup_Recipes.Category_ID = dbo.Setup_RecipeCategory.Code






GO
/****** Object:  View [dbo].[TransferItemsIn]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransferItemsIn]
AS
SELECT        dbo.RO.Resturant_ID AS Restaurant_ID, dbo.RO.Kitchen_ID, Store_Setup_1.Name AS RestaurantName, Kitchens_Setup_1.Name AS KitchenName, dbo.RO_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, 
                         dbo.RO.RO_Serial, dbo.RO.RO_No, dbo.RO.Transactions_No, dbo.RO.Status, dbo.RO.Receiving_Date, dbo.RO.Create_Date, dbo.RO.Type, dbo.RO.Comment, dbo.RO.Post_Date, dbo.RO.UserID, dbo.RO.Last_Modified_Date, 
                         dbo.RO.Approval_Date, dbo.RO.WS, dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Serial, dbo.RO_Items.Price_Without_Tax, dbo.RO_Items.Tax, dbo.RO_Items.Price_With_Tax AS Cost, dbo.RO_Items.Net_Price, 
                         dbo.Setup_Items.Category
FROM            dbo.Store_Setup AS Store_Setup_1 INNER JOIN
                         dbo.Kitchens_Setup AS Kitchens_Setup_1 ON Store_Setup_1.Code = Kitchens_Setup_1.RestaurantID INNER JOIN
                         dbo.RO ON Kitchens_Setup_1.RestaurantID = dbo.RO.Resturant_ID AND Kitchens_Setup_1.Code = dbo.RO.Kitchen_ID INNER JOIN
                         dbo.Setup_Items INNER JOIN
                         dbo.RO_Items ON dbo.Setup_Items.Code = dbo.RO_Items.Item_ID ON dbo.RO.RO_Serial = dbo.RO_Items.RO_No

GO
/****** Object:  View [dbo].[TransferItemsOut]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransferItemsOut]
AS
SELECT        dbo.Requests_tbl.From_Resturant_ID AS Restaurant_ID, dbo.Requests_tbl.From_Kitchen_ID AS Kitchen_ID, dbo.Store_Setup.Name AS RestaurantName, dbo.Kitchens_Setup.Name AS KitchenName, 
                         dbo.Requests_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, dbo.Requests_tbl.Request_Serial, dbo.Requests_tbl.Manual_Request_No, dbo.Requests_tbl.Request_Date, dbo.Requests_tbl.Comment, 
                         dbo.Requests_tbl.To_Resturant_ID, dbo.Requests_tbl.To_Kitchen_ID, dbo.Requests_tbl.WS, dbo.Requests_tbl.Post, dbo.Requests_tbl.Hold, dbo.Requests_tbl.Post_Date, dbo.Requests_tbl.Hold_Date, dbo.Requests_tbl.Type, 
                         dbo.Requests_tbl.Modifiled_Date, dbo.Requests_tbl.UserID, dbo.Requests_Items.Qty, dbo.Requests_Items.Unit, dbo.Requests_Items.serial, dbo.Requests_Items.Cost, dbo.Requests_Items.Net_Cost, 
                         dbo.Setup_Items.Category
FROM            dbo.Setup_Items INNER JOIN
                         dbo.Store_Setup INNER JOIN
                         dbo.Kitchens_Setup ON dbo.Store_Setup.Code = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Requests_tbl INNER JOIN
                         dbo.Requests_Items ON dbo.Requests_tbl.Request_Serial = dbo.Requests_Items.Request_ID ON dbo.Kitchens_Setup.RestaurantID = dbo.Requests_tbl.From_Resturant_ID AND 
                         dbo.Kitchens_Setup.Code = dbo.Requests_tbl.From_Kitchen_ID ON dbo.Setup_Items.Code = dbo.Requests_Items.Item_ID

GO
/****** Object:  View [dbo].[VendorsView]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VendorsView]
AS
SELECT        dbo.PO.PO_No, dbo.PO.Vendor_ID, dbo.PO.PaymentTerm_ID, dbo.PO.Create_Date, dbo.PO.Post_Date, dbo.PO.Last_Modified_Date, dbo.PO.Approval_Date, dbo.PO.WS, dbo.PO.Comment, 
                         dbo.Store_Setup.Name AS RestaurantName, dbo.Kitchens_Setup.Name AS KitchenName, dbo.Vendors.Name AS VendorName, dbo.PO.Kitchen_ID, dbo.PO.Restaurant_ID, dbo.RO.Status, dbo.RO.Receiving_Date, 
                         dbo.PO.Total_Price, dbo.Vendors.Code AS V_ID
FROM            dbo.PO INNER JOIN
                         dbo.Kitchens_Setup ON dbo.PO.Kitchen_ID = dbo.Kitchens_Setup.Code AND dbo.PO.Restaurant_ID = dbo.Kitchens_Setup.RestaurantID INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID INNER JOIN
                         dbo.Store_Setup ON dbo.Kitchens_Setup.RestaurantID = dbo.Store_Setup.Code INNER JOIN
                         dbo.RO ON dbo.PO.PO_No = dbo.RO.Transactions_No





GO
/****** Object:  View [dbo].[View_Stores]    Script Date: 1/20/2020 11:37:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Stores]
AS
SELECT        dbo.Items.ItemID, dbo.Setup_Items.Name AS ItemName, dbo.Store_Setup.Name AS ResturantName, dbo.Items.RestaurantID AS Restaurant_ID, dbo.Items.KitchenID AS Kitchen_ID, 
                         dbo.Kitchens_Setup.Name AS KitchenName
FROM            dbo.Items INNER JOIN
                         dbo.Setup_Items ON dbo.Items.ItemID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Store_Setup ON dbo.Items.RestaurantID = dbo.Store_Setup.Code INNER JOIN
                         dbo.Kitchens_Setup ON dbo.Items.KitchenID = dbo.Kitchens_Setup.Code AND dbo.Items.RestaurantID = dbo.Kitchens_Setup.RestaurantID


Create PROCEDURE [dbo].[SPTransActions]
	@StartDate datetime, @EndDate datetime
AS
BEGIN
	Select * from (
SELECT Receiving_Date AS _DATE,Restaurant_ID,Kitchen_ID,KitchenName,'Receive' AS Trantype,RO_Serial as ID,Item_ID,Qty,Qty as AcQty
,Price_With_Tax as Cost,Price_With_Tax as CurrentCost
From ReceiveItemsView
where Type IN ('Auto_Recieve','Recieve_Purchase') 
Union ALL
SELECT Adjacment_Date ,Restaurant_ID,Kitchen_ID,KitchenName,'Adjactment', Adjacment_ID , Item_ID, AdjacmentableQty, AdjacmentableQty , Cost, Cost 
from BinAdjView
Union ALL
SELECT Receiving_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Transfer_In',Transactions_No, Item_ID,Qty,Qty,Cost,Cost
From TransferItemsIN
Union ALL
SELECT Request_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Transfer_Out',Request_Serial,Item_ID,-Qty,-Qty,Cost,Cost
From TransferItemsOut
Union ALL
SELECT Generate_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Generate',Generate_ID,  Item_ID,-ItemQty,-ItemQty,0,0
From GeneratedRecipesView
) as Balance
where _DATE between @StartDate and @EndDate
order by Item_ID,Restaurant_ID,Kitchen_ID,_DATE
END
