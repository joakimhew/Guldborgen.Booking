-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_AddReservation
	-- Add the parameters for the stored procedure here
	@UserId INT,
	@LaundryTimeId INT,
	@Date DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO Reservation(UserId, LaundryTimeId, [Date])
	VALUES(@UserId, @LaundryTimeId, @Date)
END
