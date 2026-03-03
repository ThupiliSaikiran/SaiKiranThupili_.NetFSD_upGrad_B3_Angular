CREATE TABLE SessionInfo 
(
	SessionId INT PRIMARY KEY,
	EventId INT NOT NULL
		FOREIGN KEY REFERENCES EventDetails(EventId),
	SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle) BETWEEN 1 AND 50),
	SpeakerId INT NOT NULL
		FOREIGN KEY REFERENCES SpeakersDetails(SpeakerId),
	[Description] VARCHAR(100),
	SessionStart TIME NOT NULL,
	SessionEnd TIME NOT NULL,
	SessionUrl VARCHAR(200)
);

INSERT INTO SessionInfo  VALUES
	(1, 1, 'AI Fundamentals', 1, 
	'Introduction to Artificial Intelligence', 
	'09:00:00', '10:30:00', 
	'https://event.com/session1');


INSERT INTO SessionInfo  VALUES
	(2, 1, 'Web Development Basics', 2, 
	'Frontend and Backend overview', 
	'11:00:00', '12:30:00', 
	'https://event.com/session2');

INSERT INTO SessionInfo  VALUES
	(3, 3, 'Cyber Security', 3, 
	NULL, 
	'14:00:00', '15:15:00', 
	'https://event.com/session3');

SELECT * FROM SessionInfo;