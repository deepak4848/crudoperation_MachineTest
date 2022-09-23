create database crudoperation
use crudoperation

create table STUDENT (
StuId int primary key identity(1,1),
StuName varchar(100),
RollNo int,
contacno bigint,
gender int,  -- 1 - Male, 2- Female
countryid int references country(cid),
stateid int references state(sid)
)


create table country(
cid int primary key identity(1,1),
cname varchar(500)
)

create table state(
sid int primary key identity(1,1),
sname varchar(500),
cid int references country(cid)
)

select * from STUDENT

insert into country (cname) values ('India')
insert into country (cname) values ('Pakistan')
insert into country (cname) values ('China')
insert into country (cname) values ('USA')


insert into state (sname,cid) values ('Haryana',1)
insert into state (sname,cid) values ('UP',1)
insert into state (sname,cid) values ('Bihar',1)
insert into state (sname,cid) values ('Delhinn',null)

insert into state (sname,cid) values ('pak1',2)
insert into state (sname,cid) values ('pak2',2)
insert into state (sname,cid) values ('china1',3)
insert into state (sname,cid) values ('china2',3)
insert into state (sname,cid) values ('Uusa1P',4)
insert into state (sname,cid) values ('usa2',4)


alter procedure GetStudent 
as
begin
select A.StuId, A.StuName,A.RollNo,A.contacno ,A.gender, B.cname, C.sname 
from STUDENT A 
LEFT OUTER JOIN country B ON A.countryid =B.cid
LEFT OUTER JOIN state C ON C.sid = A.stateid
end


create procedure GetStudentRecord 
@StuId int
as
begin
select *  from STUDENT where StuId = @StuId
end





create procedure GetCountry 
as
begin
select * from country
end

alter procedure GetState
@cid int
as
begin
select * from state where cid =@cid
end


create procedure AddUpdateStudent
@StuId int =null,
@StuName varchar(100) =null,
@RollNo int =null,
@contacno bigint =null,
@gender int =null,  -- 1 - Male, 2- Female
@countryid int =null,
@stateid int =null
as
begin

if (@StuId < 0)
begin
insert into STUDENT (StuName, RollNo, contacno,gender,countryid,stateid) values (@StuName, @RollNo, @contacno,@gender,@countryid,@stateid) 
end

else
begin
update STUDENT set StuName= @StuName, RollNo = @RollNo, contacno = @contacno,gender =@gender,countryid =@countryid,stateid= @stateid 

end

end











