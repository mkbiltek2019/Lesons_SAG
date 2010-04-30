--9. Список продуктів із всіх замовлень(SalesOrderDetail)
-- із колонкою сумарної ціни і сумарної ціни з урахуванням 
--знижки(SalesOrderDetail.UnitPriceDisount)

USE AdventureWorksLT2008
SELECT 
 SalesLT.Product.Name,
 SUM(SalesLT.SalesOrderDetail.UnitPrice) as sumUnitPrice, 
 SUM(SalesLT.SalesOrderDetail.UnitPrice - SalesLT.SalesOrderDetail.UnitPriceDiscount ) as sumUnitPriceDiscount
FROM 
 SalesLT.SalesOrderDetail 
  INNER JOIN SalesLT.Product 
   ON SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID
GROUP BY SalesLT.Product.Name