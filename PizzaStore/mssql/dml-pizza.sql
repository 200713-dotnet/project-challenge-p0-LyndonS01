use PizzaStoreDb;
GO

-- get selection of stores

select StoreId, StoreName from pizza.stores;
go

-- get selection of preset pizza types

select
  SizeName,
  CrustName,
  PizzaName,
  PizzaPrice 
FROM
  pizza.pizza p 
inner JOIN pizza.size s on p.SizeId = s.SizeId
inner JOIN pizza.crust c on p.crustId = c.crustId
order by
  pizzaname ASC;
go

-- get selection of size types

select sizeid, SizeName from pizza.size;
go

-- get selection of crust types

select crustid, CrustName from pizza.crust;
go

-- get selection of topping types

select toppingid, toppingName from pizza.topping;
go

-- store: 
  -- history

  -- for the month

  select * from pizza.orders
  where year(pizza.orders.orderdate) = year(getdate()) and month(pizza.orders.orderdate) = month(getdate());

  -- filtered by user

  select * from pizza.orders
  where pizza.orders.userid = 777;

  -- sales for a given month

select
  PizzaName,
  SizeName,
  CrustName
FROM
  pizza.pizza p 
inner JOIN pizza.size s on p.SizeId = s.SizeId
inner JOIN pizza.crust c on p.crustId = c.crustId
order by
  pizzaname ASC;

go


