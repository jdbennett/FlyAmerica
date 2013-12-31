



-- -----------------------------------------------------------
-- Entity Designer DDL Script for MySQL Server 4.1 and higher
-- -----------------------------------------------------------
-- Date Created: 12/31/2013 13:01:57
-- Generated from EDMX file: C:\Projects\FlyAmerica\DAL\FlyAmerica.edmx
-- Target version: 2.0.0.0
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
SET foreign_key_checks = 0;
    DROP TABLE IF EXISTS `pilottraining`;
SET foreign_key_checks = 1;

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

CREATE TABLE `pilottrainings`(
	`TrainingId` int NOT NULL AUTO_INCREMENT UNIQUE, 
	`TrainingName` varchar (50) NOT NULL, 
	`TrainingShortDescription` varchar (350) NOT NULL, 
	`TrainingLongDescription` varchar (1000) NOT NULL, 
	`IsActive` varchar (1000) NOT NULL);

ALTER TABLE `pilottrainings` ADD PRIMARY KEY (TrainingId);






-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
