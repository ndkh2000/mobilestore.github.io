Create database NguyenDangKhanhHungDB
go
Use NguyenDangKhanhHungDB
go
Create table UserAccount(
	ID bigint Identity(1,1) primary key,
	Username varchar(50) null,
	Password varchar (50) null,
	Status nvarchar (30) null
)
Create table Category(
	ID bigint Identity(1,1) primary key,
	Name nvarchar(100) null,
	Description nvarchar(255) null
)
Create table Product(
	ID bigint Identity(1,1) primary key,
	Name nvarchar(250) null,
	Unitcost decimal(18,0) null,
	Quantity int null,
	Image nvarchar(100) null,
	Description nvarchar(255) null,
	Status nvarchar(255) null,
	ProductType bigint null,
	constraint fk_Product_Category foreign key (ProductType) references Category(ID)
)

INSERT INTO dbo.UserAccount(Username,Password,Status)
VALUES (N'admin',N'admin',N'active'),
		(N'khanhhung',N'khanhhung',N'active'),
		(N'red',N'red',N'blocked'),
		(N'pink',N'pink',N'blocked'),
		(N'henry',N'henry',N'active'),
		(N'tom',N'tom',N'active'),
		(N'dark',N'dark',N'blocked'),
		(N'dark',N'dark',N'blocked'),
		(N'bot',N'bot',N'active'),
		(N'nightbot',N'nightbot',N'active');

INSERT INTO dbo.Category(Name,Description)
VALUES (N'VSmart',N'Smartphone'),
	   (N'Huawei',N'Smartphone'),
	   (N'Iphone',N'Smartphone'),
	   (N'Samsung',N'Smartphone'),
	   (N'Xiaomi',N'Smartphone');

INSERT INTO dbo.Product(Name,Unitcost,Quantity,Image,Description,Status,ProductType)
VALUES (N'Iphone 5s',550000,100,N'image',N'99%',N'Stocking',14),
	(N'Iphone 6s',550000,150,N'image',N'99%',N'Stocking',14),
	(N'Iphone 7s',650000,200,N'image',N'99%',N'Stocking',14),
	(N'Iphone 8',750000,300,N'image',N'99%',N'Stocking',14),
	(N'Iphone 10',580000,500,N'image',N'99%',N'Stocking',14);
	   

