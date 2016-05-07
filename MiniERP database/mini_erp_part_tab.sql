CREATE DATABASE  IF NOT EXISTS `mini_erp` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `mini_erp`;
-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: localhost    Database: mini_erp
-- ------------------------------------------------------
-- Server version	5.6.25-enterprise-commercial-advanced-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `part_tab`
--

DROP TABLE IF EXISTS `part_tab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `part_tab` (
  `part_id` varchar(50) NOT NULL COMMENT 'KEY^QRY^',
  `description` varchar(200) DEFAULT NULL COMMENT 'QRY^',
  `catogory` varchar(200) DEFAULT NULL COMMENT 'QRY^',
  `size` float DEFAULT NULL COMMENT 'QRY^',
  `uom` varchar(10) DEFAULT NULL COMMENT 'QRY^',
  `qty_in_stock` int(11) DEFAULT NULL COMMENT 'QRY^',
  `price` float DEFAULT NULL COMMENT 'QRY^',
  `discount` float DEFAULT NULL COMMENT 'QRY^',
  PRIMARY KEY (`part_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `part_tab`
--

LOCK TABLES `part_tab` WRITE;
/*!40000 ALTER TABLE `part_tab` DISABLE KEYS */;
INSERT INTO `part_tab` VALUES ('DM-1000','Test Part','Emultion',4,'L',100,200,25),('DM-2000','Test Part','Whethercoat',10,'L',100,5000,25);
/*!40000 ALTER TABLE `part_tab` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-07 20:48:52
