CREATE PROCEDURE spActualizarServicio(
	@codServicio uniqueidentifier, 
	@nombre nvarchar(MAX),
	@descripcion nvarchar(MAX)
)
AS
	BEGIN
		
		UPDATE Servicio
		SET
			nombre = @nombre, 
			descripcion = @descripcion
		WHERE 
			codServicio = @codServicio

	END