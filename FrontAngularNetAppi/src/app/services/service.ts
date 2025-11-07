// src/app/servicios/estudiante.service.ts
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface Estudiante {
  id: number;
  nombre: string;
}

@Injectable({
  providedIn: 'root'  // esto permite inyectarlo directamente en el componente
})
export class EstudianteService {
  private estudiantes: Estudiante[] = [
    { id: 1, nombre: 'Juan Pérez' },
    { id: 2, nombre: 'María Gómez' }
  ];

  getEstudiantes(): Observable<Estudiante[]> {
    return of(this.estudiantes);
  }

  crearEstudiante(est: Estudiante): Observable<Estudiante> {
    est.id = this.estudiantes.length + 1;
    this.estudiantes.push(est);
    return of(est);
  }

  actualizarEstudiante(est: Estudiante): Observable<Estudiante> {
    const index = this.estudiantes.findIndex(e => e.id === est.id);
    if (index !== -1) this.estudiantes[index] = est;
    return of(est);
  }

  eliminarEstudiante(id: number): Observable<void> {
    this.estudiantes = this.estudiantes.filter(e => e.id !== id);
    return of();
  }
}
