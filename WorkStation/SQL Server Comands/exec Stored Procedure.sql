
exec dbo.spNewProject 8, 'admin123', 'quero um site'

exec dbo.spProjectTypeList
exec dbo.spCreateAd 'Andrei La556tis', 'nada', 'nata2', 'admin123', 40, 'Database'
---------------

exec dbo.spTestEmailservices 'andrei.latis.00'

exec dbo.spViewLanguageSkills

exec dbo.spViewTechnicalLanguageSkills

exec dbo.spViewTechnologySkills
------------------------------------
exec dbo.spDeleteTechnologySkill 'ola123'

exec dbo.spDeleteTechnicalLanguageSkill 'ola123'

exec dbo.spDeleteLanguageSkill 'ola123'
--------------------
exec dbo.spLanguageNewSkill 'ola123' ---ptpt

exec dbo.spTechnicalLanguageNewSkill 'ola123'----Language C#

exec dbo.spTechnologyNewSkill 'ola123'  ---tecnology
----------------------------
exec dbo.spUserProfile 'andrei.latis.00'

exec dbo.spGetProjectReview 'andrei.latis.00'

exec dbo.spLanguage 'andrei.latis.00'

exec dbo.spTechnicalLanguage 'admin123'

exec dbo.spTechnology 'X Æ A-12'

exec dbo.spAccount_Create 'admin123', 'admin', 'admin', 'admin123@gmail.com', 'ea53559838b42c9779e5fdae3edcb7f0172f8ad1c9ea6f07b77b3fd1120d6da68a7f0b0b6ddd8d38dd3dc7965228b65d8e319047d79c838f93533a228ad7d6f0', '\\Content\\upload\\img\\admin123.png', '10/12/2010' 

--exec dbo.spAccount_Update 'andrei', ''

exec dbo.spAccount_Login 'admin123@gmail.com', 'ea53559838b42c9779e5fdae3edcb7f0172f8ad1c9ea6f07b77b3fd1120d6da68a7f0b0b6ddd8d38dd3dc7965228b65d8e319047d79c838f93533a228ad7d6f0'

exec dbo.DeletRegister 'Japepino123'

exec dbo.CreateAd ' WebSite + DataBase + App Android e Ios', 'Faço Weblalal tenho 5 andos de experiencia na area de TI etc etc', 'oi', 'ola', 'olia', 'andrei.latis.00', 40, 1

exec dbo.GetAds 'Website'
exec dbo.GetStarsByUsername 'andrei.latis.00'
exec dbo.GetProfileImgByUsername 'andrei.latis.00'



