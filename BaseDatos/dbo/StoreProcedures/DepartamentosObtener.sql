CREATE PROCEDURE [dbo].[DepartamentosObtener]
	@IdDepartamento INT =NULL
AS
BEGIN
SET NOCOUNT ON

SELECT Id_Departamento,Descripcion, Ubicacion, Estado FROM Departamentos
WHERE(@IdDepartamento IS NULL OR Id_Departamento=@IdDepartamento)

END