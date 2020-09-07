create database SANA
go
use SANA
go

--Tables create
CREATE TABLE Customer  
(  
 id int IDENTITY(1,1) not null primary key, 
 Id_Customer int not null ,
 F_Name varchar (20),  
 L_Name varchar(30),
 EUser char(1),  
 Email varchar(50),
 Address varchar(50)
 );  
  CREATE TABLE orders (
	id int IDENTITY(1,1) not null primary key, 
	Id_Orders int not null ,
	
 );
 CREATE TABLE Custom_Orders  
(  
 id int IDENTITY(1,1) not null primary key, 
 FkId_Customer int not null,
 FkId_Orders int not null,
 GenerationDate datetime,
 Total money
 );

    CREATE TABLE Products  
(  
 id int IDENTITY(1,1) not null primary key, 
 Id_Product int not null,
 Title varchar (50),
 Description varchar(50) not null,
 Price money
 ); 
  CREATE TABLE Orders_Products  
(  
 id int IDENTITY(1,1) not null primary key, 
 FkId_Products int not null,
 FkId_Orders int not null,
 amount int,
 TPPrice money
 );  
 
 
 CREATE TABLE Category  
(  
 id int IDENTITY(1,1) not null primary key, 
 Description varchar(50) not null,
 Id_Category int not null,
 );
   CREATE TABLE Products_Category  
(  
 id int IDENTITY(1,1) not null primary key, 
 FkId_Products int not null,
 FkId_Category int not null
 );
  go
  --Fk create
  ALTER TABLE Custom_Orders
ADD CONSTRAINT Fk_Custom_Orders  
FOREIGN KEY (FkId_Customer) REFERENCES Customer (id)
go
  ALTER TABLE Custom_Orders
ADD CONSTRAINT Fk_Orders_Customer  
FOREIGN KEY (FkId_Orders) REFERENCES orders (id)
go
  ALTER TABLE Orders_Products
ADD CONSTRAINT Fk_Orders_Products  
FOREIGN KEY (FkId_Orders) REFERENCES orders (id)
go
  ALTER TABLE Orders_Products
ADD CONSTRAINT Fk_Products_Orders  
FOREIGN KEY (FkId_Products) REFERENCES Products (id)
go
  ALTER TABLE Products_Category
ADD CONSTRAINT Fk_Products_Category  
FOREIGN KEY (FkId_Products) REFERENCES Products (id)
go
  ALTER TABLE Products_Category
ADD CONSTRAINT Fk_Category_Products 
FOREIGN KEY (FkId_Category) REFERENCES Category (id)
go

---Create data base select * from Products

INSERT INTO Customer  
(   
 Id_Customer ,F_Name ,  L_Name ,EUser ,  Email ,Address ) 
 Values
 ( 1, 'Alejandro', 'Gutierrez', 1, 'a@a.com', 'Main street'),
 ( 2, 'Pedro', 'Gutierrez', 1, 'p@p.com', 'Main Roconda'),
 ( 3, 'Alex', 'Gutierrez', 1, 'al@al.com', 'Main Cosco')

INSERT INTO  orders ( Id_Orders )
Values
(11),
(22),
(33)

INSERT INTO Custom_Orders  (  FkId_Customer,FkId_Orders,GenerationDate,Total ) 
VALUES
(  1,2,GETDATE(),123123 ),
(  2,3,SYSDATETIME(),223123 )

INSERT INTO Products  (  Id_Product ,Description , Price, Title  )
VALUES  
(  1 ,'Producto1' , 12 , 'Rice' ),
(  2 ,'Produtcto2' , 10 , 'Beans' ),
(  3 ,'Producto 3' , 8 , 'Avocado' )
--drop database SANA

INSERT INTO Orders_Products  
(  FkId_Products ,FkId_Orders ,amount , TPPrice )
VALUES 
(1,1,1,12),
(2,1,1,12),
(3,1,1,12),
(1,2,1,12),
(1,3,1,12),
(2,3,1,12)

INSERT INTO Category  (  Description , Id_Category )
VALUES 
('VEGETABLES',1),
('SHOES',2),
('PANTS',3)

INSERT INTO Products_Category  ( FkId_Products ,FkId_Category)
VALUES
( 1 ,1),
( 2 ,1),
( 3 ,1),
( 1 ,2),
( 1 ,3),
( 2 ,2)

/*
--DROP DATABASE SANA
SELECT CO.GenerationDate,O.Id_Orders, p.Description,p.Title FROM Custom_Orders AS co INNER JOIN orders AS O
ON( O.Id_Orders = CO.FkId_Orders) 
inner join Orders_Products as op 
on o.Id_Orders=op.FkId_Orders  
inner join Products as p 
on (op.FkId_Products=p.Id_Product) -- where (p.Description='Producto1' )

select * from Products*/

select * from products_category