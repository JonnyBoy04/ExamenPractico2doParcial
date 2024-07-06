import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { IVideoJuego } from '../../shared/interfaces/IVideoJuego';
import { VideojuegosService } from '../../shared/services/videojuegos.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, FormsModule, NgFor, NgIf],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  listaVideoJuegos: IVideoJuego[] = [];

  constructor(private _videoJuegosService: VideojuegosService) {
    this.getVideoJuegos();
  }

  getVideoJuegos() {
    this._videoJuegosService.getVideoJuegos().subscribe({
      next: (videoJuegos) => {
        this.listaVideoJuegos = videoJuegos.slice(0, 3);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
