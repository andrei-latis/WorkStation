alter procedure dbo.spNewProject
	@IdAd int,
	@ClienteUserName varchar(50),
	@RequirementsAndData varchar(8000)
as
begin
	declare @ClienteId int = 0
	declare @Status int = -1

	select @ClienteId = user_id from UserTable where username = @ClienteUserName
	
	if @ClienteId = 0
	begin
		select * from TableMinusOne
	end

	select @Status = status from Project where id_ad = @IdAd and id_cliente = @ClienteId
	if @Status != -1
	begin
		select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [Project] (id_ad, id_cliente, requirements_and_data, start_date, end_date, stars, txt_review, status)
		VALUES (@IdAd, @ClienteId, @RequirementsAndData, null, null, null, null, 1)
	end	
end



/*alter procedure dbo.GetAds
	@ProjectType varchar(50)
as
begin
	declare @ProjectTypeId int = -1
	select @ProjectTypeId = id_type_project from TypeProject where txt_type_project = @ProjectType

	if @ProjectTypeId = -1
	begin 
		select * from TableMinusOne
	end
	else
	begin	
		select [AdTable].[ad_name], [TypeProject].[txt_type_project], [AdTable].[project_price], [AdTable].[ad_img1], [AdTable].[ad_description], [UserTable].[username], [UserTable].profile_img, AdTable.id_ad
		from [AdTable]
		inner join [TypeProject] on [AdTable].[project_type] = [TypeProject].[id_type_project]
		inner join [UserTable] on [AdTable].[ad_creatorID] = [UserTable].[user_id]
		where [TypeProject].[id_type_project] = @ProjectTypeId and [AdTable].[ad_closed] = 0
	end
end
*/

/*
alter procedure dbo.spCreateAd
	@AdName varchar(50),
	@AdDescription varchar(200),
	@AdImage nvarchar(MAX), 
	@AdCreatorUsename varchar(50),
	@ProjectPrice money, 
	@project_type varchar(50)
as
begin
	declare @AdCount int = 0
	declare @UserId int = 0
	declare @TypeId int = 0

	select @UserId = user_id from UserTable where username = @AdCreatorUsename

	select @TypeId = id_type_project from TypeProject where txt_type_project = @project_type

	if @UserId = 0
	begin
		select * from TableMinusOne
	end

	if @TypeId = 0
	begin
		select * from TableMinusOne
	end


	select @AdCount = Count(id_ad) from AdTable where ad_creatorID = @UserId and ad_closed = 0

	if @AdCount = 3
	begin
		select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [AdTable] (ad_name, ad_description, ad_img1, ad_creatorID, project_price, project_type, ad_closed)
		VALUES (@AdName, @AdDescription, @AdImage, @UserId, @ProjectPrice, @TypeId, 0)
	end
end
/*

/*
create procedure dbo.spTestEmailservices
	@UserName varchar(50)
as
begin
	declare @userID int
	select @userID = user_id from UserTable where username = @UserName

	select [Project].[id_project], [Project].[status], [EmailServiceTest].[userID], [EmailServiceTest].[message], [EmailServiceTest].[dateSend]
	from AdTable
	inner join Project on AdTable.id_ad = Project.id_ad
	inner join EmailServiceTest on Project.id_project = EmailServiceTest.projectID
	where AdTable.ad_creatorID = @userID 
	order by EmailServiceTest.dateSend
	 
end
*/

/*
create procedure dbo.spViewTechnologySkills
as
begin
	select * from [Technology]
end

create procedure dbo.spViewTechnicalLanguageSkills
as
begin
	select * from [TechnicalLanguage]
end

create procedure dbo.spViewLanguageSkills
as
begin
	select * from [LanguageTable]
end
*/

/*
create procedure dbo.spDeleteTechnologySkill
	@Technology varchar(50)
as
begin 
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_technology from Technology where txt_technology = @Technology

	if @SeeIfExist != '-1'
	begin
		delete from [Technology] where txt_technology = @Technology;
	end
	else
	begin
		select * from TableMinusOne
	end
end
*/

/*
alter procedure dbo.spDeleteTechnicalLanguageSkill
	@TechnicalLanguage varchar(50)
as
begin 
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_technical_language from TechnicalLanguage where txt_technical_language = @TechnicalLanguage

	if @SeeIfExist != '-1'
	begin
		delete from [TechnicalLanguage] where txt_technical_language = @TechnicalLanguage;
	end
	else
	begin
		select * from TableMinusOne
	end
end
*/

/*
create procedure dbo.spDeleteLanguageSkill
	@Language varchar(50)
as
begin 
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_language from LanguageTable where txt_language = @Language

	if @SeeIfExist != '-1'
	begin
		delete from [LanguageTable] where txt_language = @Language;
	end
	else
	begin
		select * from TableMinusOne
	end
end
*/
----------------------------------------------------------------------------------

/*
alter procedure dbo.spLanguageNewSkill
	@Language varchar(50)
as
begin
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_language from LanguageTable where txt_language = @Language

	if @SeeIfExist != '-1'
	begin
	select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [LanguageTable] (txt_language)
		VALUES (@Language)
	end
end
*/

/*
alter procedure dbo.spTechnicalLanguageNewSkill
	@TechnicalLanguage varchar(50)
as
begin
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_technical_language from TechnicalLanguage where txt_technical_language = @TechnicalLanguage

	if @SeeIfExist != '-1'
	begin
	select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [TechnicalLanguage] (txt_technical_language)
		VALUES (@TechnicalLanguage)
	end
end
/*

/*
alter procedure dbo.spTechnologyNewSkill
	@Technology varchar(50)
as
begin
	declare @SeeIfExist varchar(50) = '-1'
	select @SeeIfExist = txt_technology from Technology where txt_technology = @Technology

	if @SeeIfExist != '-1'
	begin
	select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [Technology] (txt_technology)
		VALUES (@Technology)
	end
end
*/

--------------------------------------------------------------------


/*
create procedure dbo.spUserProfile
	@username varchar(50)		
as 
begin								  
	select [profile_img], [user_bio], [user_first_name], [user_second_name], [username] 
	from [UserTable] 
	where [username] = @username
end
*/
/*
alter procedure dbo.spLanguage
	@username varchar(50)		
as 
begin
	select [LanguageTable].[txt_language] 
	from [UserTable]
	inner join [UserLanguage] on [UserTable].[user_id] = [UserLanguage].[id_user]
	inner join [LanguageTable] on [UserLanguage].[id_language] = [LanguageTable].[id_language]
	where [UserTable].[username] = @username
end
*/


/*
alter procedure dbo.spTechnicalLanguage
	@username varchar(50)		
as 
begin
	select [TechnicalLanguage].[txt_technical_language] 
	from [UserTable]
	inner join [UserTechnicalLanguage] on [UserTable].[user_id] = [UserTechnicalLanguage].[id_user]
	inner join [TechnicalLanguage] on [UserTechnicalLanguage].[id_TechnicalLanguage] = [TechnicalLanguage].[id_technical_language]
	where [UserTable].[username] = @username
end
*/

/*
alter procedure dbo.spTechnology
	@username varchar(50)		
as 
begin
	select [Technology].[txt_technology]
	from [UserTable]
	inner join [UserTechnology] on [UserTable].[user_id] = [UserTechnology].[id_user]
	inner join [Technology] on [UserTechnology].[id_technology] = [Technology].[id_technology]
	where [UserTable].[username] = @username
end
*/

/*
alter procedure dbo.spGetProjectReview
	@username varchar(50)
as
begin
	declare @DeveloperId int = 0
	set nocount on	
	select @DeveloperId = user_id from UserTable where [UserTable].[username] = @username;

	select [UserTable].[profile_img], [UserTable].user_first_name, [UserTable].[user_second_name], [Project].[Stars], [typeproject].[txt_type_project], [Project].[txt_review], [Project].[end_date]
	from [UserTable]
	inner join [Project] on [UserTable].[user_id] = [Project].[id_cliente]
	inner join [AdTable] on [Project].[id_ad] = [AdTable].[id_ad]
	inner join [TypeProject] on [AdTable].[project_type] = [TypeProject].[id_type_project]
	where [AdTable].ad_creatorID = @DeveloperId and [Project].[status] = 5
	order by [Project].[end_date]
end
*/


-- create role dbStoreProcedureOnlyAccess

