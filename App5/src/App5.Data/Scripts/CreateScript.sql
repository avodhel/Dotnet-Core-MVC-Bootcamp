Create Database ECommerceDb
go 

use ECommerceDb
go 

Create table Product(
	Id int primary key identity,
	[Name] nvarchar(100) not null,
	Brand nvarchar(100) not null,
	Price decimal not null,
	StockCount int not null
)