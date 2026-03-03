CREATE TABLE SpeakersDetails 
(
	SpeakerId int primary key,
	SpeakerName varchar(50) not null check(len(SpeakerName) between 1 and 50)
);


insert into SpeakersDetails values
		(101,'');

INSERT INTO SpeakersDetails VALUES (1, 'Sai Kiran');
INSERT INTO SpeakersDetails VALUES (2, 'John Mathew');
INSERT INTO SpeakersDetails VALUES (3, 'Priya Sharma');
INSERT INTO SpeakersDetails VALUES (4, 'Arun Kumar');
INSERT INTO SpeakersDetails VALUES (5, 'Meghana Reddy');

select * from SpeakersDetails;