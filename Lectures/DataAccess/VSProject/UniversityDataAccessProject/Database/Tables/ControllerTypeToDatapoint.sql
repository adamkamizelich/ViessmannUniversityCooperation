CREATE TABLE [dbo].[ControllerTypeToDatapoint]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [ControllerTypeId] INT NOT NULL, 
    [DatapointId] INT NOT NULL, 
    CONSTRAINT [FK_ControllerTypeToDatapoint_ControllerType] FOREIGN KEY ([ControllerTypeId]) REFERENCES [ControllerType]([Id]), 
    CONSTRAINT [FK_ControllerTypeToDatapoint_Datapoint] FOREIGN KEY ([DatapointId]) REFERENCES [Datapoint]([Id])
)
