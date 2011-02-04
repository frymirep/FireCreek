CREATE VIEW [dbo].[DotNetConvertibleLocation]	AS 
	SELECT 
		Identifier, PhoneId, CAST(Location AS VARBINARY(MAX)) AS Location 
	FROM 
		Location with (nolock)