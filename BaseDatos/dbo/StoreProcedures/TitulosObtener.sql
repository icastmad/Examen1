CREATE PROCEDURE [dbo].[TitulosObtener]
	@IdTitulo INT =NULL
AS
BEGIN
SET NOCOUNT ON

SELECT Id_Titulo,Descripcion, Estado FROM Titulos
WHERE(@IdTitulo IS NULL OR Id_Titulo=@IdTitulo)

END

