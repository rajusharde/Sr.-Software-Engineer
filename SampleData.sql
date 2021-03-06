USE [master]
GO
/****** Object:  Database [TestDb]    Script Date: 08-06-2021 12:42:10 ******/
CREATE DATABASE [TestDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TestDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TestDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestDb] SET RECOVERY FULL 
GO
ALTER DATABASE [TestDb] SET  MULTI_USER 
GO
ALTER DATABASE [TestDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestDb', N'ON'
GO
ALTER DATABASE [TestDb] SET QUERY_STORE = OFF
GO
USE [TestDb]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 08-06-2021 12:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 08-06-2021 12:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 08-06-2021 12:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSlots]    Script Date: 08-06-2021 12:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSlots](
	[EmployeeSlotId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId1] [int] NULL,
	[EmployeeId2] [int] NULL,
	[MeetingDate] [date] NULL,
	[MeetingFromTime] [time](7) NULL,
	[MeetingToTime] [time](7) NULL,
	[Message] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_EmployeeSlots] PRIMARY KEY CLUSTERED 
(
	[EmployeeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (1, N'IT')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (2, N'Operations')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (3, N'HR')
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (1, N'Project Manager')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (2, N'Software Engg.')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (3, N'Sr. Software Engg.')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (4, N'Operation Manger')
SET IDENTITY_INSERT [dbo].[Designation] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [MiddleName], [LastName], [EmployeeCode], [DesignationId], [DepartmentId], [CreatedOn], [ModifiedOn]) VALUES (1, N'Umesh', N'U', N'Chandra', N'007', 1, 1, CAST(N'2021-06-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [MiddleName], [LastName], [EmployeeCode], [DesignationId], [DepartmentId], [CreatedOn], [ModifiedOn]) VALUES (2, N'Mohini', N'H', N'Kumari', N'008', 3, 1, CAST(N'2021-06-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [MiddleName], [LastName], [EmployeeCode], [DesignationId], [DepartmentId], [CreatedOn], [ModifiedOn]) VALUES (4, N'Supriya', N'J', N'Sathe', N'004', 2, 1, CAST(N'2021-05-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [MiddleName], [LastName], [EmployeeCode], [DesignationId], [DepartmentId], [CreatedOn], [ModifiedOn]) VALUES (5, N'Rajesh', N'Y', N'Bisen', N'112', 4, 2, CAST(N'2021-05-01T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeSlots] ON 

INSERT [dbo].[EmployeeSlots] ([EmployeeSlotId], [EmployeeId1], [EmployeeId2], [MeetingDate], [MeetingFromTime], [MeetingToTime], [Message], [CreatedOn]) VALUES (1, 1, 2, CAST(N'2021-06-03' AS Date), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), N'Test Meeting', CAST(N'2021-06-02T00:00:00.000' AS DateTime))
INSERT [dbo].[EmployeeSlots] ([EmployeeSlotId], [EmployeeId1], [EmployeeId2], [MeetingDate], [MeetingFromTime], [MeetingToTime], [Message], [CreatedOn]) VALUES (2, 1, 4, CAST(N'2021-06-08' AS Date), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), N'Test Operation', CAST(N'2021-06-02T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[EmployeeSlots] OFF
GO
USE [master]
GO
ALTER DATABASE [TestDb] SET  READ_WRITE 
GO
