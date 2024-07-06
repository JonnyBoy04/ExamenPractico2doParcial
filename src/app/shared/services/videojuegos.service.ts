import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment.development';
import { Observable } from 'rxjs';
import { IVideoJuego } from '../interfaces/IVideoJuego';

@Injectable({
  providedIn: 'root',
})
export class VideojuegosService {
  private _endpoint: string = environment.apiUrl;
  private _apiUrl: string = this._endpoint + 'VideoJuegos/';

  constructor(private http: HttpClient) {}

  getVideoJuegos(): Observable<IVideoJuego[]> {
    return this.http.get<IVideoJuego[]>(`${this._apiUrl}ObtenerVideoJuegos`);
  }

  buscarVideoJuego(nombre: string): Observable<IVideoJuego[]> {
    return this.http.get<IVideoJuego[]>(
      `${this._apiUrl}BuscarProductos?query=${nombre}`
    );
  }

  buscarVideoJuegoPorCategoria(categoria: string): Observable<IVideoJuego[]> {
    return this.http.get<IVideoJuego[]>(
      `${this._apiUrl}ObtenerProductoCategoria?categoria=${categoria}`
    );
  }
}
