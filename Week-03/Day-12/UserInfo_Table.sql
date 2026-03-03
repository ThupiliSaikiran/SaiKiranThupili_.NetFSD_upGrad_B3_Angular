create database EventDb;
use EventDb;

create table UserInfo
(
	EmailId varchar(50) primary key,
	UserName varchar(50) not null,
	Role varchar(30) not null check(Role in ('Admin','Participant')),
	Password varchar(20) not null,
	CONSTRAINT chk_password_length check(len(Password) between 6 and 20)
);

insert into UserInfo values 
	('admin1@gmail.com', 'Sai Kiran', 'Admin', 'admin123'),

	('john@gmail.com', 'John', 'Participant', 'john@789'),
	
	('priya@gmail.com', 'Priya', 'Participant', 'Priya123'),

	('manager@gmail.com', 'Arun Kumar', 'Admin', 'Arun@456');

insert into UserInfo values 
	('sai@gmail.com', 'sai' , 'aaaa', 'assaassaaa');

select * from UserInfo;

