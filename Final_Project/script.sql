USE [master]
GO
/****** Object:  Database [Final_Project_ITI]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE DATABASE [Final_Project_ITI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'mainFile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SHALABYSQL\MSSQL\DATA\mainFile.mdf' , SIZE = 30720KB , MAXSIZE = 51200KB , FILEGROWTH = 5120KB ), 
 FILEGROUP [FILEGROUP1] 
( NAME = N'SecondaryFile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SHALABYSQL\MSSQL\DATA\SecondaryFile.ndf' , SIZE = 30720KB , MAXSIZE = 51200KB , FILEGROWTH = 5120KB ), 
 FILEGROUP [FILEGROUP2] 
( NAME = N'examFile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SHALABYSQL\MSSQL\DATA\examFile.ndf' , SIZE = 30720KB , MAXSIZE = 51200KB , FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'logFile', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SHALABYSQL\MSSQL\DATA\logFile.ldf' , SIZE = 5120KB , MAXSIZE = 20480KB , FILEGROWTH = 5120KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Final_Project_ITI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Final_Project_ITI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Final_Project_ITI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET ARITHABORT OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Final_Project_ITI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Final_Project_ITI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Final_Project_ITI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Final_Project_ITI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET RECOVERY FULL 
GO
ALTER DATABASE [Final_Project_ITI] SET  MULTI_USER 
GO
ALTER DATABASE [Final_Project_ITI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Final_Project_ITI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Final_Project_ITI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Final_Project_ITI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Final_Project_ITI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Final_Project_ITI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Final_Project_ITI', N'ON'
GO
ALTER DATABASE [Final_Project_ITI] SET QUERY_STORE = OFF
GO
USE [Final_Project_ITI]
GO
/****** Object:  User [Student]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE USER [Student] FOR LOGIN [Student] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [manager]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE USER [manager] FOR LOGIN [manager] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Instractor]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE USER [Instractor] FOR LOGIN [instractor] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedTableType [dbo].[id_questions]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE TYPE [dbo].[id_questions] AS TABLE(
	[ID] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[IDList]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE TYPE [dbo].[IDList] AS TABLE(
	[ID] [int] NULL
)
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[Instructor_Id] [int] IDENTITY(1,1) NOT NULL,
	[Instructor_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Instructor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_Id] [int] IDENTITY(1,1) NOT NULL,
	[Student_Name] [varchar](50) NOT NULL,
	[Class_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[class_name] [nvarchar](50) NOT NULL,
	[Dept_id] [int] NOT NULL,
	[track] [nvarchar](50) NOT NULL,
	[branch] [nvarchar](50) NOT NULL,
	[intake] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[class_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[instractor_class]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[instractor_class](
	[inst_class_ID] [int] IDENTITY(1,1) NOT NULL,
	[inst_id] [int] NOT NULL,
	[class_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[inst_class_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[student_class_inst]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create   view [dbo].[student_class_inst]
as
select [Student_Name],[class_name],[Instructor_Name] from [dbo].[Student] st ,[dbo].[Class] c,[dbo].[Instructor] inst,[dbo].[instractor_class] instcls
where st.Class_ID=c.class_id and instcls.class_id=c.class_id and inst.Instructor_Id=instcls.inst_id
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Course_Id] [int] IDENTITY(1,1) NOT NULL,
	[Course_Name] [nvarchar](50) NOT NULL,
	[Course_Max_Degree] [int] NOT NULL,
	[Course_Min_Degree] [int] NOT NULL,
	[Course_Description] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Course_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor_Course]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor_Course](
	[Instructor_Id] [int] NOT NULL,
	[Course_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Instructor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Course_inst]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[Course_inst]
as
select [Course_Name],[Instructor_Name] from Course c,[dbo].[Instructor] inst,[dbo].[Instructor_Course] inst_cour
where c.Course_Id=inst_cour.Course_Id and inst_cour.Instructor_Id  =inst.Instructor_Id
GO
/****** Object:  Table [dbo].[QuestionPool]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionPool](
	[QuestionPool_Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](100) NOT NULL,
	[Question_Type] [int] NOT NULL,
	[Course_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionPool_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Inst_Ques]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[Inst_Ques] as (

select Instructor_Id as 'Instractor_id' , Instructor_Name as  'Instractor_Name' , QuestionPool_Id as 'Ques_ID' , Question
from Instructor , QuestionPool
where Instructor_Id='1')

GO
/****** Object:  View [dbo].[Std_Course]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[Std_Course] as (

select  Student_Id as 'Student_id' , Student_Name as  'Student_Name' , Course_Name as 'CourseName'          
from Student ,Course
where Course_Id in ('1','3','4'))

GO
/****** Object:  View [dbo].[student_class]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   view [dbo].[student_class]
as
select [Student_Name],[class_name] from [dbo].[Student] st ,[dbo].[Class] c
where st.Class_ID=c.class_id
GO
/****** Object:  Table [dbo].[degree_question]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[degree_question](
	[studend_id] [int] NULL,
	[degree] [int] NULL,
	[course_id] [int] NULL,
	[Exam_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Department_ID] [int] IDENTITY(1,1) NOT NULL,
	[Department_Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Department_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[Exam_Id] [int] NULL,
	[Course_Id] [int] NOT NULL,
	[Instructor_Id] [int] NOT NULL,
	[Exam_Year] [int] NOT NULL,
 CONSTRAINT [Exam_PRIMARYKEY] PRIMARY KEY CLUSTERED 
(
	[Course_Id] ASC,
	[Instructor_Id] ASC,
	[Exam_Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Exam_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Details]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Details](
	[Exam_Id] [int] NOT NULL,
	[Exam_Date] [date] NULL,
	[Start_Time] [time](7) NOT NULL,
	[End_Time] [time](7) NULL,
	[Total_Time] [time](7) NULL,
 CONSTRAINT [Exam_details_PRIMARYKEY] PRIMARY KEY CLUSTERED 
(
	[Start_Time] ASC,
	[Exam_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Questions]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Questions](
	[Exam_Id] [int] NOT NULL,
	[Question_ID] [int] NOT NULL,
	[Question_Degree] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Type]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Type](
	[Exam_Id] [int] IDENTITY(1,1) NOT NULL,
	[Exam_Type] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Exam_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[examQuestion]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examQuestion](
	[Exam_id] [int] NULL,
	[question] [int] NULL,
	[exam_type] [nvarchar](50) NULL,
	[course_id] [int] NULL,
	[degree] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[id_questions]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[id_questions](
	[ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Instructor]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Instructor](
	[QuestionPool_Id] [int] NOT NULL,
	[Instructor_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionPool_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_true_false]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_true_false](
	[Question_Id] [int] NOT NULL,
	[Correct] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Question_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionMCQ]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionMCQ](
	[Question_Id] [int] NOT NULL,
	[Answer1] [varchar](50) NOT NULL,
	[Answer2] [varchar](50) NOT NULL,
	[Answer3] [varchar](50) NOT NULL,
	[Answer4] [varchar](50) NOT NULL,
	[Correct] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Question_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_answer]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_answer](
	[Exam_Id] [int] NOT NULL,
	[Question_Id] [int] NOT NULL,
	[Student_Id] [int] NOT NULL,
	[answer] [varchar](1) NULL,
 CONSTRAINT [Std_Ans_PRIMARYKEY] PRIMARY KEY CLUSTERED 
(
	[Question_Id] ASC,
	[Student_Id] ASC,
	[Exam_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Course]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Course](
	[Student_Id] [int] IDENTITY(1,1) NOT NULL,
	[Course_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Exam_Course]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Exam_Course](
	[Course_Id] [int] NOT NULL,
	[Exam_Id] [int] NOT NULL,
	[Student_Id] [int] NOT NULL,
	[Degree] [int] NULL,
	[inst_id] [int] NULL,
 CONSTRAINT [PK_Student_Exam_Course] PRIMARY KEY CLUSTERED 
(
	[Course_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [instrac]    Script Date: 1/30/2022 1:19:25 PM ******/
