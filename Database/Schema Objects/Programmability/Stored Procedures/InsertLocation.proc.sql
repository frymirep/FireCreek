CREATE PROCEDURE [dbo].[InsertLocation]
	@phoneId   nvarchar(20), 
	@longitude float,
	@latitude  float
AS

declare @point geography 
set @point = geography::STPointFromText('POINT(' + CAST(@longitude AS VARCHAR(20)) + ' ' + CAST(@latitude AS VARCHAR(20)) + ')', 4326)

declare @temp table(identifier bigint)

insert into	
	Location 
output 
	inserted.identifier 
into 
	@temp
values(@phoneId, @point)

select 
	identifier
from
	@temp