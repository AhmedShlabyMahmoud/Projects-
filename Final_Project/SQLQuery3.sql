
use Final_Project_ITI
CREATE TABLE Instructor
(
	Instructor_Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL ,
	Instructor_Name nVARCHAR(50) NOT NULL ,
	Manger_ID int   ,
	CONSTRAINT Instructor_fk foreign KEY (Manger_ID) REFERENCES Instructor(Instructor_Id)
)

CREATE TABLE Course
(
	Course_Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Course_Name nVARCHAR(50) NOT NULL	,
	Course_Max_Degree INT NOT NULL,
	Course_Min_Degree INT NOT NULL,
	Course_Description nVARCHAR(100),
)
CREATE TABLE Instructor_Course
(
	Instructor_Id INT ,
	Course_Id INT,
	CONSTRAINT INSt_Courset_primarykey PRIMARY KEY (Course_Id,Instructor_Id),
	CONSTRAINT INSt_relation FOREIGN KEY (Instructor_Id) REFERENCES Instructor (Instructor_Id),
	CONSTRAINT Course_relation FOREIGN KEY (Course_Id) REFERENCES Course (Course_Id)
)




 
CREATE TABLE Department
(
	Department_ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	Branch_Name NVARCHAR(50) NOT NULL,
	Branch_Intake int NOT NULL default '100' ,
	Track NVARCHAR(50) NOT NULL,
) 
CREATE TABLE Class
(
	Class_id INT ,
	Class_Name NVARCHAR(40) NOT NULL,
	Department_ID INT ,
	CONSTRAINT Class11_PRIMARYKEY PRIMARY KEY (Class_id) ,
	CONSTRAINT Department_ID_FOREIGNKEY FOREIGN KEY (Department_ID) REFERENCES Department (Department_ID) on delete cascade
) 

CREATE TABLE Student
(
	Student_Id INT PRIMARY KEY IDENTITY(1,1),
	Student_Name VARCHAR(50) NOT NULL	,
    Class_id INT ,
	CONSTRAINT Student_Class_id FOREIGN KEY (Class_id) REFERENCES Class(Class_id)
)







CREATE TABLE Student_Course
(
	Student_Id INT ,
	Course_Id INT,
	CONSTRAINT Student_Course_PRIMARYKEY PRIMARY KEY (Course_Id,Student_Id),
	CONSTRAINT Student_relation FOREIGN KEY (Student_Id) REFERENCES Student (Student_Id),
	CONSTRAINT Student_Course_relation FOREIGN KEY (Course_Id) REFERENCES Course (Course_Id)
)
CREATE TABLE QuestionPool
(
	QuestionPool_Id INT PRIMARY KEY IDENTITY(1,1),
	Question nVARCHAR(100) NOT NULL	,
	Question_Type INT NOT NULL,
	Course_ID INT NOT NULL,
	CONSTRAINT Question_Course_FOREIGNKEY FOREIGN KEY (Course_Id) REFERENCES Course (Course_Id)
) 

CREATE TABLE Question_Instructor
(
    Question_Instructor INT PRIMARY KEY IDENTITY(1,1),
	QuestionPool_Id INT NOT NULL,
	Instructor_ID INT,
	CONSTRAINT Question_Instructor_relation FOREIGN KEY (Instructor_ID) REFERENCES Instructor (Instructor_ID),
	CONSTRAINT QuestionPool_Id_relation FOREIGN KEY (QuestionPool_Id) REFERENCES QuestionPool (QuestionPool_Id) ON DELETE CASCADE,
)



CREATE TABLE QuestionMCQ
(
	Question_Id INT primary key,
	Answer1 NVARCHAR(50) NOT NULL,
	Answer2 NVARCHAR(50) NOT NULL,
	Answer3 NVARCHAR(50) NOT NULL,
	Answer4 NVARCHAR(50) NOT NULL,
    Correct  NVARCHAR(20) NOT NULL,
	CONSTRAINT Quesmcq_Answer_relation FOREIGN KEY (Question_Id) REFERENCES QuestionPool (QuestionPool_Id) on delete cascade,
	CONSTRAINT CorrectMCQ_check CHECK (Correct IN('1','2','3','4'))
)
CREATE TABLE Question_true_false
(
	Question_Id INT primary key,
	Correct NVARCHAR(1) NOT NULL,
	CONSTRAINT Questf_Answer_relation FOREIGN KEY (Question_Id) REFERENCES QuestionPool (QuestionPool_Id) on delete cascade,
	CONSTRAINT CorrectTF_check CHECK (Correct IN('F','T'))
)


