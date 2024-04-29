CREATE DATABASE DBCONTACT

USE  DBCONTACT

CREATE TABLE CONTACT(
IdContact int identity,
Names varchar(100),
LastNames varchar(100),
Phone varchar(100),
Email varchar(100)
)


insert into CONTACT(Names,LastNames,Phone,Email) values
('Jose','Perez','980980567','jose@gmail.com'),
('Maria','Paz','980456345','mar@gmail.com'),
('Thalia','Quiñon','978678456','thalia@gmail.com'),
('Belem','Madara','989845634','belem@gmail.com'),
('Alex','Espinoza','909067854','alex@gmail.com')


select * from CONTACT


create procedure sp_Register(
@Names varchar(100),
@LastNames varchar(100),
@Phone varchar(100),
@Email varchar(100) 
)
as
begin
	insert into CONTACT(Names,LastNames,Phone,Email) values (@Names,@LastNames,@Phone,@Email)
end


create procedure sp_Edit(
@IdContact int,
@Names varchar(100),
@LastNames varchar(100),
@Phone varchar(100),
@Email varchar(100) 
)
as
begin
	update CONTACT set Names = @Names, LastNames = @LastNames, Phone = @Phone , Email = @Email where IdContact = @IdContact
end

create procedure sp_Delete(
@IdContact int
)
as
begin
	delete from CONTACT where IdContact = @IdContact
end

