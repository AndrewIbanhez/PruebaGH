SELECT TOP 10
	Cliente.cliente AS NombreCliente, 
	Cliente.direccion AS Direccion, 
	Cliente.nit AS NIT,
	Producto.producto AS NombreProducto, 
	SUM(Envio.pbruto) AS SumaPesoBrutoTransac,
	DATEPART(MONTH, Envio.fecha) AS Mes, 
	DATEPART(YEAR, Envio.fecha) AS Año
FROM Cliente 
	INNER JOIN Envio INNER JOIN Producto
		ON (Producto.codProducto = Envio.codProducto)
		ON (Cliente.codCliente = Envio.codCliente)
GROUP BY cliente, producto, direccion, nit, fecha
	
