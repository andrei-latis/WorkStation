select TypeProject.txt_type_project

--Seleciona os gasos para aparecer logo no inicio 
select sum(Project.stars) as 'Stars'        -- from Project where id_cliente = 17
from UserTable
inner join UserProjectDeveloper on UserTable.user_id = UserProjectDeveloper.id_developer
inner join Project on UserProjectDeveloper.id_project = Project.id_project
inner join TypeProject on Project.type_project = TypeProject.id_type_project
where UserTable.username = 'JProC'

select sum(Project.stars) from 
{
	select UserTable.user_first_name, UserTable.user_second_name, UserTable.username, UserTable.user_bio 
	from UserTable
	inner join UserProjectDeveloper on UserTable.user_id = UserProjectDeveloper.id_developer
	inner join Project on UserProjectDeveloper.id_project = Project.id_project
	inner join TypeProject on Project.type_project = TypeProject.id_type_project
	where TypeProject.txt_type_project = 'Scripts'
}where ;


	select [user_bio], [user_first_name], [user_second_name], [username] 
	from [WorkStationDB].[dbo].[UserTable] 
	where [username] = 'JProC'

--PROFILE@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
--para selecionar dados para o profile
select user_bio, user_first_name, user_second_name, username from UserTable where username = 'JProC'

-- Para ver a/as tecnologia/s de um certo user
select Technology.txt_technology 
from UserTable
inner join UserTechnology on UserTable.user_id = UserTechnology.id_user
inner join Technology on UserTechnology.id_technology = Technology.id_technology
where UserTable.username = 'JProC'


-- Para ver a/as TechnicalLanguage/s de um certo user
select TechnicalLanguage.txt_technical_language 
from UserTable
inner join UserTechnicalLanguage on UserTable.user_id = UserTechnicalLanguage.id_user
inner join TechnicalLanguage on UserTechnicalLanguage.id_TechnicalLanguage = TechnicalLanguage.id_technical_language
where UserTable.username = 'JProC'

declare @DeveloperId int
select @DeveloperId  = user_id from UserTable where [UserTable].[username] = 'andrei.latis.00';


-- Para ver a/as Language/s de um certo user
select LanguageTable.txt_language 
from UserTable
inner join UserLanguage on UserTable.user_id = UserLanguage.id_user
inner join LanguageTable on UserLanguage.id_language = LanguageTable.id_language
where UserTable.username = 'JProC'

--para selecionar os projetos para aparecer no profile 
select UserTable.Username, typeproject.txt_type_project, Project.Stars, Project.txt_review
from UserTable
inner join Project on UserTable.user_id = Project.id_cliente
INNER JOIN UserProjectDeveloper on Project.id_project = UserProjectDeveloper.id_project
inner join TypeProject on Project.type_project = TypeProject.id_type_project
where UserProjectDeveloper.id_developer = @DeveloperId

--@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


UPDATE UserTable
SET username = 'ola123312'
WHERE username = 'andreipanda';

declare @UserName2 varchar(50) = '1'
select @UserName2 = username from UserTable where user_email = 'qdwqqwd@gmail.com'
print @UserName2
if @UserName2 != '1'
begin
	print  -1
end
else
begin
	print  'nao existe' 
end	


declare @UserName23 int = '1'
print select user_level from UserTable where username = 'ola123312'

INSERT INTO WorkStationDB.dbo.UserTable values (17, (SELECT * FROM OPENROWSET(BULK N'C:\Users\andre\Documents\Visual Studio 2015\Projects\WorkStation\img\word1.png', SINGLE_BLOB) as T1))

INSERT INTO  WorkStationDB.dbo.UserTable ([user_id], [img])
SELECT 17, *
FROM OPENROWSET(BULK N'C:\Users\andre\Documents\Visual Studio 2015\Projects\WorkStation\img\word1.png', SINGLE_BLOB) image;

ALTER SERVER ROLE [bulkadmin] ADD MEMBER [sa]

GRANT ADMINISTER BULK OPERATIONS TO [sa]

SELECT Count(*) AS DistinctCountries
FROM UserTable where blocked = 0


select Project.stars 
from AdTable
INNER join Project on AdTable.id_ad = Project.id_ad
where ad_creatorID = 17


select Count(id_ad) from AdTable where ad_creatorID =17 and ad_closed = 0