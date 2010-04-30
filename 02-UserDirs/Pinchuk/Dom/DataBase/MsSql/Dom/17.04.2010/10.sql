USE AdventureWorksLT2008
SELECT 
 (SalesLT.Product.ListPrice - SalesLT.Product.StandardCost -SalesLT.SalesOrderDetail.UnitPriceDiscount) as Profit 
 FROM 
  SalesLT.SalesOrderDetail 
  INNER JOIN SalesLT.Product 
  ON SalesLT.SalesOrderDetail.ProductID = SalesLT.Product.ProductID 