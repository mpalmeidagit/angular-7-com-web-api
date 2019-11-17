use[master]
go
Create database Laboratorio;

USE [Laboratorio]
GO

/****** Object:  Table [dbo].[tab_clientes]    Script Date: 17/11/2019 01:22:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tab_clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Endereco] [varchar](100) NOT NULL,
	[Telefone] [varchar](15) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Cidade] [varchar](100) NOT NULL,
	[DataCadastro] [datetime] NULL,
	[Ativo] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


