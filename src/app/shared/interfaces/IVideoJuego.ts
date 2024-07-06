export interface IVideoJuego {
  cveProducto: number;
  nombre: string;
  descripcion: string;
  precio: number;
  imagen: string;
  categoria: ICategoria;
}

export interface ICategoria {
  cveCategoria: number;
  nombreCategoria: string;
}
