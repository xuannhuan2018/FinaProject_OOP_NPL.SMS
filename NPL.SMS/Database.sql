-- Tao schema ten SMS
CREATE DATABASE SMS;

-- Tao bang Customer
CREATE TABLE Customer(
	customer_id int IDENTITY(1,1),
	customer_name nvarchar(100),

	primary key(customer_id)
);

-- Tao bang Employee
CREATE TABLE Employee(
	employee_id int IDENTITY(1,1),
	employee_name nvarchar(100),
	salary float,
	supervisor_id int,

	primary key(employee_id)
);

-- Tao bang product
CREATE TABLE Product(
	product_id int IDENTITY(1,1),
	product_name nvarchar(100),
	product_price float,

	primary key(product_id)
);

-- Tao bang Orders
CREATE TABLE Orders(
	order_id int IDENTITY(1,1),
	order_date datetime,
	customer_id int,
	employee_id int,
	total float,

	primary key(order_id),
	foreign key(customer_id) references Customer(customer_id) on delete cascade,
	foreign key(employee_id) references Employee(employee_id)
);

-- Tao bang LineItem
CREATE TABLE LineItem(
	order_id int,
	product_id int,
	quantity int,
	price float,

	primary key(order_id, product_id),
	foreign key(order_id) references Orders(order_id) on delete cascade,
	foreign key(product_id) references Product(product_id)
);

-- Function 04: Total_price
GO
CREATE FUNCTION FN_total_price(@orderId int)
RETURNS float
AS
	BEGIN
		DECLARE @total_price float
		SELECT @total_price = (SELECT SUM (quantity * price) FROM dbo.LineItem WHERE order_id = @orderId)
		RETURN @total_price;
	END

-- Store Produce 05: Insert Customer
GO
CREATE PROC SP_Insert_Customer(@customerName NVARCHAR(100))
AS
	INSERT INTO dbo.Customer(customer_name) VALUES (@customerName)

-- Store Produce 06: Delete Customer
go
CREATE PROC SP_Delete_Customer(@customerId INT)
AS
	BEGIN
		DELETE FROM dbo.Customer WHERE customer_id = @customerId;
	END

-- Store Produce 07: Update Customer
GO
CREATE PROC SP_Update_Customer(@customerId INT, @customerName NVARCHAR(100))
AS
	BEGIN
		UPDATE dbo.Customer SET customer_name = @customerName WHERE customer_id = @customerId;
	END
