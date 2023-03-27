-- MariaDB dump 10.19  Distrib 10.4.27-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: police
-- ------------------------------------------------------
-- Server version	10.4.27-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `admins` (
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`Username`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `Password` (`Password`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES ('Rokas','108'),('haskins','copper99'),('Poopty','droopt');
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cars`
--

DROP TABLE IF EXISTS `cars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cars` (
  `number_plate` varchar(10) NOT NULL,
  `brand` varchar(255) NOT NULL,
  `model` varchar(255) DEFAULT NULL,
  `colour` varchar(255) NOT NULL,
  `owner` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`number_plate`),
  UNIQUE KEY `number_plate` (`number_plate`),
  KEY `owner` (`owner`),
  CONSTRAINT `cars_ibfk_1` FOREIGN KEY (`owner`) REFERENCES `people` (`people_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cars`
--

LOCK TABLES `cars` WRITE;
/*!40000 ALTER TABLE `cars` DISABLE KEYS */;
INSERT INTO `cars` VALUES ('12GR32V','BMW','I8','RED',6),('22POOPV','VOLKSWAGEN','POLO','BLUE',3),('32PO74W','VOLKSWAGEN','POLO','GREEN',4),('44PTD67','PEUGEOT','3008','SILVER',3),('49BB32V','VOLVO','XC90','GREEN',2),('796A32V','BMW','X6','BLUE',1),('7HKA38Q','AUDI','Q5','WHITE',1),('87P69PV','OPEL','ASTRA','RED',5),('89HTTTH','CYBERTRUCK','TRUCK','GREY',3),('8WW12QR','MINI','CLUBMAN','RED',7),('DE45DYQ','BMW','X6','SILVER',9),('DFY354R','BATCAR','Pixy','BLACK',10),('DFY393H','VOLKSWAGEN','beetle','YELLOW',11),('DJKY998','BMW','V8','BLACK',6),('DOPOR37','AUDI','TT','SILVER',10),('FGHw93H','Pink Stealth','Stank','PINK',12),('GWE1299','LAMBORGHINI','URUS','YELLOW',7),('PQ4354R','FERRARI','Dream','RED',10),('PQ44DTR','VOLVO','C30','BROWN',8),('PRETR10','AUDI','E_TRON','WHITE',9),('WTEPO69','JEEP','WRANGLER','GREEN',8);
/*!40000 ALTER TABLE `cars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offence`
--

DROP TABLE IF EXISTS `offence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `offence` (
  `Offence_ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `description` varchar(50) NOT NULL,
  `maxFine` int(11) NOT NULL,
  `maxPoints` int(11) NOT NULL,
  PRIMARY KEY (`Offence_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offence`
--

LOCK TABLES `offence` WRITE;
/*!40000 ALTER TABLE `offence` DISABLE KEYS */;
INSERT INTO `offence` VALUES (1,'Speeding',1000,3),(2,'Speeding on a motorway',2500,6),(3,'Seat belt offence',500,0),(4,'Illegal parking',500,0),(5,'Drink driving',10000,11),(6,'Driving without a licence',10000,0),(7,'Traffic light offences',1000,3),(8,'injuring a pedestrian',500,0),(9,'Failure to have control of vehicle',1000,3),(10,'Dangerous driving',1000,11),(11,'Stolen Vehicle',5000,6),(12,'property damage with a vehicle',2500,0);
/*!40000 ALTER TABLE `offence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `officers`
--

DROP TABLE IF EXISTS `officers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `officers` (
  `Username` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`Username`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `Password` (`Password`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `officers`
--

LOCK TABLES `officers` WRITE;
/*!40000 ALTER TABLE `officers` DISABLE KEYS */;
INSERT INTO `officers` VALUES ('Carter','fuzz42'),('Regan','plod123');
/*!40000 ALTER TABLE `officers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `people`
--

DROP TABLE IF EXISTS `people`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `people` (
  `people_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `date_of_birth` date NOT NULL,
  `license_number` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`people_id`),
  UNIQUE KEY `people_id` (`people_id`),
  UNIQUE KEY `license_number` (`license_number`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `people`
--

LOCK TABLES `people` WRITE;
/*!40000 ALTER TABLE `people` DISABLE KEYS */;
INSERT INTO `people` VALUES (1,'Luke','Perkins','32 The Lane - Awesworth','1990-12-21','LUKAS34214687465'),(2,'Gordon','Luce','11  Western Terrace St - Nottingham','1991-07-11','GORDO74212685377'),(3,'James','Bruke','38  Newcastle St - Coventry','1997-04-20','JAMES74210575375'),(4,'James','Torks','65  Balford St - Birmingham','1991-06-18','JAMES74280496385'),(5,'James','Lyko','9  Tennis St - London','1994-12-29','ROBER74977455156'),(6,'Angle','Gille','26  Train St - Crew','1994-03-03','ANGLE74347462337'),(7,'Poopty','Scop','Unkown St - Wakanda','1997-11-26','POOPT74113472877'),(8,'Droopty','Poo','11 Medziotoju St - Alytus','1996-09-23','DOOPT74642579865'),(9,'Gilbert','Doo','32 Laisves Aleja St - Vilnius','1998-03-16','GILBE74642595725'),(10,'Droopty','JamePoo','22 Danger St - Kaunas','1996-09-23','DOOPWW6642579865'),(11,'Gilbert','Poo','13  Main St - Oxford','1998-03-16','GILBE78882595725'),(12,'Pink Guy','The Filthy','69  Man Cave - LA','1999-03-16','PINK71123596575'),(13,'Darius','Dan','13  Secret Spot','1960-03-02','D88PWWASDA2579865'),(14,'Speed','The speed','Time tunnel - Alaska','1980-06-16','D1564WASDAQR79865');
/*!40000 ALTER TABLE `people` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reports`
--

DROP TABLE IF EXISTS `reports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `reports` (
  `report_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `author` varchar(255) NOT NULL,
  `car_id` varchar(10) DEFAULT NULL,
  `people_id` bigint(20) DEFAULT NULL,
  `offence_id` bigint(20) NOT NULL,
  `fine_issued` varchar(255) DEFAULT NULL,
  `points_issued` varchar(255) DEFAULT NULL,
  `report_date` date NOT NULL,
  `details` varchar(150) NOT NULL,
  PRIMARY KEY (`report_id`),
  KEY `car_id` (`car_id`),
  KEY `people_id` (`people_id`),
  KEY `offence_id` (`offence_id`),
  CONSTRAINT `reports_ibfk_1` FOREIGN KEY (`car_id`) REFERENCES `cars` (`number_plate`),
  CONSTRAINT `reports_ibfk_2` FOREIGN KEY (`people_id`) REFERENCES `people` (`people_id`),
  CONSTRAINT `reports_ibfk_3` FOREIGN KEY (`offence_id`) REFERENCES `offence` (`Offence_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reports`
--

LOCK TABLES `reports` WRITE;
/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports` VALUES (1,'Carter','12GR32V',6,1,'600','2','2018-07-23','Speeded at a local school area going over 80 miles per hour!'),(2,'Carter','12GR32V',1,10,'10','3','2017-12-03','Speeded at on a highway, tailgating ongoing traffic!'),(3,'Carter','32PO74W',4,3,'200','3','2020-03-22','Drive drove without a seat belt on, driver has been issued a warning!'),(4,'Carter','44PTD67',3,4,'100','11','2019-06-12','Parking on a handicaped zone with no permit!'),(5,'Carter','22POOPV',3,2,'1000','3','2017-12-03','Speeded at on a highway, tailgating ongoing traffic!'),(6,'Regan','796A32V',1,6,'250','3','2011-07-02','Driver was stopped on routen check, licence was expiered and non valid!'),(7,'Regan','7HKA38Q',1,7,'400','5','2012-04-01','Driver did not stop on a red light!'),(8,'Regan','87P69PV',5,9,'100','3','2016-02-11','Driver failed to control the veichle on a snow day!'),(9,'Regan','89HTTTH',3,4,'200','3','2020-11-01','Car left in the middle of a tunnel entarance!'),(10,'Regan','DJKY998',6,2,'150','1','0000-00-00','Unknown driver speeding on a highway going way ower 120 miles mark!'),(11,'Regan','87P69PV',13,8,'200','4','0000-00-00','A too young idividual drove his push bike on a road!'),(12,'Carter','DJKY998',14,1,'300','1','2023-03-24','A person by the name of SPEED drives on a road with a BMW going on unbelievable speed taking over all of the cars he encouters!');
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unknown`
--

DROP TABLE IF EXISTS `unknown`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unknown` (
  `Unknown_id` bigint(20) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  PRIMARY KEY (`Unknown_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unknown`
--

LOCK TABLES `unknown` WRITE;
/*!40000 ALTER TABLE `unknown` DISABLE KEYS */;
INSERT INTO `unknown` VALUES (1,'UNKNOWN','UNKNOWN');
/*!40000 ALTER TABLE `unknown` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-27 13:56:06
