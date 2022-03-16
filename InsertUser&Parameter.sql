INSERT INTO dbo.LoginUser(username,account_status,password,account_type,first_visit)
VALUES ('angele_admin',0,'Welcome123','Admin',0)

INSERT INTO dbo.staff_info (email,full_name,phone_no,position,department,roleType,username) VALUES 
('cjiayan21@gmail.com','Angele Chan',91234567,'HR','Human Resource Department','Normal User','angele_admin')

INSERT INTO Parameter (department, position)
VALUES ('Credit Planning Department', 'Asset Manager', 'Pending', 'Pending', 'Low'),
('Human Resource Department', 'Financial Risk Manager', 'In Progress', 'Ongoing', 'Medium'),
('Corporate Banking Department', 'Credit Analyst', 'Completed', 'Completed', 'High'),
('Credit Risk Department', 'Senior Developer', 'Delay', 'Suspend', NULL),
('Credit Risk Department', 'Data Analyst', NULL, NULL, NULL),
('Legal Department', 'Business Analyst', NULL, NULL, NULL),
('Financial Information Management Department', 'Software Engineer', NULL, NULL, NULL),
('', 'IT Support', NULL, NULL, NULL),
('', 'HR', NULL, NULL, NULL)
