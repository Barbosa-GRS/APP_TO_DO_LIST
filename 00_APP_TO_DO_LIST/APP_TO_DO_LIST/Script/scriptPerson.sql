CREATE TABLE `person` (
	`id` BIGINT NOT NULL AUTO_INCREMENT,
	`name` VARCHAR(50) NOT NULL,
	`street` VARCHAR(100),
	`number` int,
	`zip_code` int,
	`city` VARCHAR(100) ,
	`state` VARCHAR(100),
	`age` TINYINT(3) NOT NULL,
	`toDoLists` VARCHAR(255),
	PRIMARY KEY (`id`)
);
