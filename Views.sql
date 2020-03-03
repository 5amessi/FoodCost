USE [FoodCost]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActionsView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActionsView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActions'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActions'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferItems'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferItems'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'

GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'

GO
/****** Object:  View [dbo].[VendorsView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[VendorsView]
GO
/****** Object:  View [dbo].[TransferOrdersOut]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[TransferOrdersOut]
GO
/****** Object:  View [dbo].[RequestTransferView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[RequestTransferView]
GO
/****** Object:  View [dbo].[RequestTransferItemsView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[RequestTransferItemsView]
GO
/****** Object:  View [dbo].[RecipesItemsView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[RecipesItemsView]
GO
/****** Object:  View [dbo].[POView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[POView]
GO
/****** Object:  View [dbo].[POItems]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[POItems]
GO
/****** Object:  View [dbo].[InventoryStats]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[InventoryStats]
GO
/****** Object:  View [dbo].[BinCard]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[BinCard]
GO
/****** Object:  View [dbo].[BeginningEndingMonthView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[BeginningEndingMonthView]
GO
/****** Object:  View [dbo].[TransActions]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[TransActions]
GO
/****** Object:  View [dbo].[TransActionsView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[TransActionsView]
GO
/****** Object:  View [dbo].[TransferItemsOut]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[TransferItemsOut]
GO
/****** Object:  View [dbo].[GeneratedRecipesView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[GeneratedRecipesView]
GO
/****** Object:  View [dbo].[BinAdjView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[BinAdjView]
GO
/****** Object:  View [dbo].[ReceivePIView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[ReceivePIView]
GO
/****** Object:  View [dbo].[ReceivePoView]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[ReceivePoView]
GO
/****** Object:  View [dbo].[ReceiveTransferItems]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[ReceiveTransferItems]
GO
/****** Object:  View [dbo].[ReceiveTransferOrders]    Script Date: 3/3/2020 1:02:41 PM ******/
DROP VIEW [dbo].[ReceiveTransferOrders]
GO
/****** Object:  View [dbo].[ReceiveTransferOrders]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceiveTransferOrders]
AS
SELECT        dbo.RO.Resturant_ID AS Restaurant_ID, dbo.RO.Kitchen_ID, Setup_Restaurant_1.Name AS RestaurantName, Setup_Kitchens_1.Name AS KitchenName, dbo.RO.RO_Serial, dbo.RO.RO_No, dbo.RO.Transactions_No, 
                         dbo.RO.Status, dbo.RO.Receiving_Date, dbo.RO.Create_Date, dbo.RO.Type, dbo.RO.Comment, dbo.RO.Post_Date, dbo.RO.UserID, dbo.RO.Last_Modified_Date, dbo.RO.Approval_Date, dbo.RO.WS, dbo.RO.Total_Cost, 
                         dbo.Transfer_Kitchens.Manual_Transfer_No, dbo.Setup_Kitchens.Name AS FromKitchen, dbo.Setup_Restaurant.Name AS FromRestaurant
FROM            dbo.Setup_Restaurant AS Setup_Restaurant_1 INNER JOIN
                         dbo.Setup_Kitchens AS Setup_Kitchens_1 ON Setup_Restaurant_1.Code = Setup_Kitchens_1.RestaurantID INNER JOIN
                         dbo.RO ON Setup_Kitchens_1.RestaurantID = dbo.RO.Resturant_ID AND Setup_Kitchens_1.Code = dbo.RO.Kitchen_ID INNER JOIN
                         dbo.Transfer_Kitchens ON dbo.RO.Transactions_No = dbo.Transfer_Kitchens.Transfer_Serial INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Transfer_Kitchens.From_Resturant_ID = dbo.Setup_Kitchens.RestaurantID AND dbo.Transfer_Kitchens.From_Kitchen_ID = dbo.Setup_Kitchens.Code INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code
WHERE        (dbo.RO.Type = 'Transfer_Resturant') OR
                         (dbo.RO.Type = 'Transfer_Kitchen')

GO
/****** Object:  View [dbo].[ReceiveTransferItems]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceiveTransferItems]
AS
SELECT        dbo.ReceiveTransferOrders.Restaurant_ID, dbo.ReceiveTransferOrders.Kitchen_ID, dbo.ReceiveTransferOrders.RestaurantName, dbo.ReceiveTransferOrders.KitchenName, dbo.ReceiveTransferOrders.RO_Serial, 
                         dbo.ReceiveTransferOrders.RO_No, dbo.ReceiveTransferOrders.Transactions_No, dbo.ReceiveTransferOrders.Status, dbo.ReceiveTransferOrders.Receiving_Date, dbo.ReceiveTransferOrders.Create_Date, 
                         dbo.ReceiveTransferOrders.Type, dbo.ReceiveTransferOrders.Comment, dbo.ReceiveTransferOrders.Post_Date, dbo.ReceiveTransferOrders.UserID, dbo.ReceiveTransferOrders.Last_Modified_Date, 
                         dbo.ReceiveTransferOrders.Approval_Date, dbo.ReceiveTransferOrders.WS, dbo.Setup_Items.Name AS ItemName, dbo.RO_Items.Item_ID, dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Price_Without_Tax, 
                         dbo.RO_Items.Tax, dbo.RO_Items.Price_With_Tax, dbo.RO_Items.Net_Price, dbo.RO_Items.QtyOnHand_To, dbo.RO_Items.Cost_To, dbo.RO_Items.QtyOnHand_From, dbo.RO_Items.Cost_From, dbo.Setup_Items.Category, 
                         dbo.ReceiveTransferOrders.Total_Cost, dbo.ReceiveTransferOrders.Manual_Transfer_No, dbo.ReceiveTransferOrders.FromKitchen, dbo.ReceiveTransferOrders.FromRestaurant
FROM            dbo.Setup_Items INNER JOIN
                         dbo.RO_Items ON dbo.Setup_Items.Code = dbo.RO_Items.Item_ID INNER JOIN
                         dbo.ReceiveTransferOrders ON dbo.RO_Items.RO_No = dbo.ReceiveTransferOrders.RO_Serial

GO
/****** Object:  View [dbo].[ReceivePoView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceivePoView]
AS
SELECT        dbo.RO.RO_Serial, dbo.RO.Transactions_No, dbo.RO.Status, dbo.RO.Receiving_Date, dbo.RO.Resturant_ID AS Restaurant_ID, dbo.RO.Kitchen_ID, dbo.RO.WS, dbo.RO.Type, dbo.RO.Comment, 
                         dbo.Setup_Restaurant.Code AS StoreID, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.RO.Create_Date, dbo.RO.Post_Date, dbo.RO.Last_Modified_Date, 
                         dbo.RO.Approval_Date, dbo.RO.Total_Cost, dbo.RO.RO_No, dbo.RO.UserID, dbo.PO.PO_No, dbo.PO.Vendor_ID, dbo.Vendors.Name AS VendorName
FROM            dbo.RO INNER JOIN
                         dbo.Setup_Kitchens ON dbo.RO.Kitchen_ID = dbo.Setup_Kitchens.Code AND dbo.RO.Resturant_ID = dbo.Setup_Kitchens.RestaurantID INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code INNER JOIN
                         dbo.PO ON dbo.RO.Transactions_No = dbo.PO.PO_Serial INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID
WHERE        (dbo.RO.Type = 'Recieve_Purchase') OR
                         (dbo.RO.Type = 'Auto_Receive')

GO
/****** Object:  View [dbo].[ReceivePIView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReceivePIView]
AS
SELECT        dbo.RO_Items.Item_ID, dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Serial, dbo.RO_Items.Net_Price, dbo.Setup_Items.Name AS ItemName, dbo.RO_Items.Price_Without_Tax, dbo.RO_Items.Tax, 
                         dbo.RO_Items.Price_With_Tax, dbo.RO_Items.QtyOnHand_From, dbo.RO_Items.Cost_From, dbo.Setup_Items.Category, dbo.RO_Items.QtyOnHand_To, dbo.RO_Items.Cost_To, dbo.ReceivePoView.RO_Serial, 
                         dbo.ReceivePoView.Transactions_No, dbo.ReceivePoView.Status, dbo.ReceivePoView.Receiving_Date, dbo.ReceivePoView.Restaurant_ID, dbo.ReceivePoView.Kitchen_ID, dbo.ReceivePoView.WS, dbo.ReceivePoView.Type, 
                         dbo.ReceivePoView.Comment, dbo.ReceivePoView.StoreID, dbo.ReceivePoView.KitchenName, dbo.ReceivePoView.Create_Date, dbo.ReceivePoView.Post_Date, dbo.ReceivePoView.Last_Modified_Date, 
                         dbo.ReceivePoView.Approval_Date, dbo.ReceivePoView.Total_Cost, dbo.ReceivePoView.RO_No, dbo.ReceivePoView.UserID, dbo.ReceivePoView.PO_No, dbo.ReceivePoView.Vendor_ID, dbo.ReceivePoView.VendorName, 
                         dbo.ReceivePoView.RestaurantName
FROM            dbo.ReceivePoView INNER JOIN
                         dbo.RO_Items INNER JOIN
                         dbo.Setup_Items ON dbo.RO_Items.Item_ID = dbo.Setup_Items.Code ON dbo.ReceivePoView.RO_Serial = dbo.RO_Items.RO_No

GO
/****** Object:  View [dbo].[BinAdjView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BinAdjView]
AS
SELECT        dbo.Adjacment_Items.AdjacmentableQty, dbo.Adjacment_Items.Variance, dbo.Adjacment_tbl.Adjacment_Date, dbo.Adjacment_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, dbo.Adjacment_tbl.KitchenID AS Kitchen_ID, 
                         dbo.Adjacment_tbl.Resturant_ID AS Restaurant_ID, dbo.Adjacment_Items.Qty, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Adjacment_Items.Cost, dbo.Setup_Items.Unit, 
                         dbo.Adjacment_Items.Adjacment_ID, dbo.Setup_Items.Category
FROM            dbo.Adjacment_Items INNER JOIN
                         dbo.Adjacment_tbl ON dbo.Adjacment_Items.Adjacment_ID = dbo.Adjacment_tbl.Adjacment_ID INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Adjacment_tbl.Resturant_ID = dbo.Setup_Restaurant.Code INNER JOIN
                         dbo.Setup_Items ON dbo.Adjacment_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Adjacment_tbl.KitchenID = dbo.Setup_Kitchens.Code AND dbo.Adjacment_tbl.Resturant_ID = dbo.Setup_Kitchens.RestaurantID
GO
/****** Object:  View [dbo].[GeneratedRecipesView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GeneratedRecipesView]
AS
SELECT        dbo.GenerateRecipe_Items.Generate_ID, dbo.GenerateRecipe_tbl.Generate_Date, dbo.GenerateRecipe_tbl.Resturant_ID AS Restaurant_ID, dbo.GenerateRecipe_tbl.Kitchen_ID, dbo.GenerateRecipe_Items.Item_ID, 
                         dbo.GenerateRecipe_Items.ItemQty, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.GenerateRecipe_tbl.Qty, dbo.Setup_Items.Name AS ItemName, 
                         dbo.GenerateRecipe_tbl.Recipe_ID, dbo.Setup_Items.Category, dbo.GenerateRecipe_Items.Cost, dbo.GenerateRecipe_Items.Net_Cost, dbo.Setup_Recipes.Name AS RecipeName, dbo.Setup_Recipes.Unit AS RecipesUnit, 
                         dbo.Setup_Items.Unit AS ItemUnit, '' AS PrevQty, '' AS CurrQty
FROM            dbo.GenerateRecipe_Items INNER JOIN
                         dbo.GenerateRecipe_tbl ON dbo.GenerateRecipe_Items.Generate_ID = dbo.GenerateRecipe_tbl.Generate_ID INNER JOIN
                         dbo.Setup_Kitchens ON dbo.GenerateRecipe_tbl.Resturant_ID = dbo.Setup_Kitchens.RestaurantID AND dbo.GenerateRecipe_tbl.Kitchen_ID = dbo.Setup_Kitchens.Code INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code INNER JOIN
                         dbo.Setup_Items ON dbo.GenerateRecipe_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Setup_Recipes ON dbo.GenerateRecipe_tbl.Recipe_ID = dbo.Setup_Recipes.Code
WHERE        (dbo.GenerateRecipe_Items.Item_ID IS NOT NULL)

GO
/****** Object:  View [dbo].[TransferItemsOut]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransferItemsOut]
AS
SELECT        dbo.Requests_tbl.From_Resturant_ID AS Restaurant_ID, dbo.Requests_tbl.From_Kitchen_ID AS Kitchen_ID, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.Setup_Kitchens.Name AS KitchenName, 
                         dbo.Requests_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, dbo.Requests_tbl.Request_Serial, dbo.Requests_tbl.Manual_Request_No, dbo.Requests_tbl.Request_Date, dbo.Requests_tbl.Comment, 
                         dbo.Requests_tbl.To_Resturant_ID, dbo.Requests_tbl.To_Kitchen_ID, dbo.Requests_tbl.WS, dbo.Requests_tbl.Post, dbo.Requests_tbl.Hold, dbo.Requests_tbl.Post_Date, dbo.Requests_tbl.Hold_Date, dbo.Requests_tbl.Type, 
                         dbo.Requests_tbl.Modifiled_Date, dbo.Requests_tbl.UserID, dbo.Requests_Items.Qty, dbo.Requests_Items.Unit, dbo.Requests_Items.serial, dbo.Requests_Items.Cost, dbo.Requests_Items.Net_Cost, 
                         dbo.Setup_Items.Category, dbo.Requests_tbl.Total_Cost, dbo.Requests_Items.QtyOnHand_To, dbo.Requests_Items.Cost_To, dbo.Requests_Items.QtyOnHand_From, dbo.Requests_Items.Cost_From
FROM            dbo.Setup_Items INNER JOIN
                         dbo.Setup_Restaurant INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Setup_Restaurant.Code = dbo.Setup_Kitchens.RestaurantID INNER JOIN
                         dbo.Requests_tbl INNER JOIN
                         dbo.Requests_Items ON dbo.Requests_tbl.Request_Serial = dbo.Requests_Items.Request_ID ON dbo.Setup_Kitchens.RestaurantID = dbo.Requests_tbl.From_Resturant_ID AND 
                         dbo.Setup_Kitchens.Code = dbo.Requests_tbl.From_Kitchen_ID ON dbo.Setup_Items.Code = dbo.Requests_Items.Item_ID

GO
/****** Object:  View [dbo].[TransActionsView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransActionsView]
AS
SELECT        TOP (100) PERCENT Balance._DATE, Balance.Restaurant_ID, Balance.Kitchen_ID, Balance.RestaurantName, Balance.KitchenName, Balance.Trantype, Balance.ID, Balance.Item_ID, Balance.ItemName, Balance.Qty, 
                         Balance.Current_Qty, Balance.Cost, Balance.CurrentCost, dbo.Setup_Items.Unit, dbo.Setup_Items.Unit2
FROM            (SELECT        Receiving_Date AS _DATE, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Receive' AS Trantype, RO_Serial AS ID, Item_ID, ItemName, Qty, QtyOnHand_To AS Current_Qty, Price_With_Tax AS Cost, 
                                                    Cost_To AS CurrentCost
                          FROM            dbo.ReceivePIView
                          UNION ALL
                          SELECT        Adjacment_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Adjactment' AS Expr1, Adjacment_ID, Item_ID, ItemName, Variance, AdjacmentableQty, Cost, Cost AS Expr2
                          FROM            dbo.BinAdjView
                          UNION ALL
                          SELECT        Receiving_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Transfer_In' AS Expr1, Transactions_No, Item_ID, ItemName, Qty, QtyOnHand_To, Price_With_Tax, Cost_To
                          FROM            dbo.ReceiveTransferItems
                          UNION ALL
                          SELECT        Request_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Transfer_Out' AS Expr1, Request_Serial, Item_ID, ItemName, - Qty AS Expr2, - QtyOnHand_From AS Expr3, Cost, Cost_From
                          FROM            dbo.TransferItemsOut
                          UNION ALL
                          SELECT        Generate_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Generate' AS Expr1, Generate_ID, Item_ID, ItemName, - ItemQty AS Expr2, - ItemQty AS Expr3, Cost, Cost AS Expr4
                          FROM            dbo.GeneratedRecipesView) AS Balance INNER JOIN
                         dbo.Setup_Items ON Balance.Item_ID = dbo.Setup_Items.Code
ORDER BY Balance._DATE

GO
/****** Object:  View [dbo].[TransActions]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransActions]
AS
SELECT        TOP (100) PERCENT _DATE, Restaurant_ID, Kitchen_ID, ResturantName, KitchenName, Trantype, ID, Item_ID, Qty, Current_Qty, Cost, CurrentCost
FROM            (SELECT        Receiving_Date AS _DATE, Restaurant_ID, Kitchen_ID, ResturantName, KitchenName, 'Receive' AS Trantype, RO_Serial AS ID, Item_ID, Qty, QtyOnHand_To AS Current_Qty, Price_With_Tax AS Cost, 
                                                    Cost_To AS CurrentCost
                          FROM            dbo.ReceivePIView
                          UNION ALL
                          SELECT        Adjacment_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Adjactment' AS Expr1, Adjacment_ID, Item_ID, Variance, AdjacmentableQty, Cost, Cost AS Expr2
                          FROM            dbo.BinAdjView
                          UNION ALL
                          SELECT        Receiving_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Transfer_In' AS Expr1, Transactions_No, Item_ID, Qty, QtyOnHand_To, Price_With_Tax, Cost_To
                          FROM            dbo.ReceiveTransferItems
                          UNION ALL
                          SELECT        Request_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Transfer_Out' AS Expr1, Request_Serial, Item_ID, - Qty AS Expr2, - QtyOnHand_From AS Expr3, Cost, Cost_From
                          FROM            dbo.TransferItemsOut
                          UNION ALL
                          SELECT        Generate_Date, Restaurant_ID, Kitchen_ID, RestaurantName, KitchenName, 'Generate' AS Expr1, Generate_ID, Item_ID, - ItemQty AS Expr2, - ItemQty AS Expr3, Cost, Cost AS Expr4
                          FROM            dbo.GeneratedRecipesView) AS Balance
ORDER BY _DATE

GO
/****** Object:  View [dbo].[BeginningEndingMonthView]    Script Date: 3/3/2020 1:02:41 PM ******/
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
/****** Object:  View [dbo].[BinCard]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BinCard]
AS
SELECT        dbo.RO_Items.Item_ID, dbo.RO_Items.Qty, dbo.RO_Items.Unit, dbo.RO_Items.Serial, dbo.RO_Items.Net_Price, dbo.RO.Receiving_Date AS Date, dbo.RO.Type, dbo.RO_Items.RO_No, dbo.RO.Kitchen_ID, 
                         dbo.Setup_Kitchens.Name AS KitchenName, dbo.Setup_Kitchens.Code, '' AS TransDetails, '' AS ItemName, dbo.RO_Items.Price_Without_Tax, dbo.RO_Items.Tax, dbo.RO_Items.Price_With_Tax, dbo.RO.Resturant_ID, 
                         '' AS RestaurantName, 0.0 AS Cost, '' AS [Net Cost], 0.0 AS OnHand, 0.0 AS Min, 0.0 AS Max, '' AS BCost, '' AS ECost, '' AS BQty, '' AS EQty, '' AS Current_Qty, '' AS CurrentCost, '' AS Trantype, '' AS _Date
FROM            dbo.RO INNER JOIN
                         dbo.RO_Items ON dbo.RO.RO_Serial = dbo.RO_Items.RO_No INNER JOIN
                         dbo.Setup_Kitchens ON dbo.RO.Kitchen_ID = dbo.Setup_Kitchens.Code AND dbo.RO.RO_Serial = dbo.Setup_Kitchens.Name2 INNER JOIN
                         dbo.Setup_Items ON dbo.RO_Items.Item_ID = dbo.Setup_Items.Code

GO
/****** Object:  View [dbo].[InventoryStats]    Script Date: 3/3/2020 1:02:41 PM ******/
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
/****** Object:  View [dbo].[POItems]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[POItems]
AS
SELECT        dbo.PO.PO_No, dbo.PO_Items.Item_ID, dbo.PO.Vendor_ID, dbo.PO.PaymentTerm_ID, dbo.PO.Create_Date, dbo.PO.Delivery_Date, dbo.PO.Post_Date, dbo.PO.Last_Modified_Date, dbo.PO.Approval_Date, dbo.PO.WS, 
                         dbo.PO.Comment, dbo.PO_Items.Qty, dbo.PO_Items.Unit, dbo.PO_Items.Serial, dbo.PO_Items.Net_Price, dbo.Setup_Items.Name AS ItemName, dbo.Setup_Restaurant.Name AS RestaurantName, 
                         dbo.Setup_Kitchens.Name AS KitchenName, dbo.Vendors.Name AS VendorName, dbo.PO.Kitchen_ID, dbo.PO.Restaurant_ID, dbo.PO_Items.PO_Serial, dbo.PO_Items.Price_Without_Tax, dbo.PO_Items.Tax, 
                         dbo.PO_Items.Price_With_Tax, dbo.PO_Items.Tax_Included
FROM            dbo.PO INNER JOIN
                         dbo.PO_Items ON dbo.PO.PO_Serial = dbo.PO_Items.PO_Serial INNER JOIN
                         dbo.Setup_Items ON dbo.PO_Items.Item_ID = dbo.Setup_Items.Code INNER JOIN
                         dbo.Setup_Kitchens ON dbo.PO.Kitchen_ID = dbo.Setup_Kitchens.Code AND dbo.PO.Restaurant_ID = dbo.Setup_Kitchens.RestaurantID INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code
						 







GO
/****** Object:  View [dbo].[POView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[POView]
AS
SELECT        dbo.PO.PO_No, dbo.PO.PaymentTerm_ID, dbo.PO.Create_Date, dbo.PO.Delivery_Date, dbo.PO.Post_Date, dbo.PO.Last_Modified_Date, dbo.PO.Approval_Date, dbo.PO.WS, dbo.PO.Comment, 
                         dbo.Setup_Restaurant.Code AS StoreID, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Vendors.Name AS VendorName, dbo.Setup_Restaurant.Name AS ResturantName, dbo.PO.Restaurant_ID, dbo.PO.Kitchen_ID, 
                         dbo.PO.Ship_To, dbo.PO.Vendor_ID, dbo.PO.Total_Price, dbo.PO.PO_Serial
FROM            dbo.PO INNER JOIN
                         dbo.Vendors ON dbo.PO.Vendor_ID = dbo.Vendors.VendorID INNER JOIN
                         dbo.Setup_Kitchens ON dbo.PO.Kitchen_ID = dbo.Setup_Kitchens.Code AND dbo.PO.Restaurant_ID = dbo.Setup_Kitchens.RestaurantID INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code

GO
/****** Object:  View [dbo].[RecipesItemsView]    Script Date: 3/3/2020 1:02:41 PM ******/
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
/****** Object:  View [dbo].[RequestTransferItemsView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RequestTransferItemsView]
AS
SELECT        dbo.Setup_Kitchens.RestaurantID AS Restaurant_ID, dbo.Setup_Kitchens.Code AS Kitchen_ID, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Transfer_Kitchens.Transfer_Serial, 
                         dbo.Transfer_Kitchens.Manual_Transfer_No, dbo.Transfer_Kitchens.Transfer_Date, dbo.Transfer_Kitchens.Comment, dbo.Transfer_Kitchens.WS, dbo.Transfer_Kitchens.Post, dbo.Transfer_Kitchens.Hold, 
                         dbo.Transfer_Kitchens.Post_Date, dbo.Transfer_Kitchens.Hold_Date, dbo.Transfer_Kitchens.Type, dbo.Transfer_Kitchens.Modifiled_Date, dbo.Transfer_Kitchens.UserID, dbo.Transfer_Kitchens.Status, 
                         dbo.Transfer_Kitchens.Create_Date, dbo.Transfer_Kitchens_Items.Item_ID, dbo.Setup_Items.Name AS ItemName, dbo.Setup_Items.Category, dbo.Transfer_Kitchens_Items.Qty, dbo.Transfer_Kitchens_Items.Unit, 
                         dbo.Transfer_Kitchens_Items.Cost, dbo.Transfer_Kitchens_Items.Net_Cost
FROM            dbo.Transfer_Kitchens INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Transfer_Kitchens.To_Resturant_ID = dbo.Setup_Kitchens.RestaurantID AND dbo.Transfer_Kitchens.To_Kitchen_ID = dbo.Setup_Kitchens.Code INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code INNER JOIN
                         dbo.Transfer_Kitchens_Items ON dbo.Transfer_Kitchens.Transfer_Serial = dbo.Transfer_Kitchens_Items.Transfer_ID INNER JOIN
                         dbo.Setup_Items ON dbo.Transfer_Kitchens_Items.Item_ID = dbo.Setup_Items.Code
GO
/****** Object:  View [dbo].[RequestTransferView]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RequestTransferView]
AS
SELECT        dbo.Setup_Kitchens.RestaurantID AS Restaurant_ID, dbo.Setup_Kitchens.Code AS Kitchen_ID, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.Setup_Kitchens.Name AS KitchenName, dbo.Transfer_Kitchens.Transfer_Serial, 
                         dbo.Transfer_Kitchens.Manual_Transfer_No, dbo.Transfer_Kitchens.Transfer_Date, dbo.Transfer_Kitchens.Comment, dbo.Transfer_Kitchens.WS, dbo.Transfer_Kitchens.Post, dbo.Transfer_Kitchens.Hold, 
                         dbo.Transfer_Kitchens.Post_Date, dbo.Transfer_Kitchens.Hold_Date, dbo.Transfer_Kitchens.Type, dbo.Transfer_Kitchens.Modifiled_Date, dbo.Transfer_Kitchens.UserID, dbo.Transfer_Kitchens.Status, 
                         dbo.Transfer_Kitchens.Create_Date
FROM            dbo.Transfer_Kitchens INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Transfer_Kitchens.To_Resturant_ID = dbo.Setup_Kitchens.RestaurantID AND dbo.Transfer_Kitchens.To_Kitchen_ID = dbo.Setup_Kitchens.Code INNER JOIN
                         dbo.Setup_Restaurant ON dbo.Setup_Kitchens.RestaurantID = dbo.Setup_Restaurant.Code
GO
/****** Object:  View [dbo].[TransferOrdersOut]    Script Date: 3/3/2020 1:02:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TransferOrdersOut]
AS
SELECT        dbo.Requests_tbl.From_Resturant_ID AS Restaurant_ID, dbo.Requests_tbl.From_Kitchen_ID AS Kitchen_ID, dbo.Setup_Restaurant.Name AS RestaurantName, dbo.Setup_Kitchens.Name AS KitchenName, 
                         dbo.Requests_tbl.Request_Serial, dbo.Requests_tbl.Manual_Request_No, dbo.Requests_tbl.Request_Date, dbo.Requests_tbl.Comment, dbo.Requests_tbl.To_Resturant_ID, dbo.Requests_tbl.To_Kitchen_ID, 
                         dbo.Requests_tbl.WS, dbo.Requests_tbl.Post, dbo.Requests_tbl.Hold, dbo.Requests_tbl.Post_Date, dbo.Requests_tbl.Hold_Date, dbo.Requests_tbl.Type, dbo.Requests_tbl.Modifiled_Date, dbo.Requests_tbl.UserID, 
                         dbo.Requests_tbl.Total_Cost
FROM            dbo.Setup_Restaurant INNER JOIN
                         dbo.Setup_Kitchens ON dbo.Setup_Restaurant.Code = dbo.Setup_Kitchens.RestaurantID INNER JOIN
                         dbo.Requests_tbl ON dbo.Setup_Kitchens.RestaurantID = dbo.Requests_tbl.From_Resturant_ID AND dbo.Setup_Kitchens.Code = dbo.Requests_tbl.From_Kitchen_ID

GO
/****** Object:  View [dbo].[VendorsView]    Script Date: 3/3/2020 1:02:41 PM ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RO_Items"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 6
               Left = 492
               Bottom = 136
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 30
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'BinCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[14] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GenerateRecipe_Items"
            Begin Extent = 
               Top = 27
               Left = 1022
               Bottom = 257
               Right = 1192
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GenerateRecipe_tbl"
            Begin Extent = 
               Top = 17
               Left = 630
               Bottom = 251
               Right = 800
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 138
               Left = 268
               Bottom = 268
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 218
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Recipes"
            Begin Extent = 
               Top = 270
               Left = 256
               Bottom = 400
               Right = 429
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'84
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GeneratedRecipesView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PO"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Vendors"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 136
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 138
               Left = 268
               Bottom = 268
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2550
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'POView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[49] 4[12] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RO_Items"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 292
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 6
               Left = 492
               Bottom = 136
               Right = 672
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReceivePoView"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 384
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 39
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2400
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePIView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[53] 4[9] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RO"
            Begin Extent = 
               Top = 7
               Left = 545
               Bottom = 359
               Right = 737
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 29
               Left = 290
               Bottom = 288
               Right = 482
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 47
               Left = 33
               Bottom = 298
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PO"
            Begin Extent = 
               Top = 2
               Left = 801
               Bottom = 400
               Right = 993
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Vendors"
            Begin Extent = 
               Top = 6
               Left = 1031
               Bottom = 136
               Right = 1201
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceivePoView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[48] 4[13] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 6
               Left = 492
               Bottom = 297
               Right = 672
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RO_Items"
            Begin Extent = 
               Top = 9
               Left = 271
               Bottom = 315
               Right = 457
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "ReceiveTransferOrders"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 364
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 19
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[54] 4[7] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Setup_Restaurant_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens_1"
            Begin Extent = 
               Top = 167
               Left = 40
               Bottom = 297
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RO"
            Begin Extent = 
               Top = 12
               Left = 296
               Bottom = 325
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Transfer_Kitchens"
            Begin Extent = 
               Top = 12
               Left = 549
               Bottom = 386
               Right = 746
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 147
               Left = 1022
               Bottom = 380
               Right = 1214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 26
               Left = 783
               Bottom = 319
               Right = 975
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 20
         Width = 284
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReceiveTransferOrders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[4] 2[31] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Balance"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActions'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[43] 4[9] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Balance"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 305
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 0
               Left = 329
               Bottom = 292
               Right = 509
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActionsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransActionsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[50] 4[11] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Setup_Items"
            Begin Extent = 
               Top = 24
               Left = 1003
               Bottom = 388
               Right = 1183
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 42
               Left = 25
               Bottom = 172
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 176
               Left = 175
               Bottom = 306
               Right = 367
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Requests_tbl"
            Begin Extent = 
               Top = 5
               Left = 487
               Bottom = 387
               Right = 684
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Requests_Items"
            Begin Extent = 
               Top = 29
               Left = 742
               Bottom = 287
               Right = 928
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferItemsOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Setup_Restaurant"
            Begin Extent = 
               Top = 6
               Left = 256
               Bottom = 161
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Setup_Kitchens"
            Begin Extent = 
               Top = 6
               Left = 486
               Bottom = 136
               Right = 678
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Requests_tbl"
            Begin Extent = 
               Top = 6
               Left = 716
               Bottom = 313
               Right = 913
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 32
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TransferOrdersOut'
GO
