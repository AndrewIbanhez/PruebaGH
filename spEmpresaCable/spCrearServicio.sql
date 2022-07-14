CREATE PROCEDURE spCrearServicio(
	@codServicio uniqueidentifier, 
	@nombre nvarchar(MAX), 
	@descripcion nvarchar(MAX)
)
AS
	BEGIN
		
		INSERT INTO Servicio(codServicio, nombre, descripcion)
		VALUES(@codServicio, @nombre, @descripcion)

	END