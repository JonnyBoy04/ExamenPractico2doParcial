using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExamenPractico.Models;

public partial class Categoria
{
    public int CveCategoria { get; set; }

    public string? NombreCategoria { get; set; }

	[JsonIgnore]
	public virtual ICollection<Producto> Productos { get; set; }
}
