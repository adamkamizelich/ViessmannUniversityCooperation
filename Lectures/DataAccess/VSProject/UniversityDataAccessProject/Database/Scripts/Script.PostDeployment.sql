USE [University]
GO
SET IDENTITY_INSERT [dbo].[ControllerType] ON 

GO
INSERT [dbo].[ControllerType] ([Id], [Name], [Category], [HardwareIndex], [SoftwareIndexMin], [SoftwareIndexMax]) VALUES (1, N'HeatPump v1', 1, 10, 0, 9)
GO
INSERT [dbo].[ControllerType] ([Id], [Name], [Category], [HardwareIndex], [SoftwareIndexMin], [SoftwareIndexMax]) VALUES (2, N'HeatPump v2', 1, 10, 10, 19)
GO
INSERT [dbo].[ControllerType] ([Id], [Name], [Category], [HardwareIndex], [SoftwareIndexMin], [SoftwareIndexMax]) VALUES (4, N'GWG v1', 2, 14, 0, 15)
GO
SET IDENTITY_INSERT [dbo].[ControllerType] OFF
GO
SET IDENTITY_INSERT [dbo].[Gateway] ON 

GO
INSERT [dbo].[Gateway] ([Id], [Name], [Address], [Serial], [Type], [IsActive]) VALUES (1, N'MyInstallation', NULL, N'325555422', 1, 1)
GO
INSERT [dbo].[Gateway] ([Id], [Name], [Address], [Serial], [Type], [IsActive]) VALUES (2, N'Installation CR', NULL, N'11554333', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Gateway] OFF
GO
SET IDENTITY_INSERT [dbo].[Controller] ON 

GO
INSERT [dbo].[Controller] ([Id], [Serial], [GatewayId], [Status], [ControllerTypeId]) VALUES (1, N'879799', 1, 1, 1)
GO
INSERT [dbo].[Controller] ([Id], [Serial], [GatewayId], [Status], [ControllerTypeId]) VALUES (2, N'66665', 1, 2, 2)
GO
INSERT [dbo].[Controller] ([Id], [Serial], [GatewayId], [Status], [ControllerTypeId]) VALUES (3, N'76767777', 2, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Controller] OFF
GO
SET IDENTITY_INSERT [dbo].[Datapoint] ON 

GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (2, N'2300', N'konf_betriebsart_rw')
GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (4, N'1134', N'konf_kesselsolltemp_rw')
GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (5, N'4300', N'konf_niveau_rw')
GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (7, N'1132', N'konf_partysolltemp_rw')
GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (8, N'2254', N'zustand_sparbetrieb_r')
GO
INSERT [dbo].[Datapoint] ([Id], [HexAddress], [Name]) VALUES (9, N'4322', N'anzahl_brennerstart_r')
GO
SET IDENTITY_INSERT [dbo].[Datapoint] OFF
GO
SET IDENTITY_INSERT [dbo].[ControllerTypeToDatapoint] ON 

GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (1, 1, 2)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (2, 1, 4)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (3, 1, 9)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (4, 2, 2)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (5, 2, 4)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (6, 2, 9)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (7, 2, 7)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (8, 4, 5)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (9, 4, 7)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (10, 4, 8)
GO
INSERT [dbo].[ControllerTypeToDatapoint] ([Id], [ControllerTypeId], [DatapointId]) VALUES (11, 4, 9)
GO
SET IDENTITY_INSERT [dbo].[ControllerTypeToDatapoint] OFF
GO
