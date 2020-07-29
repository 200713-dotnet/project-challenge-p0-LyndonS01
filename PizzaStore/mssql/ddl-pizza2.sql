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
  PizzaId int not null identity(1,1),
  CrustId int null,
  SizeId int null,
  PizzaName nvarchar(250) not null,
  PizzaPrice decimal(8,2) not null,
  DateModified datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Pizza primary key clustered (PizzaId)
);

create table Pizza.Crust
(
  CrustId int not null identity(1,1),
  CrustName nvarchar(100) not null,
--  CrustPrice decimal(8,2) not null,
  DateModified datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Crust primary key clustered (CrustId)
);

create table Pizza.Size
(
  SizeId int not null identity(1,1),
  SizeName nvarchar(100) not null,
--  SizePrice decimal(8,2) not null,
  DateModified datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Size primary key clustered (SizeId)
);

create table Pizza.Topping
(
  ToppingId int not null identity(1,1),
  ToppingName nvarchar(100) not null,
--  ToppingPrice decimal(8,2) not null,
  DateModified datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Topping primary key clustered (ToppingId)
);

create table Pizza.PizzaTopping
(
--  PizzaToppingId int not null,
  PizzaId int not null,
  ToppingId int not null identity(1,1),
  DateModified datetime2(0) not null default getdate(),
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
  OrderDate datetime2(0) not null default getdate(),
  Qty int not null default 1,
  Active bit not null default 1
);

create table Pizza.Users
(
  UserId int not null,
  UserName nvarchar(50) not null,
  LastOrderDate datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Users primary key clustered (UserId)
);

create table Pizza.Stores
(
  StoreId int not null,
  StoreName nvarchar(50) not null,
  DateModified datetime2(0) not null default getdate(),
  Active bit not null default 1,
  constraint PK_Pizza_Stores primary key clustered (StoreId)
);

alter table Pizza.Orders
  add constraint FK_Pizza_PizzaOrders_StoreId foreign key (StoreId) references Pizza.Stores (StoreId);

alter table Pizza.Orders
  add constraint FK_Pizza_PizzaOrders_UserId foreign key (UserId) references Pizza.Users (UserId); 

alter table Pizza.Orders
  add constraint FK_Pizza_PizzaOrders_PizzaId foreign key (PizzaId) references Pizza.Pizza (PizzaId);   

-- populate tables

  -- users

insert into pizza.users (userid, username)
values
(777, 'lyndons'),
(778, 'johnd')

  -- stores
  
insert into pizza.stores (storeid, storename)
values
(201, 'Location A'),
(202, 'Location B'),
(203, 'Location C')

  -- size
  
insert into pizza.size (sizename)
values
('Regular'),
('Large'),
('Family')

  -- crust
  
insert into pizza.crust (crustname)
values
('Thin'),
('Thick'),
('Stuffed')

  -- topping
  
insert into pizza.topping (toppingname)
values
('cheese'),
('extra cheese'),
('pepperoni'),
('sausage'),
('bell peppers'),
('ham'),
('pineapple'),
('bacon'),
('mushrooms')

  -- pizza
  
-- insert into pizza.pizza (pizzaid, crustid, sizeid, pizzaname, pizzaprice, datemodified, active)
-- values
-- (10000, 1000, 100, 'Cheese', 8.0, getdate(), 1),
-- (11000, 1000, 200, 'Cheese', 8.25, getdate(), 1),
-- (12000, 1000, 300, 'Cheese', 8.5, getdate(), 1),
-- (20000, 1100, 100, 'Pepperoni', 9.0, getdate(), 1),
-- (21000, 1100, 200, 'Pepperoni', 9.25, getdate(), 1),
-- (22000, 1100, 300, 'Pepperoni', 9.5, getdate(), 1),
-- (30000, 1200, 100, 'Hawaiian', 9.0, getdate(), 1),
-- (31000, 1200, 200, 'Hawaiian', 9.25, getdate(), 1),
-- (32000, 1200, 200, 'Hawaiian', 9.5, getdate(), 1)


  -- pizzatopping
  
-- insert into pizza.pizzatopping (pizzaid, toppingid, datemodified, active)
-- values
-- (10000, 100, getdate(), 1),
-- (11000, 100, getdate(), 1),
-- (12000, 100, getdate(), 1),
-- (10000, 200, getdate(), 1),
-- (11000, 200, getdate(), 1),
-- (12000, 200, getdate(), 1),
-- (20000, 100, getdate(), 1),
-- (21000, 100, getdate(), 1),
-- (22000, 100, getdate(), 1),
-- (20000, 300, getdate(), 1),
-- (21000, 300, getdate(), 1),
-- (22000, 300, getdate(), 1),
-- (30000, 100, getdate(), 1),
-- (31000, 100, getdate(), 1),
-- (32000, 100, getdate(), 1),
-- (30000, 600, getdate(), 1),
-- (31000, 600, getdate(), 1),
-- (32000, 600, getdate(), 1),
-- (30000, 700, getdate(), 1),
-- (31000, 700, getdate(), 1),
-- (32000, 700, getdate(), 1)

  -- orders
  
-- insert into pizza.orders (storeid, userid, pizzaid, orderdate, qty, active)
-- values
-- (201, 777, 12000, getdate(), 2, 1),
-- (202, 777, 14000, getdate(), 1, 1),
-- (203, 778, 11000, getdate(), 2, 1),
-- (203, 778, 17000, getdate(), 1, 1),
-- (203, 778, 15000, getdate(), 5, 1),
-- (203, 778, 17000, getdate(), 1, 1),
-- (203, 778, 16000, getdate(), 3, 1),
-- (203, 777, 17000, getdate(), 1, 1),
-- (203, 777, 11000, getdate(), 2, 1),
-- (203, 777, 15000, getdate(), 4, 1),
-- (203, 777, 10000, getdate(), 1, 1),
-- (203, 777, 18000, getdate(), 1, 1)
GO

select 'PizzaStoreDB build done!'

GO

