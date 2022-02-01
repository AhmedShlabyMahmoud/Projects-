create PROCEDURE CreateExam @tfQusion_Number int, 
@mcqQuestion_number int, 
@Question_Degree int, 
@Exam_Type_Added nvarchar(50),
@Exam_Year INT,
@Exam_Date date,
@Exam_Start_Time time,
@Exam_End_Time time,
@Exam_Total_Time time,
@List VARCHAR(MAX) = null

AS
DECLARE @MaxDegree INT,@SumQuestionDegrees INT,@Current_Exam_ID INT,@Inst_Course_ID INT,@Instructor_ID INT;
SET @SumQuestionDegrees = 0;
SET @Instructor_ID = (SELECT Instructor_Id FROM Instructor where Instructor_Name = SUSER_NAME())
SET @Inst_Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id =@Instructor_ID)
SET @MaxDegree = (SELECT Course_Max_Degree FROM Course WHERE Course_ID = @Inst_Course_ID)
IF (((@mcqQuestion_number) + (@tfQusion_Number))*(@Question_Degree) > @MaxDegree)
BEGIN 
	  RAISERROR('THE DEGREES OF THE QUESTION MORE THAN THE COURSE MAX DEGREE PLEASE CHOOSE LESS QUESTIONS', 18, 1)
	  return 404;
END
ELSE
BEGIN
-- CREATE EXAM
Insert into Exam_Type
Values(@Exam_Type_Added)
SET @Current_Exam_ID = (SELECT TOP 1 Exam_Id FROM Exam_Type ORDER BY Exam_Id DESC)
INSERT INTO Exam
VALUES(@Current_Exam_ID, @Inst_Course_ID,1,@Exam_Year)
INSERT INTO Exam_Details
VALUES(@Current_Exam_ID,@Exam_Date,@Exam_Start_Time,@Exam_End_Time,@Exam_Total_Time)


WHILE ( @SumQuestionDegrees < @MaxDegree)
BEGIN
	IF (@List is  null)
	BEGIN
		DECLARE @TEMP_NUMBER_mcq INT;
		SET @TEMP_NUMBER_mcq = (SELECT TOP 1 QuestionPool_Id FROM QuestionPool WHERE Question_Type = 1 AND Course_ID = @Inst_Course_ID ORDER BY NEWID());
			IF ( @TEMP_NUMBER_mcq not in (SELECT Question_ID from Exam_Questions where Exam_Id = @Current_Exam_ID) AND @mcqQuestion_number != 0)
				BEGIN
					SET @SumQuestionDegrees = @SumQuestionDegrees + @Question_Degree
					INSERT INTO Exam_Questions
					VALUES(@Current_Exam_ID,@TEMP_NUMBER_mcq,@Question_Degree)
					SET @mcqQuestion_number = @mcqQuestion_number - 1
				END
		DECLARE @TEMP_NUMBER_tf INT;
		SET @TEMP_NUMBER_tf = (SELECT TOP 1 QuestionPool_Id FROM QuestionPool WHERE Question_Type = 2 AND Course_ID = @Inst_Course_ID ORDER BY NEWID());
			IF ( @TEMP_NUMBER_tf not in (SELECT Question_ID from Exam_Questions where Exam_Id = @Current_Exam_ID) AND @tfQusion_Number != 0)
				BEGIN
					SET @SumQuestionDegrees = @SumQuestionDegrees + @Question_Degree
					INSERT INTO Exam_Questions
					VALUES(@Current_Exam_ID,@TEMP_NUMBER_tf,@Question_Degree)
					SET @tfQusion_Number = @tfQusion_Number - 1
				END
			IF (@tfQusion_Number = 0 AND @mcqQuestion_number = 0)
			BEGIN
				BREAK
			END
	END
	
END
END
----------------------------------------------------------------------
----------------------------------------------------------------------
-- proc to select student to the exam

CREATE PROC SelectStudents @Exam_ID INT,@Course_ID INT, @Student_ID INT
AS
IF (@Course_ID = (SELECT Course_Id FROM Student_Course WHERE @Student_ID = Student_Id) AND @Course_ID = (SELECT Course_Id FROM Exam WHERE Exam_Id = @Exam_ID))
BEGIN
INSERT INTO Student_Exam_Course
VALUES(@Exam_ID,@Course_ID,@Student_ID,null)
END
ELSE
BEGIN
	RAISERROR('This student is not listed in this course please add another one',18,1)
END

------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------

-- proc to calc student degree 

create or alter PROC CalculateDegree @Student_ID INT, @Exam_ID INT
As
Select *
Into   #Temp
From   Student_answer
where Exam_Id = @Exam_ID AND @Student_ID = Student_Id

Declare @Id int,@total_degree int = 0
WHILE EXISTS(SELECT * FROM #Temp)
Begin
    Select Top 1 @Id = Question_ID From #Temp
		if((Select Question_Type FROM QuestionPool where QuestionPool_Id = @Id) = 1)
	begin
		if((select Correct from QuestionMCQ where Question_Id = @Id) = (select answer from Student_answer where Question_Id = 1 AND Exam_Id = @Exam_ID ))
			SET @total_degree += (select Question_Degree from Exam_Questions where Question_ID = @Id AND Exam_Id = @Exam_ID)
	end
	else
	begin
		if((select Correct from Question_true_false where Question_Id = @Id) = (select answer from Student_answer where Question_Id = @Id  AND Exam_Id = @Exam_ID))
				SET @total_degree += (select Question_Degree from Exam_Questions where Question_ID = @Id AND Exam_Id = @Exam_ID)
	end
    Delete #Temp Where Question_ID = @Id

End


UPDATE Student_Exam_Course
SET Degree = @total_degree
WHERE Student_Id = @Student_ID AND Exam_Id = @Exam_ID
-----------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------
-- proc to get student course 
CREATE PROCEDURE ShowCourseQuestions
AS
Select * from QuestionPool where Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id = (SELECT Instructor_Id FROM Instructor where Instructor_Name = SUSER_NAME())) 

exec ShowCourseQuestions


--------------------------------------------------------------------------------------------
--- proc to show student course 

CREATE PROCEDURE ShowCourseStudents
AS
Select Student_Id from Student_Course where Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id = (SELECT Instructor_Id FROM Instructor where Instructor_Name = SUSER_NAME())) 


exec ShowCourseStudents-- 1,4,5,6,10


------------------------------------------------


exec ShowCourseQuestions


exec CreateExam 3, 2, 10, 'Exam', 2047, '2022-01-30', '9:00:00', '12:00:00',  '2:20:35' 

exec SelectStudents 24,1,1 -- select student exam course error 11,1,2

insert into [dbo].[Student_answer]
values (24,1,1,'1')


exec CalculateDegree 1,24 --important 


select * from [dbo].[Student_Exam_Course]





exec CreateExam 3, 2, 10, 'Exam', 2051, '2022-9-30', '9:00:00', '12:00:00',  '2:20:35' ,'1,7,11,19,21,24,25'

--------------------------
