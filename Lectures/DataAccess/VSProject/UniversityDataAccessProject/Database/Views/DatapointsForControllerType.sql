CREATE VIEW [dbo].[DatapointsForControllerType]
	AS 
	SELECT c.Id as ControllerId, d.Name as DatapointName, d.HexAddress as DatapointHexAddress
	FROM [Controller] c 
		INNER JOIN [ControllerType] ct ON c.ControllerTypeId = ct.Id
		INNER JOIN [ControllerTypeToDatapoint] ctd ON ct.Id = ctd.ControllerTypeId
		INNER JOIN [Datapoint] d ON ctd.DatapointId = d.Id