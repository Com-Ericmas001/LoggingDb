/****** Object:  Table [dbo].[Clients]    Script Date: 2016-02-27 20:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[IdClient] [int] IDENTITY(1,1) NOT NULL,
	[IpAddress] [nvarchar](100) NOT NULL,
	[UserAgent] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[ExecutedCommands]    Script Date: 2016-02-27 20:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutedCommands](
	[IdExecutedCommand] [int] IDENTITY(1,1) NOT NULL,
	[IdServiceMethod] [int] NOT NULL,
	[IdClient] [int] NOT NULL,
    [ExecutedTime] datetimeoffset NOT NULL DEFAULT GETDATE(),
	[Session] [uniqueidentifier] NULL,
	[Parms] [nvarchar](2000) NULL,
	[RequestContentType] [nvarchar](1000) NULL,
	[RequestData] [nvarchar](max) NULL,
	[ResponseContentType] [nvarchar](1000) NULL,
	[ResponseData] [nvarchar](max) NULL,
	[ResponseCode] [nvarchar](500) NULL,
 CONSTRAINT [PK_ExecutedCommands] PRIMARY KEY CLUSTERED 
(
	[IdExecutedCommand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[ServiceMethods]    Script Date: 2016-02-27 20:36:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceMethods](
	[IdServiceMethod] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](200) NOT NULL,
	[ControllerName] [nvarchar](100) NOT NULL,
	[MethodName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ServiceMethods] PRIMARY KEY CLUSTERED 
(
	[IdServiceMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [dbo].[ExecutedCommands]  WITH CHECK ADD  CONSTRAINT [FK_ExecutedCommands_Clients] FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([IdClient])
GO
ALTER TABLE [dbo].[ExecutedCommands] CHECK CONSTRAINT [FK_ExecutedCommands_Clients]
GO
ALTER TABLE [dbo].[ExecutedCommands]  WITH CHECK ADD  CONSTRAINT [FK_ExecutedCommands_ServiceMethods] FOREIGN KEY([IdServiceMethod])
REFERENCES [dbo].[ServiceMethods] ([IdServiceMethod])
GO
ALTER TABLE [dbo].[ExecutedCommands] CHECK CONSTRAINT [FK_ExecutedCommands_ServiceMethods]
GO


CREATE VIEW [dbo].[ViewLogs] AS
SELECT [IdExecutedCommand]
	  ,[ExecutedTime]
      ,[IpAddress]
      ,[UserAgent]
      ,[ServiceName]
      ,[ControllerName]
      ,[MethodName]
      ,[Parms]
      ,[RequestContentType]
      ,[RequestData]
      ,[ResponseContentType]
      ,[ResponseData]
      ,[ResponseCode]
      ,[Session]
  FROM [dbo].[ExecutedCommands] ec
  INNER JOIN [dbo].[Clients] c ON ec.[IdClient] = c.[IdClient]
  INNER JOIN [dbo].[ServiceMethods] s ON ec.[IdServiceMethod] = s.[IdServiceMethod]

GO