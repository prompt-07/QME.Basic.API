CREATE DATABASE QME;

--create table QueueData(
--QGuid varchar(255) primary key,
--QName varchar(100),
--QDesc nvarchar(max),
--QId varchar(10)
--);

select * from QueueData

--DELETE FROM QueueData;

--ALTER TABLE QueueData
--ADD 
--	QCreationDate date,
--	QCreationTime time,
--	NoOfSubscribers int;

--ALTER TABLE QueueData
--ADD 
--	QCreatorId varchar(20)

Insert into QueueData values('19319312-219312','Manual Queue','Demo','MANUAL2188','11-08-2021','14:59:00.0000000','0');


--create table UserData(
--UName varchar(255) primary key,
--EnterpriseId varchar(20),
--ContactNumberA varchar(15),
--ContactNumberB varchar(15),
--PassKey varchar(20)
--);
ALTER TABLE UserData
ALTER COLUMN 
	UserId varchar(100);

Insert into UserData values('abc@gmail.com','12313-123123','8888888888','8888888888','password123','Demo User');

select * from UserData;