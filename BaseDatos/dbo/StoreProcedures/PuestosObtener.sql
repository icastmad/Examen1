CREATE PROCEDURE [dbo].[PuestosObtener]
	@IdPuesto INT =NULL
AS
BEGIN
SET NOCOUNT ON

SELECT Id_Puesto,Nombre, Salario, Estado FROM Puestos
WHERE(@IdPuesto IS NULL OR Id_Puesto=@IdPuesto)

END
