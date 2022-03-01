INSERT INTO dbo.LoginUser(username,account_status,password,account_type,first_visit)
VALUES ('angele_admin',0,'Welcome123','Admin',0)

INSERT INTO dbo.staff_info (email,full_name,phone_no,position,department,roleType,username) VALUES 
('cjiayan21@gmail.com','Angele Chan',91234567,'HR','Human Resource Department','Normal User','angele_admin')

INSERT INTO Parameter (department, position)
VALUES ('Credit Planning Department', 'Asset Manager'),
('Human Resource Department', 'Financial Risk Manager'),
('Corporate Banking Department', 'Credit Analyst'),
('Credit Risk Department', 'Senior Developer'),
('Credit Risk Department', 'Data Analyst'),
('Legal Department', 'Business Analyst'),
('Financial Information Management Department', 'Software Engineer'),
('', 'IT Support'),
('', 'HR')
