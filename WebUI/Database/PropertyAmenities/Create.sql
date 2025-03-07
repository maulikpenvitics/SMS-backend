
CREATE TABLE [dbo].[PropertyAmenities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PropertyId] [int] NULL,
[Amenityname] [nvarchar](50) NULL,
[Modifiedby] [int] NULL,
[ModifiedDate] [datetime] NULL,


 CONSTRAINT [PK_PropertyAmenities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO