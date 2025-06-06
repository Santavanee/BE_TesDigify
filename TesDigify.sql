USE [TesDigify]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 25-Apr-25 6:35:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NOT NULL,
	[NPWP] [nvarchar](50) NOT NULL,
	[DirectorName] [nvarchar](255) NOT NULL,
	[PICName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[AllowAccess] [bit] NOT NULL,
	[FileNPWP] [nvarchar](255) NULL,
	[FilePowerOfAttorey] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customer] ADD  DEFAULT ((0)) FOR [AllowAccess]
GO
