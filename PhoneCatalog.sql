create database PhoneCatalog;
use PhoneCatalog;
create table departments
(
DepID int primary key auto_increment,
ParentsId int ,
DepName varchar(255)
);

create table employees
(
id int primary key auto_increment not null,
FirstName varchar(255),
LastName varchar(255),
PhoneNumber int,
Email varchar(255),
DepId int,
foreign key (DepId) references departments(DepId)
);

insert into departments (ParentsID, DepName) values (0,'IT');
insert into departments (ParentsID, DepName) values (0,'Support');
insert into departments (ParentsID, DepName) values (1,'IT-Designer');
insert into departments (ParentsID, DepName) values (1,'IT-Developer');
insert into departments (ParentsID, DepName) values (4,'IT-Developer-Back_End');
insert into departments (ParentsID, DepName) values (4,'IT-Developer-Front_End');

insert into employees (FirstName, LastName, PhoneNumber, Email, DepId) values ('Sidorov','Valeriy',11111111,'sidorov.val@yandex.ru',5);
insert into employees (FirstName, LastName, PhoneNumber, Email, DepId) values ('Ivanov','Ivan',2222222,'Ivanov.Ivan@yandex.ru',6);
insert into employees (FirstName, LastName, PhoneNumber, Email, DepId) values ('Petrov','Petr',3333333,'Petrov_Petr@yandex.ru',5);

