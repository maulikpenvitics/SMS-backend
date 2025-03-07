
CREATE TABLE [dbo].[Resident](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
[Password] [string] NULL,
[Firstname] [nvarchar](50) NULL,
[Lastname] [nvarchar](50) NULL,
[Email] [nvarchar](50) NULL,
[Phoneno] [int] NULL,
[Detailedinfo] [nvarchar](50) NULL,
[PropertyId] [int] NULL,
[BlockId] [int] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_Resident] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO