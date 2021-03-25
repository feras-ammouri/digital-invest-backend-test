CREATE DATABASE [DigitalInvestDB]
GO

USE [DigitalInvestDB]
GO 

CREATE TABLE [dbo].[investor](
	[Id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_investor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE [dbo].[project](
	[Id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NULL,
	[asset_class] [nvarchar](max) NULL,
	[total_volum] [decimal](18, 2) NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[funding](
	[Id] [uniqueidentifier] NOT NULL,
	[project_id] [uniqueidentifier] NOT NULL,
	[investor_id] [uniqueidentifier] NOT NULL,
	[investment_amount] [decimal](18, 2) NOT NULL,
	[investment_date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_funding] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[funding]  WITH CHECK ADD  CONSTRAINT [FK_funding_investor_investor_id] FOREIGN KEY([investor_id])
REFERENCES [dbo].[investor] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[funding] CHECK CONSTRAINT [FK_funding_investor_investor_id]
GO

ALTER TABLE [dbo].[funding]  WITH CHECK ADD  CONSTRAINT [FK_funding_project_project_id] FOREIGN KEY([project_id])
REFERENCES [dbo].[project] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[funding] CHECK CONSTRAINT [FK_funding_project_project_id]
GO

