use AdventureWorksLT2008
go
select 
  (2*manIncome.value+3*womanIncome.value) as "Income"
from 	  
  (select 
	 (SalesLT.Product.ListPrice - SalesLT.Product.StandardCost) as value
	from
	  SalesLT.ProductModel inner join
	  SalesLT.Product on 
	  SalesLT.Product.ProductModelID = SalesLT.ProductModel.ProductModelID
	where
	 (SalesLT.ProductModel.Name Like 'Women%s Mountain Shorts' AND
	  SalesLT.Product.Size Like 'M')
   ) as womanIncome,
   
   (select 
	 (SalesLT.Product.ListPrice - SalesLT.Product.StandardCost) as value
	from
	  SalesLT.ProductModel inner join
	  SalesLT.Product on 
	  SalesLT.Product.ProductModelID = SalesLT.ProductModel.ProductModelID
	where
	 SalesLT.ProductModel.Name Like 'Men%s Sports Shorts' AND
     SalesLT.Product.Size Like 'XL'
   ) as manIncome;