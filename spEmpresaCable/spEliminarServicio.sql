CREATE PROCEDURE spEliminarServicio(
	@codServicio uniqueidentifier
)
AS
	BEGIN
		
		DELETE FROM PaqueteServicio WHERE codServicio = @codServicio

		DELETE FROM Servicio WHERE codServicio = @codServicio

	END