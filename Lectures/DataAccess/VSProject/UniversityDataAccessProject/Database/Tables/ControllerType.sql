CREATE TABLE [dbo].[ControllerType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [Name] NVARCHAR(64) NOT NULL, 
    [Category] INT NOT NULL, 
    [HardwareIndex] INT NOT NULL, 
    [SoftwareIndexMin] INT NOT NULL, 
    [SoftwareIndexMax] INT NOT NULL
)
