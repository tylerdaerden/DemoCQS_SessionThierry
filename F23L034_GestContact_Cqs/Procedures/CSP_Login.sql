CREATE PROCEDURE [dbo].[CSP_Login]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT Id, Nom, Prenom, Email 
	FROM Utilisateur
	WHERE	Email = @Email 
	AND		Passwd = HASHBYTES('SHA2_256', @Passwd);
	RETURN 0
END