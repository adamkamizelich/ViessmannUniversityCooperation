CREATE TABLE [dbo].[ControllerTypes] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (MAX) NULL,
    [Category]         INT            NOT NULL,
    [HardwareIndex]    INT            NOT NULL,
    [SoftwareIndexMin] INT            NOT NULL,
    [SoftwareIndexMax] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ControllerTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

