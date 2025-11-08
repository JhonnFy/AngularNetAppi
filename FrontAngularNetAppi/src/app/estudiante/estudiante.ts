import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { EstudianteService, Estudiante } from '../estudiante/services/services';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';




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
    filaEditandoId: number | null = null;
    nombreEditado: string = ''; 

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
  Swal.fire({
    title: '¿Estás Seguro?',
    text: "¡No podrás Revertir El Cambio!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#ff0000ff',
    confirmButtonText: 'Sí, Eliminar',
    cancelButtonText: 'No, Cancelar',
    cancelButtonColor: '#006bc9ff',
    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      this.estudianteService.eliminarEstudiante(id).subscribe({
        next: () => {
          this.cargarEstudiantes();
          Swal.fire('¡Eliminado!', 'El estudiante fue eliminado correctamente.', 'success');
        },
        error: (err) => {
          const mensaje = err.error?.mensaje || 'No se puede eliminar este estudiante porque tiene registros asociados.';
          Swal.fire('Error', mensaje, 'error');
          console.error(err);
        }
      });
    } else if (result.dismiss === Swal.DismissReason.cancel) {
      Swal.fire('Cancelado', 'No se eliminó el estudiante.', 'info');
    }
  });
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
  if(!this.filtro){
    this.cargarEstudiantes();
    return;
  }

  const id = +this.filtro;
  this.estudianteService.getEstudiantePorId(+this.filtro).subscribe({
  next: (estudiante: Estudiante) => {
    this.estudiantes = estudiante ? [estudiante] : [];
    this.paginaActual = 1;
  },
  error: (err) => {
    console.error('Error filtrando estudiante', err);
    this.estudiantes = [];
  }
});


}

limpiarFiltro() {
  this.filtro = '';
  this.paginaActual = 1;
  this.cargarEstudiantes();
}


// Activar modo edición en una fila
activarEdicion(est: Estudiante) {
  this.filaEditandoId = est.id;
  this.nombreEditado = est.nombre; // copia el valor actual
}

// Cancelar edición
cancelarEdicion() {
  this.filaEditandoId = null;
  this.nombreEditado = '';
}

// Guardar cambios con confirmación
guardarEdicion(est: Estudiante) {
  Swal.fire({
    title: '¿Deseas guardar los cambios?',
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Sí, actualizar',
    cancelButtonText: 'No, cancelar'
  }).then(result => {
    if (result.isConfirmed) {
      // Llamas al servicio para actualizar
      const estudianteActualizado: Estudiante = {
        id: est.id,
        nombre: this.nombreEditado
      };

      this.estudianteService.actualizarEstudiante(estudianteActualizado).subscribe({
        next: () => {
          Swal.fire('Actualizado', 'El estudiante fue actualizado correctamente.', 'success');
          this.cargarEstudiantes(); // recarga tabla
          this.cancelarEdicion();
        },
        error: (err) => {
          Swal.fire('Error', 'No se pudo actualizar el estudiante.', 'error');
          console.error(err);
        }
      });
    }
  });
}








}


