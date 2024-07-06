using ExamenPractico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenPractico.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VideoJuegosController : ControllerBase
	{
		private readonly TiendaVideojuegosContext _baseDatos;

		public VideoJuegosController(TiendaVideojuegosContext baseDatos)
		{
			_baseDatos = baseDatos;
		}

		[HttpGet]
		[Route("ObtenerVideoJuegos")]
		public async Task<ActionResult> Lista()
		{
			var videoJuegos = await _baseDatos.Productos
										  .Include(p => p.Categoria)
										  .ToListAsync();
			return Ok(videoJuegos);
		}

		[HttpGet]
		[Route("BuscarProductos")]
		public async Task<ActionResult> Buscar(string query)
		{
			var productos = await _baseDatos.Productos
											.Include(p => p.Categoria)
											.Where(p => p.Nombre.Contains(query))
											.ToListAsync();
			return Ok(productos);
		}

		[HttpGet]
		[Route("ObtenerProductoCategoria")]
		public async Task<ActionResult> ObtenerProductoCategoria(string categoria)
		{
			var productos = await _baseDatos.Productos
											.Include(p => p.Categoria)
											.Where(p => p.Categoria.NombreCategoria == categoria)
											.ToListAsync();
			return Ok(productos);
		}
	}
}
