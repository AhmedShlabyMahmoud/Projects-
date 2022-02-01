create or alter view student_class
as
select [Student_Name],[class_name] from [dbo].[Student] st ,[dbo].[Class] c
where st.Class_ID=c.class_id

select * from student_class

create or alter view student_class_inst
as
select [Student_Name],[class_name],[Instructor_Name] from [dbo].[Student] st ,[dbo].[Class] c,[dbo].[Instructor] inst,[dbo].[instractor_class] instcls
where st.Class_ID=c.class_id and instcls.class_id=c.class_id and inst.Instructor_Id=instcls.inst_id

select * from student_class_inst

create or alter view Course_inst
as
select [Course_Name],[Instructor_Name] from Course c,[dbo].[Instructor] inst,[dbo].[Instructor_Course] inst_cour
where c.Course_Id=inst_cour.Course_Id and inst_cour.Instructor_Id  =inst.Instructor_Id

select * from Course_inst
create or alter view [Inst_Ques] as (

select Instructor_Id as 'Instractor_id' , Instructor_Name as  'Instractor_Name' , QuestionPool_Id as 'Ques_ID' , Question
from Instructor , QuestionPool
where Instructor_Id='1')

select * from [Inst_Ques]








insert into [dbo].[Student]
values ('shalaaaaby') 
















---------------------------------------------------------------------------------------

-- create view to get student course 

create or alter view Std_Course as (

select  Student_Id as 'Student_id' , Student_Name as  'Student_Name' , Course_Name as 'CourseName'          
from Student ,Course
where Course_Id in ('1','3','4'))

select * from [Std_Course]