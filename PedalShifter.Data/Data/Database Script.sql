USE [PedalShifter3]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bikes]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bikes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DailyRate] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Category] [int] NOT NULL,
	[MainImage] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[SerialNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Bikes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HostOpenHours]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HostOpenHours](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HostId] [int] NOT NULL,
	[DateJoined] [datetime2](7) NOT NULL,
	[Day] [nvarchar](100) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_HostOpenHours] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hosts]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleInitial] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Birthday] [datetime2](7) NOT NULL,
	[DateJoined] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Zipcode] [int] NOT NULL,
	[PreferredLocationLattitude] [float] NOT NULL,
	[PreferredLocationLongitude] [float] NOT NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[IdentityId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Renters]    Script Date: 10-06-2022 10:45:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Renters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleInitial] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Birthday] [datetime2](7) NULL,
	[DateJoined] [datetime2](7) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Zipcode] [int] NULL,
	[ProfilePicture] [nvarchar](max) NULL,
	[GovernmentIssuedId] [nvarchar](max) NULL,
	[IdentityId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Renters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210410110924_initial', N'5.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210414040935_renters-initial', N'5.0.4')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210425172444_InitialCreate', N'5.0.4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'76c805cf-6418-473c-9f64-858a3a0bf5df', N'Renter', N'RENTER', N'83111087-835b-46ab-a5eb-96c5e596b7cb')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'84893a7f-d216-473c-9256-c73431bfa94d', N'Host', N'HOST', N'7d19982a-3e2c-4447-8fab-65fc76c8f5ad')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8579b878-31cf-4ddb-a2d9-d5cd93696a77', N'84893a7f-d216-473c-9256-c73431bfa94d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'76d99706-50cc-45f8-bd6a-a290323edb73', N'rajibmahata143@gmail.com', N'RAJIBMAHATA143@GMAIL.COM', N'rajibmahata143@gmail.com', N'RAJIBMAHATA143@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEM2VnshsDiVVOEd+ROdzzUrlVU0RdAddn8Vf9A8+BpNJSMD2VRpOCqyUdlKUOG0oHA==', N'IZKDOS3LYNGCG45ZHKCJRSAA6LBPLTAO', N'3e1e9b62-6076-4428-aac1-40099a4ab74a', NULL, 1, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8579b878-31cf-4ddb-a2d9-d5cd93696a77', N'rajibmahata143@outlook.com', N'RAJIBMAHATA143@OUTLOOK.COM', N'rajibmahata143@outlook.com', N'RAJIBMAHATA143@OUTLOOK.COM', 1, N'AQAAAAEAACcQAAAAEE7Wfh+6ufaq4PE3/S7GcmGR/X7FBYDro7n4y+QOIxpJCaABUZL+8exlC3WHfS5KhQ==', N'EE46JYCDBUXEKFSYOGPICZPNXLZYY2Y6', N'9d35e438-a509-490e-9c2e-ab8d99ad421d', N'09100184730', 1, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Bikes] ON 

GO
INSERT [dbo].[Bikes] ([id], [Name], [DailyRate], [Description], [Category], [MainImage], [UserId], [SerialNumber]) VALUES (1, N'Bike 10', CAST(2.00 AS Decimal(18, 2)), N'Thsi is pedal shifter bike', 1, N'7353c81b-8150-4b3e-adfa-836a9837b78a_howtoshift_shifters.jpg', N'8579b878-31cf-4ddb-a2d9-d5cd93696a77', NULL)
GO
SET IDENTITY_INSERT [dbo].[Bikes] OFF
GO
SET IDENTITY_INSERT [dbo].[HostOpenHours] ON 

GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (2, 1, CAST(N'2021-04-29 09:24:23.8098576' AS DateTime2), N'Sunday', CAST(N'06:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (3, 1, CAST(N'2021-04-29 09:25:58.6252196' AS DateTime2), N'Monday', CAST(N'04:30:00' AS Time), CAST(N'11:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (4, 1, CAST(N'2021-04-29 10:04:27.3036161' AS DateTime2), N'Tuesday', CAST(N'04:00:00' AS Time), CAST(N'10:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (5, 1, CAST(N'2021-04-29 10:05:50.3064152' AS DateTime2), N'Saturday', CAST(N'04:00:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (6, 1, CAST(N'2021-04-29 10:06:07.7755251' AS DateTime2), N'Friday', CAST(N'08:00:00' AS Time), CAST(N'14:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (7, 1, CAST(N'2021-04-29 10:06:23.5991624' AS DateTime2), N'Thursday', CAST(N'03:30:00' AS Time), CAST(N'13:00:00' AS Time), 1)
GO
INSERT [dbo].[HostOpenHours] ([Id], [HostId], [DateJoined], [Day], [StartTime], [EndTime], [IsActive]) VALUES (8, 1, CAST(N'2021-04-29 10:06:38.2669303' AS DateTime2), N'Wednesday', CAST(N'14:30:00' AS Time), CAST(N'21:30:00' AS Time), 1)
GO
SET IDENTITY_INSERT [dbo].[HostOpenHours] OFF
GO
SET IDENTITY_INSERT [dbo].[Hosts] ON 

GO
INSERT [dbo].[Hosts] ([Id], [FirstName], [MiddleInitial], [LastName], [Birthday], [DateJoined], [Address], [City], [State], [Zipcode], [PreferredLocationLattitude], [PreferredLocationLongitude], [ProfilePicture], [IdentityId]) VALUES (1, N'Rajib', NULL, N'Mahata', CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01 00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, 0, 34.67, -92.43, NULL, N'8579b878-31cf-4ddb-a2d9-d5cd93696a77')
GO
SET IDENTITY_INSERT [dbo].[Hosts] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[HostOpenHours]  WITH CHECK ADD  CONSTRAINT [FK_HostOpenHours_Hosts] FOREIGN KEY([HostId])
REFERENCES [dbo].[Hosts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HostOpenHours] CHECK CONSTRAINT [FK_HostOpenHours_Hosts]
GO
