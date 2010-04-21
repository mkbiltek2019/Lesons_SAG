SELECT *
FROM AdventureWorksLT2008.SalesLT.Product,AdventureWorksLT2008.SalesLT.ProductCategory
WHERE ProductCategory.ProductCategoryID = Product.ProductCategoryID 
		AND ProductCategory.Name LIKE 'Wheels'
ORDER BY ListPrice ASC