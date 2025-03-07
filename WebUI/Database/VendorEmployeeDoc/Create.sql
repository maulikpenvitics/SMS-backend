
CREATE TABLE [dbo].[VendorEmployeeDoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Docurl] [nvarchar](50) NULL,
[Doctype] [nvarchar](50) NULL,
[VendorEmployeeId] [int] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_VendorEmployeeDoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO