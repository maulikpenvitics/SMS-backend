
CREATE TABLE [dbo].[VendorInvoiceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VendorInvoiceId] [int] NULL,
[Lineitem] [nvarchar](50) NULL,
[Amount] [decimal](18,2) NULL,
[Description] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_VendorInvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO