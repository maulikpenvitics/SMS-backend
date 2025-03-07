
CREATE TABLE [dbo].[PropertyAdvertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[Location] [nvarchar](50) NULL,
[Fromdate] [datetime] NULL,
[Todate] [datetime] NULL,
[Amount] [decimal](18,2) NULL,
[Companyname] [nvarchar](50) NULL,
[Advertisorfirstname] [nvarchar](50) NULL,
[Advertisorlastname] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_PropertyAdvertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO