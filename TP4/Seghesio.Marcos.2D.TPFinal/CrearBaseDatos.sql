CREATE DATABASE TpFinalMarcosSeghesio;

GO

USE TpFinalMarcosSeghesio;

GO

CREATE TABLE [dbo].[InsumoAccesorio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[tipoAccesorio] [int] NOT NULL,
 CONSTRAINT [PK_InsumoAccesorio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Madera](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[estaLijada] [bit] NOT NULL,
	[forma] [varchar](50) NULL,
	[tipoMadera] [varchar](50) NULL,
 CONSTRAINT [PK_Madera] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Tela](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[color] [int] NOT NULL,
	[tipoTela] [int] NOT NULL,
 CONSTRAINT [PK_Tela] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MaderaProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[estaLijada] [bit] NOT NULL,
	[forma] [varchar](50) NULL,
	[tipoMadera] [varchar](50) NULL,
 CONSTRAINT [PK_MaderaProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TelaProducto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaIngreso] [datetime] NOT NULL,
	[color] [int] NOT NULL,
	[tipoTela] [int] NOT NULL,
 CONSTRAINT [PK_TelaProducto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Torre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estadoProducto] [int] NOT NULL,
	[idMaderaPrincipal] [int] NOT NULL,
	[idTelaProducto] [int] NOT NULL,
	[idMaderaColumna] [int] NOT NULL,
	[metrosYute] [int] NOT NULL,
	[modelo] [int] NOT NULL,
	[yuteInstalado] [int] NOT NULL,
 CONSTRAINT [PK_Torre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Torre]  WITH CHECK ADD  CONSTRAINT [FK_Torre_MaderaProducto] FOREIGN KEY([idMaderaPrincipal])
REFERENCES [dbo].[MaderaProducto] ([id])
GO

ALTER TABLE [dbo].[Torre] CHECK CONSTRAINT [FK_Torre_MaderaProducto]
GO

ALTER TABLE [dbo].[Torre]  WITH CHECK ADD  CONSTRAINT [FK_Torre_MaderaProducto1] FOREIGN KEY([idMaderaColumna])
REFERENCES [dbo].[MaderaProducto] ([id])
GO

ALTER TABLE [dbo].[Torre] CHECK CONSTRAINT [FK_Torre_MaderaProducto1]
GO

ALTER TABLE [dbo].[Torre]  WITH CHECK ADD  CONSTRAINT [FK_Torre_TelaProducto] FOREIGN KEY([idTelaProducto])
REFERENCES [dbo].[TelaProducto] ([id])
GO

ALTER TABLE [dbo].[Torre] CHECK CONSTRAINT [FK_Torre_TelaProducto]
GO

CREATE TABLE [dbo].[Estante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estadoProducto] [int] NOT NULL,
	[idMaderaProducto] [int] NOT NULL,
	[idTelaProducto] [int] NOT NULL,
	[cantidadEstantes] [int] NOT NULL,
 CONSTRAINT [PK_Estante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Estante]  WITH CHECK ADD  CONSTRAINT [FK_Estante_MaderaProducto] FOREIGN KEY([idMaderaProducto])
REFERENCES [dbo].[MaderaProducto] ([id])
GO

ALTER TABLE [dbo].[Estante] CHECK CONSTRAINT [FK_Estante_MaderaProducto]
GO

ALTER TABLE [dbo].[Estante]  WITH CHECK ADD  CONSTRAINT [FK_Estante_TelaProducto] FOREIGN KEY([idTelaProducto])
REFERENCES [dbo].[TelaProducto] ([id])
GO

ALTER TABLE [dbo].[Estante] CHECK CONSTRAINT [FK_Estante_TelaProducto]
GO