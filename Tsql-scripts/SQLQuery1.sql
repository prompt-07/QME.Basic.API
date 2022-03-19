CREATE DATABASE QME;

--create table QueueData(
--QGuid varchar(255) primary key,
--QName varchar(100),
--QDesc nvarchar(max),
--QId varchar(10)
--);

select * from QueueData where QCreatorId = 'ec32bf8d-2fc3-4c2b-a9f6-e13292169aef'

DELETE FROM QueueData;

ALTER TABLE QueueData
ALTER COLUMN 
	QCreatorId varchar(40)
--	QCreationTime time,
--	NoOfSubscribers int;

--ALTER TABLE QueueData
--ADD 
--	QCreatorId varchar(20)

Insert into QueueData values('19319312-219312','Manual Queue','Demo','MANUAL2188','11-08-2021','14:59:00.0000000','0');

--Make EnterpriseId as primary key
--create table UserData(
--UName varchar(255) primary key,
--EnterpriseId varchar(20),
--ContactNumberA varchar(15),
--ContactNumberB varchar(15),
--PassKey varchar(20)
--);

--ALTER TABLE UserData DROP CONSTRAINT PK__UserData__B6DEAEE8562ECFE1
--ALTER TABLE UserData ADD primary key (EnterpriseId)

--ALTER TABLE UserData
--ALTER COLUMN 
--	EnterpriseId varchar(100) not null;

Insert into UserData values('abc@gmail.com','12313-123123','8888888888','8888888888','password123','Demo User');

select * from UserData where UserId = '0edc0141-f3fb-4105-ad0c-d38b9bad96c4';
DELETE FROM UserData;
--create table Customer(
--FullName varchar(100),
--MobileNumber varchar(15),
--EmailId varchar(100),
--ServicesDesc varchar(100),
--TenantId varchar(20)
--);

Insert into CustomerData values('Ajay','912313183','abc.c@gmail.com','asdnjasnjdsn', 'a897e372-5e15-4c96-8368-3fb8dd762720' ,'101');

select * from CustomerData where RegistrationId = '159794528';

ALTER TABLE UserData
ADD
	EmailId varchar(30)

--UPDATE CustomerData 
--SET Stage = 2 where RegistrationId Like 675540112

--DELETE FROM CustomerData;


SELECT 	*
FROM UserData
FOR JSON AUTO