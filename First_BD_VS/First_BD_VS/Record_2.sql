CREATE TABLE [dbo].[Record_2]
(
	[r_id] INT NOT NULL, 
    [phone] NVARCHAR(15) NOT NULL, 
    [id] INT FOREIGN KEY REFERENCES Record(id) NOT NULL 
)
