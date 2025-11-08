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



// abrirCrearUsuario() {
//   Swal.fire({
//     title: '<strong>Nuevo Estudiante</strong>',
//     html: `
//       <p style="font-size:0.9rem; color:#555;">DNI (Requerido)</p>
//       <div style="display:flex; align-items:center; gap:8px; margin-bottom:10px;">
//         <i class="bi bi-card-text" style="color:#ff4500; font-size:1.5rem;"></i>
//         <input id="swal-input-id" class="swal2-input" placeholder="DNI">
//       </div>
//       <div style="display:flex; align-items:center; gap:8px;">
//         <i class="bi bi-person-fill" style="color:#1e90ff; font-size:1.5rem;"></i>
//         <input id="swal-input-nombre" class="swal2-input" placeholder="Nombre" disabled>
//       </div>
//     `,
//     icon: 'question',
//     showCancelButton: true,
//     confirmButtonText: 'Sí, Crear',
//     cancelButtonText: 'No, Cancelar',
//     confirmButtonColor: '#ff0000',
//     cancelButtonColor: '#006bc9',
//     reverseButtons: true,
//     didOpen: () => {
//       const idInput = document.getElementById('swal-input-id') as HTMLInputElement;
//       const nombreInput = document.getElementById('swal-input-nombre') as HTMLInputElement;

//       // Activar/desactivar input de nombre según ID
//       idInput.addEventListener('input', () => {
//         nombreInput.disabled = !idInput.value.trim();
//       });
//     },
//     preConfirm: () => {
//       const id = (document.getElementById('swal-input-id') as HTMLInputElement).value;
//       const nombre = (document.getElementById('swal-input-nombre') as HTMLInputElement).value;
//       if (!id || !nombre) Swal.showValidationMessage('¡Completa todos los campos!');
//       return { id, nombre };
//     }
//   }).then(result => {
//     if (result.isConfirmed && result.value) {
//       console.log('Crear usuario:', result.value);
//       Swal.fire('¡Creado!', `Usuario "${result.value.nombre}" creado correctamente.`, 'success');
//     } else if (result.dismiss === Swal.DismissReason.cancel) {
//       Swal.fire('Cancelado', 'No se creó el usuario.', 'info');
//     }
//   });
// }


abrirCrearUsuario() {
    Swal.fire({
      title: '<strong>Nuevo Estudiante</strong>',
      html: `
        <p style="font-size:0.9rem; color:#555;">DNI (Requerido)</p>
        <div style="display:flex; align-items:center; gap:8px; margin-bottom:10px;">
          <i class="bi bi-card-text" style="color:#ff4500; font-size:1.5rem;"></i>
          <input id="swal-input-id" class="swal2-input" placeholder="DNI">
        </div>
        <div style="display:flex; align-items:center; gap:8px;">
          <i class="bi bi-person-fill" style="color:#1e90ff; font-size:1.5rem;"></i>
          <input id="swal-input-nombre" class="swal2-input" placeholder="Nombre" disabled>
        </div>
      `,
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Sí, Crear',
      cancelButtonText: 'No, Cancelar',
      confirmButtonColor: '#ff0000',
      cancelButtonColor: '#006bc9',
      reverseButtons: true,
      didOpen: () => {
        const idInput = document.getElementById('swal-input-id') as HTMLInputElement;
        const nombreInput = document.getElementById('swal-input-nombre') as HTMLInputElement;

        // Activar/desactivar input de nombre según ID y permitir solo números
        idInput.addEventListener('input', () => {
          idInput.value = idInput.value.replace(/\D/g, ''); // solo números
          nombreInput.disabled = !idInput.value.trim();
        });
      },
      preConfirm: () => {
        const id = (document.getElementById('swal-input-id') as HTMLInputElement).value;
        const nombre = (document.getElementById('swal-input-nombre') as HTMLInputElement).value;

        if (!id || !nombre) {
          Swal.showValidationMessage('¡Completa todos los campos!');
        } else if (!/^\d+$/.test(id)) {
          Swal.showValidationMessage('El DNI solo puede contener números');
        }

        return { id, nombre };
      }
    }).then(result => {
      if (result.isConfirmed && result.value) {
        console.log('Crear usuario:', result.value);
        const { id, nombre } = result.value; 
        this.registrarEstudiante(+id, nombre);
        Swal.fire('¡Creado!', `Usuario "${result.value.nombre}" creado correctamente.`, 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelado', 'No se creó el usuario.', 'info');
      }
    });
  }

registrarEstudiante(id: number, nombre: string) {
  this.estudianteService.registrarEstudiante({ id, nombre }).subscribe({
    next: (nuevoEst) => {
      console.log('Estudiante registrado:', nuevoEst);
      this.cargarEstudiantes(); // refresca la tabla
      this.cargarEstudiantesSinNotas(); // actualiza ArrayIdsEstudiantesSinNotas
    },
    error: (err) => {
      console.error('Error registrando estudiante:', err);
    }
  });
}







}


