
CREATE TABLE [dbo].[PropertyRenteeAgreement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[BlockId] [int] NULL,
[Unitid] [int] NULL,
[Agreementurl] [nvarchar](50) NULL,
[PropertyRenteeId] [int] NULL,
[Agreementstartdate] [datetime] NULL,
[Agreementenddate] [datetime] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_PropertyRenteeAgreement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO