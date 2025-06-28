CREATE TABLE IF NOT EXISTS `region` (
  `id` int NOT NULL AUTO_INCREMENT,
  `acronym` varchar(100) DEFAULT NULL,
  `region_name` varchar(100) DEFAULT NULL,
  `country_id` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `Fk_Region_Country` (`country_id`),
  CONSTRAINT `Fk_Region_Country` FOREIGN KEY (`country_id`) REFERENCES `country` (`id`)
)
