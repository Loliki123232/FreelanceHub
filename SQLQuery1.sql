CREATE TABLE [dbo].[ProjectInfo]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectName] NVARCHAR(50) NOT NULL, 
    [Client] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[TaskProject]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProjectId] INT NOT NULL, 
    [TaskName] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_TaskProject_ProjectInfo] FOREIGN KEY ([ProjectId]) REFERENCES [ProjectInfo]([Id])
)