// src/app/servicios/estudiante.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Estudiante {
  id: number;
  nombre: string;
}

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {
  private apiUrl = 'https://localhost:5261/api/estudiantes'; // Cambia por tu URL real

  constructor(private http: HttpClient) {}

  getEstudiantes(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(this.apiUrl);
  }

  crearEstudiante(est: Estudiante): Observable<Estudiante> {
    return this.http.post<Estudiante>(this.apiUrl, est);
  }

  actualizarEstudiante(est: Estudiante): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${est.id}`, est);
  }

  eliminarEstudiante(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
