
CREATE TABLE [dbo].[VendorInvoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NULL,
[Invoicedate] [datetime] NULL,
[Todate] [datetime] NULL,
[Amount] [decimal](18,2) NULL,
[Duedate] [datetime] NULL,
[Tax] [decimal](18,2) NULL,
[NetAmount] [decimal](18,2) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_VendorInvoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO