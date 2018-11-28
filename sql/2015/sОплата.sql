alter view sОплата as 
SELECT a.оплата, a.стоим1 + b.стоим2 - c.стоим3 AS оплатить
FROM     (SELECT dbo.оплаты.оплата, COALESCE (SUM(dbo.оплачено.сумма), 0) AS стоим1
                  FROM      dbo.оплаты LEFT OUTER JOIN
                                    dbo.оплачено ON dbo.оплаты.оплата = dbo.оплачено.оплата
                  GROUP BY dbo.оплаты.оплата) AS a INNER JOIN
                      (SELECT dbo.оплаты.оплата, COALESCE (SUM(ROUND(dbo.опл_работы.стоимость, 0)), 0) AS стоим2
                       FROM      dbo.оплаты LEFT OUTER JOIN
                                         dbo.опл_работы ON dbo.оплаты.оплата = dbo.опл_работы.оплата
                       GROUP BY dbo.оплаты.оплата) AS b ON a.оплата = b.оплата INNER JOIN
                      (SELECT dbo.оплаты.оплата, COALESCE (SUM(ROUND(dbo.возврат.сумма, 0)), 0) AS стоим3
                       FROM      dbo.оплаты LEFT OUTER JOIN
                                         dbo.возврат ON dbo.оплаты.оплата = dbo.возврат.оплата
                       GROUP BY dbo.оплаты.оплата) AS c ON a.оплата = c.оплата