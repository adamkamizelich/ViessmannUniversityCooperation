CREATE TABLE [dbo].[Datapoints] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [HexAddress] NVARCHAR (4)   NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Datapoints] PRIMARY KEY CLUSTERED ([Id] ASC)
);

