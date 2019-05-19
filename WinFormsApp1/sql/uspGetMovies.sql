USE [RazorPagesMovieContext-f9dc36d5-29a3-47bc-bd8c-212a2e1cab34]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[uspGetMovies]

SELECT	@return_value as 'Return Value'

GO
