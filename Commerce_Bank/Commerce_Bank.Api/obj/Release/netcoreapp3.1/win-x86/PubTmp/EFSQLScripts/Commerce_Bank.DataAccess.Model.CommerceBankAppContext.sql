CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE TABLE `ACCOUNT_TYPE` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` longtext CHARACTER SET utf8mb4 NULL,
        `IsActive` tinyint(1) NOT NULL,
        CONSTRAINT `PK_ACCOUNT_TYPE` PRIMARY KEY (`Id`)
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE TABLE `PERSON` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Firstname` longtext CHARACTER SET utf8mb4 NULL,
        `Lastname` longtext CHARACTER SET utf8mb4 NULL,
        `PhoneNo` longtext CHARACTER SET utf8mb4 NULL,
        `AccountNo` longtext CHARACTER SET utf8mb4 NULL,
        `IsActive` tinyint(1) NOT NULL,
        `Account_TypeId` int NOT NULL,
        CONSTRAINT `PK_PERSON` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_PERSON_ACCOUNT_TYPE_Account_TypeId` FOREIGN KEY (`Account_TypeId`) REFERENCES `ACCOUNT_TYPE` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE TABLE `BANK_ACTIVITY` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        `IsOpeningBalance` tinyint(1) NOT NULL,
        `IsDeposit` tinyint(1) NULL,
        `TrasactionAmount` decimal(65,30) NOT NULL,
        `Balance` decimal(65,30) NOT NULL,
        `TransactionDate` datetime(6) NOT NULL,
        `PersonId` int NOT NULL,
        CONSTRAINT `PK_BANK_ACTIVITY` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_BANK_ACTIVITY_PERSON_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `PERSON` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE TABLE `LAST_TRANSACTION` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `PersonId` int NOT NULL,
        `Balance` decimal(65,30) NOT NULL,
        `DateCreated` datetime(6) NOT NULL,
        CONSTRAINT `PK_LAST_TRANSACTION` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_LAST_TRANSACTION_PERSON_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `PERSON` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE TABLE `USER` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Username` longtext CHARACTER SET utf8mb4 NULL,
        `Password` longtext CHARACTER SET utf8mb4 NULL,
        `PersonId` int NOT NULL,
        CONSTRAINT `PK_USER` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_USER_PERSON_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `PERSON` (`Id`) ON DELETE RESTRICT
    );

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE INDEX `IX_BANK_ACTIVITY_PersonId` ON `BANK_ACTIVITY` (`PersonId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE INDEX `IX_LAST_TRANSACTION_PersonId` ON `LAST_TRANSACTION` (`PersonId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE INDEX `IX_PERSON_Account_TypeId` ON `PERSON` (`Account_TypeId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    CREATE INDEX `IX_USER_PersonId` ON `USER` (`PersonId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20210420154245_InitialMigration') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20210420154245_InitialMigration', '5.0.5');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

