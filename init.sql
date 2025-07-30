-- Crear la base de datos
CREATE DATABASE BDD_Polimusic_Song;
GO

-- Cambiar al contexto de la nueva base de datos
USE BDD_Polimusic_Song;
GO

-- Crear el usuario de SQL Server
CREATE LOGIN Admin_song WITH PASSWORD = 'Admin1_song_p@ssword';
GO

CREATE USER Admin_song FOR LOGIN Admin_song;
GO

-- Otorgar todos los privilegios al usuario
ALTER ROLE db_owner ADD MEMBER Admin_song;
GO

-- Crear tabla
CREATE TABLE [TBL_SONG] (
	[ID_SONG] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[SONG_NAME] VARCHAR(50) NOT NULL,
	[SONG_PATH] VARCHAR(255) NOT NULL,
	[PLAYS] INT NULL
);
GO

-- Insertar datos de prueba
INSERT INTO [TBL_SONG] ([SONG_NAME], [SONG_PATH], [PLAYS])
VALUES 
('Canción de prueba 1', '/songs/test1.mp3', 100),
('Canción Marco Marquez', '/songs/marcomarquez.mp3', 100),
('Canción de prueba 2', '/songs/test2.mp3', 250);
GO