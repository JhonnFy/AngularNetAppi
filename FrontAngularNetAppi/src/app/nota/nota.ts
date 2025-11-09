import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NotaService, Nota } from '../nota/services/services';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-nota',
  templateUrl: './nota.html',
  styleUrls: ['./nota.scss'], 
  standalone: true
})
export class NotaComponent {
    notas: Nota[] = [];
      paginaActual = 1;
      registrosPorPagina = 7;
      filaEditandoId: number | null = null;
      nombreEditado: string = ''; 
  
    constructor(
      private notaservice: NotaService,
      private http: HttpClient,
      private router: Router
    ) {}
  
    ngOnInit() {

    }

  cargarNotas() {
    this.notaservice.getNotas().subscribe((data: Nota[]) => {
      this.notas = data;
    }, (err) => console.error('Error cargando notas', err));
  }
 
  filtro: string = ''; 
  aplicarFiltro() {
    if(!this.filtro){
      this.cargarNotas();
      return;
    }
  
    const id = +this.filtro;
    this.notaservice.getNotaPorId(+this.filtro).subscribe({
    next: (nota: Nota) => {
      this.notas = this.notas ? [nota] : [];
      this.paginaActual = 1;
    },
    error: (err) => {
      console.error('Error filtrando nota', err);
      this.notas = [];
    }
    }); 
  }






}
