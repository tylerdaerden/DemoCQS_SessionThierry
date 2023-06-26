CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL IDENTITY,
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [Passwd] BINARY(32) NOT NULL, 
    CONSTRAINT [PK_Utilisateur] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Utilisateur_Email] UNIQUE ([Email])
)
