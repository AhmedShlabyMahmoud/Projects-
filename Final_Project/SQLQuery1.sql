-- trigger to delete when insterector delete questions he has put the questions in his course
use [Final_Project_ITI]
create trigger Trigger_Delete_Questions
on QuestionPool
After Delete
As 
begin
			Declare  @Instructor_ID int , @courseID_Inst int , 
			         @courseID_Question int ,    @Question_ID int ;

			set @Instructor_ID = (select Instructor_Id from Instructor where Instructor_Name = SUSER_NAME()) ;
			set  @courseID_Inst = (select distinct Course_Id from Instructor_Course where Instructor_Id = @Instructor_ID) ;
			set @Question_ID = (select Course_Id from deleted ) ;
			if ( @courseID_Inst = @Question_ID )
			BEGIN 
					print 'the Question has been deleted'
			END
			ELSE
			begin
			rollback
			        print 'This is Not Your Course :) '
			End
End

/*
select * from [dbo].[QuestionPool]

delete from QuestionPool
where [QuestionPool_Id] =39 ;

*/

-- trigger to update when insterector update questions he has put the questions in his course
create trigger TriggerUpdateQuestions
on QuestionPool
After update
As 
begin
			Declare  @Instructor_ID int , @courseID_Instructor int , 
			         @courseID_Question int ,    @Question_ID int ;

			set @Instructor_ID = (select Instructor_Id from Instructor where Instructor_Name = SUSER_NAME()) ;
			set  @courseID_Instructor = (select distinct Course_Id from Instructor_Course where Instructor_Id = @Instructor_ID) ;
			set @Question_ID = (select Course_Id from deleted ) ;
			if ( @courseID_Instructor = @Question_ID )
			BEGIN 
					print 'the Question has been Updated'
			END
			ELSE
			begin
			rollback
			        print 'This is Not Your Course :) '
			End
End
/*
select * from [dbo].[QuestionPool]

update  QuestionPool
set  [Question_Type]=2
where QuestionPool_Id =1;
*/


-- trigger to insert when insterector insert questions he has put the questions in his course
create trigger TriggerInsertQuestions
on QuestionPool
After Insert
As 
begin
			Declare  @Instructor_ID int , @courseID_Instructor int , 
			         @courseID_Question int ,    @Question_ID int ;

			set @Instructor_ID = (select Instructor_Id from Instructor where Instructor_Name = SUSER_NAME()) ;
			set  @courseID_Instructor = (select distinct Course_Id from Instructor_Course where Instructor_Id = @Instructor_ID) ;
			set @Question_ID = (select Course_Id from inserted ) ;
			if ( @courseID_Instructor = @Question_ID )
			BEGIN 
					print 'the Question has been inserted'
			END
			ELSE
			begin
			rollback
			        print 'This is Not Your Course :) '
			End
End

/*
select * from [dbo].[QuestionPool]

insert into  QuestionPool
values ('Do you Know me',2,3)
*/



