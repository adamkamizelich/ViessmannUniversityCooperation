CREATE TABLE [dbo].[Gateways] (
    [GatewayId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (20)  NOT NULL,
    [Address]    NVARCHAR (100) NULL,
    [Serial]     NVARCHAR (20)  NULL,
    [Type]       INT            NOT NULL,
    [IsActive]   BIT            NOT NULL,
    [RowVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_dbo.Gateways] PRIMARY KEY CLUSTERED ([GatewayId] ASC)
);

