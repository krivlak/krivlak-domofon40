ALTER TABLE dbo.������ ADD
	���_������ uniqueidentifier NOT NULL CONSTRAINT DF_������_���_������ DEFAULT '4e620413-ebf5-4d69-be40-5627850f5215'
	 FOREIGN KEY([���_������])
REFERENCES [dbo].[����_�����] ([���_������])
GO
