CREATE PROCEDURE [dbo].[SP_Ajout_User]

	@nom NVARCHAR(50),
    @prenom NVARCHAR(50),
    @email NVARCHAR(256),
    @telephone NVARCHAR(20),
    @login NVARCHAR(50),
    @password NVARCHAR(256),
    @pays INT
AS
	DECLARE @idUser INT
    -- si le temps, ajouter un @salt !
    INSERT INTO Membre (Nom, Prenom, Email, Telephone, [Login], [Password], Pays)
    VALUES (@nom, @prenom, @email, @telephone, @login, @password, @pays) 
    SET @idUser = @@IDENTITY


