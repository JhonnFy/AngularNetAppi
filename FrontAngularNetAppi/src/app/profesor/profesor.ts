import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ProfesorService, Profesor } from '../profesor/services/services';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-Profesor',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './Profesor.html',
  styleUrls: ['./profesor.scss']
})
export class ProfesorComponent implements OnInit {
  profesores: Profesor[] = [];
    paginaActual = 1;
    registrosPorPagina = 7;
    filaEditandoId: number | null = null;
    nombreEditado: string = ''; 

  constructor(
    private ProfesorService: ProfesorService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit() {
    this.cargarprofesores();
    this.cargarprofesoresSinNotas();
  }

  cargarprofesores() {
    this.ProfesorService.getProfesores().subscribe((data: Profesor[]) => {
      this.profesores = data;
    }, (err) => console.error('Error cargando profesores', err));
  }

  irAlDashboard() {
    this.router.navigate(['/dashboard']);
  }

getprofesoresSinNotas(){
  this.ProfesorService.ProfesoresSinNotas().subscribe((id:number[]) =>{
    console.log(id);
  })
}

getprofesoresConNotas(){
  this.ProfesorService.ProfesoresConNotas().subscribe((id:number[])=>{
    console.log(id);
  })
}

ArrayIdsprofesoresSinNotas: number [] = [];
cargarprofesoresSinNotas() {
  this.ProfesorService.ProfesoresSinNotas().subscribe((ids: number[]) => {
    this.ArrayIdsprofesoresSinNotas = ids;
    console.log(ids); 
  });
}

eliminarProfesor(id: number) {
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
      this.ProfesorService.eliminarProfesor(id).subscribe({
        next: () => {
          this.cargarprofesores();
          Swal.fire('¡Eliminado!', 'El Profesor fue eliminado correctamente.', 'success');
        },
        error: (err) => {
          const mensaje = err.error?.mensaje || 'No se puede eliminar este Profesor porque tiene registros asociados.';
          Swal.fire('Error', mensaje, 'error');
          console.error(err);
        }
      });
    } else if (result.dismiss === Swal.DismissReason.cancel) {
      Swal.fire('Cancelado', 'No se eliminó el Profesor.', 'info');
    }
  });
}


  // Getter que devuelve solo los profesores de la página actual
  get profesoresPaginados(): Profesor[] {
    const inicio = (this.paginaActual - 1) * this.registrosPorPagina;
    return this.profesores.slice(inicio, inicio + this.registrosPorPagina);
  }

  totalPaginas(): number {
    return Math.ceil(this.profesores.length / this.registrosPorPagina);
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
    this.cargarprofesores();
    return;
  }

  const id = +this.filtro;
  this.ProfesorService.getProfesorPorId(+this.filtro).subscribe({
  next: (Profesor: Profesor) => {
    this.profesores = Profesor ? [Profesor] : [];
    this.paginaActual = 1;
  },
  error: (err) => {
    console.error('Error filtrando Profesor', err);
    this.profesores = [];
  }
});


}

limpiarFiltro() {
  this.filtro = '';
  this.paginaActual = 1;
  this.cargarprofesores();
}


// Activar modo edición en una fila
activarEdicion(est: Profesor) {
  this.filaEditandoId = est.id;
  this.nombreEditado = est.nombre; // copia el valor actual
}

// Cancelar edición
cancelarEdicion() {
  this.filaEditandoId = null;
  this.nombreEditado = '';
}

// Guardar cambios con confirmación
guardarEdicion(est: Profesor) {
  Swal.fire({
    title: '¿Deseas guardar los cambios?',
    icon: 'question',
    showCancelButton: true,
    confirmButtonText: 'Sí, actualizar',
    cancelButtonText: 'No, cancelar'
  }).then(result => {
    if (result.isConfirmed) {
      // Llamas al servicio para actualizar
      const ProfesorActualizado: Profesor = {
        id: est.id,
        nombre: this.nombreEditado
      };

      this.ProfesorService.actualizarProfesor(ProfesorActualizado).subscribe({
        next: () => {
          Swal.fire('Actualizado', 'El Profesor fue actualizado correctamente.', 'success');
          this.cargarprofesores(); // recarga tabla
          this.cancelarEdicion();
        },
        error: (err) => {
          Swal.fire('Error', 'No se pudo actualizar el Profesor.', 'error');
          console.error(err);
        }
      });
    }
  });
}



// abrirCrearUsuario() {
//   Swal.fire({
//     title: '<strong>Nuevo Profesor</strong>',
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
      title: '<strong>Nuevo Profesor</strong>',
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
        this.registrarProfesor(+id, nombre);
        Swal.fire('¡Creado!', `Usuario "${result.value.nombre}" creado correctamente.`, 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelado', 'No se creó el usuario.', 'info');
      }
    });
  }

registrarProfesor(id: number, nombre: string) {
  this.ProfesorService.registrarProfesor({ id, nombre }).subscribe({
    next: (nuevoEst) => {
      console.log('Profesor registrado:', nuevoEst);
      this.cargarprofesores(); // refresca la tabla
      this.cargarprofesoresSinNotas(); // actualiza ArrayIdsprofesoresSinNotas
    },
    error: (err) => {
      console.error('Error registrando Profesor:', err);
    }
  });
}







}


