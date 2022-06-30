CREATE TABLE FoodCategory (
    id int NOT NULL PRIMARY KEY,
    name varchar(255),
    price int
);


CREATE TABLE Customer (
    id int NOT NULL PRIMARY KEY,
    name varchar(255),
    addedon datetime
);


CREATE TABLE CustomerFoodOrder (
	id int NOT NULL PRIMARY KEY, 
	customerid int FOREIGN KEY REFERENCES Customer(id), 
	fromdate datetime, 
	todate datetime, 
	starterquantity int, 
	maincoursequantity int,  
	dessertquantity int, 
	addedon datetime
);

insert into FoodCategory(id, name,  price) values (1, 'Starter', 3);
insert into FoodCategory(id, name,  price) values (2, 'Main Course', 5);
insert into FoodCategory(id, name,  price) values (3, 'Desert', 2);


insert into Customer(id, name, addedon) values (2, 'Kaiser','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (4, 'Aftab','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (5, 'Ruike','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (6, 'Amelia','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (7, 'Hasib','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (8, 'Alin','2022-06-18 00:00:01');
insert into Customer(id, name, addedon) values (9, 'Rares','2022-06-18 00:00:01');




insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (4, 2, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 5, 0, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (5, 2, '2022-06-01 00:00:01', '2022-06-10 00:00:01', 0, 1, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (6, 4, '2022-06-01 00:00:01', '2022-06-10 00:00:01', 0, 1, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (7, 2, '2022-06-01 00:00:01', '2022-06-10 00:00:01', 0, 0, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (8, 2, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 15, 50, 20 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (9, 5, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 15, 50, 20 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (10, 2, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 15, 50, 20 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (11, 2, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 15, 50, 20 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (12, 2, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 15, 100, 20 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (13, 6, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 5, 0, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (14, 6, '2022-06-18 00:00:01', '2022-06-18 00:00:01', 5, 5, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (15, 7, '2022-06-05 00:00:01', '2022-07-02 00:00:01', 40, 10, 0 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (16, 8, '2022-01-07 00:00:01', '2022-07-02 00:00:01', 2, 0, 13 ,'2022-06-18 00:00:01');
insert into CustomerFoodOrder(id,customerid,fromdate,todate,starterquantity,maincoursequantity,dessertquantity,addedon) values (17, 9, '2022-07-07 00:00:01', '2022-07-20 00:00:01', 2, 0, 13 ,'2022-06-18 00:00:01');