CREATE NONCLUSTERED INDEX [instrac] ON [dbo].[Instructor]
(
	[Instructor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [Department_ID_Class] FOREIGN KEY([Dept_id])
REFERENCES [dbo].[Department] ([Department_ID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [Department_ID_Class]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [Exam_Course_FOREIGNKEY] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Course_Id])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [Exam_Course_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [Exam_Student_FOREIGNKEY] FOREIGN KEY([Instructor_Id])
REFERENCES [dbo].[Instructor] ([Instructor_Id])
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [Exam_Student_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam]  WITH CHECK ADD  CONSTRAINT [ExamType_FOREIGNKEY] FOREIGN KEY([Exam_Id])
REFERENCES [dbo].[Exam_Type] ([Exam_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exam] CHECK CONSTRAINT [ExamType_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam_Details]  WITH CHECK ADD  CONSTRAINT [Exam_detail_FOREIGNKEY] FOREIGN KEY([Exam_Id])
REFERENCES [dbo].[Exam_Type] ([Exam_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exam_Details] CHECK CONSTRAINT [Exam_detail_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam_Questions]  WITH CHECK ADD  CONSTRAINT [ExamType_Question_FOREIGNKEY] FOREIGN KEY([Exam_Id])
REFERENCES [dbo].[Exam_Type] ([Exam_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Exam_Questions] CHECK CONSTRAINT [ExamType_Question_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam_Questions]  WITH CHECK ADD  CONSTRAINT [QUESTION_ID_EXAM_FOREIGNKEY] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[QuestionPool] ([QuestionPool_Id])
GO
ALTER TABLE [dbo].[Exam_Questions] CHECK CONSTRAINT [QUESTION_ID_EXAM_FOREIGNKEY]
GO
ALTER TABLE [dbo].[instractor_class]  WITH CHECK ADD  CONSTRAINT [ID_Class] FOREIGN KEY([class_id])
REFERENCES [dbo].[Class] ([class_id])
GO
ALTER TABLE [dbo].[instractor_class] CHECK CONSTRAINT [ID_Class]
GO
ALTER TABLE [dbo].[instractor_class]  WITH CHECK ADD  CONSTRAINT [inst_ID_Class] FOREIGN KEY([inst_id])
REFERENCES [dbo].[Instructor] ([Instructor_Id])
GO
ALTER TABLE [dbo].[instractor_class] CHECK CONSTRAINT [inst_ID_Class]
GO
ALTER TABLE [dbo].[Instructor_Course]  WITH CHECK ADD  CONSTRAINT [Course_relation] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Course_Id])
GO
ALTER TABLE [dbo].[Instructor_Course] CHECK CONSTRAINT [Course_relation]
GO
ALTER TABLE [dbo].[Instructor_Course]  WITH CHECK ADD  CONSTRAINT [INSt_relation] FOREIGN KEY([Instructor_Id])
REFERENCES [dbo].[Instructor] ([Instructor_Id])
GO
ALTER TABLE [dbo].[Instructor_Course] CHECK CONSTRAINT [INSt_relation]
GO
ALTER TABLE [dbo].[Question_Instructor]  WITH CHECK ADD  CONSTRAINT [Question_Ins_relation] FOREIGN KEY([Instructor_ID])
REFERENCES [dbo].[Instructor] ([Instructor_Id])
GO
ALTER TABLE [dbo].[Question_Instructor] CHECK CONSTRAINT [Question_Ins_relation]
GO
ALTER TABLE [dbo].[Question_Instructor]  WITH CHECK ADD  CONSTRAINT [QuestionPool_Id_relation] FOREIGN KEY([QuestionPool_Id])
REFERENCES [dbo].[QuestionPool] ([QuestionPool_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question_Instructor] CHECK CONSTRAINT [QuestionPool_Id_relation]
GO
ALTER TABLE [dbo].[Question_true_false]  WITH CHECK ADD  CONSTRAINT [Questf_Answer_relation] FOREIGN KEY([Question_Id])
REFERENCES [dbo].[QuestionPool] ([QuestionPool_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question_true_false] CHECK CONSTRAINT [Questf_Answer_relation]
GO
ALTER TABLE [dbo].[QuestionMCQ]  WITH CHECK ADD  CONSTRAINT [Quesmcq_Answer_relation] FOREIGN KEY([Question_Id])
REFERENCES [dbo].[QuestionPool] ([QuestionPool_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuestionMCQ] CHECK CONSTRAINT [Quesmcq_Answer_relation]
GO
ALTER TABLE [dbo].[QuestionPool]  WITH CHECK ADD  CONSTRAINT [Question_Course_FOREIGNKEY] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Course_Id])
GO
ALTER TABLE [dbo].[QuestionPool] CHECK CONSTRAINT [Question_Course_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_answer]  WITH CHECK ADD  CONSTRAINT [Std_Ans_Ex_FOREIGNKEY] FOREIGN KEY([Exam_Id])
REFERENCES [dbo].[Exam_Type] ([Exam_Id])
GO
ALTER TABLE [dbo].[Student_answer] CHECK CONSTRAINT [Std_Ans_Ex_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_answer]  WITH CHECK ADD  CONSTRAINT [Std_Ans_Qs_FOREIGNKEY] FOREIGN KEY([Question_Id])
REFERENCES [dbo].[QuestionPool] ([QuestionPool_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student_answer] CHECK CONSTRAINT [Std_Ans_Qs_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_answer]  WITH CHECK ADD  CONSTRAINT [Std_Ans_St_FOREIGNKEY] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Student] ([Student_Id])
GO
ALTER TABLE [dbo].[Student_answer] CHECK CONSTRAINT [Std_Ans_St_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [Std_Course_relation] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Course_Id])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [Std_Course_relation]
GO
ALTER TABLE [dbo].[Student_Course]  WITH CHECK ADD  CONSTRAINT [Std_relation] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Student] ([Student_Id])
GO
ALTER TABLE [dbo].[Student_Course] CHECK CONSTRAINT [Std_relation]
GO
ALTER TABLE [dbo].[Student_Exam_Course]  WITH CHECK ADD  CONSTRAINT [Exam_Details_FOREIGNKEY] FOREIGN KEY([Exam_Id])
REFERENCES [dbo].[Exam_Type] ([Exam_Id])
GO
ALTER TABLE [dbo].[Student_Exam_Course] CHECK CONSTRAINT [Exam_Details_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_Exam_Course]  WITH CHECK ADD  CONSTRAINT [Exam_SId_Course_FOREIGNKEY] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Course_Id])
GO
ALTER TABLE [dbo].[Student_Exam_Course] CHECK CONSTRAINT [Exam_SId_Course_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Student_Exam_Course]  WITH CHECK ADD  CONSTRAINT [Exam_Std_FOREIGNKEY] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Student] ([Student_Id])
GO
ALTER TABLE [dbo].[Student_Exam_Course] CHECK CONSTRAINT [Exam_Std_FOREIGNKEY]
GO
ALTER TABLE [dbo].[Exam_Type]  WITH CHECK ADD  CONSTRAINT [ExamType_check] CHECK  (([Exam_Type]='Corrective' OR [Exam_Type]='Exam'))
GO
ALTER TABLE [dbo].[Exam_Type] CHECK CONSTRAINT [ExamType_check]
GO
ALTER TABLE [dbo].[Question_true_false]  WITH CHECK ADD  CONSTRAINT [CorrectTF_check] CHECK  (([Correct]='T' OR [Correct]='F'))
GO
ALTER TABLE [dbo].[Question_true_false] CHECK CONSTRAINT [CorrectTF_check]
GO
ALTER TABLE [dbo].[QuestionMCQ]  WITH CHECK ADD  CONSTRAINT [CorrectMCQ_check] CHECK  (([Correct]='4' OR [Correct]='3' OR [Correct]='2' OR [Correct]='1'))
GO
ALTER TABLE [dbo].[QuestionMCQ] CHECK CONSTRAINT [CorrectMCQ_check]
GO
/****** Object:  StoredProcedure [dbo].[CalculateDegree]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROC [dbo].[CalculateDegree] @Student_ID INT, @Exam_ID INT
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
GO
/****** Object:  StoredProcedure [dbo].[Create_Exam]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[Create_Exam]
@tfQusion_Number int, 
@mcqQuestion_number int, 
@Question_Degree int, 
@Exam_Type_Added nvarchar(50),
@Exam_Year INT,
@Exam_Date date,
@Exam_Start_Time time,
@Exam_End_Time time,
@Exam_Total_Time time,
@inst_name  nvarchar(50),
@List VARCHAR(MAX) = null

AS

DECLARE @MaxDegree INT,@SumQuestionDegrees INT,@Current_Exam_ID INT,@Inst_Course_ID INT,@Instructor_ID INT;
SET @SumQuestionDegrees = 0;
SET @Instructor_ID = (SELECT Instructor_Id FROM Instructor where Instructor_Name = @inst_name)
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
if @Inst_Course_ID is null
begin set @Inst_Course_ID=1 end
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
GO
/****** Object:  StoredProcedure [dbo].[Create_Exam1]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[Create_Exam1] 
@Exam_Type_Added nvarchar(50),
@Exam_Year INT,
@Exam_Date date,
@Exam_Start_Time time,
@Exam_End_Time time,
@Exam_Total_Time time,
@inst_name  nvarchar(50)
AS
DECLARE @MaxDegree INT,@SumQuestionDegrees INT,@Current_Exam_ID INT,@Inst_Course_ID INT,@Instructor_ID INT,@n int =1,
@x int ,
@y int ,
@degree int
SET @SumQuestionDegrees = 0;
SET @Instructor_ID = (SELECT Instructor_Id FROM Instructor where Instructor_Name = @inst_name)
SET @Inst_Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id =@Instructor_ID)
SET @MaxDegree = (SELECT Course_Max_Degree FROM Course WHERE Course_ID = @Inst_Course_ID)
BEGIN
set @x=(select count(qi.QuestionPool_Id) from [dbo].[Question_Instructor] qi where qi.Instructor_ID= @Instructor_ID)
insert into id_questions values (@x)
if @x>=1
set @degree=(100/@x)
while  @n<=@x
begin
set @y=((select top (@n) qi.QuestionPool_Id from [dbo].[Question_Instructor] qi where qi.Instructor_ID= @Instructor_ID)
except
(select top (@n-1) qi.QuestionPool_Id from [dbo].[Question_Instructor] qi where qi.Instructor_ID= @Instructor_ID)
)
insert into examQuestion
values(@Exam_Year,@y,@Exam_Type_Added,@Inst_Course_ID,@degree)
insert into id_questions values (@y)
set @n=@n+1
end 
end
GO
/****** Object:  StoredProcedure [dbo].[CreateExam]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[CreateExam]
@tfQusion_Number int, 
@mcqQuestion_number int, 
@Question_Degree int, 
@Exam_Type_Added nvarchar(50),
@Exam_Year INT,
@Exam_Date date,
@Exam_Start_Time time,
@Exam_End_Time time,
@Exam_Total_Time time,
@inst_name  nvarchar(50),
@List VARCHAR(MAX) = null

AS

DECLARE @MaxDegree INT,@SumQuestionDegrees INT,@Current_Exam_ID INT,@Inst_Course_ID INT,@Instructor_ID INT;
SET @SumQuestionDegrees = 0;
SET @Instructor_ID = (SELECT Instructor_Id FROM Instructor where Instructor_Name = @inst_name)
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
if @Inst_Course_ID is null
begin set @Inst_Course_ID=1 end
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
GO
/****** Object:  StoredProcedure [dbo].[SelectStudents]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SelectStudents] @Exam_ID INT,@Course_ID INT, @Student_ID INT
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

GO
/****** Object:  StoredProcedure [dbo].[ShowCourseQuestions]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowCourseQuestions]
AS
Select * from QuestionPool where Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id = (SELECT Instructor_Id FROM Instructor where Instructor_Name = SUSER_NAME())) 

GO
/****** Object:  StoredProcedure [dbo].[ShowCourseStudents]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowCourseStudents]
AS
Select Student_Id from Student_Course where Course_ID = (SELECT Course_Id FROM Instructor_Course where Instructor_Id = (SELECT Instructor_Id FROM Instructor where Instructor_Name = SUSER_NAME())) 


GO
/****** Object:  StoredProcedure [dbo].[Student_answer_in_Exam]    Script Date: 1/30/2022 1:19:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[Student_answer_in_Exam]
@Exam_year int,
@Student_id int,
@Cours_id int,
@qustion_id int,
@answer nvarchar(10),
@degree int
AS

if @answer=(select [Correct] from [dbo].[QuestionMCQ] where [Question_Id]=@qustion_id)
update   degree_question
set degree+=@degree
where [studend_id]=@Student_id and @Exam_year=[Exam_id] 

GO
USE [master]
GO
ALTER DATABASE [Final_Project_ITI] SET  READ_WRITE 
GO
