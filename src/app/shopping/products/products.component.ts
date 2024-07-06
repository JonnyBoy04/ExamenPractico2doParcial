import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { IVideoJuego } from '../../shared/interfaces/IVideoJuego';
import { VideojuegosService } from '../../shared/services/videojuegos.service';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, FormsModule, NgFor, NgIf],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent {
  listaVideoJuegos: IVideoJuego[] = [];
  isResultLoaded: boolean = false;

  nombreVideoJuego: string = '';

  constructor(private _videoJuegosService: VideojuegosService) {
    this.getVideoJuegos();
  }

  getVideoJuegos() {
    this._videoJuegosService.getVideoJuegos().subscribe({
      next: (videoJuegos) => {
        this.listaVideoJuegos = videoJuegos;
        this.isResultLoaded = true;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  buscarVideoJuego() {
    if (this.nombreVideoJuego == '') {
      this.getVideoJuegos();
      return;
    }
    this._videoJuegosService.buscarVideoJuego(this.nombreVideoJuego).subscribe({
      next: (videoJuego) => {
        this.listaVideoJuegos = videoJuego;
        this.isResultLoaded = true;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  buscarPorCategoria(categoria: string) {
    this._videoJuegosService.buscarVideoJuegoPorCategoria(categoria).subscribe({
      next: (videoJuego) => {
        this.listaVideoJuegos = videoJuego;
        this.isResultLoaded = true;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
