import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NotaService, Nota } from '../nota/services/services';
import { Router, RouterModule } from '@angular/router'; // <- RouterModule
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-nota',
  templateUrl: './nota.html',
  styleUrls: ['./nota.scss'], 
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class NotaComponent implements OnInit { 
    notas: Nota[] = [];
    paginaActual = 1;
    registrosPorPagina = 7;
    filaEditandoId: number | null = null;
    nombreEditado: string = ''; 
    filtro: string = ''; 

    constructor(
      private notaservice: NotaService,
      private http: HttpClient,
      private router: Router
    ) {}

    ngOnInit() {
      this.cargarNotas();
    }

    cargarNotas() {
      this.notaservice.getNotas().subscribe((data: Nota[]) => {
        this.notas = data;
      }, (err) => console.error('Error cargando notas', err));
    }

    aplicarFiltro() {
      if(!this.filtro){
        this.cargarNotas();
        return;
      }

      const id = +this.filtro;
      this.notaservice.getNotaPorId(id).subscribe({
        next: (nota: Nota) => {
          this.notas = nota ? [nota] : [];
          this.paginaActual = 1;
        },
        error: (err) => {
          console.error('Error filtrando nota', err);
          this.notas = [];
        }
      }); 
    }

    limpiarFiltro() {
      this.filtro = '';
      this.paginaActual = 1;
      this.cargarNotas();
    }
}
