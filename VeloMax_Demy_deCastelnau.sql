-- BDD VeloMax de UGO DEMY et HELOISE DE CASTELNAU
-- ESILV A3 TD D, groupe D1

-- ON DELETE CASCADE ON UPDATE NO ACTION

DROP DATABASE IF EXISTS velomax;
CREATE DATABASE IF NOT EXISTS velomax;

USE velomax;
set sql_safe_updates=0;

-- CREATION TABLES
DROP TABLE IF EXISTS modele;
CREATE TABLE IF NOT EXISTS modele
(
no_modele INT PRIMARY KEY NOT NULL,
date_intro_modele DATETIME,
date_discontinuation_modele DATETIME
);

DROP TABLE IF EXISTS bicyclette;
CREATE TABLE IF NOT EXISTS bicyclette
(
no_bicyclette VARCHAR(15) PRIMARY KEY NOT NULL,
nom_bicyclette VARCHAR(25),
grandeur_bicyclette VARCHAR(15),
prix_bicyclette INT,
no_modele INT, FOREIGN KEY (no_modele) REFERENCES modele(no_modele) ON DELETE CASCADE,
ligne_produit VARCHAR(30)
);

DROP TABLE IF EXISTS piece;
CREATE TABLE piece 
(
 no_piece VARCHAR(6) PRIMARY KEY NOT NULL,
 description_piece VARCHAR(50) , 
 nom_fournisseur VARCHAR(25),
 no_catalogue_fournisseur VARCHAR(10),
 date_intro_piece DATETIME,
 date_discontinuation_piece DATETIME,
 quantite_stock INT
 ); 
 
 DROP TABLE IF EXISTS fournisseur;
 CREATE TABLE fournisseur
 ( 
 siret VARCHAR(30) PRIMARY KEY NOT NULL,
 nom_entreprise VARCHAR(30),
 contact_entreprise VARCHAR(30),
 adresse_entreprise VARCHAR(50),
 libelle_satisfaction INT
 );
 
DROP TABLE IF EXISTS client_boutique;
 CREATE TABLE client_boutique
 (
 nom_compagnie VARCHAR(50) PRIMARY KEY NOT NULL,
 adresse_boutique VARCHAR(50),
 tel_boutique VARCHAR(10),
 courriel_boutique VARCHAR(50),
 nom_contact_boutique VARCHAR(30),
 pourcentage_remise FLOAT
 );
 
 DROP TABLE IF EXISTS client_individuel;
 CREATE TABLE client_individuel
 (
 no_client INT PRIMARY KEY NOT NULL auto_increment ,
 nom_client VARCHAR(25),
 prenom_client VARCHAR(25),
 adresse_client VARCHAR(50),
 tel_client VARCHAR(10),
 courriel_client VARCHAR(50)
 
 );
 
DROP TABLE IF EXISTS commande;
CREATE TABLE commande 
(
 no_commande VARCHAR(5) PRIMARY KEY NOT NULL ,
 date_commande DATETIME , 
 adresse_livraison VARCHAR(50),
 date_livraison DATETIME,
 nom_compagnie VARCHAR(50), FOREIGN KEY (nom_compagnie) REFERENCES client_boutique(nom_compagnie) ON DELETE CASCADE ON UPDATE NO ACTION,
 no_client INT, FOREIGN KEY (no_client) REFERENCES client_individuel(no_client) ON DELETE CASCADE ON UPDATE NO ACTION
); 

DROP TABLE IF EXISTS fidelio;
CREATE TABLE fidelio
 (
 no_fidelio INT PRIMARY KEY NOT NULL,
 description_fidelio VARCHAR(25),
 cout_fidelio INT, 
 duree_fidelio INT,
 rabais_fidelio FLOAT
 );
 
 -- CONSTRAINT
DROP TABLE IF EXISTS assemblage;
CREATE TABLE assemblage
(
id_assemblage INT PRIMARY KEY,
nom_bicyclette VARCHAR(15),
grandeur_bicyclette VARCHAR(15),
no_piece VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_guidon VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_frein VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_selle VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_da VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_dr VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_roueav VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_rouear VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_reflecteurs VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_pedalier VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_ordinateur VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_piece_panier VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION

);

 
DROP TABLE IF EXISTS contient_piece;
CREATE TABLE contient_piece
(
id_contient_piece INT PRIMARY KEY auto_increment,
no_piece VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
no_commande VARCHAR(5), FOREIGN KEY (no_commande) REFERENCES commande(no_commande) ON DELETE CASCADE ON UPDATE NO ACTION,
quantite_piece INT
);
 
DROP TABLE IF EXISTS contient_bicyclette;
CREATE TABLE contient_bicyclette
(
id_contient_bicyclette INT PRIMARY KEY auto_increment,
no_bicyclette VARCHAR(15), FOREIGN KEY (no_bicyclette) REFERENCES bicyclette(no_bicyclette) ON DELETE CASCADE ON UPDATE NO ACTION, 
no_commande VARCHAR(5), FOREIGN KEY (no_commande) REFERENCES commande(no_commande) ON DELETE CASCADE ON UPDATE NO ACTION,
quantite_bicyclette INT
);

DROP TABLE IF EXISTS fournit;
CREATE TABLE fournit
(
no_piece VARCHAR(6), FOREIGN KEY (no_piece) REFERENCES piece(no_piece) ON DELETE CASCADE ON UPDATE NO ACTION,
siret VARCHAR(30), FOREIGN KEY (siret) REFERENCES fournisseur(siret) ON DELETE CASCADE ON UPDATE NO ACTION,
prix_fournisseur_piece INT,
delai_fournisseur_piece INT
);

DROP TABLE IF EXISTS adhere;
CREATE TABLE adhere
(
no_client INT, FOREIGN KEY (no_client) REFERENCES client_individuel(no_client) ON DELETE CASCADE ON UPDATE NO ACTION,
no_fidelio INT, FOREIGN KEY (no_fidelio) REFERENCES fidelio(no_fidelio) ON DELETE CASCADE ON UPDATE NO ACTION,
date_adhesion DATETIME,
date_paiement DATETIME
);

-- INSERTION DANS LA TABLE MODELE
INSERT INTO `velomax`.`modele`(`no_modele`,`date_intro_modele`,`date_discontinuation_modele`) 
	VALUES 
		(1,'1999-12-31','2000-01-01'),
		(2,'1999-01-25','2020-03-17'),
        (3,'2000-06-20','2003-06-19'),
        (4,'1997-02-23','2004-12-11');

-- INSERTION DANS LA TABLE BICYCLETTE
INSERT INTO `velomax`.`bicyclette` (`no_bicyclette`,`nom_bicyclette`,`grandeur_bicyclette`,`prix_bicyclette`,`no_modele`,`ligne_produit`) 
	VALUES 
		('101','Kilimandjaro','Adultes',569,1,'VTT'),
        ('102','NorthPole','Adultes',329,1,'VTT'),
        ('103','MontBlanc','Jeunes',399,1,'VTT'),
        ('104','Hooligan','Jeunes',199,1,'VTT'),
        
		('105','Orléans','Hommes',229,2,'Vélo de course'),
        ('106','Orléans','Dames',229,2,'Vélo de course'),
        ('107','BlueJay','Hommes',349,2,'Vélo de course'),
        ('108','BlueJay','Dames',349,2,'Vélo de course'),
        
        
        ('109','Trail Explorer','Filles',129,3,'Classique'),
        ('110','Trail Explorer','Garçons',129,3,'Classique'),
        ('111','Night Hawk','Jeunes',189,3,'Classique'),
        ('112','Tierra Verde','Hommes',199,3,'Classique'),
        ('113','Tierra Verde','Dames',199,3,'Classique'),
        
        ('114','Mud Zinger I','Jeunes',279,4,'BMX'),
        ('115','Mud Zinger II','Adultes',359,4,'BMX');

-- INSERTION DANS LA TABLE FIDELIO
INSERT INTO `velomax`.`fidelio`(`no_fidelio`,`description_fidelio`,`cout_fidelio`,`duree_fidelio`,`rabais_fidelio`) 
	VALUES 
		(0,' NON Fidélio',0,0,0),
		(1,'Fidélio',15,1,5),
        (2,'Fidélio Or',25,2,8),
        (3,'Fidélio Platine',60,2,10),
        (4,'Fidélio Max',100,3,12);

-- INSERTION DANS LA TABLE PIECE
INSERT INTO `velomax`.`piece`(`no_piece`,`description_piece`,`nom_fournisseur`,`no_catalogue_fournisseur`,`date_intro_piece`,`date_discontinuation_piece`,`quantite_stock`)
	VALUES
		('C32','Cadre','Piking',1,'2000-01-01','2021-01-01',0),
        ('C34','Cadre','Bicloune',1,'2000-01-01','2020-01-01',1),
        ('C76','Cadre','Piking',2,'2000-01-01','2020-01-01',7),
        ('C43','Cadre','Piking',3,'2000-01-01','2020-01-01',2),
        ('C44f','Cadre','Piking',4,'2000-01-01','2020-01-01',5),
        ('C43f','Cadre','Bicloune',2,'2000-01-01','2020-01-01',8),
        ('C01','Cadre','Stuff',1,'2000-01-01','2024-01-01',0),
        ('C02','Cadre','Piking',5,'1999-01-01','2020-01-01',0),
        ('C15','Cadre','Stuff',2,'2000-01-01','2020-01-01',8),
        ('C87','Cadre','Piking',6,'2000-01-01','2020-01-01',6),
        ('C87f','Cadre','Stuff',3,'2000-01-01','2020-01-01',6),
        ('C25','Cadre','Stuff',4,'2000-01-01','2020-01-01',3),
        ('C26','Cadre','Bicloune',3,'2000-01-01','2020-01-01',2),
        
        ('G7','Guidon','Bicloune',4,'2000-01-01','2023-01-01',1),
        ('G9','Guidon','Bicloune',5,'2000-01-01','2020-01-01',1),
        ('G12','Guidon','Bicloune',6,'2000-01-01','2020-01-01',7),
        
        ('F3','Freins','Bicloune',7,'2000-01-01','2020-01-01',9),
        ('F9','Freins','Bicloune',8,'2000-01-01','2020-01-01',9),
        
        ('S88','Selle','Stuff',5,'2000-01-01','2020-01-01',8),
        ('S37','Selle','Stuff',6,'1999-01-01','2020-01-01',8),
        ('S35','Selle','Stuff',7,'2000-01-01','2020-01-01',9),
        ('S02','Selle','Stuff',8,'2000-01-01','2020-01-01',6),
        ('S03','Selle','Stuff',9,'2000-01-01','2020-01-01',7),
        ('S34','Selle','Stuff',10,'2000-01-01','2020-01-01',4),
        ('S36','Selle','Bicloune',9,'2000-01-01','2020-01-01',6),
        ('S87','Selle','Bicloune',10,'1999-01-01','2020-01-01',6),
        
        ('DV133','Dérailleur Avant ','Stuff',11,'2000-01-01','2020-01-01',6),
        ('DV17','Dérailleur Avant ','Stuff',12,'2000-01-01','2019-01-01',7),
        ('DV87','Dérailleur Avant ','Stuff',13,'2000-01-01','2019-01-01',6),
        ('DV57','Dérailleur Avant ','Stuff',14,'2000-01-01','2019-01-01',1),
        ('DV15','Dérailleur Avant ','Bicloune',11,'2000-01-01','2019-01-01',1),
        ('DV41','Dérailleur Avant ','Bicloune',12,'2000-01-01','2020-01-01',4),
        ('DV132','Dérailleur Avant ','Bicloune',13,'2000-01-01','2019-01-01',0),
        
        ('DR56','Dérailleur Arrière','Bicloune',14,'2000-01-01','2020-01-01',1),
        ('DR87','Dérailleur Arrière','Stuff',15,'2000-01-01','2021-01-01',5),
        ('DR86','Dérailleur Arrière','Stuff',16,'2000-01-01','2020-01-01',7),
        ('DR23','Dérailleur Arrière','Bicloune',15,'2000-01-01','2020-01-01',6),
        ('DR76','Dérailleur Arrière','Bicloune',16,'2000-01-01','2020-01-01',7),
        ('DR52','Dérailleur Arrière','Bicloune',17,'2000-01-01','2020-01-01',8),
        
        ('R45','Roue avant','Piking',7,'2000-01-01','2020-01-01',6),
        ('R48','Roue avant','Piking',8,'2000-01-01','2020-01-01',6),
        ('R12_av','Roue avant','Piking',9,'2000-01-01','2020-01-01',6),
        ('R19','Roue avant','Piking',10,'2000-01-01','2020-01-01',6),
        ('R1','Roue avant','Piking',11,'2000-01-01','2020-01-01',6),
        ('R11','Roue avant','Piking',12,'2000-01-01','2020-01-01',6),
        ('R44','Roue avant','Bicloune',18,'2000-01-01','2020-01-01',6),
        
        ('R46','Roue arrière','Bicloune',19,'2000-01-01','2020-01-01',6),
        ('R47','Roue arrière','Piking',13,'2000-01-01','2020-01-01',6),
        ('R32','Roue arrière','Piking',14,'2000-01-01','2021-01-01',6),
        ('R18','Roue arrière','Piking',15,'2000-01-01','2020-01-01',6),
        ('R2','Roue arrière','Bicloune',20,'2000-01-01','2020-01-01',6),
        ('R12_ar','Roue arrière','Bicloune',21,'2000-01-01','2020-01-01',6),
        
        ('R02','Réflecteurs','Bicloune',22,'1999-01-01','2021-01-01',6),
		('R09','Réflecteurs','Bicloune',23,'2000-01-01','2020-01-01',6),
		('R10','Réflecteurs','Bicloune',24,'2000-01-01','2020-01-01',6),
        
        ('P12','Pédalier','Bicloune',25,'2000-01-01','2020-01-01',6),
        ('P34','Pédalier','Bicloune',26,'2000-01-01','2020-01-01',6),
        ('P1','Pédalier','Bicloune',27,'1998-01-01','2020-01-01',6),
        ('P15','Pédalier','Bicloune',28,'2000-01-01','2020-01-01',6),
        
        ('O2','Ordinateur','Piking',16,'2000-01-01','2020-01-01',6),
        ('O4','Ordinateur','Piking',17,'1990-01-01','2020-01-01',6),
        
        ('S01','Panier','Piking',18,'2000-01-01','2020-01-01',6),
        ('S05','Panier','Stuff',17,'2000-01-01','2020-01-01',6),
        ('S74','Panier','Stuff',18,'1990-01-01','2020-01-01',6),
        ('S73','Panier','Stuff',19,'2000-01-01','2020-01-01',6) ;

-- INSERTION DANS LA TABLE FOURNISSEUR
-- libellé : 1 très bon, 2 bon, 3 moyen, 4 mauvais
INSERT INTO `velomax`.`fournisseur`(`siret`,`nom_entreprise`,`contact_entreprise`,`adresse_entreprise`,`libelle_satisfaction`) 
	VALUES
		('36252187900034','Piking','info@entreprise.fr','1 Rue des Bles, 93210 Saint-Denis',1),
        ('34536187900034','Stuff','info@entreprise2.fr','5 avenue des Chars, 78000 Versailles',2),
        ('34536197900034','Bicloune','info@entreprise3.fr','65 Avenue Daumesnil, 75012 Paris',4);

-- INSERTION DANS LA TABLE CLIENTS BOUTIQUES
INSERT INTO `velomax`.`client_boutique`(`nom_compagnie`,`adresse_boutique`,`tel_boutique`,`courriel_boutique`,`nom_contact_boutique`,`pourcentage_remise`) 
	VALUES
		('Velotority','1 Rue du Liban, 75020 Paris','0158513578','contact@velotority.fr','James',5),
        ('Veloworld','10 Rue Père Lachaise, 75012 Paris','0159463589','contact@veloworld.fr','Franck',10.2);

-- INSERTION DANS LA TABLE CLIENTS INDIVIDUELS
INSERT INTO `velomax`.`client_individuel`(`no_client`,`nom_client`,`prenom_client`,`adresse_client`,`tel_client`,`courriel_client`)
	VALUES 
		(1,'Delon','Alain','1 rue du Fossé des Bois, 75006 Paris',0644176457,'alain.delon@hotmail.fr'),
        (2,'Rouger','Maxine','6 avenue des fleurs, 750001 Paris',0789567834,'maxine.rouger@hotmail.fr'),
        (3,'Deloi','Alix','1 rue du Fossé des Bois, 75006 Paris',0649176457,'alix.deloi@hotmail.fr');

