USE AdventureWorksLT2008
SELECT  MIN(summ.SUMA) AS SummaQty ,
        SalesLT.Customer.FirstName
FROM    ( SELECT    SUM(SalesLT.SalesOrderDetail.OrderQty) AS SUMA ,
                    SalesLT.SalesOrderHeader.CustomerID
          FROM      SalesLT.SalesOrderDetail ,
                    SalesLT.SalesOrderHeader
          WHERE     SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
          GROUP BY  SalesLT.SalesOrderHeader.CustomerID
        ) AS [summ] ,
        SalesLT.Customer
WHERE   SalesLT.Customer.CustomerID = summ.CustomerID
GROUP BY SalesLT.Customer.FirstName ,
        summ.SUMA
HAVING  Min(summ.SUMA)<=ALL ( SELECT    SUM(SalesLT.SalesOrderDetail.OrderQty) AS SUMA
                              FROM      SalesLT.SalesOrderDetail ,
                                        SalesLT.SalesOrderHeader
                              WHERE     SalesLT.SalesOrderDetail.SalesOrderID = SalesLT.SalesOrderHeader.SalesOrderID
                              GROUP BY  SalesLT.SalesOrderHeader.CustomerID )
ORDER BY SummaQty ASC
