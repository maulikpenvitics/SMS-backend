
CREATE TABLE [dbo].[Property](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Propertyname] [nvarchar](50) NULL,
[Address1] [nvarchar](50) NULL,
[Address2] [nvarchar](50) NULL,
[Cityid] [int] NULL,
[Stateid] [int] NULL,
[Countryid] [int] NULL,
[Zipcode] [int] NULL,
[Phoneno] [int] NULL,
[Email] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO