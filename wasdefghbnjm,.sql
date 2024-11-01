USE [DBTarefaAnderline]
GO
/****** Object:  Table [dbo].[Prioridades]    Script Date: 28/10/2024 11:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prioridades](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Prioridades] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusTarefa]    Script Date: 28/10/2024 11:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusTarefa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
 CONSTRAINT [PK_StatusTarefa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarefa]    Script Date: 28/10/2024 11:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarefa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDPrioridade] [int] NOT NULL,
	[IDStatus] [int] NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DataCriacao] [datetime] NOT NULL,
 CONSTRAINT [PK_Tarefa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 28/10/2024 11:40:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](200) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Prioridades] ON 

INSERT [dbo].[Prioridades] ([ID], [Descricao]) VALUES (1, N'Curso SAEP')
INSERT [dbo].[Prioridades] ([ID], [Descricao]) VALUES (2, N'TCC')
SET IDENTITY_INSERT [dbo].[Prioridades] OFF
GO
SET IDENTITY_INSERT [dbo].[StatusTarefa] ON 

INSERT [dbo].[StatusTarefa] ([ID], [Descricao]) VALUES (1, N'Curso SAEP')
INSERT [dbo].[StatusTarefa] ([ID], [Descricao]) VALUES (2, N'Offline')
SET IDENTITY_INSERT [dbo].[StatusTarefa] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarefa] ON 

INSERT [dbo].[Tarefa] ([ID], [IDUsuario], [IDPrioridade], [IDStatus], [Descricao], [DataCriacao]) VALUES (1, 1, 2, 1, N'Tarefa 1', CAST(N'2024-10-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tarefa] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID], [Login], [Senha]) VALUES (1, N'Antony', N'12345')
INSERT [dbo].[Usuario] ([ID], [Login], [Senha]) VALUES (2, N'Reginaldo', N'regis123')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_Prioridades] FOREIGN KEY([IDPrioridade])
REFERENCES [dbo].[Prioridades] ([ID])
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_Prioridades]
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_StatusTarefa] FOREIGN KEY([IDStatus])
REFERENCES [dbo].[StatusTarefa] ([ID])
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_StatusTarefa]
GO
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_Usuario] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuario] ([ID])
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_Usuario]
GO
