CREATE TABLE EventDetails 
(
	EventId int primary key,
	EventName varchar(50) NOT NULL check(len(EventName) between 1 and 50),
	EventCategory varchar(50) NOT NULL check(len(EventCategory) between 1 and 50),
	EventDate datetime NOT NULL,
	Description varchar(100),
	Status varchar(20) check(Status in ('Active','In-Active'))
);

INSERT INTO EventDetails 
VALUES (1,'Tech Fest','IT','2026-03-10 10:00:00','Annual technical event','Active');

select * from EventDetails;

INSERT INTO EventDetails 
VALUES (2,'Cultural Night','Arts','2026-04-15 18:30:00','Music and dance program','In-Active');

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL);

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL,'sss');

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL,'Active');