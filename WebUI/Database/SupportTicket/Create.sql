
CREATE TABLE [dbo].[SupportTicket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ticket] [nvarchar](50) NULL,
[Description] [nvarchar](50) NULL,
[Severity] [nvarchar](50) NULL,
[Duedate] [datetime] NULL,
[ServiceId] [int] NULL,
[Status] [nvarchar](50) NULL,
[Comment] [nvarchar](50) NULL,
[VendorEmployeeId] [int] NULL,
[VendorId] [int] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_SupportTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO