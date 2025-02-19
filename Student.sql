create database CMCUni2;
use CMCUni2;

-- Tạo bảng Students
CREATE TABLE Students (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- ID tự động tăng
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Class NVARCHAR(50) NOT NULL
);
GO

INSERT INTO Students (Name, Age, Class) VALUES 
('Nguyen Van A', 20, 'CTK44'),
('Tran Thi B', 21, 'CTK45'),
('Le Van C', 22, 'CTK46');
GO

SELECT * FROM Students;

