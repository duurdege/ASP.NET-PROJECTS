


Create Table AdminTB
(
ID int primary key identity(1,1),
AdminNmae varchar(50),
AdminUser varchar(50),
Gender varchar(50),
Email varchar(50),
Number varchar(50),
Adminpassword varchar(50),
Date varchar(50),
Photo varchar(50)
)     

    
Select *  from AdminTB

create table ClassTB

(
ID int primary key identity(1,1),
Faculty varchar(50),
Department varchar(50),
Class varchar(50),
ClassCode varchar(50),
 
Date varchar(50)

)      

Select *  from ClassTB    


Create table SubjectTB
(
 ID int primary key identity(1,1),
 ClassName varchar(50),
 Subject varchar(50),
 subCode varchar(50),
 Date varchar(50),
 TeacherID varchar(50),
)
 select *   from SubjectTB

 
Create Table TeacherTB(

ID int primary key identity(1,1),
TeacherName varchar(50),
TeacherID varchar(50),
TGender varchar(50),
TEmail varchar(50),
Tadress varchar(50),
TNumber varchar(50),
Teacherpassword varchar(50),
Date varchar(50),
TPhoto varchar(50)

)
select TeacherName from TeacherTB where TeacherID = 'E2022121'
select * from TeacherTB



select * from TeacherTB



 -- Acadamic Table 
 create table Academic 
 (

  ID int primary key identity(1,1),
  Code varchar(50),
  Course varchar(50),
  Class Varchar(50),
  Academic_Year varchar(50),
  Lecturer varchar(50),
  EMPID VARCHAR(50),
  Semester varchar(50)

 )

 select * from academic
  

  Create table student
  (
  ID int primary key identity(1,1),
  FullName varchar(50),
  StudentID varchar(50),
  Number varchar(50),
  Email varchar(50),
  Address Varchar(50),
  Gender Varchar(50),
  Password varchar(50),
  Date varchar(50),
  Faculty varchar(50),
  Department Varchar(50),
  Clas varchar(50),
  Semester Varchar(50),
  Photo varchar(50)
  )  
  

  select * from student         
  
  Create Table Result
  (
  ID int Primary key identity(1,1),
  CourseCode varchar(50),
  CourseName varchar(50),
  EMPID varchar(50),
  StudentID varchar(50),
  LecturerName Varchar(50),
  Midterm int not null,
  Final int not null,
  Activity int not null,
  Total int not null,
  StudentName varchar(50),
  StudentClass varchar(50),
  StudentDepartment varchar(50),
  StudentSemester varchar(50)
  
  )       
  
  
  select * from Result        
  Delete  from Result                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  