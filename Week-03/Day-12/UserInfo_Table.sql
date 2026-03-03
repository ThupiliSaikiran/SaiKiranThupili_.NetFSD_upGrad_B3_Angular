CREATE DATABASE EventDb;
USE EventDb;

CREATE TABLE UserInfo
(
	EmailId VARCHAR(50) PRIMARY KEY,
	UserName VARCHAR(50) NOT NULL,
	[Role] VARCHAR(30) NOT NULL CHECK(Role in ('Admin','Participant')),
	[Password] VARCHAR(20) NOT NULL CHECK(len(Password) between 6 and 20)
);

INSERT INTO UserInfo VALUES 
	('admin1@gmail.com', 'Sai Kiran', 'Admin', 'admin123'),

	('john@gmail.com', 'John', 'Participant', 'john@789'),
	
	('priya@gmail.com', 'Priya', 'Participant', 'Priya123'),

	('manager@gmail.com', 'Arun Kumar', 'Admin', 'Arun@456');

INSERT INTO UserInfo VALUES 
	('sai@gmail.com', 'sai' , 'aaaa', 'assaassaaa');

SELECT * FROM UserInfo;

