CREATE PROCEDURE [dbo].[CSP_Register]
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	INSERT INTO [Utilisateur] ([Nom], [Prenom], [Email], [Passwd])
	VALUES (@Nom, @Prenom, @Email, HASHBYTES('SHA2_256', @Passwd));
	RETURN 0
END
