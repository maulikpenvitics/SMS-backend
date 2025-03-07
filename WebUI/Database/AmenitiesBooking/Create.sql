
CREATE TABLE [dbo].[AmenitiesBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[PropertyAmenitiesId] [int] NULL,
[UserId] [int] NULL,
[Amenitiesstatus] [int] NULL,
[Availabilitytimeslots] [datetime] NULL,
[Bokingpurpose] [nvarchar](50) NULL,
[Checkintime] [nvarchar](50) NULL,
[Checkouttime] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[Modifieddate] [datetime] NULL,


 CONSTRAINT [PK_AmenitiesBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO