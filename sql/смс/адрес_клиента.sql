USE domofon14
GO
CREATE FUNCTION адрес_клиента
(
@клиент uniqueidentifier ='9ED3F139-9FA7-E311-9649-4C001076112B'
)
RETURNS varchar(50)
AS
BEGIN
DECLARE @адрес varchar(50)

SELECT @адрес = 'ул.'+улицы.наимен+'дом.'+str(дома.номер)+' '+дома.корпус+'кв.'+str(клиенты.квартира)+' '+клиенты.фио
FROM улицы inner join дома
on улицы.улица=дома.дом
inner join клиенты 
on дома.дом= клиенты.дом
WHERE клиенты.клиент = @клиент;
RETURN @адрес
END
