
CREATE TABLE [dbo].[PropertyDocs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[Unitid] [int] NULL,
[Docurl] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_PropertyDocs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO