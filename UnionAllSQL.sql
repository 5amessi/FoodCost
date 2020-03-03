Select * from (
SELECT Receiving_Date AS _DATE,Restaurant_ID,Kitchen_ID,KitchenName,'Receive' AS Trantype,RO_Serial as ID,Item_ID,Qty,Qty as Current_Qty
,Price_With_Tax as Cost,Price_With_Tax as CurrentCost
From ReceivePIView
Union ALL
SELECT Adjacment_Date ,Restaurant_ID,Kitchen_ID,KitchenName,'Adjactment', Adjacment_ID , Item_ID, Variance, AdjacmentableQty , Cost, Cost 
from BinAdjView
Union ALL
SELECT Receiving_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Transfer_In',Transactions_No, Item_ID,Qty,Qty,Price_With_Tax,Net_Price
From ReceiveTransferItems
Union ALL
SELECT Request_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Transfer_Out',Request_Serial,Item_ID,-Qty,-Qty,Cost,Cost
From TransferItemsOut
Union ALL
SELECT Generate_Date,Restaurant_ID,Kitchen_ID,KitchenName,'Generate',Generate_ID,  Item_ID,-ItemQty,-ItemQty,0,0
From GeneratedRecipesView
) as Balance
order by Item_ID,Restaurant_ID,Kitchen_ID,_DATE