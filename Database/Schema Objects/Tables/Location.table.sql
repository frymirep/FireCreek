CREATE TABLE [dbo].[Location]
(
	Identifier bigint primary key identity (1,1), 
	PhoneId nvarchar(20),
	Location geography,
)
