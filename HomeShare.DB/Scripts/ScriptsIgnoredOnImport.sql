
-- ajout de biens dans la DB pour test les sliders/recherches
INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Appartement bien situÃ© en centre-ville',
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
GO

INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Maison en bord de mer',
'Une magnifique demeure situÃ©e le long de la cÃ´te',
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
GO

INSERT INTO BienEchange (titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal,
Photo, AssuranceObligatoire, isEnabled, DisabledDate, Longitude, Latitude, idMembre, DateCreation)
VALUES ('Duplex aux Champs ElysÃ©es',
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
GO

-- Update photo

UPDATE BienEchange
SET Photo = '4.jpg'
WHERE idBien = 3
GO

UPDATE BienEchange
SET Photo = '5.jpg'
WHERE idBien = 2
GO
