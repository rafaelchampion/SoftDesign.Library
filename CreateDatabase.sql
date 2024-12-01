﻿--
-- Script was generated by Devart dbForge Studio for MySQL, Version 10.0.225.0
-- Product home page: http://www.devart.com/dbforge/mysql/studio
-- Script date 01/12/2024 14:41:45
-- Server version: 8.0.32
--

--
-- Disable foreign keys
--
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

--
-- Set SQL mode
--
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

--
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE SoftDesignLibrary;

--
-- Drop table `Books`
--
DROP TABLE IF EXISTS Books;

--
-- Drop table `Users`
--
DROP TABLE IF EXISTS Users;

--
-- Set default database
--
USE SoftDesignLibrary;

--
-- Create table `Users`
--
CREATE TABLE Users (
  Id bigint NOT NULL AUTO_INCREMENT,
  Username varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PasswordHash varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PasswordSalt longtext DEFAULT NULL,
  Email varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  FirstName varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  LastName varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  CreatedAt datetime NOT NULL,
  UpdateDate datetime DEFAULT NULL,
  DeletedDate datetime DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 3,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

--
-- Create index `IX_Email` on table `Users`
--
ALTER TABLE Users
ADD UNIQUE INDEX IX_Email (Email);

--
-- Create index `IX_Username` on table `Users`
--
ALTER TABLE Users
ADD UNIQUE INDEX IX_Username (Username);

--
-- Create table `Books`
--
CREATE TABLE Books (
  Id bigint NOT NULL AUTO_INCREMENT,
  Title varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  Author varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  Isbn varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  CreatedAt datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  UpdateDate datetime DEFAULT NULL,
  DeletedDate datetime DEFAULT NULL,
  PRIMARY KEY (Id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 30,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci,
ROW_FORMAT = DYNAMIC;

-- 
-- Dumping data for table Users
--
INSERT INTO Users VALUES
(1, 'systemadmin', 'ahnCJ2GaDZVJ1uyEyEMmsxcnXgVNf+ia4mpQn13W5Yc=', 'n6MFgdel1mrV9tRm5Lmygg==', 't@t.com', NULL, NULL, '2024-12-01 14:41:04', NULL, NULL);

-- 
-- Dumping data for table Books
--
INSERT INTO Books VALUES
(1, 'Refatoração: Aperfeiçoando o Design de Códigos Existentes', 'Martin Fowler', '9788575227244', '2024-12-01 14:41:04', NULL, NULL),
(2, 'Código Limpo: Habilidades Práticas do Agile Software', 'Robert C. Martin', '9788576082675', '2024-12-01 14:41:04', NULL, NULL),
(3, 'C# e .NET - Fundamentos e Técnicas Avançadas', 'Rodrigo Turini e Loiane Groner', '9788535286168', '2024-12-01 14:41:04', NULL, NULL),
(4, 'C#. Como Programar', 'Harvey Deitel e Paul J. Deitel', '9788534614597', '2024-12-01 14:41:04', NULL, NULL),
(5, 'Trabalho Eficaz com Código Legado', 'Michael Feathers', '9788576089797', '2024-12-01 14:41:04', NULL, NULL),
(6, 'Domain-Driven Design: Atacando as Complexidades no Coração do Software', 'Eric Evans', '9788576082736', '2024-12-01 14:41:04', NULL, NULL),
(7, 'Estruturas de Dados e Algoritmos com C#', 'D. Malhotra e N. Chaudhary', '9788575226100', '2024-12-01 14:41:04', NULL, NULL),
(8, 'Introdução ao Design de Interfaces para a Web', 'Patrick J. Lynch e Sarah Horton', '9788576082101', '2024-12-01 14:41:04', NULL, NULL),
(10, 'Programando com C# 9 e .NET 5', 'Mark J. Price', '9788575227121', '2024-12-01 14:41:04', NULL, NULL),
(11, 'Desenvolvimento de Aplicações Empresariais com C# e .NET', 'Jon Galloway e Philip Japikse', '9788575226551', '2024-12-01 14:41:04', NULL, NULL),
(12, 'Head First Design Patterns', 'Eric Freeman e Elisabeth Robson', '9788576088776', '2024-12-01 14:41:04', NULL, NULL),
(13, 'Design Patterns: Padrões de Projeto', 'Erich Gamma e outros', '9788573939897', '2024-12-01 14:41:04', NULL, NULL),
(14, 'Arquitetura Limpa: O Guia do Artesão para Estruturas de Software', 'Robert C. Martin', '9788576082674', '2024-12-01 14:41:04', NULL, NULL),
(15, 'The Pragmatic Programmer', 'Andrew Hunt e David Thomas', '9788576086634', '2024-12-01 14:41:04', NULL, NULL),
(16, 'Microsoft .NET: Architecting Applications for the Enterprise', 'Dino Esposito e Andrea Saltarello', '9788576089901', '2024-12-01 14:41:04', NULL, NULL),
(17, 'Entity Framework Core in Action', 'Jon Smith', '9788575226735', '2024-12-01 14:41:04', NULL, NULL),
(18, 'Pro ASP.NET Core MVC', 'Adam Freeman', '9788575225899', '2024-12-01 14:41:04', NULL, NULL),
(19, 'Clean Architecture: A Craftsman''s Guide to Software Structure', 'Robert C. Martin', '9788576087593', '2024-12-01 14:41:04', NULL, NULL),
(20, 'Padrões de Arquitetura de Aplicações Corporativas', 'Martin Fowler', '9788576088583', '2024-12-01 14:41:04', NULL, NULL),
(21, 'C# Pocket Reference', 'Joseph Albahari e Ben Albahari', '9788576088316', '2024-12-01 14:41:04', NULL, NULL),
(22, 'More Effective C#', 'Bill Wagner', '9788576086120', '2024-12-01 14:41:04', NULL, NULL),
(23, 'Kotlin for Android Developers', 'Antonio Leiva', '9788576088070', '2024-12-01 14:41:04', NULL, NULL),
(24, 'Python Fluente', 'Luciano Ramalho', '9788576086731', '2024-12-01 14:41:04', NULL, NULL),
(25, 'Estruturas de Dados com Java', 'Narasimha Karumanchi', '9788576087987', '2024-12-01 14:41:04', NULL, NULL),
(26, 'TEST TITLE', 'TEST AUTHOR', '1234567890', '2024-12-01 13:27:47', NULL, NULL),
(27, 'TEST TITLE 2', 'TEST AUTHOR 2', '1234567890', '2024-12-01 13:28:24', NULL, NULL),
(28, 'TEST BOOK 213', 'TEST AUTHOR 123', '1234567890', '2024-12-01 13:29:09', NULL, NULL),
(29, 'Desenvolvimento Web com ASP.NET Core', 'Adam Freeman', '9788575225967', '2024-12-01 14:41:04', NULL, NULL);

--
-- Restore previous SQL mode
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

--
-- Enable foreign keys
--
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;