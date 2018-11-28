USE [domofon14]
GO

/****** Object:  View [dbo].[sОплата]    Script Date: 06.08.2016 20:25:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[sОплата]
AS
SELECT a.оплата, a.стоим1 + b.стоим2 - c.стоим3 AS оплатить
FROM     (SELECT dbo.оплаты.оплата, COALESCE (SUM(dbo.оплачено.сумма), 0) AS стоим1
                  FROM      dbo.оплаты LEFT OUTER JOIN
                                    dbo.оплачено ON dbo.оплаты.оплата = dbo.оплачено.оплата
                  GROUP BY dbo.оплаты.оплата) AS a INNER JOIN
                      (SELECT оплаты_2.оплата, COALESCE (SUM(ROUND(dbo.опл_работы.стоимость, 0)), 0) AS стоим2
                       FROM      dbo.оплаты AS оплаты_2 LEFT OUTER JOIN
                                         dbo.опл_работы ON оплаты_2.оплата = dbo.опл_работы.оплата
                       GROUP BY оплаты_2.оплата) AS b ON a.оплата = b.оплата INNER JOIN
                      (SELECT оплаты_1.оплата, COALESCE (SUM(ROUND(dbo.возврат.сумма, 0)), 0) AS стоим3
                       FROM      dbo.оплаты AS оплаты_1 LEFT OUTER JOIN
                                         dbo.возврат ON оплаты_1.оплата = dbo.возврат.оплата
                       GROUP BY оплаты_1.оплата) AS c ON a.оплата = c.оплата


GO
