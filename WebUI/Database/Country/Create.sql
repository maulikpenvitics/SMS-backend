
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Shortname] [nvarchar](50) NULL,
[Name] [nvarchar](50) NULL,
[Phonecode] [int] NULL,
[CreatedBy] [int] NULL,
[ModifiedBy] [int] NULL,
[CreatedDate] [datetime] NULL,
[ModifiedDate] [datetime] NULL,
[IsActive] [bit] NULL,
[IsDeleted] [bit] NULL,


 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO