use AdventureWorksLT2008
go
select 
  SalesLT.Product.Name,
  SalesLT.Product.ProductNumber,
  SalesLT.Product.ListPrice,
  SalesLT.Product.StandardCost,
  ((SalesLT.Product.ListPrice/SalesLT.Product.StandardCost)*100) as "Percen"
from 	  
  SalesLT.Product  
where  
 (SalesLT.Product.ListPrice<>0) AND  
 (SalesLT.Product.StandardCost<>0) AND
 (
  (((SalesLT.Product.ListPrice/SalesLT.Product.StandardCost)*100) >=150)AND
  (((SalesLT.Product.ListPrice/SalesLT.Product.StandardCost)*100) <=200)
 )
order by 
   5;