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
    private profesorservice: ProfesorService,
    private estudianteservice: EstudianteService
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
      title: '<strong>Nueva Nota</strong>',
      html: `
        <input id="swal-id" class="swal2-input" placeholder="ID Nota">
        <input id="swal-nombre" class="swal2-input" placeholder="Nombre Nota">
        <input id="swal-profesor" class="swal2-input" placeholder="ID Profesor">
        <input id="swal-estudiante" class="swal2-input" placeholder="ID Estudiante">
        <input id="swal-valor" class="swal2-input" placeholder="Valor (0-5)">
      `,
      focusConfirm: false,
      showCancelButton: true,
      confirmButtonText: 'Crear',
      cancelButtonText: 'Cancelar',
      preConfirm: async () => {
        const id = +(document.getElementById('swal-id') as HTMLInputElement).value;
        const nombre = (document.getElementById('swal-nombre') as HTMLInputElement).value.trim();
        const idProfesor = +(document.getElementById('swal-profesor') as HTMLInputElement).value;
        const idEstudiante = +(document.getElementById('swal-estudiante') as HTMLInputElement).value;
        const valor = +(document.getElementById('swal-valor') as HTMLInputElement).value;

        if (!id || !nombre || !idProfesor || !idEstudiante || isNaN(valor)) {
          Swal.showValidationMessage('Todos los campos son obligatorios');
          return false;
        }

        // Validar si profesor y estudiante existen
        const profExiste = await this.profesorservice.getProfesorPorId(idProfesor).toPromise().catch(() => null);
        const estExiste = await this.estudianteservice.getEstudiantePorId(idEstudiante).toPromise().catch(() => null);

        if (!profExiste) {
          Swal.showValidationMessage(`El profesor con ID ${idProfesor} no existe`);
          return false;
        }
        if (!estExiste) {
          Swal.showValidationMessage(`El estudiante con ID ${idEstudiante} no existe`);
          return false;
        }

        return { id, nombre, idProfesor, idEstudiante, valor };
      }
    }).then((result) => {
      if (result.isConfirmed && result.value) {
        this.notaservice.registrarNota(result.value).subscribe({
          next: () => {
            this.cargarNotas();
            Swal.fire('Éxito', 'Nota creada correctamente', 'success');
          },
          error: (err) => {
            console.error('Error creando nota', err);
            Swal.fire('Error', 'No se pudo crear la nota', 'error');
          }
        });
      }
    });
  }












    
}
