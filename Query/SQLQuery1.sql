SELECT TOP 10 * FROM [dbo].[AspNetRoles]

SELECT TOP 10 * FROM [dbo].[AspNetUserLogins]

SELECT TOP 10 * FROM [dbo].[AspNetUserTokens]

-- USER --
SELECT TOP 10 * FROM [dbo].[AspNetUsers]

UPDATE [dbo].[AspNetUsers] SET [EmailConfirmed] = 1 WHERE [UserName] = 'hotelzadmin@gmail.com'