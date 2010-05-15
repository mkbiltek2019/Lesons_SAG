SELECT t1.[CustomerID]
      ,t1.[TerritoryID]
      ,t1.[AccountNumber]
      ,t1.[CustomerType]
      ,t1.[rowguid]
      ,t1.[ModifiedDate]
  FROM [AdventureWorks].[Sales].[Customer] t1 INNER JOIN [AdventureWorks].[Sales].[CustomerAddress] t2
		ON t1.[CustomerID]= t2.[CustomerID]
		INNER JOIN [AdventureWorks].[Person].[Address] t3
		ON t3.[AddressID] = t2.[AddressID]
	WHERE t3.[AddressLine2] is NULL