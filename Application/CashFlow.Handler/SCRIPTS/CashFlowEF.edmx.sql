
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/14/2018 14:19:02
-- Generated from EDMX file: C:\mc2techGit\PoaTek\Application\CashFlow.DAO\CashFlowEF.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transaction] (
    [TransactionId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(2000)  NULL,
    [Amount] decimal(18,0)  NULL,
    [TransactionDate] datetime  NOT NULL,
    [PaymentTypeId] uniqueidentifier  NOT NULL,
    [ResourceId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PaymentTypes'
CREATE TABLE [dbo].[PaymentType] (
    [PaymentTypeId] uniqueidentifier  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Resources'
CREATE TABLE [dbo].[Resource] (
    [ResourceId] uniqueidentifier  NOT NULL,
    [Active] bit  NOT NULL,
    [Name] nvarchar(500)  NOT NULL,
    [Username] nvarchar(500)  NOT NULL,
    [Email] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleId] uniqueidentifier  NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [Active] bit  NOT NULL
);
GO

-- Creating table 'RoleResource'
CREATE TABLE [dbo].[RoleResource] (
    [Roles_Id] uniqueidentifier  NOT NULL,
    [RoleResource_Role_ResourceId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all AUTO INCREMENT GUID COLUMNS
-- --------------------------------------------------

ALTER TABLE [dbo].[PaymentType] ADD  CONSTRAINT [DF_PaymentType_PaymentTypeId]  DEFAULT (newid()) FOR [PaymentTypeId]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_RoleId]  DEFAULT (newid()) FOR [RoleId]
GO
ALTER TABLE [dbo].[Resource] ADD  CONSTRAINT [DF_Resource_ResourceId]  DEFAULT (newid()) FOR [ResourceId]
GO
ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [DF_Transaction_TransactionId]  DEFAULT (newid()) FOR [TransactionId]
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TransactionId] in table 'Transactions'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [PK_Transaction]
    PRIMARY KEY CLUSTERED ([TransactionId] ASC);
GO

-- Creating primary key on [PaymentTypeId] in table 'PaymentTypes'
ALTER TABLE [dbo].[PaymentType]
ADD CONSTRAINT [PK_PaymentType]
    PRIMARY KEY CLUSTERED ([PaymentTypeId] ASC);
GO

-- Creating primary key on [ResourceId] in table 'Resources'
ALTER TABLE [dbo].[Resource]
ADD CONSTRAINT [PK_Resource]
    PRIMARY KEY CLUSTERED ([ResourceId] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Roles_Id], [RoleResource_Role_ResourceId] in table 'RoleResource'
ALTER TABLE [dbo].[RoleResource]
ADD CONSTRAINT [PK_RoleResource]
    PRIMARY KEY CLUSTERED ([Roles_Id], [RoleResource_Role_ResourceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PaymentTypeId] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_PaymentTypeTransaction]
    FOREIGN KEY ([PaymentTypeId])
    REFERENCES [dbo].[PaymentType]
        ([PaymentTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentTypeTransaction'
CREATE INDEX [IX_FK_PaymentTypeTransaction]
ON [dbo].[Transaction]
    ([PaymentTypeId]);
GO

-- Creating foreign key on [ResourceId] in table 'Transactions'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_ResourceTransaction]
    FOREIGN KEY ([ResourceId])
    REFERENCES [dbo].[Resource]
        ([ResourceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResourceTransaction'
CREATE INDEX [IX_FK_ResourceTransaction]
ON [dbo].[Transaction]
    ([ResourceId]);
GO

-- Creating foreign key on [Roles_Id] in table 'RoleResource'
ALTER TABLE [dbo].[RoleResource]
ADD CONSTRAINT [FK_RoleResource_Role]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Role]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleResource_Role_ResourceId] in table 'RoleResource'
ALTER TABLE [dbo].[RoleResource]
ADD CONSTRAINT [FK_RoleResource_Resource]
    FOREIGN KEY ([RoleResource_Role_ResourceId])
    REFERENCES [dbo].[Resource]
        ([ResourceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleResource_Resource'
CREATE INDEX [IX_FK_RoleResource_Resource]
ON [dbo].[RoleResource]
    ([RoleResource_Role_ResourceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------