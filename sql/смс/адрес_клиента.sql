USE domofon14
GO
CREATE FUNCTION �����_�������
(
@������ uniqueidentifier ='9ED3F139-9FA7-E311-9649-4C001076112B'
)
RETURNS varchar(50)
AS
BEGIN
DECLARE @����� varchar(50)

SELECT @����� = '��.'+�����.������+'���.'+str(����.�����)+' '+����.������+'��.'+str(�������.��������)+' '+�������.���
FROM ����� inner join ����
on �����.�����=����.���
inner join ������� 
on ����.���= �������.���
WHERE �������.������ = @������;
RETURN @�����
END
