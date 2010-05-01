SELECT 
	[ID]
    ,[Name]
    ,
	Male =
	CASE [Sex]	
	    WHEN 'F' THEN 0
        WHEN 'M' THEN 1
        ELSE 'Not set'
    END, 
	Female =
	CASE [Sex]	
	    WHEN 'F' THEN 1
        WHEN 'M' THEN 0
        ELSE 'Not set'
    END
FROM [AdventureWorksLT].[dbo].[Employee]