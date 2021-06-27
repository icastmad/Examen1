﻿CREATE PROCEDURE [dbo].[TitulosActualizar]
@Id_Titulo INT,
@Descripcion VARCHAR(250), 
@Estado BIT
AS
  BEGIN
  SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		
		UPDATE Titulos
		SET
		Descripcion=@Descripcion,
		Estado=@Estado
		WHERE Id_Titulo=@Id_Titulo

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
