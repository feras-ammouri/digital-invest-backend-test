USE [DigitalInvestDb]
GO

INSERT INTO [dbo].[project]
           ([Id]
           ,[name]
           ,[asset_class]
           ,[total_volum]
           ,[description])
     VALUES
	 (
           '7229c3fd-a545-4234-a241-c8525a8a047e',
           'Project Test',
		   'Project Asset Class',
		   20000,
		   'Project Description'
	),
	(
           '7229c3fd-a545-4234-a241-c8525a8a047c',
           'Second Project Test',
		   'Second Asset Class',
		   30000,
		   'Second Project Description'
	)
GO

INSERT INTO [dbo].[investor]
           ([Id]
           ,[name])
     VALUES
           ('7229c3fd-a545-4234-a241-c8525a8a047e',
           'Investor Test'),
		   ('7229c3fd-a545-4234-a241-c8525a8a047c',
           'Second Investor Test')
GO
