create table ParticipantEventDetails 
(
	id int IDENTITY(1,1)primary key,
	ParticipantEmailId varchar(50) not null
		FOREIGN KEY REFERENCES UserInfo(EmailId),
	EventId int not null
		FOREIGN KEY REFERENCES EventDetails(EventId),
	SessionId int not null
		FOREIGN KEY REFERENCES SessionInfo(SessionId),
	IsAttended bit check(IsAttended in(0,1))
); 

insert into ParticipantEventDetails values
	('admin1@gmail.com',1,1,0);

insert into ParticipantEventDetails values
	('min1@gmail.com',1,1,0);

insert into ParticipantEventDetails values
	('priya@gmail.com',1,3,0);
	
update ParticipantEventDetails set IsAttended = 1 where id=4;

delete from ParticipantEventDetails where id=3;

select * from ParticipantEventDetails;