
CREATE TABLE [dbo].[Vendor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
[Lastname] [nvarchar](50) NULL,
[Companyname] [nvarchar](50) NULL,
[Address1] [nvarchar](50) NULL,
[Address2] [nvarchar](50) NULL,
[Cityid] [int] NULL,
[Stateid] [int] NULL,
[Countryid] [int] NULL,
[ModifiedBy] [int] NULL,
[ModifiedDate] [datetime] NULL,


 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO