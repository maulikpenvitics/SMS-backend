CREATE TABLE [dbo].[Unit](
    [UnitId] [int] IDENTITY(1,1) NOT NULL,
    [UnitName] [nvarchar](50) NULL,
    [BlockId] [int] NULL,

    CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
    (
        [UnitId] ASC
    ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
            ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) 
    ON [PRIMARY],

    CONSTRAINT [FK_Unit_Block] FOREIGN KEY ([BlockId]) REFERENCES [dbo].[Block]([Id])
) ON [PRIMARY]
GO
