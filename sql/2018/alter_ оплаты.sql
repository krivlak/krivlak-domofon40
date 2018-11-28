ALTER TABLE dbo.оплаты ADD
	вид_оплаты uniqueidentifier NOT NULL CONSTRAINT DF_оплаты_вид_оплаты DEFAULT '4e620413-ebf5-4d69-be40-5627850f5215'
	 FOREIGN KEY([вид_оплаты])
REFERENCES [dbo].[виды_оплат] ([вид_оплаты])
GO
