-- data definition language

--use master;
--go

drop database PizzaStoreDb;
go
-- CREATE

create database PizzaStoreDb; --project
go

use PizzaStoreDb;
go

--drop schema Pizza;
--go

create schema Pizza; --namespace
go

--constraints = datatype, key, default, check, null, computed
--number datatypes = tinyint (int8), smallint (int16), int (int32), bigint (int64), numeric, decimal, money
--text datatypes = text, ntext, varchar (ascii), nvarchar (utf-8), char (ascii), nchar(utf-8)
--datetime datatypes = date, time, datetime, datetime2
--boolean datatypes = bit

create table Pizza.Pizza
(
  PizzaId int not null,
  CrustId int null,
  SizeId int null,
  PizzaName nvarchar(250) not null,
  PizzaPrice decimal(8,2) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Pizza primary key clustered (PizzaId)
);

create table Pizza.Crust
(
  CrustId int not null,
  CrustName nvarchar(100) not null,
  CrustPrice decimal(8,2) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Crust primary key clustered (CrustId)
);

create table Pizza.Size
(
  SizeId int not null,
  SizeName nvarchar(100) not null,
  SizePrice decimal(8,2) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Size primary key clustered (SizeId)
);

create table Pizza.Topping
(
  ToppingId int not null,
  ToppingName nvarchar(100) not null,
  ToppingPrice decimal(8,2) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Topping primary key clustered (ToppingId)
);

create table Pizza.PizzaTopping
(
--  PizzaToppingId int not null,
  PizzaId int not null,
  ToppingId int not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1
--  constraint PK_Pizza_PizzaTopping primary key clustered (PizzaToppingId)
);

alter table Pizza.Pizza
  add constraint FK_Pizza_CrustId foreign key (CrustId) references Pizza.Crust (CrustId);

alter table Pizza.Pizza
  add constraint FK_Pizza_SizeId foreign key (SizeId) references Pizza.Size (SizeId);

alter table Pizza.PizzaTopping
  add constraint FK_Pizza_PizzaTopping_PizzaId foreign key (PizzaId) references Pizza.Pizza(PizzaId);

alter table Pizza.PizzaTopping
  add constraint FK_Pizza_PizzaTopping_ToppingId foreign key (ToppingId) references Pizza.Topping(ToppingId);

-- create orders, stores an users tables

create table Pizza.Orders
(
  StoreId int not null,
  UserId int not null,
  PizzaId int not null,
  OrderDate datetime2(0) not null,
  Qty int not null,
  Active bit not null default 1
);

create table Pizza.Users
(
  UserId int not null,
  UserName nvarchar(50) not null,
  LastOrderDate datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Users primary key clustered (UserId)
);

create table Pizza.Stores
(
  StoreId int not null,
  StoreName nvarchar(50) not null,
  DateModified datetime2(0) not null,
  Active bit not null default 1,
  constraint PK_Pizza_Stores primary key clustered (StoreId)
);

alter table Pizza.Orders
  add constraint FK_Pizza_PizzaOrders_StoreId foreign key (StoreId) references Pizza.Stores (StoreId);

alter table Pizza.Orders
  add constraint FK_Pizza_PizzaOrders_UserId foreign key (UserId) references Pizza.Users (UserId); 

-- populate tables

  -- users

insert into pizza.users (userid, username, lastorderdate, active)
values
(777, 'lyndons', getdate(), 1),
(778, 'johnd', getdate(), 1)

  -- stores
  
insert into pizza.stores (storeid, storename, datemodified, active)
values
(201, 'Location A', getdate(), 1),
(202, 'Location B', getdate(), 1),
(203, 'Location C', getdate(), 1)

  -- size
  
insert into pizza.size (sizeid, sizename, sizeprice, datemodified, active)
values
(100, 'Regular', 0.25, getdate(), 1),
(200, 'Large', 0.5, getdate(), 1),
(300, 'Family', 0.75, getdate(), 1)

  -- crust
  
insert into pizza.crust (crustid, crustname, crustprice, datemodified, active)
values
(1000, 'Thin', 0.25, getdate(), 1),
(1100, 'Thick', 0.5, getdate(), 1),
(1200, 'Stuffed', 0.75, getdate(), 1)

  -- topping
  
insert into pizza.topping (toppingid, toppingname, toppingprice, datemodified, active)
values
(100, 'cheese', 0.25, getdate(), 1),
(200, 'extra cheese', 0.25, getdate(), 1),
(300, 'pepperoni', 0.5, getdate(), 1),
(400, 'sausage', 0.5, getdate(), 1),
(500, 'bell peppers', 0.3, getdate(), 1),
(600, 'ham', 0.5, getdate(), 1),
(700, 'pineapple', 0.4, getdate(), 1),
(800, 'bacon', 0.5, getdate(), 1),
(900, 'mushrooms', 0.3, getdate(), 1)

  -- pizza
  
insert into pizza.pizza (pizzaid, crustid, sizeid, pizzaname, pizzaprice, datemodified, active)
values
(10000, 1000, 100, 'Cheese', 8.0, getdate(), 1),
(11000, 1000, 200, 'Cheese', 8.25, getdate(), 1),
(12000, 1000, 300, 'Cheese', 8.5, getdate(), 1),
(13000, 1100, 100, 'Pepperoni', 9.0, getdate(), 1),
(14000, 1100, 200, 'Pepperoni', 9.25, getdate(), 1),
(15000, 1100, 300, 'Pepperoni', 9.5, getdate(), 1),
(16000, 1200, 100, 'Hawaiian', 9.0, getdate(), 1),
(17000, 1200, 200, 'Hawaiian', 9.25, getdate(), 1),
(18000, 1200, 200, 'Hawaiian', 9.5, getdate(), 1)


  -- pizzatopping
  
insert into pizza.pizzatopping (pizzaid, toppingid, datemodified, active)
values
(10000, 100, getdate(), 1),
(11000, 100, getdate(), 1),
(12000, 100, getdate(), 1),
(10000, 200, getdate(), 1),
(11000, 200, getdate(), 1),
(12000, 200, getdate(), 1),
(13000, 100, getdate(), 1),
(14000, 100, getdate(), 1),
(15000, 100, getdate(), 1),
(13000, 300, getdate(), 1),
(14000, 300, getdate(), 1),
(15000, 300, getdate(), 1),
(16000, 100, getdate(), 1),
(17000, 100, getdate(), 1),
(18000, 100, getdate(), 1),
(16000, 600, getdate(), 1),
(17000, 600, getdate(), 1),
(18000, 600, getdate(), 1),
(16000, 700, getdate(), 1),
(17000, 700, getdate(), 1),
(18000, 700, getdate(), 1)

  -- orders
  
insert into pizza.orders (storeid, userid, pizzaid, orderdate, qty, active)
values
(201, 777, 12000, getdate(), 2, 1),
(202, 777, 14000, getdate(), 1, 1),
(203, 778, 11000, getdate(), 2, 1),
(203, 778, 17000, getdate(), 1, 1),
(203, 778, 15000, getdate(), 5, 1),
(203, 778, 17000, getdate(), 1, 1),
(203, 778, 16000, getdate(), 3, 1),
(203, 777, 17000, getdate(), 1, 1),
(203, 777, 11000, getdate(), 2, 1),
(203, 777, 15000, getdate(), 4, 1),
(203, 777, 10000, getdate(), 1, 1),
(203, 777, 18000, getdate(), 1, 1)
GO

select 'PizzaStoreDB build done!'

GO

