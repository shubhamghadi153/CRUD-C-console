create table employee
(
	id int primary key identity,
	name varchar(100),
	email varchar(100),
	dept varchar(100),
	salary decimal(9,2)
);
select * from employee;

create proc SaveEmp
	@name varchar(100),
	@email varchar(100),
	@dept varchar(100),
	@salary decimal(9,2)
as
begin
	insert into employee values(@name,@email,@dept,@salary);
end

select * from employee;

create proc FetchEmps
as
begin
	select * from employee;
end;

create proc DeleteEmp
	@empid int
as
begin
	delete from employee where id = @empid;
end

create proc SearchEmp
	@empid int
as
begin
	select * from employee where id = @empid;
end

drop proc SearchEmp

create table Auth(
id int primary key identity,
email varchar (100),
username varchar(100) not null,
password varchar unique,
role varchar(100) 
)

select * from Auth

create proc SaveRegistration
	@email varchar (100),
	@username varchar(100),
	@password varchar(100),
	@role varchar(100)
as
begin
	insert into Auth values(@email,@username,@password,@role);
end


create proc UpdateEmpDetails
	@empid int,
	@email varchar (100),
	@username varchar(100),
	@password varchar(100),
	@role varchar(100)
as
begin
	update Auth set email=@email , username =@username , password=@password, role=@role where id=@empid;
	Select * from employee;
end

