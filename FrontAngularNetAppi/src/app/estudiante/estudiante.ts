// src/app/estudiante/estudiante.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { EstudianteService, Estudiante } from '../services/service';

@Component({
  selector: 'app-estudiante',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './estudiante.html',
  styleUrls: ['./estudiante.scss']
})
export class EstudianteComponent implements OnInit {
  estudiantes: Estudiante[] = [];
  estudiante: Estudiante = { id: 0, nombre: '' };

  constructor(private estudianteService: EstudianteService, private router: Router) {}

  ngOnInit() {
    this.cargarEstudiantes();
  }

  // Cargar todos los estudiantes
  cargarEstudiantes() {
    this.estudianteService.getEstudiantes().subscribe(data => {
      this.estudiantes = data;
    });
  }

  // Guardar o actualizar estudiante
  guardarEstudiante() {
    if (!this.estudiante.nombre) return; // validar que nombre no esté vacío

    if (this.estudiante.id === 0) {
      // Crear
      this.estudianteService.crearEstudiante(this.estudiante).subscribe(() => {
        this.cargarEstudiantes();
        this.limpiarFormulario();
      });
    } else {
      // Actualizar
      this.estudianteService.actualizarEstudiante(this.estudiante).subscribe(() => {
        this.cargarEstudiantes();
        this.limpiarFormulario();
      });
    }
  }

  // Editar estudiante
  editarEstudiante(est: Estudiante) {
    this.estudiante = { ...est };
  }

  // Eliminar estudiante
  eliminarEstudiante(id: number) {
    if (!confirm('¿Deseas eliminar este estudiante?')) return;
    this.estudianteService.eliminarEstudiante(id).subscribe(() => {
      this.cargarEstudiantes();
    });
  }

  // Limpiar formulario
  limpiarFormulario() {
    this.estudiante = { id: 0, nombre: '' };
  }

  // Regresar al dashboard
  regresarDashboard() {
    this.router.navigate(['/dashboard']);
  }
}