/*
alter procedure dbo.spAccount_Create	
	@Username varchar(50),
	@FirstName varchar(50),
	@SecondName varchar(50),
	@UserEmail varchar(50), 
	@UserPassword varchar(128), 
	@UserProfileImg nvarchar(MAX),
	@UserBirthday date			
as 
begin								    
	set nocount on

	declare @user_id1 int = -1
	declare @user_id2 int = -1

	select @user_id1 = user_id from UserTable where username = @Username
	select @user_id2 = user_id from UserTable where user_email = @UserEmail

	if(@user_id1 != -1 OR @user_id2 != -1)
	begin
		select * from TableMinusOne
	end
	else
	begin
		INSERT INTO [UserTable] (username, user_first_name, user_second_name, user_email, user_password, profile_img, user_birthday, user_level, blocked)
		VALUES (@Username, @FirstName, @SecondName, @UserEmail, @UserPassword, @UserProfileImg, @UserBirthday, 0, 0)
	end
end 
*/


/*
alter procedure dbo.spAccount_Update --EditNormal Usando Username
 	@Username varchar(50),
	@FirstName varchar(50),
	@SecondName varchar(50),
	@UserEmail varchar(50), 
	@UserPassword varchar(50), 
	@UserBirthday date, 
	@UserLevel	tinyint = 1 			
as 
begin								    
	set nocount on

	declare @UserName2 varchar(50) = '0'

	select @UserName2 = username from UserTable where user_email = @UserEmail

	if @UserName2 != '0'
	begin
		print -1
	end
	else
	begin
		UPDATE UserTable
		SET user_first_name = @FirstName,
		user_second_name = @SecondName, user_email = @UserEmail, 
		user_password = @UserPassword, user_birthday = @UserBirthday
		WHERE username = @Username;
	end
end 
*/


/*
create procedure dbo.spAccount_UpdateUsername --EditUsername
 	@Username varchar(50),
	@UserEmail varchar(50)			
as 
begin								    
	set nocount on

	declare @UserEmail2 varchar(50) = '0'

	select @UserEmail2 = user_email from UserTable where username = @Username

	if @UserEmail2 != '0'
	begin
		print -1
	end
	else
	begin
		UPDATE UserTable
		SET username = @Username
		WHERE user_email = @UserEmail;
	end
end 
*/

/*
alter procedure dbo.spAccount_Login --EditUsername
 	@UserEmail varchar(50),
	@UserPassword varchar(128)
			
as 
begin								    
	set nocount on

	declare @UserPassword2 varchar(128) = '0' 

	select @UserPassword2 = user_password from UserTable where user_email = @UserEmail and blocked = 0

	if @UserPassword2 != @UserPassword 
	begin
		select * from TableMinusOne
	end
	else
	begin
		select user_level, username from UserTable where user_email = @UserEmail
	end
end 
*/


/*
create procedure dbo.spImgU
	@Name nvarchar(255),
	@Size int,
	@Img varbinary(MAX), 
	@NewId int output
as 
begin
	insert into img 
	values (@Name, @Size, @Img)

	select @NewId = SCOPE_IDENTITY()
end
*/


/*
alter procedure dbo.DeletRegister
	@Username varchar(50)
as
begin
	delete from UserTable where username = @Username;
end
*/


/*
alter procedure dbo.CreateAd
	@AdName varchar(50), 
	@AdDescription varchar(200),
	@AdImg1 nvarchar(MAX),
	@AdImg2 nvarchar(MAX),
	@AdImg3 nvarchar(MAX),
	@AdCreatorUsername varchar(50),
	@ProjectPrice money,
	@ProjectType int
as
begin
	declare @Ads int
	declare @UserID int

	select @UserID = user_id from UserTable where username = @AdCreatorUsername

	SELECT @Ads = Count(*)
	FROM [AdTable] where ad_creatorID = @UserID

	if @Ads >= 5
	begin
		return -1
	end
	else
	begin		
		INSERT INTO [AdTable] (ad_name, ad_description, ad_img1, ad_img2, ad_img3, ad_creatorID, project_price, project_type, ad_closed)
		VALUES (@AdName, @AdDescription, @AdImg1, @AdImg2, @AdImg3, @UserID, @ProjectPrice, @ProjectType, 0)
	end
end
*/




/*
alter procedure dbo.GetStarsByUsername
	@Username varchar(50)
as
begin
	declare @Stars int = -1
	declare @UserNameId int = -1

	select @UserNameId = user_id from [UserTable] where username = @Username

	SELECT sum([Project].[stars]) as stars
	FROM [AdTable]
	full outer join [Project] on [AdTable].id_ad = [Project].id_ad
	where ad_creatorID = @UserNameId

end
*/

/*
alter procedure dbo.GetProfileImgByUsername
	@Username varchar(50)
as
begin
	select profile_img from [UserTable] where username = @Username
end
*/



