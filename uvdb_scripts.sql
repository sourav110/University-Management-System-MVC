USE [master]
GO
/****** Object:  Database [UVDbGtx]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE DATABASE [UVDbGtx]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UVDbGtx', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UVDbGtx.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UVDbGtx_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UVDbGtx_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UVDbGtx] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UVDbGtx].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UVDbGtx] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UVDbGtx] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UVDbGtx] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UVDbGtx] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UVDbGtx] SET ARITHABORT OFF 
GO
ALTER DATABASE [UVDbGtx] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UVDbGtx] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UVDbGtx] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UVDbGtx] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UVDbGtx] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UVDbGtx] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UVDbGtx] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UVDbGtx] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UVDbGtx] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UVDbGtx] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UVDbGtx] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UVDbGtx] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UVDbGtx] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UVDbGtx] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UVDbGtx] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UVDbGtx] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UVDbGtx] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [UVDbGtx] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UVDbGtx] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UVDbGtx] SET  MULTI_USER 
GO
ALTER DATABASE [UVDbGtx] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UVDbGtx] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UVDbGtx] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UVDbGtx] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UVDbGtx]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AllocatedClassrooms]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocatedClassrooms](
	[AllocatedClassroomId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[FromTime] [nvarchar](max) NOT NULL,
	[ToTime] [nvarchar](max) NOT NULL,
	[IsAllocated] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AllocatedClassrooms] PRIMARY KEY CLUSTERED 
(
	[AllocatedClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignCourses]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignCourses](
	[AssignCourseId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CreditToBeTaken] [float] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AssignCourses] PRIMARY KEY CLUSTERED 
(
	[AssignCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](8000) NOT NULL,
	[CourseName] [varchar](8000) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[CourseCredit] [float] NOT NULL,
	[AssignedTo] [nvarchar](max) NULL,
	[IsAssigned] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Days]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Days](
	[DayId] [int] IDENTITY(1,1) NOT NULL,
	[DayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Days] PRIMARY KEY CLUSTERED 
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](7) NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Designations] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnrollCourses]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourses](
	[EnrollCourseId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[GradeLetter] [nvarchar](max) NULL,
	[IsGraded] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EnrollCourses] PRIMARY KEY CLUSTERED 
(
	[EnrollCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grades]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[GradeLetter] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Grades] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[SemesterId] [int] IDENTITY(1,1) NOT NULL,
	[SemesterNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Semesters] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[Email] [varchar](8000) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1/2/2020 1:58:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [varchar](8000) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [float] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_CourseId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[AllocatedClassrooms]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DayId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DayId] ON [dbo].[AllocatedClassrooms]
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[AllocatedClassrooms]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_RoomId] ON [dbo].[AllocatedClassrooms]
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[AssignCourses]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[AssignCourses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[AssignCourses]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Courses]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SemesterId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_SemesterId] ON [dbo].[Courses]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[EnrollCourses]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_StudentId] ON [dbo].[EnrollCourses]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Students]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentId] ON [dbo].[Teachers]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DesignationId]    Script Date: 1/2/2020 1:58:57 AM ******/
CREATE NONCLUSTERED INDEX [IX_DesignationId] ON [dbo].[Teachers]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllocatedClassrooms] ADD  DEFAULT ((0)) FOR [IsAllocated]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT ((0)) FOR [CourseCredit]
GO
ALTER TABLE [dbo].[Courses] ADD  DEFAULT ((0)) FOR [IsAssigned]
GO
ALTER TABLE [dbo].[EnrollCourses] ADD  DEFAULT ((0)) FOR [IsGraded]
GO
ALTER TABLE [dbo].[Teachers] ADD  DEFAULT ((0)) FOR [RemainingCredit]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms] CHECK CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Days_DayId] FOREIGN KEY([DayId])
REFERENCES [dbo].[Days] ([DayId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms] CHECK CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Days_DayId]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms] CHECK CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[AllocatedClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Rooms_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([RoomId])
GO
ALTER TABLE [dbo].[AllocatedClassrooms] CHECK CONSTRAINT [FK_dbo.AllocatedClassroms_dbo.Rooms_RoomId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[AssignCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AssignCourses_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId])
GO
ALTER TABLE [dbo].[AssignCourses] CHECK CONSTRAINT [FK_dbo.AssignCourses_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([SemesterId])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.Semesters_SemesterId]
GO
ALTER TABLE [dbo].[EnrollCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EnrollCourses_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[EnrollCourses] CHECK CONSTRAINT [FK_dbo.EnrollCourses_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[EnrollCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EnrollCourses_dbo.Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[EnrollCourses] CHECK CONSTRAINT [FK_dbo.EnrollCourses_dbo.Students_StudentId]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designations] ([DesignationId])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Designations_DesignationId]
GO
USE [master]
GO
ALTER DATABASE [UVDbGtx] SET  READ_WRITE 
GO
