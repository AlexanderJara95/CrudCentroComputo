# CrudCentroComputo
Crud de prueba realizado con Net Core 5

La base de datos

create table Marca(
id_marca int PRIMARY KEY NOT NULL,
marca varchar(50),    
);

create table Categoria(
id_categ int PRIMARY KEY NOT NULL,
categoria varchar(50),    
);

create table Productos(
id_prod varchar(10)PRIMARY KEY NOT NULL,
descripcion varchar(50),    
precio decimal,
id_categ int,
id_marca int,
foreign key (id_categ) references Categoria(id_categ),
foreign key (id_marca) references Marca(id_marca)
);
select * from productos;
