USE [master]
GO
/****** Object:  Database [TeacherDatabase]    Script Date: 13-10-2019 17:38:12 ******/
CREATE DATABASE [TeacherDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TeacherDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TeacherDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TeacherDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TeacherDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TeacherDatabase] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TeacherDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TeacherDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TeacherDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TeacherDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TeacherDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TeacherDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [TeacherDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TeacherDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TeacherDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TeacherDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TeacherDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TeacherDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TeacherDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TeacherDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TeacherDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TeacherDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TeacherDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TeacherDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TeacherDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TeacherDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TeacherDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TeacherDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TeacherDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TeacherDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [TeacherDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [TeacherDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TeacherDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TeacherDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TeacherDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TeacherDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TeacherDatabase', N'ON'
GO
ALTER DATABASE [TeacherDatabase] SET QUERY_STORE = OFF
GO
USE [TeacherDatabase]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Report] [varbinary](max) NULL,
	[Descr] [nvarchar](255) NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leave]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leave](
	[LeaveID] [bigint] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](255) NULL,
	[LeaveDescription] [nvarchar](255) NULL,
	[TempContact] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[LeaveType] [nvarchar](255) NULL,
	[LeaveCount] [smallint] NULL,
	[ApprovalStatus] [nvarchar](255) NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[LeaveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prev_Experience]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prev_Experience](
	[Employer] [nvarchar](50) NOT NULL,
	[TID] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](255) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
 CONSTRAINT [PK_Prev_Experience] PRIMARY KEY CLUSTERED 
(
	[Employer] ASC,
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[TID] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publication]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publication](
	[No] [nvarchar](50) NOT NULL,
	[Journal] [nvarchar](100) NULL,
	[Descr] [nvarchar](255) NULL,
 CONSTRAINT [PK_Publication] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualification]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualification](
	[TID] [nvarchar](255) NOT NULL,
	[UG/PG/PHD] [nvarchar](50) NOT NULL,
	[University/School] [nvarchar](255) NULL,
	[YOP] [date] NULL,
	[Specification] [nvarchar](255) NULL,
 CONSTRAINT [PK_Qualification] PRIMARY KEY CLUSTERED 
(
	[TID] ASC,
	[UG/PG/PHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scripts]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scripts](
	[Subj_Id] [int] NOT NULL,
	[Year] [date] NOT NULL,
	[TID] [nvarchar](255) NOT NULL,
	[No_Of_Scripts] [int] NULL,
 CONSTRAINT [PK_Scripts] PRIMARY KEY CLUSTERED 
(
	[Subj_Id] ASC,
	[Year] ASC,
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Project]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Project](
	[Proj_Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[USN] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Student_Project] PRIMARY KEY CLUSTERED 
(
	[Proj_Id] ASC,
	[Name] ASC,
	[USN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Photo] [varbinary](max) NULL,
	[Address] [nvarchar](255) NULL,
	[DOB] [date] NULL,
	[Designation_Id] [int] NOT NULL,
	[Pan] [nvarchar](10) NULL,
	[Aadhar] [numeric](10, 0) NULL,
	[Phno] [numeric](10, 0) NULL,
	[Fingerprint] [varbinary](max) NULL,
	[Dept_Id] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher_Events]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher_Events](
	[Event_Id] [nvarchar](50) NOT NULL,
	[Teacher_Id] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Teacher_Events] PRIMARY KEY CLUSTERED 
(
	[Event_Id] ASC,
	[Teacher_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher_Publication]    Script Date: 13-10-2019 17:38:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher_Publication](
	[TID] [nvarchar](255) NOT NULL,
	[Pub_No] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Teacher_Publication] PRIMARY KEY CLUSTERED 
(
	[TID] ASC,
	[Pub_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 13-10-2019 17:38:12 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13-10-2019 17:38:12 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13-10-2019 17:38:12 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 13-10-2019 17:38:12 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 13-10-2019 17:38:12 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 13-10-2019 17:38:12 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Leave] ADD  CONSTRAINT [status_default]  DEFAULT ('pending') FOR [ApprovalStatus]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Prev_Experience]  WITH CHECK ADD  CONSTRAINT [FK_Prev_Experience_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Prev_Experience] CHECK CONSTRAINT [FK_Prev_Experience_Teacher]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Teacher]
GO
ALTER TABLE [dbo].[Qualification]  WITH CHECK ADD  CONSTRAINT [FK_Qualification_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Qualification] CHECK CONSTRAINT [FK_Qualification_Teacher]
GO
ALTER TABLE [dbo].[Scripts]  WITH CHECK ADD  CONSTRAINT [FK_Scripts_Subject] FOREIGN KEY([Subj_Id])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Scripts] CHECK CONSTRAINT [FK_Scripts_Subject]
GO
ALTER TABLE [dbo].[Scripts]  WITH CHECK ADD  CONSTRAINT [FK_Scripts_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Scripts] CHECK CONSTRAINT [FK_Scripts_Teacher]
GO
ALTER TABLE [dbo].[Student_Project]  WITH CHECK ADD  CONSTRAINT [FK_Student_Project_Project] FOREIGN KEY([Proj_Id])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Student_Project] CHECK CONSTRAINT [FK_Student_Project_Project]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation1] FOREIGN KEY([Designation_Id])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation1]
GO
ALTER TABLE [dbo].[Teacher_Events]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Events_Events] FOREIGN KEY([Event_Id])
REFERENCES [dbo].[Events] ([Title])
GO
ALTER TABLE [dbo].[Teacher_Events] CHECK CONSTRAINT [FK_Teacher_Events_Events]
GO
ALTER TABLE [dbo].[Teacher_Events]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Events_Teacher] FOREIGN KEY([Teacher_Id])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Teacher_Events] CHECK CONSTRAINT [FK_Teacher_Events_Teacher]
GO
ALTER TABLE [dbo].[Teacher_Publication]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Publication_Publication] FOREIGN KEY([Pub_No])
REFERENCES [dbo].[Publication] ([No])
GO
ALTER TABLE [dbo].[Teacher_Publication] CHECK CONSTRAINT [FK_Teacher_Publication_Publication]
GO
ALTER TABLE [dbo].[Teacher_Publication]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Publication_Teacher] FOREIGN KEY([TID])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Teacher_Publication] CHECK CONSTRAINT [FK_Teacher_Publication_Teacher]
GO
USE [master]
GO
ALTER DATABASE [TeacherDatabase] SET  READ_WRITE 
GO
