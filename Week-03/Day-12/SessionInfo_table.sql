create table SessionInfo 
(
	SessionId int primary key,
	EventId int not null
		FOREIGN KEY REFERENCES EventDetails(EventId),
	SessionTitle varchar(50) not null check(len(SessionTitle) between 1 and 50),
	SpeakerId int not null
		FOREIGN KEY REFERENCES SpeakersDetails(SpeakerId),
	Description varchar(100),
	SessionStart time not null,
	SessionEnd time not null,
	SessionUrl varchar(200)
);

insert into SessionInfo  values
	(1, 1, 'AI Fundamentals', 1, 
	'Introduction to Artificial Intelligence', 
	'09:00:00', '10:30:00', 
	'https://event.com/session1');


insert into SessionInfo  values
	(2, 1, 'Web Development Basics', 2, 
	'Frontend and Backend overview', 
	'11:00:00', '12:30:00', 
	'https://event.com/session2');

insert into SessionInfo  values
	(3, 3, 'Cyber Security', 3, 
	NULL, 
	'14:00:00', '15:15:00', 
	'https://event.com/session3');

select * from SessionInfo;