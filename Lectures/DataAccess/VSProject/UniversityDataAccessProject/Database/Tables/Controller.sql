CREATE TABLE [dbo].[Controller]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Serial] NVARCHAR(64) NOT NULL, 
    [GatewayId] INT NULL, 
    [Status] INT NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    [ControllerTypeId] INT NULL, 
    CONSTRAINT [FK_Controller_Gateway] FOREIGN KEY ([GatewayId]) REFERENCES [Gateway]([Id]), 
    CONSTRAINT [FK_Controller_ControllerType] FOREIGN KEY (ControllerTypeId) REFERENCES [ControllerType]([Id])
)