CREATE TABLE Exam_Type
(
	Exam_Id INT PRIMARY KEY IDENTITY(1,1),
	Exam_Type NVARCHAR(50) NOT NULL,
	CONSTRAINT ExamType_check CHECK (Exam_Type in ('Exam' , 'Corrective')),
) 




CREATE TABLE Exam
(
	Exam_Id INT ,
	Course_Id INT NOT NULL,
	Instructor_ID INT NOT NULL,
	Exam_Date datetime,
	Start_Time datetime ,
	End_Time datetime ,
	Exam_Year INT NOT NULL,
	CONSTRAINT Exam_PRIMARYKEY PRIMARY KEY (Course_Id,Instructor_ID,Exam_Year),
	CONSTRAINT ExamType_FOREIGNKEY FOREIGN KEY (Exam_Id) REFERENCES Exam_Type (Exam_Id) on delete cascade,
	CONSTRAINT Exam_Course_FOREIGNKEY FOREIGN KEY (Course_Id) REFERENCES Course (Course_Id),
	CONSTRAINT Exam_Student_FOREIGNKEY FOREIGN KEY (Instructor_ID) REFERENCES Instructor (Instructor_ID),
)


CREATE TABLE Student_Exam
(
    Student_Exam INT  PRIMARY KEY IDENTITY(1,1),
	Exam_Id INT ,
	Student_Id INT ,
	Degree INT ,
	CONSTRAINT Exam_Details_FOREIGNKEY FOREIGN KEY (Exam_Id) REFERENCES Exam_Type (Exam_Id),
	CONSTRAINT Exam_Std_FOREIGNKEY FOREIGN KEY (Student_Id) REFERENCES Student (Student_Id),
) 





CREATE TABLE Student_answer
(
	Exam_Id INT not null,
	Question_Id INT NOT NULL,
	Student_Id INT NOT NULL,
	answer nVARCHAR(20) ,
	CONSTRAINT Student_answer_PRIMARYKEY PRIMARY KEY (Question_Id,Student_Id,Exam_Id),
	CONSTRAINT  Student_answer_Ex_FOREIGNKEY FOREIGN KEY (Exam_Id) REFERENCES Exam_Type (Exam_Id),
	CONSTRAINT  Student_answer_Qs_FOREIGNKEY FOREIGN KEY (Question_Id) REFERENCES QuestionPool (QuestionPool_Id) ON DELETE CASCADE,
	CONSTRAINT  Student_answer_St_FOREIGNKEY FOREIGN KEY (Student_Id) REFERENCES Student (Student_Id),
) 


CREATE TABLE Exam_Questions
(
	Exam_Id INT NOT NULL,
	Question_ID INT NOT NULL,
	Question_Degree INT NOT NULL,
	CONSTRAINT Exam_Question_PRIMARYKEY PRIMARY KEY (Exam_Id,Question_ID),
	CONSTRAINT ExamType_Question_FOREIGNKEY FOREIGN KEY (Exam_Id) REFERENCES Exam_Type (Exam_Id) on delete cascade,
	CONSTRAINT QUESTION_ID_EXAM_FOREIGNKEY FOREIGN KEY (Question_ID) REFERENCES QuestionPool (QuestionPool_Id),
)
create table Department
(
Department_ID int PRIMARY KEY IDENTITY(1,1),
 Department_Name nvarchar(50) not null 
)

create table Class
(
class_id int primary key identity(1,1),
class_name nvarchar(50) not null ,
Dept_id int not null ,
track nvarchar(50) not null , branch nvarchar(50)not null ,
intake int not null 
CONSTRAINT Department_ID_Class FOREIGN KEY (Dept_id) REFERENCES Department (Department_ID),
)


create table instractor_class
(
inst_class_ID int primary key identity(1,1),
inst_id int not null ,
class_id int not null 
CONSTRAINT inst_ID_Class FOREIGN KEY (inst_id) REFERENCES Instructor (Instructor_ID),
CONSTRAINT ID_Class FOREIGN KEY (class_id) REFERENCES Class (class_id),

)
  table id_questions
(
  ID INT
)
CREATE  table degree_question
(
[studend_id] int ,[degree] int ,[course_id] int 

,Exam_id int 
)






 