-- INSERTION DANS LA TABLE COMMANDE
INSERT INTO `velomax`.`commande`(`no_commande`,`date_commande`,`adresse_livraison`,`date_livraison`,`nom_compagnie`,`no_client`) 
	VALUES 
		(1,'2021-05-04','1 rue du Fossé des Bois,75006 Paris','2021-05-14',null,1),
        (3,'2021-05-04','1 rue du Fossé des Bois,75006 Paris','2021-05-14',null,2),
        (2,'2021-05-02','10 Rue Père Lachaise,75012 Paris','2021-05-06','Veloworld',null),
        (4,'2021-05-02','1 Rue du Liban, 75020 Paris','2021-05-06','Velotority',null),
        (5,'2021-05-02','10 Rue Père Lachaise,75012 Paris','2021-05-06','Veloworld',null),
        (6,'2021-05-02','10 Rue Père Lachaise,75012 Paris','2021-05-06','Veloworld',null);
        

-- INSERTION DANS LA TABLE ASSEMBLAGE
-- no_bicyclette
INSERT INTO `velomax`.`assemblage`(`id_assemblage`,`nom_bicyclette`,`grandeur_bicyclette`,`no_piece`,`no_piece_guidon`,`no_piece_frein`,`no_piece_selle`,`no_piece_da`,`no_piece_dr`,`no_piece_roueav`,`no_piece_rouear`,`no_piece_reflecteurs`,`no_piece_pedalier`,`no_piece_ordinateur`,`no_piece_panier`)
	VALUES 
		(1,'Kilimandjaro', 'Adultes', 'C32', 'G7', 'F3', 'S88', 'DV133', 'DR56', 'R45', 'R46', null, 'P12', 'O2', null),
        (2, 'NorthPole', 'Adultes', 'C34', 'G7', 'F3', 'S88', 'DV17', 'DR87', 'R48', 'R47', null, 'P12', null, null),
        (3, 'MontBlanc', 'Jeunes', 'C76', 'G7', 'F3', 'S88', 'DV17', 'DR87', 'R48', 'R47', null, 'P12', 'O2', null),
        (4, 'Hooligan', 'Jeunes', 'C76', 'G7', 'F3', 'S88', 'DV87', 'DR86', 'R12', 'R32', null, 'P12', null, null),
        (5, 'Orléans', 'Hommes', 'C43', 'G9', 'F9', 'S37', 'DV57', 'DR86', 'R19', 'R18', 'R02', 'P34', null, null),
        (6, 'Orléans', 'Dames', 'C44f', 'G9', 'F9', 'S35', 'DV57', 'DR86', 'R19', 'R18', 'R02', 'P34', null, null),
        (7, 'BlueJay', 'Hommes', 'C43', 'G9', 'F9', 'S37', 'DV57', 'DR87', 'R19', 'R18', 'R02', 'P34', 'O4', null),
        (8, 'BlueJay', 'Dames', 'C43f', 'G9', 'F9', 'S35', 'DV57', 'DR87', 'R19', 'R18', 'R02', 'P34', 'O4', null),
        
        (9, 'Trail Explorer', 'Filles', 'C01', 'G12', null, 'S02', null, null, 'R1', 'R2', 'R09', 'P1', null, 'S01'),
        (10, 'Trail Explorer', 'Garcons', 'C02', 'G12', null, 'S03', null, null, 'R1', 'R2', 'R09', 'P1', null, 'S05'),
        
        (11, 'Night Hawk', 'Jeunes', 'C15', 'G12', 'F9', 'S36', 'DV15','DR23', 'R11', 'R12', 'R10', 'P15', null, 'S74'),
       
        (12, 'Tierra Verde', 'Hommes', 'C87', 'G12', 'F9', 'S36', 'DV41', 'DR76', 'R11', 'R12', 'R10', 'P15', null, 'S74'),
        (13, 'Tierra Verde', 'Dames', 'C87f', 'G12', 'F9', 'S34', 'DV41', 'DR76', 'R1', 'R2', 'R09', 'P15', null, 'S73'),
        (14, 'Mud Zinger I', 'Jeunes', 'C25', 'G7', 'F3', 'S87', 'DV132', 'DR52', 'R44', 'R47', null, 'P12', null, null),
        (15, 'Mud Zinger II', 'Adultes', 'C26', 'G7', 'F3', 'S87', 'DV133', 'DR52', 'R44', 'R47', null, 'P12', null, null);
        
        
        
