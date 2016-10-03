CREATE TABLE [dbo].[Gateway] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR(64)   NOT NULL,
    [Address]    NVARCHAR(1000) NULL,
    [Serial]     NVARCHAR(32)   NOT NULL,
    [Type]       INT          NOT NULL,
    [IsActive]   BIT          NULL,
    [RowVersion] TIMESTAMP   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


