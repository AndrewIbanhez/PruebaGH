CREATE PROCEDURE spObtenerServicios
AS
	BEGIN
		SELECT
			X.codServicio, 
			X.nombre, 
			X.descripcion
		FROM Servicio AS X

	END