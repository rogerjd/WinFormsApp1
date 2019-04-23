CREATE PROCEDURE [dbo].[USP_EmpByFirstName]
	@firstName varchar(25)
AS
	SELECT *
	from Employees
	where FirstName like @firstName + '%'
RETURN 0
