USE [domofon14]
GO

/****** Object:  View [dbo].[s������]    Script Date: 06.08.2016 20:25:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[s������]
AS
SELECT a.������, a.�����1 + b.�����2 - c.�����3 AS ��������
FROM     (SELECT dbo.������.������, COALESCE (SUM(dbo.��������.�����), 0) AS �����1
                  FROM      dbo.������ LEFT OUTER JOIN
                                    dbo.�������� ON dbo.������.������ = dbo.��������.������
                  GROUP BY dbo.������.������) AS a INNER JOIN
                      (SELECT ������_2.������, COALESCE (SUM(ROUND(dbo.���_������.���������, 0)), 0) AS �����2
                       FROM      dbo.������ AS ������_2 LEFT OUTER JOIN
                                         dbo.���_������ ON ������_2.������ = dbo.���_������.������
                       GROUP BY ������_2.������) AS b ON a.������ = b.������ INNER JOIN
                      (SELECT ������_1.������, COALESCE (SUM(ROUND(dbo.�������.�����, 0)), 0) AS �����3
                       FROM      dbo.������ AS ������_1 LEFT OUTER JOIN
                                         dbo.������� ON ������_1.������ = dbo.�������.������
                       GROUP BY ������_1.������) AS c ON a.������ = c.������


GO
