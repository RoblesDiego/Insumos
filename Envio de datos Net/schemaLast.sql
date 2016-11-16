-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema InsumosBolivia
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Table `RegistroLote`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `RegistroLote` (
  `idRegistroLote` INT NOT NULL AUTO_INCREMENT,
  `codigoRegistroLote` VARCHAR(45) NULL,
  `versionControl` INT NULL DEFAULT 01,
  `lote` VARCHAR(45) NULL,
  `fecha` TIMESTAMP(0) NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idRegistroLote`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Esterilizacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Esterilizacion` (
  `idEsterilizacion` INT NOT NULL AUTO_INCREMENT,
  `noEsterilizacion` INT NULL,
  `tipoPresentacion` VARCHAR(45) NULL,
  `presion` DECIMAL(1) NULL,
  `temperatura` INT NULL,
  `horaInicio` TIME(0) NULL,
  `horaFinal` TIME(0) NULL,
  `tiempoCalentamiento` INT NULL,
  `tiempoEsterilizado` INT NULL,
  `Observacion` VARCHAR(45) NULL,
  `RegistroLote_idRegistroLote` INT NULL,
  PRIMARY KEY (`idEsterilizacion`),
  INDEX `fk_Esterilizacion_RegistroLote_idx` (`RegistroLote_idRegistroLote` ASC),
  CONSTRAINT `fk_Esterilizacion_RegistroLote`
    FOREIGN KEY (`RegistroLote_idRegistroLote`)
    REFERENCES `RegistroLote` (`idRegistroLote`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `RegistroEsterilizacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `RegistroEsterilizacion` (
  `idRegistroEsterilizacion` INT NOT NULL AUTO_INCREMENT,
  `fechahora` TIMESTAMP(0) NULL,
  `temperatura` INT NULL,
  `presion` DECIMAL(1) NULL,
  `etapa` VARCHAR(45) NULL,
  `Esterilizacion_idEsterilizacion` INT NULL,
  PRIMARY KEY (`idRegistroEsterilizacion`),
  INDEX `fk_RegistroEsterilizacion_Esterilizacion1_idx` (`Esterilizacion_idEsterilizacion` ASC),
  CONSTRAINT `fk_RegistroEsterilizacion_Esterilizacion1`
    FOREIGN KEY (`Esterilizacion_idEsterilizacion`)
    REFERENCES `Esterilizacion` (`idEsterilizacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
