import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Estudiante, EstudianteService } from '../estudiante/services/services';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './estudiante.html',
  styleUrls: ['./estudiante.scss']
})
export class EstudianteComponent implements OnInit {
  estudiantes: Estudiante[] = [];
  estudiante: Estudiante = { id: 0, nombre: '' };

  constructor(private estudianteService: EstudianteService) {}

  ngOnInit() {
    this.cargarEstudiantes();
  }

  cargarEstudiantes() {
    this.estudianteService.getEstudiantes().subscribe({
      next: data => this.estudiantes = data,
      error: err => console.error('Error cargando estudiantes:', err)
    });
  }

  guardarEstudiante() {
    if (this.estudiante.id === 0) {
      // Crear
      this.estudianteService.crearEstudiante(this.estudiante).subscribe({
        next: () => { this.cargarEstudiantes(); this.limpiarFormulario(); },
        error: err => console.error('Error creando estudiante:', err)
      });
    } else {
      // Actualizar
      this.estudianteService.actualizarEstudiante(this.estudiante).subscribe({
        next: () => { this.cargarEstudiantes(); this.limpiarFormulario(); },
        error: err => console.error('Error actualizando estudiante:', err)
      });
    }
  }

  editarEstudiante(est: Estudiante) {
    this.estudiante = { ...est };
  }

  eliminarEstudiante(id: number) {
    this.estudianteService.eliminarEstudiante(id).subscribe({
      next: () => this.cargarEstudiantes(),
      error: err => console.error('Error eliminando estudiante:', err)
    });
  }

  limpiarFormulario() {
    this.estudiante = { id: 0, nombre: '' };
  }
}
