import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EstudianteService, Estudiante } from '../estudiante/services/services';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './estudiante.html',
  styleUrls: ['./estudiante.scss']
})
export class EstudianteComponent implements OnInit {
  estudiantes: Estudiante[] = [];
    paginaActual = 1;
    registrosPorPagina = 7;

  constructor(
    private estudianteService: EstudianteService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.cargarEstudiantes();
    this.cargarEstudiantesSinNotas();
  }

  cargarEstudiantes() {
    this.estudianteService.getEstudiantes().subscribe((data: Estudiante[]) => {
      this.estudiantes = data;
    }, (err) => console.error('Error cargando estudiantes', err));
  }

  irAlDashboard() {
    this.router.navigate(['/dashboard']);
  }

getEstudiantesSinNotas(){
  this.estudianteService.EstudiantesSinNotas().subscribe((id:number[]) =>{
    console.log(id);
  })
}

getEstudiantesConNotas(){
  this.estudianteService.EstudiantesConNotas().subscribe((id:number[])=>{
    console.log(id);
  })
}

ArrayIdsEstudiantesSinNotas: number [] = [];
cargarEstudiantesSinNotas() {
  this.estudianteService.EstudiantesSinNotas().subscribe((ids: number[]) => {
    this.ArrayIdsEstudiantesSinNotas = ids;
    console.log(ids); 
  });
}


  eliminarEstudiante(id: number) {
  if (confirm('¿Estás seguro de eliminar este estudiante?')) {
    this.estudianteService.eliminarEstudiante(id).subscribe({
      next: () => {
        this.cargarEstudiantes();
        alert('Estudiante eliminado correctamente.');
      },
      error: (err) => {
        if (err.error && err.error.mensaje) {
          alert(err.error.mensaje);
        } else if (err.status === 400) {
          alert('No se puede eliminar este estudiante porque tiene registros asociados.');
        } else {
          alert('No se puede eliminar este estudiante porque tiene registros asociados.');
          console.error(err);
        }
      }
    });
  } else {
    alert('No se eliminó el estudiante.');
  }
}



  // Getter que devuelve solo los estudiantes de la página actual
  get estudiantesPaginados(): Estudiante[] {
    const inicio = (this.paginaActual - 1) * this.registrosPorPagina;
    return this.estudiantes.slice(inicio, inicio + this.registrosPorPagina);
  }

  totalPaginas(): number {
    return Math.ceil(this.estudiantes.length / this.registrosPorPagina);
  }

  paginaSiguiente() {
    if (this.paginaActual < this.totalPaginas()) this.paginaActual++;
  }

  paginaAnterior() {
    if (this.paginaActual > 1) this.paginaActual--;
  }



filtro: string = ''; 
aplicarFiltro() {
  this.paginaActual = 1;
}

limpiarFiltro() {
  this.filtro = '';
  this.paginaActual = 1;
}







}


