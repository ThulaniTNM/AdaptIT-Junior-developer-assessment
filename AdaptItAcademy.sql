CREATE DATABASE [AdaptItAcademyDB]
GO

USE [AdaptItAcademyDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Course code] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](max) NOT NULL,
	[CourseDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[Course code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhysicalAddresses]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicalAddresses](
	[PhysicalAddressId] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [nvarchar](max) NOT NULL,
	[Suburb] [nvarchar](max) NOT NULL,
	[Province] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostalCodePhysicalAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PhysicalAddresses] PRIMARY KEY CLUSTERED 
(
	[PhysicalAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostalAddresses]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostalAddresses](
	[PostalAddressId] [int] IDENTITY(1,1) NOT NULL,
	[Area] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[UserId] [int] NOT NULL,
	[PostalCodePostalAddress] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PostalAddresses] PRIMARY KEY CLUSTERED 
(
	[PostalAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainings]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainings](
	[TrainingID] [int] IDENTITY(1,1) NOT NULL,
	[TrainingStartDate] [datetime2](7) NOT NULL,
	[TrainingPeriod] [int] NOT NULL,
	[TrainingEndDate] [datetime2](7) NOT NULL,
	[TrainingRegistrationClosingDate] [datetime2](7) NOT NULL,
	[AvailableSeats] [int] NOT NULL,
	[TrainingCost] [decimal](18, 2) NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_Trainings] PRIMARY KEY CLUSTERED 
(
	[TrainingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[PhonenNumer] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DietaryRequirements] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTrainings]    Script Date: 2023/02/02 17:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTrainings](
	[UserTrainingId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TrainingId] [int] NOT NULL,
	[PaymentStatus] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserTrainings] PRIMARY KEY CLUSTERED 
(
	[UserTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PhysicalAddresses] ADD  DEFAULT (N'') FOR [PostalCodePhysicalAddress]
GO
ALTER TABLE [dbo].[PostalAddresses] ADD  DEFAULT (N'') FOR [PostalCodePostalAddress]
GO
ALTER TABLE [dbo].[PhysicalAddresses]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalAddresses_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhysicalAddresses] CHECK CONSTRAINT [FK_PhysicalAddresses_Users_UserId]
GO
ALTER TABLE [dbo].[PostalAddresses]  WITH CHECK ADD  CONSTRAINT [FK_PostalAddresses_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostalAddresses] CHECK CONSTRAINT [FK_PostalAddresses_Users_UserId]
GO
ALTER TABLE [dbo].[Trainings]  WITH CHECK ADD  CONSTRAINT [FK_Trainings_Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Course code])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trainings] CHECK CONSTRAINT [FK_Trainings_Courses_CourseId]
GO
ALTER TABLE [dbo].[UserTrainings]  WITH CHECK ADD  CONSTRAINT [FK_UserTrainings_Trainings_TrainingId] FOREIGN KEY([TrainingId])
REFERENCES [dbo].[Trainings] ([TrainingID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTrainings] CHECK CONSTRAINT [FK_UserTrainings_Trainings_TrainingId]
GO
ALTER TABLE [dbo].[UserTrainings]  WITH CHECK ADD  CONSTRAINT [FK_UserTrainings_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTrainings] CHECK CONSTRAINT [FK_UserTrainings_Users_UserId]
GO
