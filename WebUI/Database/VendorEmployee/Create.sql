
CREATE TABLE [dbo].[VendorEmployee](
	[VendorEmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NULL,
[Id] [int] NULL,
[Firstname] [nvarchar](50) NULL,
[Lastname] [nvarchar](50) NULL,
[Phoneno] [int] NULL,
[Address1] [nvarchar](50) NULL,
[Address2] [nvarchar](50) NULL,
[Cityid] [int] NULL,
[Stateid] [int] NULL,
[Countryid] [int] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_VendorEmployee] PRIMARY KEY CLUSTERED 
(
	[VendorEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO