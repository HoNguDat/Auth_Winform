USE [master]
GO
/****** Object:  Database [Winform_Auth]    Script Date: 11/06/2023 06:48:31 PM ******/
CREATE DATABASE [Winform_Auth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Winform_Auth', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Winform_Auth.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Winform_Auth_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Winform_Auth_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Winform_Auth] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Winform_Auth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Winform_Auth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Winform_Auth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Winform_Auth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Winform_Auth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Winform_Auth] SET ARITHABORT OFF 
GO
ALTER DATABASE [Winform_Auth] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Winform_Auth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Winform_Auth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Winform_Auth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Winform_Auth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Winform_Auth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Winform_Auth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Winform_Auth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Winform_Auth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Winform_Auth] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Winform_Auth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Winform_Auth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Winform_Auth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Winform_Auth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Winform_Auth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Winform_Auth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Winform_Auth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Winform_Auth] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Winform_Auth] SET  MULTI_USER 
GO
ALTER DATABASE [Winform_Auth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Winform_Auth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Winform_Auth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Winform_Auth] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Winform_Auth] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Winform_Auth] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Winform_Auth] SET QUERY_STORE = ON
GO
ALTER DATABASE [Winform_Auth] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Winform_Auth]
GO
/****** Object:  Table [dbo].[db_User]    Script Date: 11/06/2023 06:48:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[db_User](
	[Id] [nvarchar](20) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[UserName] [varchar](30) NULL,
	[Pass] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[db_User] ([Id], [FullName], [UserName], [Pass]) VALUES (N'NV001', N'Hồ Ngũ Đạt', N'ngudatho', N'ngudat')
GO
/****** Object:  StoredProcedure [dbo].[sp_fetchData]    Script Date: 11/06/2023 06:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_fetchData]
as
select*from db_User
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 11/06/2023 06:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Login]
@UserName varchar(30),@Pass varchar(30)
as
begin
if exists (select * from db_User where UserName=@UserName and Pass=@Pass)
	select 1
else if exists (select * from db_User where UserName=@UserName and Pass!=@Pass)
	select 2
else if exists(select * from db_User where UserName!=@UserName and Pass=@Pass)
	select 3
else if exists(select * from db_User where UserName!=@UserName and Pass!=@Pass)
	select 4
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Register]    Script Date: 11/06/2023 06:48:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Register](@Id nvarchar(20),@FullName nvarchar(50),@UserName varchar(30),@Pass varchar(30))
as 
insert into db_User(Id,FullName,UserName,Pass)
values(@Id,@FullName,@UserName,@Pass)
GO
USE [master]
GO
ALTER DATABASE [Winform_Auth] SET  READ_WRITE 
GO
