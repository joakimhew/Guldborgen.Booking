CREATE TABLE [dbo].[UserSession] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [UserId]         NVARCHAR (50)    NOT NULL,
    [ExpirationDate] DATETIME         NULL,
    CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

