USE [FabioPaes_BD]
GO
/****** Object:  Table [dbo].[pemissaousuario]    Script Date: 18/01/2022 20:23:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pemissaousuario](
	[per_id] [int] NOT NULL,
	[use_id] [int] NOT NULL,
	[per_nomefrm] [varchar](80) NOT NULL,
	[per_descricao] [varchar](100) NOT NULL,
	[per_bloqueado] [varchar](5) NOT NULL,
	[per_alterar] [varchar](5) NOT NULL,
	[per_excluir] [varchar](5) NOT NULL,
	[per_imprimir] [varchar](5) NOT NULL,
 CONSTRAINT [PK_pemissaousuario] PRIMARY KEY CLUSTERED 
(
	[per_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 18/01/2022 20:23:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[use_id] [int] NOT NULL,
	[use_nome] [varchar](150) NOT NULL,
	[use_login] [varchar](90) NOT NULL,
	[use_grupo] [varchar](90) NOT NULL,
	[use_senha] [varchar](300) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[use_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pemissaousuario]  WITH CHECK ADD  CONSTRAINT [FK_pemissaousuario_usuario] FOREIGN KEY([use_id])
REFERENCES [dbo].[usuario] ([use_id])
GO
ALTER TABLE [dbo].[pemissaousuario] CHECK CONSTRAINT [FK_pemissaousuario_usuario]
GO
