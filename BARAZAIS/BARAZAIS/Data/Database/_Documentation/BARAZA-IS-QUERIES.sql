show databases;
drop database barazadb;
create database barazadb;
use barazadb;

show tables;
select * from aspnetusers;
select * from aspnetroles;
select * from Companies;

insert into Companies values(
	default,now(),now(),"CMP", "DropCode", "","111-222-333", "info@dropcode.co.tz","0754999954","Ilala, Dar es salaam"
);