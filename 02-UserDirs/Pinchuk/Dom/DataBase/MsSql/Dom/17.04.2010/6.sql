use AdventureWorksLT2008
SELECT SalesLT.Product.Name,SalesLT.Product.ListPrice,SalesLT.Product.StandardCost,  SalesLT.Product.StandardCost/SalesLT.Product.ListPrice*100  as "Процент націнки"
FROM SalesLT.Product, SalesLT.ProductCategory
WHERE SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID AND 
	SalesLT.Product.StandardCost/SalesLT.Product.ListPrice*100>150 AND
	SalesLT.Product.StandardCost/SalesLT.Product.ListPrice*100<200
ORDER BY SalesLT.ProductCategory.Name ASC