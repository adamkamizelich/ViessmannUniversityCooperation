CREATE TABLE [dbo].[ControllerTypeToDatapoint] (
    [ControllerTypeId] INT NOT NULL,
    [DatapointId]      INT NOT NULL,
    CONSTRAINT [PK_dbo.ControllerTypeToDatapoint] PRIMARY KEY CLUSTERED ([ControllerTypeId] ASC, [DatapointId] ASC),
    CONSTRAINT [FK_dbo.ControllerTypeToDatapoint_dbo.ControllerTypes_ControllerTypeId] FOREIGN KEY ([ControllerTypeId]) REFERENCES [dbo].[ControllerTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ControllerTypeToDatapoint_dbo.Datapoints_DatapointId] FOREIGN KEY ([DatapointId]) REFERENCES [dbo].[Datapoints] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ControllerTypeId]
    ON [dbo].[ControllerTypeToDatapoint]([ControllerTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DatapointId]
    ON [dbo].[ControllerTypeToDatapoint]([DatapointId] ASC);

