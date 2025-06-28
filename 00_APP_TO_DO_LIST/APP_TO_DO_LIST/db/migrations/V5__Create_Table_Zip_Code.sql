CREATE TABLE IF NOT EXISTS `zip_code` (
  `id` int NOT NULL AUTO_INCREMENT,
  `zip_code` varchar(100) DEFAULT NULL,
  `street` varchar(100) DEFAULT NULL,
  `neighborhood` varchar(100) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
)
