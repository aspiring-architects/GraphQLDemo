USE [GraphQLDemoDB]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 22-02-2022 17:24:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS dbo.StudentResult
GO
DROP TABLE IF EXISTS [dbo].[Student]
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [bigint] Primary Key Identity(1,1) NOT NULL,
	[RegistrationNo] [varchar](50) NOT NULL,
	[StudName] [varchar](50) NOT NULL,
	[Gender] [char](1) NOT NULL
)
GO

CREATE TABLE dbo.StudentResult
(
	[StudentResultId] [bigint] Primary Key Identity(1,1) NOT NULL,	
	[StudentId] [bigint] NOT NULL REFERENCES Student(StudentId),	
	MarksScored INT NOT NULL,
	Result VARCHAR(10) NOT NULL
)
GO

INSERT INTO Student(RegistrationNo,StudName, Gender) VALUES 
('R001','Ravi','M'),
('R002','Ramu','M'),
('R003','Radha','F'),
('R004','Kumar','M')
GO
INSERT INTO StudentResult(StudentId,MarksScored,Result) VALUES
(1, 90, 'Pass'),
(2, 20, 'Fail'),
(3, 90, 'Pass'),
(4, 30, 'Fail')
GO