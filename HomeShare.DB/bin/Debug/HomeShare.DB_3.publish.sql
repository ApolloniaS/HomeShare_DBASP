/*
Script de déploiement pour HomeShareDBASP

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HomeShareDBASP"
:setvar DefaultFilePrefix "HomeShareDBASP"
:setvar DefaultDataPath "C:\Users\sorel\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\sorel\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Modification de [dbo].[Vue_AvisMembres]...';


GO
ALTER VIEW [dbo].[Vue_AvisMembres]
	AS 
	SELECT        dbo.AvisMembreBien.note, dbo.AvisMembreBien.message, dbo.AvisMembreBien.idMembre, dbo.AvisMembreBien.DateAvis, dbo.BienEchange.idBien, dbo.Membre.Login, dbo.AvisMembreBien.idAvis
FROM            dbo.AvisMembreBien LEFT JOIN
                         dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien LEFT JOIN
                         dbo.Membre ON dbo.AvisMembreBien.idMembre = dbo.Membre.idMembre AND dbo.BienEchange.idMembre = dbo.Membre.idMembre
GO
PRINT N'Mise à jour terminée.';


GO
