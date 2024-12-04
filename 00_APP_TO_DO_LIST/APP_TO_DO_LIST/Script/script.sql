CREATE TABLE `to_do_list` (
    `id` BIGINT NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(80) NOT NULL,
    `description` VARCHAR(100) NOT NULL,
    `status` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`id`)
);
