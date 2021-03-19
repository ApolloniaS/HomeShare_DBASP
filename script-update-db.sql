-- ajout de biens dans la DB pour test les sliders/recherches
INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Appartement bien situé en centre-ville',
'Superbe appartement pour deux personnes au coeur de la capitale',
'ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
2,
5,
'Luxembourg-Ville',
'Rue des Champs',
'42',
'12345',
'1.jpg',
0,
1,
NULL,
11.5,
12.5,
1,
'20210321')

INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Maison en bord de mer',
'Une magnifique demeure située le long de la côte',
'ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
4,
1,
'Ostende',
'Rue des Vagues',
'7',
'7285',
'2.jpg',
0,
1,
NULL,
42.5,
17.5,
3,
'20210212')

INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Duplex aux Champs Elysées',
'Parfaite location pour les amoureux du shopping !',
'ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
3,
2,
'Paris',
'Rue des Prix',
'125',
'75800',
'3.jpg',
0,
1,
NULL,
98.7,
16.5,
4,
'20210320')

-- Update photo

UPDATE BienEchange
SET Photo = '4.jpg'
WHERE idBien = 3

UPDATE BienEchange
SET Photo = '5.jpg'
WHERE idBien = 2

-- Rajout de notes
-- 2 biens avec + que 6/10
INSERT INTO AvisMembreBien (note, [message], idMembre, idBien, DateAvis, Approuve)
VALUES (7,
'Moyen mais alentours vraiment bien',
4,
5,
GETDATE(),
1)

INSERT INTO AvisMembreBien (note, [message], idMembre, idBien, DateAvis, Approuve)
VALUES (8,
'Très bien pour la durée du séjour mais pas plus longtemps !!',
4,
6,
GETDATE(),
1)

INSERT INTO AvisMembreBien (note, [message], idMembre, idBien, DateAvis, Approuve)
VALUES (3,
'Nul',
3,
7,
GETDATE(),
1)

-- Ajout d'une SP pour entrer l'user (ajout du sel si le temps)
CREATE PROCEDURE [dbo].[SP_Ajout_User]

	@nom NVARCHAR(50),
    @prenom NVARCHAR(50),
    @email NVARCHAR(256),
    @tel NVARCHAR(20),
    @login NVARCHAR(50),
    @password NVARCHAR(256),
    @pays INT
AS
	DECLARE @idUser INT
    -- si le temps, ajouter un @salt !
    INSERT INTO Membre (Nom, Prenom, Email, Telephone, [Login], [Password], Pays)
    VALUES (@nom, @prenom, @email, @tel, @login, @password, @pays) 
    SET @idUser = @@IDENTITY
	
-- Ajout colonne "drapeau" dans pays pour la page de recherche
ALTER TABLE Pays
ADD drapeau NVARCHAR(50)

-- Remplissage des drapeaux
UPDATE Pays SET drapeau = 'be.jpg' WHERE idPays = 1
UPDATE Pays SET drapeau = 'fr.jpg' WHERE idPays = 2
UPDATE Pays SET drapeau = 'it.jpg' WHERE idPays = 3
UPDATE Pays SET drapeau = 'pb.jpg' WHERE idPays = 4
UPDATE Pays SET drapeau = 'lu.jpg' WHERE idPays = 5
UPDATE Pays SET drapeau = 'au.jpg' WHERE idPays = 6
UPDATE Pays SET drapeau = 'us.jpg' WHERE idPays = 7
UPDATE Pays SET drapeau = 'ru.jpg' WHERE idPays = 8
UPDATE Pays SET drapeau = 'es.jpg' WHERE idPays = 9
UPDATE Pays SET drapeau = 'pt.jpg' WHERE idPays = 10
UPDATE Pays SET drapeau = 'ei.jpg' WHERE idPays = 11

-- QOL: correction de la faute d'orthographe des pays
UPDATE Pays SET libelle = 'Australie' WHERE idPays = 6
UPDATE Pays SET libelle = 'Angleterre' WHERE idPays = 8

-- Vue pour rechercher les avis des membres selon l'id du bien
CREATE VIEW [dbo].[Vue_AvisMembres]
	AS 
	SELECT        dbo.AvisMembreBien.note, dbo.AvisMembreBien.message, dbo.AvisMembreBien.idMembre, dbo.AvisMembreBien.DateAvis, dbo.BienEchange.idBien, dbo.Membre.Login, dbo.AvisMembreBien.idAvis
FROM            dbo.AvisMembreBien LEFT JOIN
                         dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien LEFT JOIN
                         dbo.Membre ON dbo.AvisMembreBien.idMembre = dbo.Membre.idMembre AND dbo.BienEchange.idMembre = dbo.Membre.idMembre





