use IPC2_2S2020

create table Usuario(
	ID_Usuario int,
	Nombre varchar(50),
	Apellido varchar(50),
	NombreUser varchar(25),
	Contraseña varchar(25),
	FechaNac date,
	País varchar(25),
	Correo varchar(35),
	primary key (ID_Usuario)
);

create table TipoPartida(
	ID_TipoPartida int,
	Nombre varchar(25),
	Descripcion varchar(25),
	primary key (ID_TipoPartida)
);

create table Ficha(
	ID_Ficha int,
	Color varchar(20),
	Fila varchar(5),
	Columna varchar(5),
	primary key (ID_Ficha)
);

create table Marcador(
	ID_Marcador int,
	NoFichasNegras int,
	NoFichasBlancas int,
	primary key (ID_Marcador)
);

create table Tablero(
	ID_Tablero int,
	id_ficha int,
	id_marcador int,
	constraint fk_ficha foreign key (id_ficha) references Ficha (ID_Ficha),
	constraint fk_marcador foreign key (id_marcador) references Marcador (ID_Marcador),
	primary key (ID_Tablero)
);

create table Torneo(
	ID_Torneo int,
	Nombre varchar(30),
	CantidadJug int,
	primary key (ID_Torneo)
);

create table Partida(
	ID_Partida int,
	id_tipopartida int,
	id_tablero int,
	constraint fk_tipopartida foreign key (id_tipopartida) references TipoPartida (ID_TipoPartida),
	constraint fk_tablero foreign key (id_tablero) references Tablero (ID_Tablero),
	primary key (ID_Partida)
);

create table Sala(
	ID_Sala int,
	id_partida int,
	id_usuario int,
	constraint fk_partida foreign key (id_partida) references Partida (ID_Partida),
	constraint fk_usuario foreign key (id_usuario) references Usuario (ID_Usuario),
	primary key (ID_Sala)
);

create table TipoReporte(
	ID_TipoReporte int,
	Nombre varchar(25),
	Descripcion varchar(35),
	primary key (ID_TipoReporte)
);

create table Reporte(
	ID_Reporte int,
	idUsuario int,
	idTipoReporte int,
	constraint fk_U foreign key (idUsuario) references Usuario (ID_Usuario),
	constraint fk_tiporeporte foreign key (idTipoReporte) references TipoReporte (ID_TipoReporte),
	primary key (ID_Reporte)
);

Alter table Sala add CantMovJ1 int;
Alter table Sala add CantMovJ2 int;

Alter table Partida add id_torneo int;
Alter table Partida add constraint fk_idTorneo Foreign Key (id_torneo) references Torneo(ID_Torneo);

insert into TipoPartida values(1, 'J vs CPU', 'Jugador contra CPU');
insert into TipoPartida values(2, 'J vs J', 'Jugador contra Jugador');
insert into TipoPartida values(3, 'Torneo', 'Partida de Torneo');

insert into Usuario values(1, 'Elder Anibal', 'Pum Rojas', 'Conker', '00761', '2/9/1999', 'Guatemala', 'ElderPum@gmail.com');