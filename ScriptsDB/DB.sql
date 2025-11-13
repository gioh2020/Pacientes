Create DataBase pacientes;



CREATE TABLE `pacientes`.`paciente` (
  `id` VARCHAR(200) NOT NULL,
  `TipoDocumento` VARCHAR(45) NULL,
  `NumeroDocumento` VARCHAR(45) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Genero` VARCHAR(45) NULL,
  `Direccion` VARCHAR(45) NULL,
  `Telefono` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));
