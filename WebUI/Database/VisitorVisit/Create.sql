
CREATE TABLE [dbo].[VisitorVisit](
	[Visitor] [int] IDENTITY(1,1) NOT NULL,
	[VisitorId] [int] NULL,
[Checkin] [datetime] NULL,
[Checkout] [datetime] NULL,
[BlockId] [int] NULL,
[Unit] [nvarchar](50) NULL,
[Gatepass] [int] NULL,
[UserId] [int] NULL,
[Purpose] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,
[User] [nvarchar](50) NULL,


 CONSTRAINT [PK_VisitorVisit] PRIMARY KEY CLUSTERED 
(
	[Visitor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO