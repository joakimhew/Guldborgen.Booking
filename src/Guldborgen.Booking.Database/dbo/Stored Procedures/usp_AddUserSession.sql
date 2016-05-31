-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddUserSession]
	@Id UNIQUEIDENTIFIER,
	@UserId INT,
	@ExpirationDate DATETIME = NULL

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM dbo.UserSession
	WHERE UserId = @UserId

	INSERT INTO dbo.UserSession(Id, UserId, ExpirationDate)
	VALUES (@Id, @UserId, @ExpirationDate)

END
