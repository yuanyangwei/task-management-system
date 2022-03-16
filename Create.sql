CREATE TABLE Parameter
(
     department NVARCHAR(50) NULL,
     position NVARCHAR(50) NULL,
	 taskStatus NVARCHAR(50) NULL,
	 projectStatus NVARCHAR(50) NULL,
	 priority  NVARCHAR(50) NULL,
);

CREATE TABLE LoginUser
(
     username VARCHAR(50) NOT NULL UNIQUE,
     account_status BIT NOT NULL,
     password VARCHAR(20) NOT NULL,
	 account_type VARCHAR(20) NOT NULL,
	 first_visit BIT NOT NULL
     
     PRIMARY KEY (username)
);

CREATE TABLE staff_info
(
    [employee_id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NOT NULL UNIQUE,
	[full_name] [nvarchar](50) NOT NULL,
	[phone_no] [int] NOT NULL UNIQUE,
	[position] [nvarchar](250) NOT NULL,
	[department] [nvarchar](250) NOT NULL,
	[roleType] [nvarchar](250) NOT NULL,
    [username] VARCHAR(50) NOT NULL
	
	PRIMARY KEY (employee_id),
    FOREIGN KEY (username) REFERENCES LoginUser (username)
    ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE ProjectInfo
(
     project_id [int] IDENTITY(1,1) NOT NULL UNIQUE, 
     project_name VARCHAR(250) NOT NULL, 
	 project_des VARCHAR(250) NULL,
	 project_status [varchar](max) NOT NULL,
	 [department] VARCHAR(250) NOT NULL,
	 creation_date DATETIME NOT NULL DEFAULT GETDATE(),
	 lastupdate_date DATETIME NOT NULL DEFAULT GETDATE()

	 PRIMARY KEY (project_id)
);


CREATE TABLE TaskInfo
(
    [task_id] [int] IDENTITY(1,1) NOT NULL,
	[project_id] [int] NOT NULL,
	[task_name] [varchar](250) NOT NULL,
	[task_desc] [varchar](max) NULL,
	[task_comment] [varchar](max) NULL,
	[task_status] [varchar](250) NOT NULL,
	[priority] [varchar](250) NOT NULL,
	[start_date] [date] NULL,
	[due_date] [date] NULL,
	[assigner] [varchar](50) NOT NULL,
	[assignee] [varchar](50) NULL,
	 creation_date DATETIME NOT NULL DEFAULT GETDATE(),
	 lastupdate_date DATETIME NOT NULL DEFAULT GETDATE()
     
	 PRIMARY KEY (task_id),
	 FOREIGN KEY (project_id) REFERENCES ProjectInfo (project_id)
	 ON DELETE CASCADE ON UPDATE CASCADE
);

--drop table LoginUser
--drop table [dbo].[ProjectInfo]
--drop table [dbo].[staff_info]
--drop table [dbo].[TaskInfo]


