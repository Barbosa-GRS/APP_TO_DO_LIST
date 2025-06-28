CREATE TABLE IF NOT EXISTS `adress` (
  `id` int NOT NULL AUTO_INCREMENT,
  `number` int DEFAULT NULL,
  `zipCodeId` int NOT NULL,
  `countryId` int NOT NULL,
  `regionId` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_Adress_zipcode` (`zipCodeId`),
  KEY `FK_Adress_country` (`countryId`),
  KEY `FK_Adress_region` (`regionId`),
  CONSTRAINT `FK_Adress_country` FOREIGN KEY (`countryId`) REFERENCES `country` (`id`),
  CONSTRAINT `FK_Adress_region` FOREIGN KEY (`regionId`) REFERENCES `region` (`id`),
  CONSTRAINT `FK_Adress_zipcode` FOREIGN KEY (`zipCodeId`) REFERENCES `zip_code` (`id`)
)
