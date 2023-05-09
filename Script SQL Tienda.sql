CREATE DATABASE SCI_MS

USE [SCI_MS]

-- DROP TABLE departamentos
CREATE TABLE departamentos (
	id int NOT NULL,
	numero_departamento int NOT NULL,
	nombre varchar(255) NOT NULL, 
	constraint PK_DEPARTAMENTO primary key (id)
);

-- DROP TABLE clases
CREATE TABLE clases (
	id int NOT NULL,
	numero_clase int NOT NULL,
	nombre varchar(255) NOT NULL,
	id_departamento int NOT NULL,
	constraint PK_CLASE primary key (id),
	constraint FK_CLASE_DEPARTAMENTO foreign key (id_departamento) references departamentos(id)
);

-- DROP TABLE familias
CREATE TABLE familias (
	id int NOT NULL, 
	numero_familia varchar(2) NOT NULL,
	nombre varchar(255) NOT NULL,
	id_clase int NOT NULL,
	constraint PK_FAMILIA primary key (id),
	constraint FK_FAMILIA_CLASE foreign key (id_clase) references clases(id)
);

-- DROP TABLE productos
CREATE TABLE productos (  
	sku int NOT NULL,  
	articulo varchar(15) NOT NULL,  
	marca varchar(15) NOT NULL,  
	modelo varchar(20) NOT NULL,  
	departamento int NOT NULL,  
	clase int NOT NULL,  
	familia int NOT NULL, 
	fecha_alta date NOT NULL,  
	stock int NOT NULL,
	cantidad int NOT NULL,  
	descontinuado bit NOT NULL,  
	fecha_baja date NOT NULL,  
	constraint PK_PROD primary key (sku),
	constraint FK_PROD_CLASE foreign key (clase) references clases(id),
	constraint FK_PROD_DEPARTAMENTO foreign key (departamento) references departamentos(id),
	constraint FK_PROD_FAMILIA foreign key (familia) references familias(id)
);

-- INSERCIÓN DE REGISTROS DE INTEGRIDAD
insert into departamentos values (1, 1, 'DOMÉSTICOS');
insert into departamentos values (2, 2, 'ELECTRÓNICA');
insert into departamentos values (3, 3, 'MUEBLE SUELTO');
insert into departamentos values (4, 4, 'SALAS, RECÁMARAS, COMEDORES');

insert into clases values (1, 1, 'COMESTIBLES', 1);
insert into clases values (2, 2, 'BATIDORAS', 1);
insert into clases values (3, 3, 'LICUADORAS', 1);
insert into clases values (4, 4, 'CAFETERAS', 1);
insert into clases values (5, 1, 'AMPLIFICADORES CAR AUDIO', 2);
insert into clases values (6, 2, 'AUTO STÉREOS', 2);
insert into clases values (7, 1, 'COLCHÓN', 3);
insert into clases values (8, 2, 'JUEGO BOX', 3);
insert into clases values (9, 1, 'SALAS', 4);
insert into clases values (10, 2, 'COMPLEMENTOS PARA SALAS', 4);
insert into clases values (11, 3, 'SOFÁS CAMA', 4);

insert into familias values (1, '00','SIN NOMBRE', 1);
insert into familias values (2, '01', 'LICUADORAS', 2);
insert into familias values (3, '02', 'EXCLUSIVO COPPEL.COM', 2);
insert into familias values (4, '01', 'BATIDORA MANUAL', 3);
insert into familias values (5, '02', 'PROCESADOR', 3);
insert into familias values (6, '03', 'PICADORA', 3);
insert into familias values (7, '04', 'BATIDORA PEDESTAL', 3);
insert into familias values (8, '05', 'BATIDORA FUENTE DE SODAS', 3);
insert into familias values (9, '06', 'MULTIPRÁCTICOS', 3);
insert into familias values (10, '07', 'EXCLUSIVO COPPEL.COM', 3);
insert into familias values (11, '01', 'CAFETERAS', 4);
insert into familias values (12, '02', 'PERCOLADORAS', 4);
insert into familias values (13, '01', 'AMPLIFICADOR/RECEPTOR', 5);
insert into familias values (14, '02', 'KIT DE INSTALACIÓN', 5);
insert into familias values (15, '03', 'AMPLIFICADORES COPPEL', 5);
insert into familias values (16, '01', 'AUTOSTÉREO CD C/BOCINAS', 6);
insert into familias values (17, '02', 'ACCESIORIOS CAR AUDIO', 6);
insert into familias values (18, '03', 'AMPLIFICADOR', 6);
insert into familias values (19, '04', 'ALARMA AUTO/CASA/OFICINA', 6);
insert into familias values (20, '05', 'SIN MECANISMO', 6);
insert into familias values (21, '06', 'CON CD', 6);
insert into familias values (22, '07', 'MULTIMEDIA', 6);
insert into familias values (23, '08', 'PAQUETE SIN MECANISMO', 6);
insert into familias values (24, '09', 'PAQUETE CON CD', 6);
insert into familias values (25, '01', 'PILLOW TOP KS', 7);
insert into familias values (26, '02', 'PILLOW TOP DOBLE KS', 7);
insert into familias values (27, '03', 'HULE ESPUMA KS', 7);
insert into familias values (28, '01', 'ESTÁNDAR INDIVIDUAL', 8);
insert into familias values (29, '02', 'PILLOW TOP INDIVIDUAL', 8);
insert into familias values (30, '03', 'PILOW TOP DOBLE INDIVIDUAL', 8);
insert into familias values (31, '01', 'ESQUINERAS SUPERIORES', 9);
insert into familias values (32, '02', 'TIPO L SECCIONAL', 9);
insert into familias values (33, '01', 'SILLÓN OCASIONAL', 10);
insert into familias values (34, '02', 'PUFF', 10);
insert into familias values (35, '03', 'BAÚL', 10);
insert into familias values (36, '04', 'TABURETE', 10);
insert into familias values (37, '01', 'SOFÁ CAMA TAPIZADO', 11);
insert into familias values (38, '02', 'SOFÁ CAMA CLÁSICO', 11);
insert into familias values (39, '03', 'ESTUDIO', 11);
