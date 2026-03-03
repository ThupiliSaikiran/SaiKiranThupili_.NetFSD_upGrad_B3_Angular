CREATE TABLE ParticipantEventDetails 
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	ParticipantEmailId VARCHAR(50) NOT NULL
		FOREIGN KEY REFERENCES UserInfo(EmailId),
	EventId INT NOT NULL
		FOREIGN KEY REFERENCES EventDetails(EventId),
	SessionId INT NOT NULL
		FOREIGN KEY REFERENCES SessionInfo(SessionId),
	IsAttended BIT
); 

INSERT INTO ParticipantEventDetails VALUES
	('admin1@gmail.com',1,1,0);

INSERT INTO ParticipantEventDetails VALUES
	('min1@gmail.com',1,1,0);

INSERT INTO ParticipantEventDetails VALUES
	('priya@gmail.com',1,3,0);
	
UPDATE ParticipantEventDetails SET IsAttended = 1 WHERE id=4;

DELETE FROM ParticipantEventDetails WHERE id=3;

SELECT * FROM ParticipantEventDetails;