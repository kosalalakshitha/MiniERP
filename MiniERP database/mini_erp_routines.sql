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
-- Temporary view structure for view `customer_order_line`
--

DROP TABLE IF EXISTS `customer_order_line`;
/*!50001 DROP VIEW IF EXISTS `customer_order_line`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `customer_order_line` AS SELECT 
 1 AS `order_no`,
 1 AS `line_no`,
 1 AS `part_no`,
 1 AS `part_description`,
 1 AS `part_category`,
 1 AS `qty`,
 1 AS `unit_price`,
 1 AS `discount`,
 1 AS `discounted_price`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `customer_order_line`
--

/*!50001 DROP VIEW IF EXISTS `customer_order_line`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `customer_order_line` AS select `customer_order_line_tab`.`order_no` AS `order_no`,`customer_order_line_tab`.`line_no` AS `line_no`,`customer_order_line_tab`.`part_no` AS `part_no`,(select `part_tab`.`description` from `part_tab` where (`part_tab`.`part_id` = `customer_order_line_tab`.`part_no`)) AS `part_description`,(select `category_tab`.`category_name` from (`category_tab` join `part_tab`) where ((`part_tab`.`part_id` = `customer_order_line_tab`.`part_no`) and (`category_tab`.`category_name` = `part_tab`.`catogory`))) AS `part_category`,`customer_order_line_tab`.`qty` AS `qty`,`customer_order_line_tab`.`unit_price` AS `unit_price`,`customer_order_line_tab`.`discount` AS `discount`,`customer_order_line_tab`.`discounted_price` AS `discounted_price` from `customer_order_line_tab` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-07 20:48:53
