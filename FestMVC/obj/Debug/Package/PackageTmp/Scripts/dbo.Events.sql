CREATE TABLE [dbo].[Events] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [FestivalId]    BIGINT         NOT NULL,
    [InstructorId]  BIGINT         NOT NULL,
    [RoomId]        BIGINT         NOT NULL,
    [StartDate]     DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [EndDate]       DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [Discriminator] NVARCHAR (128) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Events_dbo.Festivals_FestivalId] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Events_dbo.Instructors_InstructorId] FOREIGN KEY ([InstructorId]) REFERENCES [dbo].[Instructors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Events_dbo.Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FestivalId]
    ON [dbo].[Events]([FestivalId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_InstructorId]
    ON [dbo].[Events]([InstructorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoomId]
    ON [dbo].[Events]([RoomId] ASC);

