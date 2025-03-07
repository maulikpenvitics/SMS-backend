
CREATE TABLE [dbo].[PropertyVehicleTito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyVehicleId] [int] NULL,
[Checkintime] [datetime] NULL,
[Checkouttime] [datetime] NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_PropertyVehicleTito] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO