CREATE TABLE IF NOT EXISTS `to_do_list` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` text,
  `status` varchar(255) DEFAULT NULL,
  `person_id` int NOT NULL,
  PRIMARY KEY (`id`)
)
