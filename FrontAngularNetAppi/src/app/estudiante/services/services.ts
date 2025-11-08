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
  private baseUrl = 'http://localhost:5261/api/estudiante';

  constructor(private http: HttpClient) {}

  getEstudiantes(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(this.baseUrl);
  }

  getEstudiantePorId(id: number): Observable<Estudiante> {
    return this.http.get<Estudiante>(`${this.baseUrl}/${id}`);
  }

  eliminarEstudiante(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  EstudiantesConNotas(): Observable<number[]>{
    return this.http.get<number[]>(`${this.baseUrl}/EstudiantesConNotas`);
  }

  EstudiantesSinNotas(): Observable<number[]>{
    return this.http.get<number[]>(`${this.baseUrl}/EstudiantesSinNotas`);
  }


  // Otros métodos que ya tengas: crearEstudiante, actualizarEstudiante...
}
