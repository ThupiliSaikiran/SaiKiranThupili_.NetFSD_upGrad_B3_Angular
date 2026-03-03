CREATE TABLE SpeakersDetails 
(
	SpeakerId INT PRIMARY KEY,
	SpeakerName VARCHAR(50) NOT NULL CHECK(LEN(SpeakerName) BETWEEN 1 AND 50)
);


INSERT INTO SpeakersDetails VALUES
		(101,'');

INSERT INTO SpeakersDetails VALUES (1, 'Sai Kiran');
INSERT INTO SpeakersDetails VALUES (2, 'John Mathew');
INSERT INTO SpeakersDetails VALUES (3, 'Priya Sharma');
INSERT INTO SpeakersDetails VALUES (4, 'Arun Kumar');
INSERT INTO SpeakersDetails VALUES (5, 'Meghana Reddy');

SELECT * FROM SpeakersDetails;