-- INSERTION DANS LA TABLE CONTIENT_PIECE

INSERT INTO `velomax`.`contient_piece`(`id_contient_piece`,`no_piece`,`no_commande`,`quantite_piece`)
	VALUES 
		(null,'C32',1,2),
        (null,'F3',1,1),
        (null,'R2',1,4),
         (null,'R2',2,4),
        (null,'S88',2,2),
        (null,'S37',2,3),
        (null,'S36',2,2),
        (null,'S36',3,2),
        (null,'C02',1,2);


-- INSERTION DANS LA TABLE CONTIENT_BICYCLETTE

INSERT INTO `velomax`.`contient_bicyclette`(`id_contient_bicyclette`,`no_bicyclette`,`no_commande`,`quantite_bicyclette`)
	VALUES 
		(null,101,1,2),
        (null,102,1,1),
        (null,102,2,6),
        (null,105,3,4),
        (null,105,2,4),
        (null,107,4,2),
        (null,109,6,3),
        (null,110,1,2);

-- INSERTION DANS LA TABLE FOURNIT


INSERT INTO `velomax`.`fournit`(`no_piece`,`siret`,`prix_fournisseur_piece`,`delai_fournisseur_piece`)
	VALUES 
    
		('C32','36252187900034',10,2),
		('C76','36252187900034',10,2),
		('C43','36252187900034',10,2),
		('C44f','36252187900034',10,1),
		('C02','36252187900034',9,9),
		('C87','36252187900034',10,6),
        ('R45','36252187900034',10,2),
        ('R48','36252187900034',10,2),
        ('R12_av','36252187900034',10,9),
        ('R19','36252187900034',10,2),
        ('R1','36252187900034',6,2),
        ('R11','36252187900034',6,2),
        ('R47','36252187900034',10,3),
        ('R32','36252187900034',8,2),
        ('R18','36252187900034',10,5),
        ('O2','36252187900034',1,1),
        ('O4','36252187900034',1,2),
        ('S01','36252187900034',8,2),
        
        ('DV132','36252187900034',6,2),
		('G7','36252187900034',10,9),
        ('F3','36252187900034',10,4),
        ('S88','36252187900034',6,2),
        ('DV133','36252187900034',5,5),
        ('DR56','36252187900034',4,2),
		('C25','36252187900034',6,2),
        ('S88','36252187900034',10,2),
        ('S37','36252187900034',7,2),
        ('S35','36252187900034',10,3),
    
		('C01','34536187900034',6,8),
        ('C15','34536187900034',10,2),
        ('C87f','34536187900034',5,4),
        ('C25','34536187900034',6,2),
        ('S88','34536187900034',10,3),
        ('S37','34536187900034',7,2),
        ('S35','34536187900034',10,2),
        ('S02','34536187900034',7,9),
        ('S03','34536187900034',9,2),
        ('S34','34536187900034',10,2),
        ('DV133','34536187900034',4,2),
        ('DV17','34536187900034',10,1),
        ('DV87','34536187900034',5,2),
        ('DV57','34536187900034',7,1),
        ('DR87','34536187900034',10,9),
        ('DR86','34536187900034',8,5),
        ('S05','34536187900034',2,2),
        ('S74','34536187900034',9,9),
        ('S73','34536187900034',10,2),
   
		
        ('R11','34536187900034',6,3),
        ('R47','34536187900034',12,2),
        ('P12','34536187900034',6,4),
        ('P15','34536187900034',14,2),
        ('DR76','34536187900034',10,10),
        ('DR76','34536187900034',10,10),
        ('R02','34536187900034',10,10),
        ('R09','34536187900034',10,10),
 
		('C34','34536197900034',10,5),
        ('C43f','34536197900034',10,5),
        ('C26','34536197900034',10,5),
        ('G7','34536197900034',10,2),
        ('G9','34536197900034',10,2),
        ('G12','34536197900034',10,3),
        ('F3','34536197900034',10,3),
        ('F9','34536197900034',10,2),
        ('S36','34536197900034',9,9),
        ('S87','34536197900034',10,2),
        ('DV15','34536197900034',10,2),
        ('DV41','34536197900034',7,1),
        ('DV132','34536197900034',10,1),
        ('DR56','34536197900034',10,4),
        ('DR23','34536197900034',8,5),
        ('DR76','34536197900034',6,2),
        ('DR52','34536197900034',10,2),
        ('R44','34536197900034',10,9),
        ('R46','34536197900034',10,6),
        ('R12_ar','34536197900034',6,2),
        ('DR76','34536197900034',10,2),
        ('DR76','34536197900034',10,2),
        ('R02','34536197900034',10,2),
        ('R09','34536197900034',6,2),
        ('R10','34536197900034',10,2),
        ('P12','34536197900034',10,2),
        ('P34','34536197900034',1,2),
        ('P1','34536197900034',1,2),
        ('P15','34536197900034',8,2),
      
        ('C01','34536197900034',5,10),
        ('C15','34536197900034',10,3),
        ('C87f','34536197900034',5,2),
        ('C25','34536197900034',6,4),
	
        ('DR86','34536197900034',8,6),
        ('S05','34536197900034',2,1),
        ('R11','34536197900034',6,9),
        ('R47','34536197900034',10,8),
        ('R32','34536197900034',8,9),
        ('R18','34536197900034',10,2),
        ('O2','34536197900034',1,2);
        

-- INSERTION DANS LA TABLE ADHERE  

INSERT INTO `velomax`.`adhere`(`no_client`,`no_fidelio`,`date_adhesion`,`date_paiement`)
	VALUES 
		(1,1,'2000-06-01','2021-05-01'),
        (2,2,'2014-04-01','2016-04-01'),
        (2,3,'2000-04-01','2014-04-01'),
        (2,4,'2000-05-01','2021-04-01'),
        (3,4,'2000-05-01','2020-06-01');
        
