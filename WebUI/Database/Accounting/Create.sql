
CREATE TABLE [dbo].[Accounting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Accountname] [nvarchar](50) NULL,
[PropertyId] [int] NULL,
[VendorId] [int] NULL,
[Accountid] [int] NULL,
[Accountno] [nvarchar](50) NULL,
[Balance] [int] NULL,
[Entitytype] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_Accounting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO