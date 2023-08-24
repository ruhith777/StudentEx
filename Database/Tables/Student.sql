create table Student
(
Id int Identity(1,1) NOT NULL,
Name varchar(20) NOT NULL,
Branch varchar(10) NOT NULL,
RollNo int NOT NULL,
DoB datetime,
City varchar(10),
constraint Pk_student primary key(Id)
);