CREATE PROCEDURE [dbo].[PuestosActualizar]
@IdPuesto INT,
@Nombre VARCHAR(250), 
@Salario INT,
@Estado BIT
AS
  BEGIN
  SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		
		UPDATE Puestos
		SET
		Nombre=@Nombre,
		Salario=@Salario,
		Estado=@Estado
		WHERE Id_Puesto=@IdPuesto

	   COMMIT TRANSACTION TRASA

	   SELECT 0 AS CodError , '' AS MsgError

   END TRY

   BEGIN CATCH
		SELECT
			ERROR_NUMBER() AS CodError,
			ERROR_MESSAGE() AS MsgError
		ROLLBACK TRANSACTION TRASA

   END CATCH

  END
