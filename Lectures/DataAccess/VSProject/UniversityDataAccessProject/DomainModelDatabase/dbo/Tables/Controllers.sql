CREATE TABLE [dbo].[Controllers] (
    [ControllerKey]     INT           IDENTITY (1, 1) NOT NULL,
    [Serial]            NVARCHAR (20) NULL,
    [GatewayId]         INT           NOT NULL,
    [Status]            INT           NOT NULL,
    [RowVersion]        ROWVERSION    NOT NULL,
    [ControllerTypeKey] INT           NOT NULL,
    CONSTRAINT [PK_dbo.Controllers] PRIMARY KEY CLUSTERED ([ControllerKey] ASC),
    CONSTRAINT [FK_dbo.Controllers_dbo.ControllerTypes_ControllerTypeKey] FOREIGN KEY ([ControllerTypeKey]) REFERENCES [dbo].[ControllerTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Controllers_dbo.Gateways_GatewayId] FOREIGN KEY ([GatewayId]) REFERENCES [dbo].[Gateways] ([GatewayId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GatewayId]
    ON [dbo].[Controllers]([GatewayId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ControllerTypeKey]
    ON [dbo].[Controllers]([ControllerTypeKey] ASC);

