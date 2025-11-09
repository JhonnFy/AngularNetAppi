import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { NotaService, Nota } from '../nota/services/services';
import { Router, RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
import { ProfesorService } from '../profesor/services/services';
import { EstudianteService } from '../estudiante/services/services';


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
    valorEditado: number | null = null;
    filtro: string = ''; 

    constructor(
  private notaservice: NotaService,
  private http: HttpClient,
  private router: Router,
  private profesorService: ProfesorService,
  private estudianteService: EstudianteService
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

    // Activar modo edición en una fila
    activarEdicion(nota: Nota) {
      this.filaEditandoId = nota.id;
      this.nombreEditado = nota.nombre;
      this.valorEditado = nota.valor;
    }

    // Cancelar edición
    cancelarEdicion() {
      this.filaEditandoId = null;
      this.nombreEditado = '';
      this.valorEditado = null;
    }

    // Guardar cambios con confirmación
    guardarEdicion(nota: Nota) {
      Swal.fire({
        title: '¿Deseas guardar los cambios?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sí, actualizar',
        cancelButtonText: 'No, cancelar'
      }).then(result => {
        if (result.isConfirmed) {
          const notaActualizada: Nota = {
            id: nota.id,
            nombre: this.nombreEditado,
            valor: this.valorEditado ?? nota.valor,
            idProfesor: nota.idProfesor,
            idEstudiante: nota.idEstudiante
          };

          this.notaservice.actualizarNota(notaActualizada).subscribe({
            next: () => {
              Swal.fire('Actualizado', 'La nota fue actualizada correctamente.', 'success');
              this.cargarNotas();
              this.cancelarEdicion();
            },
            error: (err) => {
              Swal.fire('Error', 'No se pudo actualizar la nota.', 'error');
              console.error(err);
            }
          });
        }
      });
    }

    // Eliminar nota con confirmación
    eliminarNota(id: number) {
      Swal.fire({
        title: '¿Estás seguro?',
        text: "¡No podrás revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#ff0000ff',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'No, cancelar',
        cancelButtonColor: '#006bc9ff',
        reverseButtons: true
      }).then((result) => {
        if (result.isConfirmed) {
          this.notaservice.eliminarNota(id).subscribe({
            next: () => {
              this.cargarNotas();
              Swal.fire('¡Eliminado!', 'La nota fue eliminada correctamente.', 'success');
            },
            error: (err) => {
              Swal.fire('Error', 'No se puede eliminar esta nota.', 'error');
              console.error(err);
            }
          });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
          Swal.fire('Cancelado', 'No se eliminó la nota.', 'info');
        }
      });
    }

    // Getter que devuelve solo las notas de la página actual
    get notasPaginadas(): Nota[] {
      const inicio = (this.paginaActual - 1) * this.registrosPorPagina;
      return this.notas.slice(inicio, inicio + this.registrosPorPagina);
    }

    totalPaginas(): number {
      return Math.ceil(this.notas.length / this.registrosPorPagina);
    }

    paginaSiguiente() {
      if (this.paginaActual < this.totalPaginas()) this.paginaActual++;
    }

    paginaAnterior() {
      if (this.paginaActual > 1) this.paginaActual--;
    }



abrirCrearNota() {
  Swal.fire({
    title: '<strong>Crear Nota</strong>',
    html: `
      <div style="display:flex; align-items:center; gap:6px; margin-bottom:6px;">
        <i class="bi bi-hash" style="font-size:1.2rem;"></i>
        <input id="swal-input-id" class="swal2-input" placeholder="ID Nota">
      </div>
      <div style="display:flex; align-items:center; gap:6px; margin-bottom:6px;">
        <i class="bi bi-pencil" style="font-size:1.2rem;"></i>
        <input id="swal-input-nombre" class="swal2-input" placeholder="Nombre Nota">
      </div>
      <div style="display:flex; align-items:center; gap:6px; margin-bottom:6px;">
        <i class="bi bi-person-fill" style="font-size:1.2rem;"></i>
        <input id="swal-input-idProfesor" class="swal2-input" placeholder="ID Profesor">
      </div>
      <div style="display:flex; align-items:center; gap:6px; margin-bottom:6px;">
        <i class="bi bi-person" style="font-size:1.2rem;"></i>
        <input id="swal-input-idEstudiante" class="swal2-input" placeholder="ID Estudiante">
      </div>
      <div style="display:flex; align-items:center; gap:6px; margin-bottom:6px;">
        <i class="bi bi-pencil-square" style="font-size:1.2rem;"></i>
        <input id="swal-input-valor" class="swal2-input" placeholder="Valor Nota">
      </div>
    `,
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Crear',
    cancelButtonText: 'Cancelar',
    confirmButtonColor: '#ff0000',
    cancelButtonColor: '#006bc9',
    reverseButtons: true,
    preConfirm: async () => {
      const id = (document.getElementById('swal-input-id') as HTMLInputElement).value;
      const nombre = (document.getElementById('swal-input-nombre') as HTMLInputElement).value;
      const idProfesor = (document.getElementById('swal-input-idProfesor') as HTMLInputElement).value;
      const idEstudiante = (document.getElementById('swal-input-idEstudiante') as HTMLInputElement).value;
      const valor = (document.getElementById('swal-input-valor') as HTMLInputElement).value;

      if (!id || !nombre || !idProfesor || !idEstudiante || !valor) {
        Swal.showValidationMessage('¡Completa todos los campos!');
        return false;
      }

      // Validar Profesor
      const profesorExist = await this.profesorService.getProfesorPorId(+idProfesor).toPromise()
        .then(() => true)
        .catch(() => false);

      if (!profesorExist) {
        Swal.showValidationMessage(`El Profesor con ID ${idProfesor} no existe.`);
        return false;
      }

      // Validar Estudiante
      const estudianteExist = await this.estudianteService.getEstudiantePorId(+idEstudiante).toPromise()
        .then(() => true)
        .catch(() => false);

      if (!estudianteExist) {
        Swal.showValidationMessage(`El Estudiante con ID ${idEstudiante} no existe.`);
        return false;
      }

      return { id: +id, nombre, idProfesor: +idProfesor, idEstudiante: +idEstudiante, valor: +valor };
    }
  }).then(result => {
    if (result.isConfirmed && result.value) {
      this.notaservice.registrarNota(result.value).subscribe({
        next: () => {
          Swal.fire('¡Creada!', `La nota se creó correctamente.`, 'success');
          this.cargarNotas(); // refresca tabla
        },
        error: (err) => {
          console.error('Error creando nota:', err);
          Swal.fire('Error', 'No se pudo crear la nota.', 'error');
        }
      });
    }
  });
}


    
}
