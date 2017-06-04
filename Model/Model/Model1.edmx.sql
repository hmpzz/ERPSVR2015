
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2017 16:45:19
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

IF OBJECT_ID(N'[dbo].[FK_T_sexT_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_userSet] DROP CONSTRAINT [FK_T_sexT_user];
GO
IF OBJECT_ID(N'[dbo].[FK_T_HFT_user]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[T_userSet] DROP CONSTRAINT [FK_T_HFT_user];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T_userSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_userSet];
GO
IF OBJECT_ID(N'[dbo].[T_sexSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_sexSet];
GO
IF OBJECT_ID(N'[dbo].[T_HFSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_HFSet];
GO
IF OBJECT_ID(N'[dbo].[t_BMSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_BMSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_userSet'
CREATE TABLE [dbo].[T_userSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [RS_no] nvarchar(50)  NOT NULL,
    [rs_name] nvarchar(50)  NOT NULL,
    [T_sexId] int  NOT NULL,
    [T_HFId] int  NOT NULL,
    [t_BMBM_no] nvarchar(50)  NOT NULL,
    [T_xlId] int  NOT NULL,
    [Memo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_sexSet'
CREATE TABLE [dbo].[T_sexSet] (
    [Id] int  NOT NULL,
    [sex_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_HFSet'
CREATE TABLE [dbo].[T_HFSet] (
    [Id] int  NOT NULL,
    [HF_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 't_BMSet'
CREATE TABLE [dbo].[t_BMSet] (
    [id] nvarchar(max)  NOT NULL,
    [BM_no] nvarchar(50)  NOT NULL,
    [BM_name] nvarchar(max)  NOT NULL,
    [Memo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'T_xlSet'
CREATE TABLE [dbo].[T_xlSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [XL_name] nvarchar(max)  NOT NULL
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

-- Creating primary key on [BM_no] in table 't_BMSet'
ALTER TABLE [dbo].[t_BMSet]
ADD CONSTRAINT [PK_t_BMSet]
    PRIMARY KEY CLUSTERED ([BM_no] ASC);
GO

-- Creating primary key on [Id] in table 'T_xlSet'
ALTER TABLE [dbo].[T_xlSet]
ADD CONSTRAINT [PK_T_xlSet]
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

-- Creating foreign key on [t_BMBM_no] in table 'T_userSet'
ALTER TABLE [dbo].[T_userSet]
ADD CONSTRAINT [FK_t_BMT_user]
    FOREIGN KEY ([t_BMBM_no])
    REFERENCES [dbo].[t_BMSet]
        ([BM_no])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_t_BMT_user'
CREATE INDEX [IX_FK_t_BMT_user]
ON [dbo].[T_userSet]
    ([t_BMBM_no]);
GO

-- Creating foreign key on [T_xlId] in table 'T_userSet'
ALTER TABLE [dbo].[T_userSet]
ADD CONSTRAINT [FK_T_xlT_user]
    FOREIGN KEY ([T_xlId])
    REFERENCES [dbo].[T_xlSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T_xlT_user'
CREATE INDEX [IX_FK_T_xlT_user]
ON [dbo].[T_userSet]
    ([T_xlId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------