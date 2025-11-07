// src/app/estudiante/estudiante.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
//import { EstudianteService, Estudiante } from '../servicios/estudiante.service';
import { EstudianteService, Estudiante } from '../estudiante/service';
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

  ngOnInit(): void {
    this.cargarEstudiantes();
  }

  cargarEstudiantes(): void {
    this.estudianteService.getEstudiantes()
      .subscribe((data: Estudiante[]) => {
        this.estudiantes = data;
      });
  }

  guardarEstudiante(): void {
    if (this.estudiante.id === 0) {
      this.estudianteService.crearEstudiante(this.estudiante)
        .subscribe(() => {
          this.cargarEstudiantes();
          this.limpiarFormulario();
        });
    } else {
      this.estudianteService.actualizarEstudiante(this.estudiante)
        .subscribe(() => {
          this.cargarEstudiantes();
          this.limpiarFormulario();
        });
    }
  }

  editarEstudiante(est: Estudiante): void {
    this.estudiante = { ...est };
  }

  eliminarEstudiante(id: number): void {
    this.estudianteService.eliminarEstudiante(id)
      .subscribe(() => this.cargarEstudiantes());
  }

  limpiarFormulario(): void {
    this.estudiante = { id: 0, nombre: '' };
  }
}
