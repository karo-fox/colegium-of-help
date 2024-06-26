-- MySQL dump 10.13  Distrib 8.0.37, for Win64 (x86_64)
--
-- Host: localhost    Database: colegiumofhelpdb
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `background_equipment`
--

DROP TABLE IF EXISTS `background_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `background_equipment` (
  `equipment_id` int NOT NULL,
  `background_id` int NOT NULL,
  KEY `equipment_id` (`equipment_id`),
  KEY `background_id` (`background_id`),
  CONSTRAINT `background_equipment_ibfk_1` FOREIGN KEY (`equipment_id`) REFERENCES `equipment` (`id`),
  CONSTRAINT `background_equipment_ibfk_2` FOREIGN KEY (`background_id`) REFERENCES `backgrounds` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `background_equipment`
--

LOCK TABLES `background_equipment` WRITE;
/*!40000 ALTER TABLE `background_equipment` DISABLE KEYS */;
INSERT INTO `background_equipment` VALUES (6,1),(7,2),(8,3),(9,4),(5,5);
/*!40000 ALTER TABLE `background_equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `backgrounds`
--

DROP TABLE IF EXISTS `backgrounds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `backgrounds` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `skill_proficiencies` char(255) DEFAULT NULL,
  `feature` char(255) NOT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `backgrounds_ibfk_1` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `backgrounds`
--

LOCK TABLES `backgrounds` WRITE;
/*!40000 ALTER TABLE `backgrounds` DISABLE KEYS */;
INSERT INTO `backgrounds` VALUES (1,'Akolita','Intuicja; Religia','Schronienie dla wiernych. Wraz z towarzyszami mo┼╝esz liczy─ç na darmowe leczenie i opiek─Ö w ┼Ťwi─ůtyni, kaplicy albo innym miejscu kultu twojej religii.',1),(2,'Artysta','Akrobatyka; Wyst─Öpy','Na ┼╝yczenie publiczno┼Ťci. Zawsze jeste┼Ť w stanie znale┼║─ç sobie miejsce do wyst─Öpowania. P├│ki wyst─Öpujesz co wiecz├│r, otrzymujesz darmowe zakwaterowanie i wy┼╝ywienie.',1),(3,'Ludowy Bohater','Opieka nad zwierz─Ötami; Sztuka przetrwania','Ludowa go┼Ťcinno┼Ť─ç. Ludzie ukryj─ů ci─Ö przed prawem lub szukaj─ůcymi ci─Ö osobami, cho─ç nie b─Öd─ů ryzykowa─ç dla ciebie ┼╝ycia.',1),(4,'M─Ödrzec','Historia; Wiedza tajemna','Badacz. Kiedy pr├│bujesz czego┼Ť si─Ö nauczy─ç lub co┼Ť sobie przypomnie─ç, a nie masz potrzebnej informacji, to najcz─Ö┼Ťciej wiesz sk─ůd i od kogo mo┼╝esz j─ů zdoby─ç.',1),(5,'Przest─Öpca','Oszustwo; Skradanie si─Ö','Kontakt w p├│┼é┼Ťwiatku. Posiadasz lojalny i godny zaufania kontakt, b─Öd─ůcy twoim ┼é─ůcznikiem ze ┼Ťwiatem przest─Öpczym. Masz swoje sposoby, by odbiera─ç od niego wiadomo┼Ťci i je nadawa─ç.',1);
/*!40000 ALTER TABLE `backgrounds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `character_equipment`
--

DROP TABLE IF EXISTS `character_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `character_equipment` (
  `equipment_id` int NOT NULL,
  `character_id` int NOT NULL,
  KEY `equipment_id` (`equipment_id`),
  KEY `character_id` (`character_id`),
  CONSTRAINT `character_equipment_ibfk_1` FOREIGN KEY (`equipment_id`) REFERENCES `equipment` (`id`),
  CONSTRAINT `character_equipment_ibfk_2` FOREIGN KEY (`character_id`) REFERENCES `characters` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character_equipment`
--

