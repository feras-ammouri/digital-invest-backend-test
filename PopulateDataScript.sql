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


INSERT INTO [dbo].[funding]
           ([Id]
           ,[project_id]
           ,[investor_id]
           ,[investment_amount]
           ,[investment_date])
     VALUES
           ('D41F1ED8-2830-405D-8EF6-44098569D7A9',
           '7229C3FD-A545-4234-A241-C8525A8A047E',
           '7229C3FD-A545-4234-A241-C8525A8A047C',
           100.05,
           '2021-03-24 21:25:32.7656201')
GO


