CREATE VIEW [dbo].[Vue_AvisMembres]
	AS 
	SELECT        dbo.AvisMembreBien.note, dbo.AvisMembreBien.message, dbo.AvisMembreBien.idMembre, dbo.AvisMembreBien.DateAvis, dbo.BienEchange.idBien, dbo.Membre.Login, dbo.AvisMembreBien.idAvis
FROM            dbo.AvisMembreBien LEFT JOIN
                         dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien LEFT JOIN
                         dbo.Membre ON dbo.AvisMembreBien.idMembre = dbo.Membre.idMembre AND dbo.BienEchange.idMembre = dbo.Membre.idMembre
