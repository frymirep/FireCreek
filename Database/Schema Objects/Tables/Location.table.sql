CREATE TABLE [dbo].[Location]
(
	Identifier bigint primary key identity (1,1), 
	PhoneId nvarchar(37),
	Location geography,
	LocationText as Location.STAsText(),
	[Timestamp] datetime,
	Longitude float(53),
	Latitude float(53)
)