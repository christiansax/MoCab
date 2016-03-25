CREATE VIEW [dbo].[View_Interaction]
	AS
	SELECT	[i].*, [ie].[Text] AS StateName, [it].[Text] AS TypeName
	FROM	[Interaction] i inner join [InteractionState] ie
			ON [i].[StateId]=[ie].[Id]
			inner join [InteractionType] it
			ON [i].[Type]=[it].[Id]
