CREATE TABLE [dbo].[tbl_Cad_Colab]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [colaborador] VARCHAR(50) NOT NULL, 
    [fa] VARCHAR(10) NOT NULL, 
    [acao] VARCHAR(20) NOT NULL, 
    [senha] VARCHAR(20) NOT NULL
)