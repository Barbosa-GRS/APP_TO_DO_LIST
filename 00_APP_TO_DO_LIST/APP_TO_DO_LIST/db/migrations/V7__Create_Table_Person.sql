CREATE TABLE IF NOT EXISTS `person` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `age` int DEFAULT NULL,
  `adressId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Person_Adress` (`adressId`),
  CONSTRAINT `FK_Person_Adress` FOREIGN KEY (`adressId`) REFERENCES `adress` (`id`)
)
