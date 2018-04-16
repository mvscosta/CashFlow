
-- --------------------------------------------------
-- DML Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2017 03:07:35
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CashFlow];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- CLEANING TABLES
-- --------------------------------------------------
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DELETE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[Resources]', 'U') IS NOT NULL
    DELETE [dbo].[Votos];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DELETE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[PaymentTypes]', 'U') IS NOT NULL
    DELETE [dbo].[PaymentTypes];
GO
-- --------------------------------------------------
-- INSERTING START DATA
-- --------------------------------------------------

INSERT INTO ROLES VALUES
('9aad2927-9df9-4dc4-98bb-55e44ea0db66','Employee','Employee Role',1)
, ('aecd4ef0-39fd-439f-a642-89070ba8887d','Manager','Manager Role',1)

INSERT INTO RESOURCES VALUES
('a91879c1-7eca-45ed-90fe-00904048c6f3',1,'Manager 1','manager','manager@mc2tech.com.br', 'aecd4ef0-39fd-439f-a642-89070ba8887d')
, ('aadf131f-6819-48e2-9b23-9f170404b7c6',1,'Employee 1','employee','employee@mc2tech.com.br', 'aecd4ef0-39fd-439f-a642-89070ba8887d')



-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------