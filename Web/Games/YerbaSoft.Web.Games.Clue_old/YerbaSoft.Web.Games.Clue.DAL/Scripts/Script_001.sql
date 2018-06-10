DROP TABLE [dbo].[Game];
DROP TABLE [dbo].[Usuario];
go
CREATE TABLE [dbo].[Usuario] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Nombre]   VARCHAR (50)     NOT NULL,
    [Login]    VARCHAR (50)     NOT NULL,
    [Password] VARCHAR (50)     NOT NULL,
	[Sexo]	   CHAR(1)			NOT NULL,
	[Logo]	   VARCHAR (100)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO [dbo].[Usuario] ([Id], [Nombre], [Login], [Password], [Sexo], [Logo]) VALUES (N'00000000-0000-0000-0000-000000000001', N'Admin', N'admin', N'admin', 'M', 'man.png');
INSERT INTO [dbo].[Usuario] ([Id], [Nombre], [Login], [Password], [Sexo], [Logo]) VALUES (N'00000000-0000-0000-0000-000000000002', N'Bot', N'bot', N'YerbaSoftSA1982', 'M', 'robot.png');
INSERT INTO [dbo].[Usuario] ([Id], [Nombre], [Login], [Password], [Sexo], [Logo]) VALUES (N'00000000-0000-0000-0000-000000000003', N'Bot Dificil', N'botdifcil', N'YerbaSoftSA1982', 'M', 'robot.png');
--------------------------
CREATE TABLE [dbo].[Game] (
    [Id]			UNIQUEIDENTIFIER NOT NULL,
    [Nombre]		VARCHAR (50)     NOT NULL,
	[Descripcion]   VARCHAR (2000)   NOT NULL,
	[Codigo]		VARCHAR (50)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO [dbo].[Game] ([Id], [Nombre], [Descripcion], [Codigo]) VALUES (N'00000000-0000-0000-0001-000000000000', N'Clue', 'El clue es un juego basado en el Cluedo, a su vez basado en el Espionaje. <a class="btn btn-default" href="https://es.wikipedia.org/wiki/Cluedo">Ver más &raquo;</a>', 'Clue');
--------------------------
