SELECT t1.[CustomerID]
      ,t1.[TerritoryID]
      ,t1.[AccountNumber]
      ,t1.[CustomerType]
      ,t1.[rowguid]
      ,t1.[ModifiedDate]
  FROM [AdventureWorks].[Sales].[Customer] t1 INNER JOIN [AdventureWorks].[Sales].[CustomerAddress]	t2
		ON t1.[CustomerID] = t2.[CustomerID]
		INNER JOIN [AdventureWorks].[Person].[Address] t3
		ON t2.[AddressID] = t3.[AddressID]
		INNER JOIN [AdventureWorks].[Person].[StateProvince] t4
		ON t4.[StateProvinceID] = t3.[StateProvinceID]
  WHERE t4.[Name] = 'Washington'
	 
		
