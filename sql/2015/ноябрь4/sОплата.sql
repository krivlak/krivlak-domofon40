alter view s������ as 
SELECT a.������, a.�����1 + b.�����2 - c.�����3 AS ��������
FROM     (SELECT dbo.������.������, COALESCE (SUM(dbo.��������.�����), 0) AS �����1
                  FROM      dbo.������ LEFT OUTER JOIN
                                    dbo.�������� ON dbo.������.������ = dbo.��������.������
                  GROUP BY dbo.������.������) AS a INNER JOIN
                      (SELECT dbo.������.������, COALESCE (SUM(ROUND(dbo.���_������.���������, 0)), 0) AS �����2
                       FROM      dbo.������ LEFT OUTER JOIN
                                         dbo.���_������ ON dbo.������.������ = dbo.���_������.������
                       GROUP BY dbo.������.������) AS b ON a.������ = b.������ INNER JOIN
                      (SELECT dbo.������.������, COALESCE (SUM(ROUND(dbo.�������.�����, 0)), 0) AS �����3
                       FROM      dbo.������ LEFT OUTER JOIN
                                         dbo.������� ON dbo.������.������ = dbo.�������.������
                       GROUP BY dbo.������.������) AS c ON a.������ = c.������