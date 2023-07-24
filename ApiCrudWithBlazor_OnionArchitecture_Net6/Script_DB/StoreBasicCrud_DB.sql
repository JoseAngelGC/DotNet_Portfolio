CREATE DATABASE StoreBasicCrud;
GO

USE StoreBasicCrud;
GO

CREATE TABLE Category(
idCategory INT PRIMARY KEY IDENTITY NOT NULL,
nombre VARCHAR(30) NOT NULL
);
GO

CREATE TABLE Products(
idProduct INT PRIMARY KEY IDENTITY NOT NULL,
nombre VARCHAR(30) NOT NULL,
precio DECIMAL(14,2) NOT NULL,
idCategory INT NOT NULL,
CONSTRAINT fk_Categoria FOREIGN KEY(idCategory) REFERENCES Category(idCategory)
);
GO

INSERT INTO Category(nombre) VALUES('Lacteos'),('Botanas'),('Abarrotes'),('Arinas y Pan'),('Bebidas'),('Higiene Personal');
GO

INSERT INTO Products(nombre,precio,idCategory) VALUES('Leche Entera',24.50,1),('Papas',16,2),('Galletas Saladas',14.50,4),
			('Agua Mineral',26,5), ('Leche Deslactosada',28,1),('Papel Higiénico',36,6), ('Yoghurt',14.40,1),('Mayonesa',35,3),
			('Frituras de Maíz',17.32,2),('Pan Tostados',22.50,4),('Queso Ranchero',18,3)
GO