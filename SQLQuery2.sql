CREATE TABLE [dbo].[TimeRecords]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [ProjectName] NVARCHAR(100) NOT NULL,
    [TaskName] NVARCHAR(100) NOT NULL,
    [StartTime] DATETIME NOT NULL,
    [Duration] TIME NOT NULL,
    [Price] DECIMAL(10, 2) NOT NULL,
    [RecordDate] DATETIME DEFAULT GETDATE()
)