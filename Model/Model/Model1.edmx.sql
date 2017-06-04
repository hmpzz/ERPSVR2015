
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2017 16:25:26
-- Generated from EDMX file: D:\GIT\erpsvr2015\Model\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [erp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_userSet'
CREATE TABLE [dbo].[T_userSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [RS_no] nvarchar(50)  NOT NULL,
    [rs_name] nvarchar(50)  NOT NULL,
    [T_sexId] int  NOT NULL,
    [T_HFId] int  NOT NULL
);
GO

-- Creating table 'T_sexSet'
CREATE TABLE [dbo].[T_sexSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sex_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_HFSet'
CREATE TABLE [dbo].[T_HFSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HF_name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RS_no] in table 'T_userSet'
ALTER TABLE [dbo].[T_userSet]
ADD CONSTRAINT [PK_T_userSet]
    PRIMARY KEY CLUSTERED ([RS_no] ASC);
GO

-- Creating primary key on [Id] in table 'T_sexSet'
ALTER TABLE [dbo].[T_sexSet]
ADD CONSTRAINT [PK_T_sexSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'T_HFSet'
ALTER TABLE [dbo].[T_HFSet]
ADD CONSTRAINT [PK_T_HFSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [T_sexId] in table 'T_userSet'
ALTER TABLE [dbo].[T_userSet]
ADD CONSTRAINT [FK_T_sexT_user]
    FOREIGN KEY ([T_sexId])
    REFERENCES [dbo].[T_sexSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T_sexT_user'
CREATE INDEX [IX_FK_T_sexT_user]
ON [dbo].[T_userSet]
    ([T_sexId]);
GO

-- Creating foreign key on [T_HFId] in table 'T_userSet'
ALTER TABLE [dbo].[T_userSet]
ADD CONSTRAINT [FK_T_HFT_user]
    FOREIGN KEY ([T_HFId])
    REFERENCES [dbo].[T_HFSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T_HFT_user'
CREATE INDEX [IX_FK_T_HFT_user]
ON [dbo].[T_userSet]
    ([T_HFId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------