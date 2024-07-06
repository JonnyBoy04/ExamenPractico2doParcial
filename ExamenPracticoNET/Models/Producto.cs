using System;
using System.Collections.Generic;

namespace ExamenPractico.Models;

public partial class Producto
{
    public int CveProducto { get; set; }

    public int CveCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Imagen { get; set; }

	public virtual Categoria Categoria { get; set; }
}
