CREATE VIEW [dbo].[Vue_AvisMembres]
	AS 
	SELECT        dbo.AvisMembreBien.note, dbo.AvisMembreBien.message, dbo.AvisMembreBien.idMembre, dbo.AvisMembreBien.DateAvis, dbo.BienEchange.idBien, dbo.Membre.Login, dbo.AvisMembreBien.idAvis
FROM            dbo.AvisMembreBien INNER JOIN
                         dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien INNER JOIN
                         dbo.Membre ON dbo.AvisMembreBien.idMembre = dbo.Membre.idMembre AND dbo.BienEchange.idMembre = dbo.Membre.idMembre
