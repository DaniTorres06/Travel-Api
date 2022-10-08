USE [Travel]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/10/2022 2:52:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autores]    Script Date: 8/10/2022 2:52:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](45) NOT NULL,
	[apellidos] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Autores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Autores_has_libros]    Script Date: 8/10/2022 2:52:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autores_has_libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[autores_id] [int] NOT NULL,
	[libros_ISBN] [int] NOT NULL,
 CONSTRAINT [PK_Autores_has_libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editoriales]    Script Date: 8/10/2022 2:52:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editoriales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](45) NOT NULL,
	[Sede] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Editoriales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libros]    Script Date: 8/10/2022 2:52:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libros](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [int] NOT NULL,
	[Editoriales_id] [int] NOT NULL,
	[Titulo] [nvarchar](45) NOT NULL,
	[Sinopsis] [nvarchar](max) NULL,
	[N_paginas] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221007135116_initial', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Autores] ON 
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (1, N'Miguel de Cervantes', N'Saavedra')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (2, N'Gabriel', N'Garcia Marquez')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (3, N'William', N'Shakespeare')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (4, N'Edgar', N'Alan Poe')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (5, N'Dani', N'Torres')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (6, N'Dani', N'Torres')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (7, N'Dani', N'Torres')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (8, N'Yulieth', N'Cardona')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (10, N'Javier', N'Marias')
GO
INSERT [dbo].[Autores] ([Id], [nombre], [apellidos]) VALUES (11, N'Javier2', N'Marias')
GO
SET IDENTITY_INSERT [dbo].[Autores] OFF
GO
SET IDENTITY_INSERT [dbo].[Autores_has_libros] ON 
GO
INSERT [dbo].[Autores_has_libros] ([Id], [autores_id], [libros_ISBN]) VALUES (1, 3, 1528)
GO
INSERT [dbo].[Autores_has_libros] ([Id], [autores_id], [libros_ISBN]) VALUES (2, 2, 55)
GO
INSERT [dbo].[Autores_has_libros] ([Id], [autores_id], [libros_ISBN]) VALUES (3, 2, 552)
GO
SET IDENTITY_INSERT [dbo].[Autores_has_libros] OFF
GO
SET IDENTITY_INSERT [dbo].[Editoriales] ON 
GO
INSERT [dbo].[Editoriales] ([Id], [Nombre], [Sede]) VALUES (1, N'Los tres editores', N'Cali')
GO
INSERT [dbo].[Editoriales] ([Id], [Nombre], [Sede]) VALUES (2, N'Merlin SAS', N'Cali')
GO
INSERT [dbo].[Editoriales] ([Id], [Nombre], [Sede]) VALUES (3, N'Merlin SAS', N'Medellin')
GO
SET IDENTITY_INSERT [dbo].[Editoriales] OFF
GO
SET IDENTITY_INSERT [dbo].[Libros] ON 
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (1, 1528, 3, N'Ready player one', N'Año 2045. El adolescente Wade Watts es solo una de las millones de personas que se evaden del sombrío mundo real para sumergirse en un mundo utópico virtual donde todo es posible: OASIS. Wade participa en la búsqueda del tesoro que el creador de este mundo imaginario dejó oculto en su obra. No obstante, hay gente muy peligrosa compitiendo contra él.', N'350')
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (2, 2552, 2, N'Ready player Two', N' Días después de ganar el concurso del fundador de OASIS, James Halliday, Wade Watts recibe información sobre una nueva tecnología que Halliday creó y que nunca lanzó al público en general.', N'550')
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (3, 1364, 1, N'Viva sus fortalezas', N'N/A', N'250')
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (4, 2255, 1, N'El principito', N'El principito es una narración corta del escritor francés Antoine de Saint-Exupéry, que trata de la historia de un pequeño príncipe que parte de su asteroide a una travesía por el universo, en la cual descubre la extraña forma en que los adultos ven la vida y comprende el valor del amor y la amistad.', N'270')
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (5, 55, 3, N'Cien años de soledad', N'N/A', N'870')
GO
INSERT [dbo].[Libros] ([Id], [ISBN], [Editoriales_id], [Titulo], [Sinopsis], [N_paginas]) VALUES (6, 552, 3, N'El amor en los tiempos del colera', N'N/A', N'870')
GO
SET IDENTITY_INSERT [dbo].[Libros] OFF
GO