LOCK TABLES `character_equipment` WRITE;
/*!40000 ALTER TABLE `character_equipment` DISABLE KEYS */;
/*!40000 ALTER TABLE `character_equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characters`
--

DROP TABLE IF EXISTS `characters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characters` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `race` int NOT NULL,
  `background` int NOT NULL,
  `class` int NOT NULL,
  `subclass` int DEFAULT NULL,
  `level` int NOT NULL,
  `strength` int NOT NULL,
  `dexterity` int NOT NULL,
  `constitution` int NOT NULL,
  `intelligence` int NOT NULL,
  `wisdom` int NOT NULL,
  `charisma` int NOT NULL,
  `current_HP` int NOT NULL,
  `total_HP` int NOT NULL,
  `proficiencies` char(255) NOT NULL,
  `langauges` char(255) NOT NULL,
  `equipment` int NOT NULL,
  `spell_slots` char(255) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `race` (`race`),
  KEY `background` (`background`),
  KEY `class` (`class`),
  KEY `subclass` (`subclass`),
  CONSTRAINT `characters_ibfk_1` FOREIGN KEY (`race`) REFERENCES `races` (`id`),
  CONSTRAINT `characters_ibfk_2` FOREIGN KEY (`background`) REFERENCES `backgrounds` (`id`),
  CONSTRAINT `characters_ibfk_3` FOREIGN KEY (`class`) REFERENCES `classes` (`id`),
  CONSTRAINT `characters_ibfk_4` FOREIGN KEY (`subclass`) REFERENCES `subclasses` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characters`
--

LOCK TABLES `characters` WRITE;
/*!40000 ALTER TABLE `characters` DISABLE KEYS */;
INSERT INTO `characters` VALUES (1,'mekhat',3,3,1,2,3,8,0,15,0,0,0,15,20,'Lekkie pancerze;┼Ürednie pancerze;Ci─Ö┼╝kie pancerze;Tarcza;Bronie proste;Bronie ┼╝o┼énierskie;','Nizio┼éczy',0,NULL),(2,'Ungrund',1,2,1,1,5,15,8,15,5,10,10,14,14,'Lekkie pancerze;┼Ürednie pancerze;Ci─Ö┼╝kie pancerze;Tarcza;Bronie proste;Bronie ┼╝o┼énierskie;','Krasnoludzki',0,NULL);
/*!40000 ALTER TABLE `characters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_class_traits`
--

DROP TABLE IF EXISTS `class_class_traits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_class_traits` (
  `class_trait_id` int NOT NULL,
  `class_id` int NOT NULL,
  KEY `class_trait_id` (`class_trait_id`),
  KEY `class_id` (`class_id`),
  CONSTRAINT `class_class_traits_ibfk_1` FOREIGN KEY (`class_trait_id`) REFERENCES `class_traits` (`id`),
  CONSTRAINT `class_class_traits_ibfk_2` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_class_traits`
--

LOCK TABLES `class_class_traits` WRITE;
/*!40000 ALTER TABLE `class_class_traits` DISABLE KEYS */;
INSERT INTO `class_class_traits` VALUES (1,1),(2,1),(3,1),(6,2),(7,2),(12,3),(13,3),(14,3);
/*!40000 ALTER TABLE `class_class_traits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_equipment`
--

DROP TABLE IF EXISTS `class_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_equipment` (
  `equipment_id` int NOT NULL,
  `class_id` int NOT NULL,
  `slot` int NOT NULL,
  KEY `equipment_id` (`equipment_id`),
  KEY `class_id` (`class_id`),
  CONSTRAINT `class_equipment_ibfk_1` FOREIGN KEY (`equipment_id`) REFERENCES `equipment` (`id`),
  CONSTRAINT `class_equipment_ibfk_2` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_equipment`
--

LOCK TABLES `class_equipment` WRITE;
/*!40000 ALTER TABLE `class_equipment` DISABLE KEYS */;
INSERT INTO `class_equipment` VALUES (3,1,1),(2,1,1),(4,2,1),(1,3,1);
/*!40000 ALTER TABLE `class_equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_spells`
--

DROP TABLE IF EXISTS `class_spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_spells` (
  `spell_id` int NOT NULL,
  `class_id` int NOT NULL,
  KEY `spell_id` (`spell_id`),
  KEY `class_id` (`class_id`),
  CONSTRAINT `class_spells_ibfk_1` FOREIGN KEY (`spell_id`) REFERENCES `spells` (`id`),
  CONSTRAINT `class_spells_ibfk_2` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_spells`
--

LOCK TABLES `class_spells` WRITE;
/*!40000 ALTER TABLE `class_spells` DISABLE KEYS */;
INSERT INTO `class_spells` VALUES (1,2),(3,2);
/*!40000 ALTER TABLE `class_spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_traits`
--

DROP TABLE IF EXISTS `class_traits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `class_traits` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `description` char(255) NOT NULL,
  `refresh_time` enum('short rest','long rest','short or long rest','none','other') NOT NULL,
  `level` int NOT NULL,
  `optional` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_traits`
--

LOCK TABLES `class_traits` WRITE;
/*!40000 ALTER TABLE `class_traits` DISABLE KEYS */;
INSERT INTO `class_traits` VALUES (1,'Styl Walki','Specjalizujesz si─Ö w okre┼Ťlonym stylu walki. Wybierz jedn─ů spo┼Ťr├│d nast─Öpuj─ůcych mo┼╝liwo┼Ťci. Nie mo┼╝esz wybra─ç danego stylu walki wi─Öcej ni┼╝ raz, nawet je┼Ťli p├│┼║niej otrzymasz tak─ů szans─Ö.','none',1,0),(2,'Drugi Oddech','Mo┼╝esz u┼╝y─ç akcji dodatkowej w swojej turze, by odzyska─ç punkty wytrzyma┼éo┼Ťci w liczbie r├│wnej 1k10+tw├│j poziom wojownika. Aby ponownie skorzysta─ç z tej zdolno┼Ťci musisz uko┼äczy─ç kr├│tki lub d┼éugi odpoczynek.','short or long rest',1,0),(3,'Przyp┼éyw Si┼é','Od 2. poziomu mo┼╝esz na chwil─Ö pokona─ç w┼éasne ograniczenia. W swojej turze mo┼╝esz wykona─ç jeszcze jedn─ů akcj─Ö, opr├│cz swojej akcji podstawowej i mo┼╝liwej akcji dodatkowej.','short or long rest',2,0),(4,'Ulepszone trafienie krytyczne','Od chwili, gdy wybierasz ten archetyp na 3. poziomie, twoje ataki broni─ů skutkuj─ů trafieniem krytycznym przy wyniku 19 lub 20.','none',3,0),(5,'Rzucanie czar├│w','Po osi─ůgni─Öciu 3. poziomu rozszerzasz swoje umiej─Ötno┼Ťci bojowe o zdolno┼Ť─ç rzucania czar├│w.','none',3,0),(6,'Rzucanie czar├│w','Jako znawca magii i wiedzy tajemnej posiadasz ksi─Ög─Ö, w kt├│rej gromadzisz czary dokumentuj─ůce twoje kolejne kroki na ┼Ťcie┼╝ce mocy. Zapoznaj si─Ö z rozdzia┼éem zawieraj─ůcym og├│lne zasady rzucania zakl─Ö─ç oraz z list─ů czar├│w maga.\r\n','none',1,0),(7,'Odzyskiwanie mocy','Mo┼╝esz odzyska─ç wybrane kom├│rki czar├│w. Mog─ů mie─ç one ┼é─ůczn─ů liczb─Ö kr─Ög├│w nie wi─Öksz─ů od po┼éowy twojego poziomu maga i ┼╝adna z nich nie mo┼╝e pochodzi─ç z kr─Ögu 6. lub wy┼╝szego.','short rest',1,0),(8,'Uczony w iluzji','Pocz─ůwszy od wyboru tej szko┼éy na 2. poziomie, koszt i czas wpisywania czar├│w iluzji do ksi─Ögi czar├│w zostaje zmniejszony o po┼éow─Ö.','none',2,0),(9,'Ulepszona pomniejsza iluzja','Poznajesz sztuczk─Ö pomniejsza iluzja. Je┼Ťli ju┼╝ j─ů znasz, wybierz inn─ů sztuczk─Ö maga, kt├│rej chcesz si─Ö nauczy─ç.\r\nGdy rzucasz pomniejsz─ů iluzj─Ö, mo┼╝esz stworzy─ç jednocze┼Ťnie zar├│wno wra┼╝enie d┼║wi─Öku, jak i obrazu.','none',2,0),(10,'Uczony w nekromancji','Pocz─ůwszy od wyboru tej szko┼éy na 2. poziomie, koszt i czas wpisywania czar├│w nekromancji do ksi─Ögi czar├│w zostaje zmniejszony o po┼éow─Ö.','none',2,0),(11,'Ponure ┼╝niwa','Raz na tur─Ö, zabiwszy jedn─ů lub wi─Öcej istot czarem co najmniej 1. kr─Ögu, odzyskujesz punkty wytrzyma┼éo┼Ťci r├│wne podwojonemu kr─Ögowi tego czaru, albo potrojonemu, je┼Ťli nale┼╝y do szko┼éy nekromancji.','none',2,0),(12,'Znawstwo','Na 1. poziomie wybierasz dwie ze swych bieg┼éo┼Ťci w umiej─Ötno┼Ťciach albo bieg┼éo┼Ť─ç w u┼╝ywaniu narz─Ödzi z┼éodziejskich i jedn─ů bieg┼éo┼Ť─ç w umiej─Ötno┼Ťci. W ka┼╝dym te┼Ťcie cechy wykonywanym z ich u┼╝yciem premia z bieg┼éo┼Ťci zostaje podwojona.\r\n','none',1,0),(13,'Ukradkowy atak','Raz na rund─Ö, gdy atakujesz z u┼éatwieniem broni─ů finezyjn─ů lub dystansow─ů, mo┼╝esz zada─ç jednemu celowi 1k6 dodatkowych obra┼╝e┼ä.','none',1,0),(14,'Grypsera','Ucz─ůc si─Ö swojego fachu, pozna┼ée┼Ť tajne po┼é─ůczenie dialektu, ┼╝argonu i specjalnego kodu, pomagaj─ůce wplata─ç ukryte wiadomo┼Ťci w pozornie niewinne konwersacje.','none',1,0),(15,'Chytre zagranie','Od 2. poziomu po┼é─ůczenie zwinno┼Ťci i zdolno┼Ťci szybkiego kombinowania pozwala ci bardzo sprawnie reagowa─ç. Podczas walki w ka┼╝dej swojej turze mo┼╝esz w ramach akcji dodatkowej wykona─ç Odst─ůpienie, Ukrycie si─Ö lub Unik.','none',2,0),(16,'Szybkie d┼éonie','Pocz─ůwszy od 3. poziomu, mo┼╝esz w ramach akcji dodatkowej zapewnionej przez Chytre zagranie wykona─ç test Zr─Öczno┼Ťci (Zwinne d┼éonie), u┼╝y─ç narz─Ödzi z┼éodziejskich do rozbrojenia pu┼éapki lub otwarcia zamka albo wykona─ç akcj─Ö U┼╝ycia obiektu.','none',3,0),(17,'Praca na wysoko┼Ťci','Zyskujesz zdolno┼Ť─ç szybkiej wspinaczki; wspinanie si─Ö nie kosztuje ci─Ö ju┼╝ dodatkowej szybko┼Ťci.\r\nPonadto, podczas skoku z rozbiegu przemierzasz dystans zwi─Ökszony o odleg┼éo┼Ť─ç r├│wn─ů twojemu modyfikatorowi ze Zr─Öczno┼Ťci x 30 centymetr├│w.\r\n','none',3,0),(18,'Skrytob├│jstwo','Osi─ůgasz wyj─ůtkow─ů skuteczno┼Ť─ç, gdy wyprzedzasz swoich przeciwnik├│w. Masz u┼éatwienie w testach ataku przeciw istotom, kt├│re nie przeprowadzi┼éy jeszcze swojej tury. Co wi─Öcej, wszystkie twoje trafienia w zaskoczone istoty s─ů trafieniami krytycznymi.','none',3,0);
/*!40000 ALTER TABLE `class_traits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `hit_die` int NOT NULL,
  `proficiencies` char(255) NOT NULL,
  `skills_proficiencies_num` int NOT NULL,
  `skill_proficiencies` char(255) NOT NULL,
  `saving_throw_proficiencies` char(255) NOT NULL,
  `money` int NOT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `classes_ibfk_1` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,'Wojownik',10,'Lekkie pancerze; ┼Ürednie pancerze; Ci─Ö┼╝kie pancerze; Tarcza; Bronie proste; Bronie ┼╝o┼énierskie;',2,'Akrobatyka;Atletyka;Historia;Intuicja;Opieka nad zwierz─Ötami;Percepcja;Sztuka przetrwania;Zastraszanie','SI┼ü;KON',100,1),(2,'Mag',6,'Dr─ůg;Kusza lekka;Proca;Strza┼éka;Sztylet',12,'Historia;Intuicja;Medycyna;Religia;┼Üledztwo;Wiedza tajemna;','INT;MDR',60,1),(3,'┼üotr',8,'Lekkie pancerze;Bronie proste;Kusza r─Öczna;Miecz d┼éugi;Miecz kr├│tki;Rapier;Narz─Ödzia z┼éodziejskie',4,'Akrobatyka;Atletyka;Intuicja;Oszustwo;Percepcja;Perswazja;Skradanie si─Ö;┼Üledztwo;Wyst─Öpy;Zastraszanie;Zwinne d┼éonie','ZRC;INT',120,1);
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipment` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `description` char(255) NOT NULL,
  `rarity` char(100) NOT NULL,
  `weight` float NOT NULL,
  `cost` char(20) NOT NULL,
  `magic` tinyint(1) NOT NULL,
  `alignment` char(100) DEFAULT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `equipment_ibfk_1` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (1,'┼üom','Zapewnia u┼éatwienie w testach Si┼éy, gdy mo┼╝na u┼╝ywa─ç go u┼╝y─ç jako d┼║wigni.','pospolity',2.5,'2 sz',0,'Nie dotyczy',1),(2,'Miecz kr├│tki','┼╗o┼énierska bro┼ä bia┼éa, 1k6 k┼éute (SI┼ü/ZRC), finezyjna (modyfikator z ZRC lub SI┼ü), lekka (mo┼╝na walczy─ç dwiema)','pospolity',1,'10 sz',0,'Nie dotyczy',1),(3,'Kr├│tki ┼éuk i 20 strza┼é','Prosta bro┼ä dystansowa 1k6 k┼éute (ZRC), wymaga amunicji (strza┼éa), zasi─Ög 24m/96m, dwur─Öczna (atak wymaga dw├│ch r─ůk)','pospolity',1,'25 sz',0,'Nie dotyczy',1),(4,'Ksi─Öga czar├│w','Przedmiot niezwykle istotny dla mag├│w, b─Öd─ůcy zwykle oprawion─ů w sk├│r─Ö ksi─Ög─ů licz─ůc─ů 100 pustych welinowych stron, odpowiednich do zapisywania czar├│w.','pospolity',1.5,'50 sz',0,'Nie dotyczy',1),(5,'Narz─Ödzia z┼éodziejskie','Ten zestaw narz─Ödzi zawiera komplet wytrych├│w, niewielki pilnik, ma┼ée lusterko na metalowej r─ůczce, no┼╝yczki o w─ůskich ostrzach i szczypce.','pospolity',0.5,'25 sz',0,'Nie dotyczy',1),(6,'Szaty','Standardowy zestaw szat.','pospolity',2,'1 sz',0,'Nie dotyczy',1),(7,'Lutnia','Instrument muzyczny.','pospolity',1,'35 sz',0,'Nie dotyczy',1),(8,'Garnek','Metalowy. Przechowuje do 4l.','pospolity',5,'2 sz',0,'Nie dotyczy',1),(9,'Atrament','Buteleczka, 30ml.','pospolity',0,'10 sz',0,'Nie dotyczy',1),(10,'Sztylet jadu','Zyskujesz premi─Ö +1 do test├│w ataku i rzut├│w na obra┼╝enia.\r\nW ramach akcji mo┼╝esz spowodowa─ç, ┼╝e ostrze pokryje g─Östa, czarna trucizna. Cel otrzymuje 2k10 obra┼╝e┼ä od trucizny i zostaje zatruty na 1 minut─Ö.','rzadki',0.5,'250 sz',1,'┼üotr',2);
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `races`
--

DROP TABLE IF EXISTS `races`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `races` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `size` enum('malutki','ma┼éy','┼Ťredni','du┼╝y','wielki','ogromny') DEFAULT NULL,
  `speed` int NOT NULL,
  `langauges` char(255) NOT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `races_ibfk_1` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `races`
--

LOCK TABLES `races` WRITE;
/*!40000 ALTER TABLE `races` DISABLE KEYS */;
INSERT INTO `races` VALUES (1,'Krasnolud','┼Ťredni',9,'Krasnoludzki',1),(2,'Elf','┼Ťredni',9,'Elfi',1),(3,'Nizio┼éek','ma┼éy',9,'Nizio┼éczy',1),(4,'Cz┼éowiek','┼Ťredni',9,'Wsp├│lny',1),(5,'Centaur','du┼╝y',12,'Le┼Ťny',4);
/*!40000 ALTER TABLE `races` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `racial_traits`
--

DROP TABLE IF EXISTS `racial_traits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `racial_traits` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `description` char(255) NOT NULL,
  `refresh_time` enum('short rest','long rest','short or long rest','none','other') NOT NULL,
  `race` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `race` (`race`),
  CONSTRAINT `racial_traits_ibfk_1` FOREIGN KEY (`race`) REFERENCES `races` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `racial_traits`
--

LOCK TABLES `racial_traits` WRITE;
/*!40000 ALTER TABLE `racial_traits` DISABLE KEYS */;
INSERT INTO `racial_traits` VALUES (1,'Krasnoludzka odporno┼Ť─ç','Masz u┼éatwienie w rzutach obronnych przeciw truciznom i odporno┼Ť─ç na obra┼╝enia od trucizn.','none',1),(2,'Rodow├│d fey','Masz u┼éatwienie w rzutach obronnych przeciw zauroczeniu i magia nie mo┼╝e ci─Ö u┼Ťpi─ç.','none',2),(3,'Szcz─Ö┼Ťcie','Kiedy wyrzucisz 1 w te┼Ťcie ataku, te┼Ťcie cechy lub rzucie obronnym, mo┼╝esz przerzuci─ç ko┼Ť─ç. Musisz jednak zaakceptowa─ç nowy wynik.','none',3),(4,'Zwinno┼Ť─ç nizio┼éka','Mo┼╝esz przemie┼Ťci─ç si─Ö przez pole zajmowane przez inn─ů istot─Ö, kt├│ra jest wi─Ökszego rozmiaru ni┼╝ ty.','none',3),(5,'Szar┼╝a.','Je┼╝eli przemie┼Ťcisz si─Ö co najmniej 9m przed wykonaniem ataku, mo┼╝esz wykona─ç dodatkowy atak swoimi kopytami w ramach akcji dodatkowej.','none',5);
/*!40000 ALTER TABLE `racial_traits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sources`
--

DROP TABLE IF EXISTS `sources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sources` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sources`
--

LOCK TABLES `sources` WRITE;
/*!40000 ALTER TABLE `sources` DISABLE KEYS */;
INSERT INTO `sources` VALUES (1,'Podr─Öcznik Gracza'),(2,'Przewodnik Mistrza Podziemi'),(3,'Xanathar\'s Guide to Everything'),(4,'Mordekainen\'s Monsters of the Multiverse');
/*!40000 ALTER TABLE `sources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spells`
--

DROP TABLE IF EXISTS `spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `spells` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `level` enum('sztuczka','1','2','3','4','5','6','7','8','9') NOT NULL,
  `school` enum('Iluzji','Nekromancji','Odpychania','Przywo┼éywania','Przemiany','Urok├│w','Wieszczenia','Wywo┼éywania','Inne') NOT NULL,
  `casting_time` char(100) NOT NULL,
  `spell_range` char(100) NOT NULL,
  `components` char(100) NOT NULL,
  `duration` char(100) NOT NULL,
  `concentration` tinyint(1) NOT NULL,
  `saving_throw` char(100) DEFAULT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `spells_ibfk_1` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spells`
--

LOCK TABLES `spells` WRITE;
/*!40000 ALTER TABLE `spells` DISABLE KEYS */;
INSERT INTO `spells` VALUES (1,'Alarm','1','Odpychania','1 minuta','9 metr├│w','W, S, M','8 godzin',0,'Nie',1),(3,'Barwna kula','1','Wywo┼éywania','1 akcja','27 metr├│w','W, S, M (diament o warto┼Ťci co najmniej 50 sz)','Natychmiastowy',0,'Nie',1),(4,'Fa┼észywe ┼╝ycie','1','Nekromancji','1 akcja','Na siebie','W, S, M (niewielka ilo┼Ť─ç alkoholu lub spirytusu)','1 godzina',0,'Nie',1),(5,'Milcz─ůcy obraz','1','Iluzji','1 akcja','18 metr├│w','W, S, M (odrobina zwierz─Öcego runa)','do 10 minut',1,'Nie',1),(6,'Heroizm','1','Urok├│w','1 akcja','Dotyk','W, S','do 1 minuty',1,'Nie',1);
/*!40000 ALTER TABLE `spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subclass_class_traits`
--

DROP TABLE IF EXISTS `subclass_class_traits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subclass_class_traits` (
  `class_trait_id` int NOT NULL,
  `subclass_id` int NOT NULL,
  KEY `class_trait_id` (`class_trait_id`),
  KEY `subclass_id` (`subclass_id`),
  CONSTRAINT `subclass_class_traits_ibfk_1` FOREIGN KEY (`class_trait_id`) REFERENCES `class_traits` (`id`),
  CONSTRAINT `subclass_class_traits_ibfk_2` FOREIGN KEY (`subclass_id`) REFERENCES `subclasses` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subclass_class_traits`
--

LOCK TABLES `subclass_class_traits` WRITE;
/*!40000 ALTER TABLE `subclass_class_traits` DISABLE KEYS */;
INSERT INTO `subclass_class_traits` VALUES (18,5),(17,6),(16,6),(11,4),(10,4),(9,3),(8,3),(4,1),(5,2);
/*!40000 ALTER TABLE `subclass_class_traits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subclass_spells`
--

DROP TABLE IF EXISTS `subclass_spells`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subclass_spells` (
  `spell_id` int NOT NULL,
  `subclass_id` int NOT NULL,
  KEY `spell_id` (`spell_id`),
  KEY `subclass_id` (`subclass_id`),
  CONSTRAINT `subclass_spells_ibfk_1` FOREIGN KEY (`spell_id`) REFERENCES `spells` (`id`),
  CONSTRAINT `subclass_spells_ibfk_2` FOREIGN KEY (`subclass_id`) REFERENCES `subclasses` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subclass_spells`
--

LOCK TABLES `subclass_spells` WRITE;
/*!40000 ALTER TABLE `subclass_spells` DISABLE KEYS */;
INSERT INTO `subclass_spells` VALUES (6,2),(4,4),(5,3);
/*!40000 ALTER TABLE `subclass_spells` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subclasses`
--

DROP TABLE IF EXISTS `subclasses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subclasses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` char(100) NOT NULL,
  `class` int NOT NULL,
  `source_book` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `class` (`class`),
  KEY `source_book` (`source_book`),
  CONSTRAINT `subclasses_ibfk_1` FOREIGN KEY (`class`) REFERENCES `classes` (`id`),
  CONSTRAINT `subclasses_ibfk_2` FOREIGN KEY (`source_book`) REFERENCES `sources` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subclasses`
--

LOCK TABLES `subclasses` WRITE;
/*!40000 ALTER TABLE `subclasses` DISABLE KEYS */;
INSERT INTO `subclasses` VALUES (1,'Czempion',1,1),(2,'Mistyczny rycerz',1,1),(3,'Szko┼éa iluzji',2,1),(4,'Szko┼éa nekromancji',2,1),(5,'Skrytob├│jca',3,1),(6,'Z┼éodziej',3,1);
/*!40000 ALTER TABLE `subclasses` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-25 19:08:46
