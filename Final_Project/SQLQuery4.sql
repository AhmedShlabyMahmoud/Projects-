ALTER TABLE Student_answer DROP CONSTRAINT Exam_Details_FOREIGNKEY;

insert into [dbo].[Instructor] 
values 
		('Ahmed',2) ,
		('Ali',2) , 
		('Alaa',2) , 
		('Alyaa',2) , 
		('Alyia',2) , 
		('shalaby',5) , 
		('omar',5) , 
		('amr',5) , 
		('amaar',5)

select * from [dbo].[Instructor]---id=9
------------------------------------------------------1
 insert into [dbo].[Department]
values ('minia' ,100,'.Net') ,
		('Smart' ,100,'.Net') ,('minia',100 ,'.Net') 

select * from [dbo].[Department]

---------------------------------------------------2
 insert into [dbo].[Class]
values ('Group_1' ,1) ,
		('Group_2' ,1),('Group_1' ,2),('Group_2' ,2)

select * from [dbo].[Class]



-----------------------------------3
insert into [dbo].[Student]
values ('Bahaa',1) ,
		('Mohamed',1) ,
		('Mahmoud',1) , 
		('Alaa',1) , 
		('khaled',1) , 
		('Zaki',2) , 
		('Asharaf',2) , 
		('sara',3) , 
		('yara',3) , 
		('shika',4)

select * from [dbo].[Student]

----------------------------------------------4
insert into [dbo].[Course]
values ('.Net' , 100,50,'.Net Course') ,
		('C#' , 100,50,' C# Course') ,
		('Html' ,100,50,'Html Course') ,
		('Css' , 100,50,'Css Course') ,
		('JS' , 100,50,'JS Course') 
	
select * from [dbo].[Course]
------------------------------------------------5
insert into [dbo].[QuestionPool]
values ('what Do you know about .net?' , 1 ,1) ,
	   ('what Do you know about c# ?' , 1 ,2) ,
       ('what Do you know about html?' , 1 ,3) ,
	   ('what Do you know about css ?' , 1 ,4) ,
	   ('what Do you know about JS ?' , 1 ,5) ,

	 
	(' Do you know .net' , 2,1),
	(' Do you know C#' , 2,2),
	(' Do you know html' , 2,3),
	(' Do you know css', 2,4),
	(' Do you know js' , 2,5)
	
	
	select * from [dbo].[QuestionPool] --id=10
--------------------------------------------------6

insert into [dbo].Question_Instructor
values(1,1),
	  (2,2),
	  (3,3),
	  (4,4),
	  (5,5),
	  (6,6),
	  (7,7),
	  (8,8),
	  (9,9)
	 
	 select * from  [dbo].Question_Instructor ---id=9 Instructor


	 ------------------------------------------------7
insert into [dbo].[QuestionMCQ]
values (3,'X','W','Y','Z','4'),
       (4,'11','22','33','44','1'),
       (5,'Low','Low','Low','Low','4'),
       
-- qID - answers 1 - 4  -- Correct answer
select *  from [dbo].[QuestionMCQ]
insert into [dbo].[Question_true_false]
values (6,'T'),
       (7,'T'),
       (8,'F'),
       (9,'F'),
       (10,'F')
        select * from [dbo].[Question_true_false]
		-----------------------------------------------------------------
		--------------------------------------------------------
-- qid - correct answer
select * from [dbo].[Exam_Type]
insert into [dbo].[Exam_Type]
values ('Exam'),
       ('Corrective')
      
--exam -- corrective

insert into [dbo].[Exam]
values (3,3,3,'2022-10-1 9:00:00','2022-10-1 9:00:00','2022-10-1 11:00:00',2021),
(2,2,2,'2022-10-1 9:00:00','2022-10-1 9:00:00','2022-10-1 11:00:00',2020)
    
    
  
     
-- exam ID - COURSE ID  INST ID  EXAM YEAR
select * from [dbo].[Exam]

------------------------------------------------

select * from [dbo].[Student_Exam]
	  
insert into [dbo].[Student_Exam]
values (2,2,80),
(2,3,90),(3,4,70),(1,5,99),
       (2,4,55)


       



  select *from [dbo].[Student_answer]
	  ALTER TABLE Student_answer DROP CONSTRAINT Student_answer_Ex_FOREIGNKEY;

	  
insert into [dbo].[Student_answer]
values (1,1,2,'A'),
       (2,2,4,'2'),
       (3,3,3,'3')
   


	   	   Select * From [dbo].[Student_answer]
	 

insert into Department
values('.net'),('php')
insert into Class
values('group_1',1,'back-end','minia',42),
('group_1',2,'front-end','smart',43)

insert into instractor_class
values(1,1),(2,2)
--instractor class
