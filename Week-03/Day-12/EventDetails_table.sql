CREATE TABLE EventDetails 
(
	EventId INT PRIMARY KEY,
	EventName VARCHAR(50) NOT NULL CHECK(LEN(EventName) BETWEEN 1 AND 50),
	EventCategory VARCHAR(50) NOT NULL CHECK(LEN(EventCategory) BETWEEN 1 AND 50),
	EventDate DATETIME NOT NULL,
	[Description] VARCHAR(100),
	[Status] VARCHAR(20) CHECK(Status IN ('Active','In-Active'))
);

INSERT INTO EventDetails 
VALUES (1,'Tech Fest','IT','2026-03-10 10:00:00','Annual technical event','Active');

SELECT * FROM EventDetails;

INSERT INTO EventDetails 
VALUES (2,'Cultural Night','Arts','2026-04-15 18:30:00','Music and dance program','In-Active');

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL);

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL,'sss');

INSERT INTO EventDetails 
VALUES (3,'Workshop','Programming','2026-05-01 09:00:00',NULL,'Active');


INSERT INTO EventDetails 
VALUES (4,'ddddddddddddddddddddddddddddddddd','Programming','2026-05-01 09:00:00',NULL,'Active');

DELETE FROM EventDetails WHERE EventId = 4;