show databases;
drop database electronics;
create database electronics;
use electronics;

show tables;
select * from aspnetusers;
select * from aspnetroles;
select * from aspnetuserclaims;
select * from Companies;
select * from Suppliers;
select * from Taxes;
select * from Grns;
select * from Products;
select * from productbills;
update aspnetusers set EmailConfirmed = true where Id = 1;
