USE AdventureWorksLT2008
SELECT SalesLT.Product.*
FROM  SalesLT.Product, SalesLT.ProductCategory
WHERE SalesLT.Product.ProductCategoryID = SalesLT.ProductCategory.ProductCategoryID AND
	 SalesLT.ProductCategory.Name = 'Wheels'
ORDER BY StandardCost ASC