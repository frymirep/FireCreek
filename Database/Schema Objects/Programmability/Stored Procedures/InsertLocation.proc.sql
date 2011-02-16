CREATE PROCEDURE [dbo].[InsertLocation]
	@phoneId   nvarchar(37), 
	@longitude float(53),
	@latitude  float(53),
	@timestamp datetime
AS

declare @point geography 
set @point = geography::STPointFromText('POINT(' +cast(convert(decimal(28,9), @longitude) as nvarchar(50)) + ' ' + cast(convert(decimal(28,9), @latitude) as nvarchar(50)) + ')', 4326)

declare @temp table(identifier bigint)

insert into	
	Location(PhoneId,Location,[Timestamp],Longitude,Latitude)
output 
	inserted.identifier 
into 
	@temp
values(@phoneId, @point, @timestamp, @longitude, @latitude)

select 
	identifier
from
	@temp