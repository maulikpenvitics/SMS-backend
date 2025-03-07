
CREATE TABLE [dbo].[PropertyVehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[Vehiclenumber] [int] NULL,
[Model] [nvarchar](50) NULL,
[PropertyOwnersId] [int] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_PropertyVehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO