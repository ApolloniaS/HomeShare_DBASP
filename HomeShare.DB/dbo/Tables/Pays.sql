CREATE TABLE [dbo].[Pays] (
    [idPays]  INT           IDENTITY (1, 1) NOT NULL,
    [Libelle] NVARCHAR (50) NOT NULL,
    [drapeau] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Pays] PRIMARY KEY CLUSTERED ([idPays] ASC)
);



