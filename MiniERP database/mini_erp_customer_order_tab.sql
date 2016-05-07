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
-- Table structure for table `customer_order_tab`
--

DROP TABLE IF EXISTS `customer_order_tab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer_order_tab` (
  `order_no` varchar(50) NOT NULL COMMENT 'KEY^QRY^',
  `customer_no` varchar(50) DEFAULT NULL COMMENT 'QRY^',
  `customer_name` varchar(200) DEFAULT NULL COMMENT 'QRY^',
  `delivery_add` varchar(500) DEFAULT NULL COMMENT 'QRY^',
  `delivary_date` varchar(50) DEFAULT NULL COMMENT 'QRY^',
  `total_net_ammount` decimal(10,0) DEFAULT NULL,
  `total_discount_ammount` decimal(10,0) DEFAULT NULL,
  `invoiced_value` decimal(10,0) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL COMMENT 'QRY^',
  `payment_type` varchar(45) DEFAULT NULL COMMENT 'QRY^',
  `cheque_no` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_order_tab`
--

LOCK TABLES `customer_order_tab` WRITE;
/*!40000 ALTER TABLE `customer_order_tab` DISABLE KEYS */;
INSERT INTO `customer_order_tab` VALUES ('P00001','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-23',0,0,0,'Planed','Cheque','12321321321'),('P00002','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-25',0,0,0,'Planed','Cash',''),('P00003','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-25',0,0,0,'Planed','',''),('P00004','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-25',0,0,0,'Planed','',''),('P00005','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-20',0,0,0,'Planed','',''),('P00006','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-29',0,0,0,'Planed','',''),('P00007','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-29',0,0,0,'Planed','',''),('P00008','001','Test Customer','131/2, Sri Dhammananda Road, Templers Road, Mt. Lavinea.','2015-12-29',0,0,0,'Planed','','');
/*!40000 ALTER TABLE `customer_order_tab` ENABLE KEYS */;
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
