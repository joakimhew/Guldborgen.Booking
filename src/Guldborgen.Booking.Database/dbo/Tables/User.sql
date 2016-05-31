CREATE TABLE [dbo].[User] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Username]         NVARCHAR (50)  NOT NULL,
    [FirstName]        NVARCHAR (50)  NOT NULL,
    [LastName]         NVARCHAR (50)  NOT NULL,
    [Password]         NVARCHAR (100) NOT NULL,
    [RegistrationDate] DATETIME       CONSTRAINT [DF__User__RegDate__108B795B] DEFAULT (getdate()) NOT NULL,
    [Email]            NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK__User__3214EC07F400BB4B] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Username]
    ON [dbo].[User]([Username] ASC);

